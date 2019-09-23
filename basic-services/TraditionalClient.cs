using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace JohnsonControls.Metasys.BasicServices
{
    public class TraditionalClient
    {
        private FlurlClient client;

        private string accessToken;

        private DateTime tokenExpires;

        private bool refresh;

        private const int MAX_PAGE_SIZE = 1000;

        /// <summary>
        /// Creates a new TraditionalClient.
        /// </summary>
        /// <remarks>
        /// Takes an optional CultureInfo which is useful for formatting numbers. If not specified,
        /// the user's current culture is used.
        /// </remarks>
        /// <param name="cultureInfo"></param>
        public TraditionalClient(string hostname, bool ignoreCertificateErrors = false, ApiVersion version = ApiVersion.V2,  CultureInfo cultureInfo = null)
        {
            var culture = cultureInfo ?? CultureInfo.CurrentCulture;
            accessToken = null;
            tokenExpires = DateTime.UtcNow;
            FlurlHttp.Configure(settings => settings.OnErrorAsync = HandleFlurlErrorAsync);

            if (ignoreCertificateErrors) {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                HttpClient httpClient = new HttpClient(httpClientHandler);
                httpClient.BaseAddress = new Uri($"https://{hostname}"
                    .AppendPathSegments("api", version));
                client = new FlurlClient(httpClient);
            } else {
                client = new FlurlClient($"https://{hostname}"
                    .AppendPathSegments("api", version));
            }
        }

        private async Task HandleFlurlErrorAsync(HttpCall call)
        {
            if (call.Exception.GetType() != typeof(Flurl.Http.FlurlParsingException))
            {
                string error = $"{call.Exception.Message}";
                if (call.RequestBody != null) {
                    error += $", with body: {call.RequestBody.ToString()}";
                }
                await LogErrorAsync(error).ConfigureAwait(false);
            }
            call.ExceptionHandled = true;
        }

        private async Task LogErrorAsync(String message)
        {
            await Console.Error.WriteLineAsync(message).ConfigureAwait(false);
        }

        /// <summary>
        /// Attempts to login to the given host.
        /// </summary>
        /// <returns>
        /// Access token, expiration date.
        /// </returns>
        public (string,DateTime) TryLogin(string username, string password, bool refresh = true)
        {
            return TryLoginAsync(username, password, refresh).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Attempts to login to the given host asynchronously.
        /// </summary>
        /// <returns>
        /// Access token, expiration date.
        /// </returns>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        public async Task<(string,DateTime)> TryLoginAsync(string username, string password, bool refresh = true)
        {
            this.refresh = refresh;
            
            var response = await client.Request("login")
                .PostJsonAsync(new { username, password })
                .ReceiveJson<JToken>()
                .ConfigureAwait(false);

            try
            {
                var accessToken = response["accessToken"];
                var expires = response["expires"];
                this.accessToken = $"Bearer {accessToken.Value<string>()}";
                this.tokenExpires = expires.Value<DateTime>();
                client.Headers.Add("Authorization", this.accessToken);
                if (refresh)
                {
                    ScheduleRefresh();
                }
            }
            catch (System.NullReferenceException)
            {
                await LogErrorAsync("Could not get access token.").ConfigureAwait(false);
                accessToken = null;
                tokenExpires = DateTime.UtcNow;
            }
            return (this.accessToken, this.tokenExpires);
        }

        /// <summary>
        /// Requests a new access token before current token expires.
        /// </summary>
        /// <returns>
        /// Access token, expiration date.
        /// </returns>
        public (string, DateTime) Refresh()
        {
            return RefreshAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Requests a new access token before current token expires asynchronously.
        /// </summary>
        /// <returns>
        /// Access token, expiration date.
        /// </returns>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        public async Task<(string, DateTime)> RefreshAsync()
        {
            var response = await client.Request("refreshToken")
                .GetJsonAsync<JToken>()
                .ConfigureAwait(false);

            try
            {
                var accessToken = response["accessToken"];
                var expires = response["expires"];
                this.accessToken = $"Bearer {accessToken.Value<string>()}";
                this.tokenExpires = expires.Value<DateTime>();
                client.Headers.Remove("Authorization");
                client.Headers.Add("Authorization", this.accessToken);
                if (refresh)
                {
                    ScheduleRefresh();
                }
            }
            catch (System.NullReferenceException)
            {
                await LogErrorAsync("Refresh could not get access token.").ConfigureAwait(false);
                accessToken = null;
                tokenExpires = DateTime.UtcNow;
            }
            return (this.accessToken, this.tokenExpires);
        }

        /// <summary>
        /// Will call Refresh() a minute before the token expires.
        /// </summary>
        private void ScheduleRefresh()
        {
            DateTime now = DateTime.UtcNow;
            TimeSpan delay = tokenExpires - now;
            delay.Subtract(new TimeSpan(0, 1, 0));

            if (delay <= TimeSpan.Zero)
            {
                delay = TimeSpan.Zero;
            }

            int delayms = (int)delay.TotalMilliseconds;

            // If the time in milliseconds is greater than max int delayms will be negative and will not schedule a refresh.
            if (delayms >= 0)
            {
                System.Threading.Tasks.Task.Delay(delayms).ContinueWith(_ => Refresh());
            }
        }

        /// <summary>
        /// Returns the current access token and it's expiration date.
        /// </summary>
        /// <returns>
        /// Access token, expiration date.
        /// </returns>
        public (string, DateTime) GetAccessToken()
        {
            return (this.accessToken, this.tokenExpires);
        }

        /// <summary>
        /// Returns the object identifier (id) of the specified object.
        /// </summary>
        public Guid GetObjectIdentifier(string itemReference)
        {
            return GetObjectIdentifierAsync(itemReference).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Returns the object identifier (id) of the specified object asynchronously.
        /// </summary>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        /// <exception cref="System.FormatException"></exception>
        public async Task<Guid> GetObjectIdentifierAsync(string itemReference)
        {
            var response = await client.Request("objectIdentifiers")
                .SetQueryParam("fqr", itemReference)
                .GetStringAsync()
                .ConfigureAwait(false);

            try
            {
                var id = new Guid(response.Trim('"'));
                return id;
            }
            catch (System.FormatException)
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// Read one attribute value given the Guid of the object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        public Variant ReadProperty(Guid id, string attributeName)
        {
            return ReadPropertyAsync(id, attributeName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Read one attribute value given the Guid of the object asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        public async Task<Variant> ReadPropertyAsync(Guid id, string attributeName)
        {
            var response = await client.Request(new Url("objects")
                .AppendPathSegments(id, "attributes", attributeName))
                .GetJsonAsync<JToken>()
                .ConfigureAwait(false);

            try
            {
                var attribute = response["item"][attributeName];
                return new Variant(id, attribute, attributeName);
            }
            catch (System.NullReferenceException)
            {
                return new Variant(id, null, attributeName);
            }
        }

        /// <summary>
        /// Read many attribute values given the Guids of the objects.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="attributeNames"></param>
        public IEnumerable<Variant> ReadPropertyMultiple(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames)
        {
            return ReadPropertyMultipleAsync(ids, attributeNames).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Read many attribute values given the Guids of the objects asynchronously.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="attributeNames"></param>
        /// <exception cref="System.NullReferenceException"></exception>
        public async Task<List<Variant>> ReadPropertyMultipleAsync(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames)
        {
            if (ids == null || attributeNames == null)
            {
                return null;
            }

            List<Variant> results = new List<Variant>() { };
            var taskList = new List<Task<(Guid, JToken)>>();

            foreach (var id in ids)
            {
                taskList.Add(ReadObjectAsync(id));
            }

            await Task.WhenAll(taskList).ConfigureAwait(false);

            foreach (var task in taskList.ToList())
            {
                foreach (string attributeName in attributeNames)
                {
                    Guid id = task.Result.Item1;
                    try
                    {
                        JToken value = task.Result.Item2["item"][attributeName];
                        results.Add(new Variant(id, value, attributeName));
                    }
                    catch (System.NullReferenceException)
                    {
                        results.Add(new Variant(id, null, attributeName));
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Read entire object given the Guid of the object asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        private async Task<(Guid, JToken)> ReadObjectAsync(Guid id)
        {
            var response = await client.Request(new Url("objects")
                .AppendPathSegment(id))
                .GetJsonAsync<JToken>()
                .ConfigureAwait(false);
            return (id, response);
        }

        /// <summary>
        /// Write a single attribute given the Guid of the object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <param name="newValue"></param>
        public void WriteProperty(Guid id, string attributeName, object newValue, string priority = null)
        {
            WritePropertyAsync(id, attributeName, newValue, priority).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Write a single attribute given the Guid of the object asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <param name="newValue"></param>
        public async Task WritePropertyAsync(Guid id, string attributeName, object newValue, string priority = null)
        {
            List<(string, object)> list = new List<(string, object)>();
            list.Add((attributeName, newValue));
            var item = GetWritePropertyBody(list, priority);

            await WritePropertyRequestAsync(id, item).ConfigureAwait(false);
        }

        /// <summary>
        /// Write to all attributes given the Guids of the objects.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="attributeValues">The (attribute, value) pairs</param>
        /// <param name="priority"></param>
        public void WritePropertyMultiple(IEnumerable<Guid> ids, 
            IEnumerable<(string, object)> attributeValues, string priority = null)
        {
            WritePropertyMultipleAsync(ids, attributeValues, priority).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Write many attribute values given the Guids of the objects asynchronously.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="attributeValues">The (attribute, value) pairs</param>
        /// <param name="priority"></param>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        public async Task WritePropertyMultipleAsync(IEnumerable<Guid> ids, 
            IEnumerable<(string, object)> attributeValues, string priority = null)
        {
            if (ids == null || attributeValues == null) {
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
        /// Creates the body for the WriteProperty and WritePropertyMultiple requests.
        /// </summary>
        private Dictionary<string, object> GetWritePropertyBody(
            IEnumerable<(string, object)> attributeValues, string priority)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            foreach (var attribute in attributeValues)
            {
                pairs.Add(attribute.Item1, attribute.Item2);
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
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        private async Task WritePropertyRequestAsync(Guid id, Dictionary<string, object> body)
        {
            var json = new { item = body };
            var response = await client.Request(new Url("objects")
                .AppendPathSegment(id))
                .PatchJsonAsync(json)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Get all available commands given the Guid of the object.
        /// </summary>
        /// <param name="id"></param>
        public IEnumerable<Command> GetCommands(Guid id)
        {
            return GetCommandsAsync(id).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get all available commands given the Guid of the object asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        public async Task<IEnumerable<Command>> GetCommandsAsync(Guid id)
        {
            var token = await client.Request(new Url("objects")
                .AppendPathSegments(id, "commands"))
                .GetJsonAsync<JToken>()
                .ConfigureAwait(false);

            List<Command> commands = new List<Command>();

            var array = token as JArray;
                
            if (array != null)
            {
                foreach (JObject command in array)
                {
                    Command c = new Command(command);
                    commands.Add(c);
                }
            }
            else
            {
                await LogErrorAsync("Could not parse response data.").ConfigureAwait(false);
            }
            return commands;
        }

        /// <summary>
        /// Send a command to an object.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="command"></param>
        /// <param name="values"></param>
        public void SendCommand(Guid id, string command, IEnumerable<object> values = null)
        {
            SendCommandAsync(id, command, values).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Send a command to an object asynchronously.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="command"></param>
        /// <param name="values"></param>
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
        /// <param name="ids"></param>
        /// <param name="command"></param>
        /// <param name="json">The command body</param>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        private async Task SendCommandRequestAsync(Guid id, string command, IEnumerable<object> values)
        {
            var response = await client.Request(new Url("objects")
                .AppendPathSegments(id, "commands", command))
                .PutJsonAsync(values)
                .ConfigureAwait(false);
        }
    }
}
