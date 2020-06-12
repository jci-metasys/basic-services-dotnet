using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Net;
using System.Collections;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using JohnsonControls.Metasys.BasicServices.Utils;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// An HTTP client for consuming the most commonly used endpoints of the Metasys API.
    /// </summary>
    public class MetasysClient : BasicServiceProvider, IMetasysClient
    {
        /// <summary>The current session token.</summary>
        protected AccessToken AccessToken;

        /// <summary>The flag used to control automatic session refreshing.</summary>
        protected bool RefreshToken;

        /// <summary>Resource Manager to provide localized translations.</summary>
        protected static System.Resources.ResourceManager Resource = new System.Resources.ResourceManager("JohnsonControls.Metasys.BasicServices.Resources.MetasysResources", typeof(MetasysClient).Assembly);

        /// <summary>Dictionary to provide keys from the commandIdEnumSet.</summary>
        /// <value>Keys as en-US translations, values as the commandIdEnumSet Enumerations.</value>
        protected static Dictionary<string, string> CommandEnumerations;

        /// <summary>Dictionaries to provide keys from the objectTypeEnumSet since there are duplicate keys.</summary>
        /// <value>Keys as en-US translations, values as the objectTypeEnumSet Enumerations.</value>
        protected static List<Dictionary<string, string>> ObjectTypeEnumerations;

        /// <inheritdoc />
        public CultureInfo Culture { get; set; }

        /// <summary>
        /// The hostname of Metasys API server.
        /// </summary>
        protected string Hostname { get; private set; }

        /// <summary>
        /// An optional boolean flag for ignoring certificate errors by bypassing certificate verification steps.
        /// </summary>
        protected bool IgnoreCertificateErrors { get; private set; }
           

        private static CultureInfo CultureEnUS = new CultureInfo(1033);

        /// <summary>
        /// Stores retrieved Ids and serves as an in-memory caching layer.
        /// </summary>
        protected Dictionary<string, Guid> IdentifiersDictionary = new Dictionary<string, Guid>();

        /// <inheritdoc />
        public ITrendService Trends { get; set; }

        /// <inheritdoc />
		public IAlarmsService Alarms { get; set; }

        /// <inheritdoc />
        public IAuditService Audits { get; set; }

        /// <summary>
        /// Creates a new MetasysClient.
        /// </summary>
        /// <remarks>
        /// Takes an optional boolean flag for ignoring certificate errors by bypassing certificate verification steps.
        /// Verification bypass is not recommended due to security concerns. If your Metasys server is missing a valid certificate it is
        /// recommended to add one to protect your private data from attacks over external networks.
        /// Takes an optional flag for the api version of your Metasys server.
        /// Takes an optional CultureInfo which is useful for formatting numbers and localization of strings. If not specified,
        /// the machine's current culture is used.
        /// Takes an optional flag for logging client errors. If not specified, it is enabled by default according to log4Net.config file.
        /// </remarks>
        /// <param name="hostname">The hostname of the Metasys server.</param>
        /// <param name="ignoreCertificateErrors">Use to bypass server certificate verification.</param>
        /// <param name="version">The server's Api version.</param>
        /// <param name="cultureInfo">Localization culture for Metasys enumeration translations.</param>
        /// <param name="logClientErrors">Set this flag to false to disable logging of client errors.</param>
        public MetasysClient(string hostname, bool ignoreCertificateErrors = false, ApiVersion version = ApiVersion.v2, CultureInfo cultureInfo = null, bool logClientErrors = true)
        {
            Hostname = hostname;
            // Set Metasys culture if specified, otherwise use current machine Culture.
            Culture = cultureInfo ?? CultureInfo.CurrentCulture;
            Version = version;
            IgnoreCertificateErrors = ignoreCertificateErrors;
            // Initialize the HTTP client with a base URL    
            if (IgnoreCertificateErrors)
            {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                HttpClient httpClient = new HttpClient(httpClientHandler);
                httpClient.BaseAddress = new Uri($"https://{hostname}"
                    .AppendPathSegments("api", Version));
                Client = new FlurlClient(httpClient);
            }
            else
            {
                Client = new FlurlClient($"https://{hostname}"
                    .AppendPathSegments("api", Version));
            }
            // Set preferences about logging
            LogClientErrors = logClientErrors;
            // Init related services
            Trends = new TrendServiceProvider(Client, Version,logClientErrors);
            Alarms = new AlarmServiceProvider(Client, Version, logClientErrors);
            Audits = new AuditServiceProvider(Client, Version, logClientErrors);
        }
        /// <inheritdoc />
        public string Localize(string resource, CultureInfo cultureInfo = null)
        {
            // Priority is the cultureInfo parameter if available, otherwise MetasysClient culture.
            return Utils.ResourceManager.Localize(resource, cultureInfo ?? Culture);
        }
        /// <inheritdoc />
        public string GetCommandEnumeration(string resource)
        {
            // Priority is the cultureInfo parameter if available, otherwise MetasysClient culture.
            return Utils.ResourceManager.GetCommandEnumeration(resource);
        }

        /// <inheritdoc />
        public string GetObjectTypeEnumeration(string resource)
        {
            // Priority is the cultureInfo parameter if available, otherwise MetasysClient culture.
            return Utils.ResourceManager.GetObjectTypeEnumeration(resource);
        }

        /// <summary>Use to log an error message from an asynchronous context.</summary>
        private async Task LogErrorAsync(String message)
        {
            await Console.Error.WriteLineAsync(message).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public AccessToken TryLogin(string username, string password, bool refresh = true)
        {
            return TryLoginAsync(username, password, refresh).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<AccessToken> TryLoginAsync(string username, string password, bool refresh = true)
        {
            this.RefreshToken = refresh;

            try
            {
                var response = await Client.Request("login")
                    .PostJsonAsync(new { username, password })
                    .ReceiveJson<JToken>()
                    .ConfigureAwait(false);

                CreateAccessToken(Hostname, username, response);
            }
            catch (FlurlHttpException e)
            {
                ThrowHttpException(e);
            }
            return this.AccessToken;
        }

        /// <inheritdoc />
        public AccessToken Refresh()
        {
            return RefreshAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<AccessToken> RefreshAsync()
        {
            try
            {
                var response = await Client.Request("refreshToken")
                    .GetJsonAsync<JToken>()
                    .ConfigureAwait(false);
                // Since it's a refresh, get issue info from the current token
                CreateAccessToken(AccessToken.Issuer, AccessToken.IssuedTo, response);
            }
            catch (FlurlHttpException e)
            {
                ThrowHttpException(e);
            }
            return this.AccessToken;
        }

        /// <summary>
        /// Creates a new AccessToken from a JToken and sets the client's authorization header if successful.
        /// On failure leaves the AccessToken and authorization header in previous state.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="issuer"></param>
        /// <param name="issuedTo"></param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysTokenException"></exception>
        private void CreateAccessToken(string issuer, string issuedTo, JToken token)
        {
            try
            {
                var accessTokenValue = token["accessToken"];
                var expires = token["expires"];
                var accessToken = $"Bearer {accessTokenValue.Value<string>()}";
                var date = expires.Value<DateTime>();
                this.AccessToken = new AccessToken(issuer, issuedTo, accessToken, date);
                Client.Headers.Remove("Authorization");
                Client.Headers.Add("Authorization", this.AccessToken.Token);
                if (RefreshToken)
                {
                    ScheduleRefresh();
                }
            }
            catch (Exception e) when (e is System.ArgumentNullException
                || e is System.NullReferenceException || e is System.FormatException)
            {
                throw new MetasysTokenException(token.ToString(), e);
            }
        }

        /// <summary>
        /// Will call Refresh() a minute before the token expires.
        /// </summary>
        private void ScheduleRefresh()
        {
            DateTime now = DateTime.UtcNow;
            TimeSpan delay = AccessToken.Expires - now.AddSeconds(-1); // minimum renew gap of 1 sec in advance
            // Renew one minute before expiration if there is more than one minute time 
            if (delay > new TimeSpan(0, 1, 0))
            {
                delay.Subtract(new TimeSpan(0, 1, 0));
            }
            if (delay <= TimeSpan.Zero)
            {
                // Token already expired
                return;
            }
            int delayms;
            if (delay.TotalMilliseconds > int.MaxValue)
            {
                // Delay is set to int MaxValue to do not go negative with double to int conversion.
                delayms = int.MaxValue;
            }
            else
            {
                delayms = (int)delay.TotalMilliseconds;
            }
            System.Threading.Tasks.Task.Delay(delayms).ContinueWith(_ => Refresh());
        }

        /// <inheritdoc />
        public AccessToken GetAccessToken()
        {
            return this.AccessToken;
        }

        /// <inheritdoc />
        public void SetAccessToken(AccessToken accessToken)
        {
            this.AccessToken = accessToken;
        }

        /// <inheritdoc />
        public Guid GetObjectIdentifier(string itemReference)
        {
            return GetObjectIdentifierAsync(itemReference).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<Guid> GetObjectIdentifierAsync(string itemReference)
        {
            // Sanitize given itemReference
            var normalizedItemReference = itemReference.Trim().ToUpper();
            // Returns cached value when available, otherwise perform request
            if (!IdentifiersDictionary.ContainsKey(normalizedItemReference))
            {
                JToken response = null;
                try
                {
                    response = await Client.Request("objectIdentifiers")
                        .SetQueryParam("fqr", itemReference)
                        .GetJsonAsync<JToken>()
                        .ConfigureAwait(false);
                    // Stores value for caching and return
                    IdentifiersDictionary[normalizedItemReference] = ParseObjectIdentifier(response);
                }
                catch (FlurlHttpException e)
                {
                    if (e.Call.HttpStatus == HttpStatusCode.BadRequest && response != null && response["message"] != null
                        && response["message"].Value<string>().Contains("not found"))
                    {
                        // Metasys respond with "Identifier is not found." message, so make exception explicit
                        throw new MetasysHttpNotFoundException(e);
                    }
                    ThrowHttpException(e);
                }
            }
            return IdentifiersDictionary[normalizedItemReference];
        }

        /// <inheritdoc />
        public Variant ReadProperty(Guid id, string attributeName)
        {
            return ReadPropertyAsync(id, attributeName).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<Variant> ReadPropertyAsync(Guid id, string attributeName)
        {
            JToken response = null; Variant result = new Variant();
            try
            {
                response = await Client.Request(new Url("objects")
                    .AppendPathSegments(id, "attributes", attributeName))
                    .GetJsonAsync<JToken>()
                    .ConfigureAwait(false);
                result = new Variant(id, response, attributeName, Culture, Version);
            }
            catch (FlurlHttpException e)
            {
                ThrowHttpException(e);
            }
            catch (System.NullReferenceException e)
            {
                throw new MetasysPropertyException(response.ToString(), e);
            }
            return result;
        }

        /// <summary>
        /// Overload of ReadPropertyAsync for internal use where Exception suppress is needed, e.g. ReadPropertyMultiple 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <param name="suppressNotFoundException"></param>
        /// <returns></returns>
        protected async Task<Variant> ReadPropertyAsync(Guid id, string attributeName, bool suppressNotFoundException = true)
        {
            try
            {
                return await ReadPropertyAsync(id, attributeName).ConfigureAwait(false);
            }
            catch (MetasysHttpNotFoundException) when (suppressNotFoundException)
            {
                return null;
            }
        }

        /// <inheritdoc />
        public IEnumerable<VariantMultiple> ReadPropertyMultiple(IEnumerable<Guid> ids,
        IEnumerable<string> attributeNames)
        {
            return ReadPropertyMultipleAsync(ids, attributeNames).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<VariantMultiple>> ReadPropertyMultipleAsync(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames)
        {
            if (ids == null || attributeNames == null)
            {
                return null;
            }
            List<VariantMultiple> results = new List<VariantMultiple>();
            if (Version > ApiVersion.v2) {
                var response=await PostBatchRequestAsync("objects", ids, attributeNames, "attributes").ConfigureAwait(false);
                return ToVariantMultiples(response);
            }
            var taskList = new List<Task<Variant>>();
            // Prepare Tasks to Read attributes list. In Metasys 11 this will be implemented server side
            foreach (var id in ids)
            {
                foreach (string attributeName in attributeNames)
                {
                    // Much faster reading single property than the entire object, even though we have more server calls
                    taskList.Add(ReadPropertyAsync(id, attributeName, true)); // Using internal signature with exception suppress
                }
            }
            await Task.WhenAll(taskList).ConfigureAwait(false);
            foreach (var id in ids)
            {
                // Get attributes of the specific Id
                List<Task<Variant>> attributeList = taskList.Where(w =>
                    (w.Result != null && w.Result.Id == id)).ToList();
                List<Variant> variants = new List<Variant>();
                foreach (var t in attributeList)
                {
                    if (t.Result != null) // Something went wrong if the result is unknown
                    {
                        variants.Add(t.Result); // Prepare variants list
                    }
                }
                if (variants.Count > 0 || attributeNames.Count() == 0)
                {
                    // Aggregate results only when objects was found or no attributes specified
                    results.Add(new VariantMultiple(id, variants));
                }
            }
            return results.AsEnumerable();
        }

        /// <inheritdoc />
        public void WriteProperty(Guid id, string attributeName, object newValue, string priority = null)
        {
            WritePropertyAsync(id, attributeName, newValue, priority).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task WritePropertyAsync(Guid id, string attributeName, object newValue, string priority = null)
        {
            List<(string Attribute, object Value)> list = new List<(string Attribute, object Value)>();
            list.Add((Attribute: attributeName, Value: newValue));
            var item = GetWritePropertyBody(list, priority);
            await WritePropertyRequestAsync(id, item).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public void WritePropertyMultiple(IEnumerable<Guid> ids,
            IEnumerable<(string Attribute, object Value)> attributeValues, string priority = null)
        {
            WritePropertyMultipleAsync(ids, attributeValues, priority).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task WritePropertyMultipleAsync(IEnumerable<Guid> ids,
            IEnumerable<(string Attribute, object Value)> attributeValues, string priority = null)
        {
            if (ids == null || attributeValues == null)
            {
                return;
            }

            var item = GetWritePropertyBody(attributeValues, priority);
            var taskList = new List<Task>();

            foreach (var id in ids)
            {
                taskList.Add(WritePropertyRequestAsync(id, item));
            }
            await Task.WhenAll(taskList).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates the body for the WriteProperty and WritePropertyMultiple requests as a dictionary.
        /// </summary>
        /// <param name="attributeValues">The (attribute, value) pairs.</param>
        /// <param name="priority">Write priority as an enumeration from the writePriorityEnumSet.</param>
        /// <returns>Dictionary of the attribute, value pairs.</returns>
        private Dictionary<string, object> GetWritePropertyBody(
            IEnumerable<(string Attribute, object Value)> attributeValues, string priority)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            foreach (var attribute in attributeValues)
            {
                pairs.Add(attribute.Attribute, attribute.Value);
            }

            if (priority != null)
            {
                pairs.Add("priority", priority);
            }

            return pairs;
        }

        /// <summary>
        /// Write one or many attribute values in the provided json given the Guid of the object asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <returns>Asynchronous Task Result.</returns>
        private async Task WritePropertyRequestAsync(Guid id, Dictionary<string, object> body)
        {
            var json = new { item = body };

            try
            {
                var response = await Client.Request(new Url("objects")
                    .AppendPathSegment(id))
                    .PatchJsonAsync(json)
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException e)
            {
                ThrowHttpException(e);
            }
        }

        /// <inheritdoc />
        public IEnumerable<Command> GetCommands(Guid id)
        {
            return GetCommandsAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Command>> GetCommandsAsync(Guid id)
        {
            try
            {
                var token = await Client.Request(new Url("objects")
                    .AppendPathSegments(id, "commands"))
                    .GetJsonAsync<JToken>()
                    .ConfigureAwait(false);

                List<Command> commands = new List<Command>();
                var array = token as JArray;

                if (array != null)
                {
                    foreach (JObject command in array)
                    {
                        try
                        {
                            Command c = new Command(command, Culture);
                            commands.Add(c);
                        }
                        catch (Exception e)
                        {
                            throw new MetasysCommandException(command.ToString(), e);
                        }
                    }
                }

                return commands;
            }
            catch (FlurlHttpException e)
            {
                ThrowHttpException(e);
            }
            return null;
        }

        /// <inheritdoc />
        public void SendCommand(Guid id, string command, IEnumerable<object> values = null)
        {
            SendCommandAsync(id, command, values).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task SendCommandAsync(Guid id, string command, IEnumerable<object> values = null)
        {
            if (values == null)
            {
                await SendCommandRequestAsync(id, command, new string[0]).ConfigureAwait(false);
            }
            else
            {
                await SendCommandRequestAsync(id, command, values).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Send a command to an object asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <param name="values"></param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <returns>Asynchronous Task Result.</returns>
        private async Task SendCommandRequestAsync(Guid id, string command, IEnumerable<object> values)
        {
            try
            {
                var response = await Client.Request(new Url("objects")
                    .AppendPathSegments(id, "commands", command))
                    .PutJsonAsync(values)
                    .ConfigureAwait(false);
            }
            catch (FlurlHttpException e)
            {
                ThrowHttpException(e);
            }
        }

        /// <inheritdoc />
        public IEnumerable<MetasysObject> GetNetworkDevices(string type = null)
        {
            return GetNetworkDevicesAsync(type).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<MetasysObject>> GetNetworkDevicesAsync(string type = null)
        {
            var response = await this.GetAllAvailablePagesAsync("networkDevices", new Dictionary<string, string> { { "type", type } }).ConfigureAwait(false);
            return toMetasysObject(response);
        }


        /// <inheritdoc />
        public IEnumerable<MetasysObjectType> GetNetworkDeviceTypes()
        {
            return GetNetworkDeviceTypesAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<MetasysObjectType>> GetNetworkDeviceTypesAsync()
        {
            return await GetResourceTypesAsync("networkDevices", "availableTypes").ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all resource types asynchronously.
        /// </summary>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        public async Task<IEnumerable<MetasysObjectType>> GetResourceTypesAsync(string resource, string pathSegment)
        {
            List<MetasysObjectType> types = new List<MetasysObjectType>() { };

            try
            {
                var response = await Client.Request(new Url(resource)
                    .AppendPathSegment(pathSegment))
                    .GetJsonAsync<JToken>()
                    .ConfigureAwait(false);
                try
                {
                    // The response is a list of typeUrls, not the type data
                    var list = response["items"] as JArray;
                    foreach (var item in list)
                    {
                        try
                        {
                            JToken typeToken = item;
                            // Retrieve type token from url (when available) and construct Metasys Object Type
                            if (item["typeUrl"] != null)
                            {
                                var url = item["typeUrl"].Value<string>();
                                typeToken = await GetWithFullUrl(url).ConfigureAwait(false);
                            }
                            var type = GetType(typeToken);
                            types.Add(type);
                        }
                        catch (System.ArgumentNullException e)
                        {
                            throw new MetasysHttpParsingException(response.ToString(), e);
                        }
                    }
                }
                catch (System.NullReferenceException e)
                {
                    throw new MetasysHttpParsingException(response.ToString(), e);
                }
            }
            catch (FlurlHttpException e)
            {
                ThrowHttpException(e);
            }
            return types;
        }

        /// <summary>
        /// Gets the type from a token retrieved from a typeUrl 
        /// </summary>
        /// <param name="typeToken"></param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysObjectTypeException"></exception>
        protected MetasysObjectType GetType(JToken typeToken)
        {
            try
            {
                string description = typeToken["description"].Value<string>();
                int id = typeToken["id"].Value<int>();
                string key = GetObjectTypeEnumeration(description);
                string translation = Localize(key);
                if (translation != key)
                {
                    // A translation was found
                    description = translation;
                }
                return new MetasysObjectType(id, key, description);
            }
            catch (Exception e) when (e is System.ArgumentNullException
                || e is System.NullReferenceException || e is System.FormatException)
            {
                throw new MetasysObjectTypeException(typeToken.ToString(), e);
            }
        }

        /// <inheritdoc />
        public IEnumerable<MetasysObject> GetObjects(Guid id, int levels = 1, bool includeInternalObjects = false)
        {
            return GetObjectsAsync(id, levels, includeInternalObjects).GetAwaiter().GetResult();
        }


        /// <inheritdoc />
        public IEnumerable<MetasysObject> GetSpaces(SpaceTypeEnum? type = null)
        {
            return GetSpacesAsync(type).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<MetasysObject>> GetSpacesAsync(SpaceTypeEnum? type = null)
        {
            Dictionary<string, string> parameters = null;
            if (type != null)
            {
                // Init Dictionary with Space Type parameter
                parameters = new Dictionary<string, string>() { { "type", ((int)type).ToString() } };
            }
            var spaces = await GetAllAvailablePagesAsync("spaces", parameters).ConfigureAwait(false);
            return toMetasysObject(spaces, type: MetasysObjectTypeEnum.Space);
        }

        /// <inheritdoc />
        public IEnumerable<MetasysObject> GetSpaceChildren(Guid id)
        {
            return GetSpaceChildrenAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<MetasysObject>> GetSpaceChildrenAsync(Guid id)
        {
            var spaceChildren = await GetAllAvailablePagesAsync("spaces", null, id.ToString(), "spaces").ConfigureAwait(false);
            return toMetasysObject(spaceChildren, MetasysObjectTypeEnum.Space);
        }


        /// <inheritdoc />
        public IEnumerable<MetasysObject> GetEquipment()
        {
            return GetEquipmentAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<MetasysObject>> GetEquipmentAsync()
        {
            var equipment = await GetAllAvailablePagesAsync("equipment").ConfigureAwait(false);
            return toMetasysObject(equipment, MetasysObjectTypeEnum.Equipment);
        }

        /// <inheritdoc />
        public IEnumerable<MetasysObjectType> GetSpaceTypes()
        {
            return GetSpaceTypesAsync().GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<MetasysObjectType>> GetSpaceTypesAsync()
        {
            return await GetResourceTypesAsync("enumSets", "1766/members").ConfigureAwait(false);
        }

        /// <inheritdoc />
        public IEnumerable<MetasysObject> GetSpaceEquipment(Guid spaceId)
        {
            return GetSpaceEquipmentAsync(spaceId).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<MetasysObject>> GetSpaceEquipmentAsync(Guid spaceId)
        {
            var spaceEquipment = await GetAllAvailablePagesAsync("spaces", null, spaceId.ToString(), "equipment").ConfigureAwait(false);
            return toMetasysObject(spaceEquipment, MetasysObjectTypeEnum.Equipment);
        }

        /// <inheritdoc />
        public IEnumerable<MetasysPoint> GetEquipmentPoints(Guid equipmentId, bool readAttributeValue = true)
        {
            return GetEquipmentPointsAsync(equipmentId, readAttributeValue).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<MetasysPoint>> GetEquipmentPointsAsync(Guid equipmentId, bool readAttributeValue = true)
        {
            List<MetasysPoint> points = new List<MetasysPoint>() { }; List<Guid> guids = new List<Guid>();
            List<MetasysPoint> pointsWithAttribute = new List<MetasysPoint>() { };
            var response = await GetAllAvailablePagesAsync("equipment", null, equipmentId.ToString(), "points").ConfigureAwait(false);
            try
            {
                foreach (var item in response)
                {
                    MetasysPoint point = new MetasysPoint(item);
                    // Retrieve object Id from full URL 
                    string objectId = point.ObjectUrl.Split('/').Last();
                    point.ObjectId = ParseObjectIdentifier(objectId);
                    // Retrieve attribute Id from full URL 
                    string attributeId = point.AttributeUrl.Split('/').Last();
                    if (point.ObjectId != Guid.Empty) // Sometime can happen that there are empty Guids.
                    {
                        // Collect Guids to perform read property multiple in "one call" (supporting only presentValue so far)
                        if (attributeId == "85" && readAttributeValue)
                        {
                            guids.Add(point.ObjectId);
                            pointsWithAttribute.Add(point);
                        }
                        else
                        {
                            points.Add(point);
                        }
                    }
                }
            }
            catch (System.NullReferenceException e)
            {
                throw new MetasysHttpParsingException(response.ToString(), e);
            }
            if (readAttributeValue)
            {
                // Try to Read Present Value when available. Note: can't read attribute ID from attribute full URL of point since we got only the description.
                var results = await ReadPropertyMultipleAsync(guids, new List<string> { "presentValue" }).ConfigureAwait(false);
                foreach (var r in results)
                {
                    var point = pointsWithAttribute.SingleOrDefault(s => s.ObjectId == r.Id);
                    // Assign present values back from the attribute collection
                    point.PresentValue = r.Values?.SingleOrDefault(s => s.Attribute == "presentValue");
                    // Finally add the point back to the original list
                    points.Add(point);
                }
            }
            return points;
        }

        /// <inheritdoc cref="GetObjects(Guid, int)"/>
        public async Task<IEnumerable<MetasysObject>> GetObjectsAsync(Guid id, int levels, bool includeInternalObjects = false)
        {
            Dictionary<string, string> parameters = null;
            if (Version > ApiVersion.v2)
            {
                // Since API v3 we could use the includeInternalObjects parameter
                parameters = new Dictionary<string, string>();
                parameters.Add("includeInternalObjects", includeInternalObjects.ToString());
            }
            var objects = await GetObjectChildrenAsync(id, parameters, levels).ConfigureAwait(false);
            return toMetasysObject(objects);
        }

        /// <inheritdoc />
        public virtual AccessToken TryLogin(string credManTarget, bool refresh = true)
        {
            return TryLoginAsync(credManTarget, refresh).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public virtual async Task<AccessToken> TryLoginAsync(string credManTarget, bool refresh = true)
        {
            // Retrieve credentials first
            var credentials = CredentialUtil.GetCredential(credManTarget);
            // Get the control back to TryLogin method
            return await TryLoginAsync(CredentialUtil.convertToUnSecureString(credentials.Username), CredentialUtil.convertToUnSecureString(credentials.Password), refresh).ConfigureAwait(false);
        }

        /// <summary>
        /// Convert a JToken batch request response into VariantMultiple.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected IEnumerable<VariantMultiple> ToVariantMultiples(JToken response)
        {
            List<VariantMultiple> multiples = new List<VariantMultiple>();
            foreach (var r in response["responses"])
            {
                var respIds = r["id"].Value<string>().Split('_');
                var objId = new Guid(respIds[0]);
                string attr = respIds[1];
                List<Variant> values= new List<Variant>();
                if (r["status"].Value<int>() == 200)
                {
                    values.Add(new Variant(objId, r["body"], attr, Culture, Version));
                } // Don't add the variant to the list if the response is not successful
                var m = multiples.SingleOrDefault(s => s.Id == objId);
                if (m == null)
                {
                    // Add a new multiple for the current object                   
                    multiples.Add(new VariantMultiple(objId, values));
                }
                else
                {
                    // Variant multiple already exists, just add Values
                    var newList = m.Values.ToList();
                    newList.AddRange(values);
                    m.Values = newList;
                }                             
            }
            return multiples;
        }
    }
}
