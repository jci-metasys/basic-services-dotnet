using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using log4net.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JohnsonControls.Metasys.BasicServices.Utils;
using System.Dynamic;


namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provide enumeration item for the endpoints of the Metasys Enumerations API.
    /// </summary>
    public sealed class EnumerationServiceProvider : BasicServiceProvider, IEnumerationService
    {
        private readonly CultureInfo _CultureInfo = new CultureInfo("en-US");

        /// <summary>
        /// Initializes a new instance of <see cref="NetworkDeviceServiceProvider"/> with supplied data.
        /// </summary>
        /// <param name="client">The FlurlClient to get response from URL.</param>
        /// <param name="version">The server's Api version.</param>
        /// <param name="logClientErrors">Set this flag to false to disable logging of client errors.</param>
        public EnumerationServiceProvider(IFlurlClient client, ApiVersion version, bool logClientErrors = true) : base(client, version, logClientErrors)
        {
        }

        // Get ------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public IEnumerable<MetasysEnumeration> Get()
        {
            return GetAsync().GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysEnumeration>> GetAsync()
        {
            CheckVersion(Version);

            List<MetasysEnumeration> enums = new List<MetasysEnumeration>() { };

            if (Version > ApiVersion.v3) 
            { 
                try
                {
                    var response = await Client.Request(new Url("enumerations"))
                        .GetJsonAsync<JToken>()
                        .ConfigureAwait(false);
                    try
                    {
                        var items = response["items"];
                        dynamic kvpList = JsonConvert.DeserializeObject<ExpandoObject>(items.ToString());
                        foreach (KeyValuePair<string, object> kvp in kvpList)
                        {
                            if (kvp.Key.Length > 0)
                            {
                                var itm = kvp.Value as IDictionary<string, object>;
                                String key = kvp.Key;
                                String name = (itm.ContainsKey("name")) ? itm["name"].ToString() : String.Empty;
                                bool isTwoState = bool.Parse((itm.ContainsKey("isTwoState")) ? itm["isTwoState"].ToString() : Convert.ToString(false));
                                bool isMultiState = bool.Parse((itm.ContainsKey("isMultiState")) ? itm["isMultiState"].ToString() : Convert.ToString(false));
                                int numberOfStates = int.Parse((itm.ContainsKey("numberOfStates")) ? itm["numberOfStates"].ToString() : Convert.ToString(0));

                                var enumItem = new MetasysEnumeration(key, name, isTwoState, isMultiState, numberOfStates, Culture);
                                enums.Add(enumItem);
                            }
                        }
                    }
                    catch (System.NullReferenceException e)
                    { throw new MetasysHttpParsingException(response.ToString(), e); }
                }
                catch (FlurlHttpException e)
                { ThrowHttpException(e); }
            }
            else
            { throw new MetasysUnsupportedApiVersion(Version.ToString()); }

            return enums;
        }

        // Create ----------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public void Create(string name, IEnumerable<String> values)
        {
            CreateAsync(name, values).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task CreateAsync(string name, IEnumerable<String> values)
        {
            CheckVersion(Version);
            try
            {
                if (Version > ApiVersion.v3) 
                { 
                    //Check if the name is not blank or the length of the list of members is >= 2
                    if (name.Length > 0 && values.Count() >= 2)
                    {
                        JObject body = new JObject();
                        JObject item = new JObject();
                        JArray members = new JArray();
                        item.Add(propertyName: "name", value: name);
                        foreach (String v in values)
                        {
                            members.Add(v.ToString());
                        }
                        item.Add(propertyName: "members", value: members);
                        body.Add(propertyName: "item", value: item);
                        // Post the list of requests and return responses as JToken
                        var response = await Client.Request(new Url("enumerations"))
                                                    .PostJsonAsync(body)
                                                    .ConfigureAwait(false);
                    }
                }else 
                { throw new MetasysUnsupportedApiVersion(Version.ToString()); }
            }
            catch (FlurlHttpException e)
            { ThrowHttpException(e); }
        }

        // GetValues ------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public IEnumerable<MetasysEnumValue> GetValues(String id)
        {
            return GetEnumValues(id);
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysEnumValue>> GetValuesAsync(String id)
        {
            return await GetEnumValuesAsync(id);
        }

        // Edit ----------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public void Edit(String id, string name, IEnumerable<String> values)
        {
            EditAsync(id, name, values).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task EditAsync(String id, string name, IEnumerable<String> values)
        {
            CheckVersion(Version);
            try
            {
                if (Version > ApiVersion.v3) 
                { 
                    //Check if the name is not blank or the length of the list of members is >= 2
                    if (name.Length > 0 && values.Count() >= 2)
                    {
                        JObject body = new JObject();
                        JObject item = new JObject();
                        JObject members = new JObject();
                        item.Add(propertyName: "name", value: name);
                        for (int i = 0; i < values.Count(); i++)
                        {
                            members.Add(propertyName: id + "." + i.ToString(), value: JObject.FromObject(new { name = values.ToList()[i] }));
                        }
                        item.Add(propertyName: "members", value: members);
                        body.Add(propertyName: "item", value: item);
                        // Patch the list of requests and return responses as JToken
                        var response = await Client.Request(new Url("enumerations")
                                                    .AppendPathSegments(id))
                                                    .PatchJsonAsync(body)
                                                    .ConfigureAwait(false);
                    }
                }else
                { throw new MetasysUnsupportedApiVersion(Version.ToString()); }
            }
            catch (FlurlHttpException e)
            { ThrowHttpException(e); }
        }

        // Replace ----------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public void Replace(String id, string name, IEnumerable<String> values)
        {
            ReplaceAsync(id, name, values).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task ReplaceAsync(String id, string name, IEnumerable<String> values)
        {
            CheckVersion(Version);
            try
            {
                if (Version > ApiVersion.v3) 
                {
                    //Check if the name is not blank or the length of the list of members is >= 2
                    if (id.Length > 0 && name.Length > 0 && values.Count() >= 2)
                    {
                        JObject body = new JObject();
                        JObject item = new JObject();
                        JArray members = new JArray();
                        item.Add(propertyName: "name", value: name);
                        foreach (String v in values)
                        {
                            members.Add(v.ToString());
                        }
                        item.Add(propertyName: "members", value: members);
                        body.Add(propertyName: "item", value: item);
                        // Put the list of requests and return responses as JToken
                        var response = await Client.Request(new Url("enumerations")
                                                        .AppendPathSegments(id))
                                                        .PutJsonAsync(body)
                                                        .ConfigureAwait(false);
                    }
                }else 
                { throw new MetasysUnsupportedApiVersion(Version.ToString()); }
            }
            catch (FlurlHttpException e)
            { ThrowHttpException(e); }
        }

        // Delete ----------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public void Delete(string id)
        {
            DeleteAsync(id).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task DeleteAsync(string id)
        {
            CheckVersion(Version);
            try
            {
                if (Version > ApiVersion.v3) 
                { 
                    var response = await Client.Request(new Url("enumerations")
                                                                .AppendPathSegments(id))
                                                                .DeleteAsync()
                                                                .ConfigureAwait(false);
                }else 
                { throw new MetasysUnsupportedApiVersion(Version.ToString());}
            }
            catch (FlurlHttpException e)
            { ThrowHttpException(e); }
        }
    }
}
