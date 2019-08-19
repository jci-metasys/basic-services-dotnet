using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    public class TraditionalClient
    {
        private FlurlClient client;

        private const string clientUndefinedMessage = "Client undefined please login with TryLogin method.";

        /// <summary>
        /// Creates a new TraditionalClient.
        /// </summary>
        /// <remarks>
        /// Takes an optional CultureInfo which is useful for formatting numbers. If not specified,
        /// the user's current culture is used.
        /// </remarks>
        /// <param name="cultureInfo"></param>
        public TraditionalClient(CultureInfo cultureInfo = null)
        {
            var culture = cultureInfo ?? CultureInfo.CurrentCulture;
            FlurlHttp.Configure(settings => settings.OnErrorAsync = HandleFlurlErrorAsync);
            FlurlHttp.Configure(settings => settings.OnError = HandleFlurlError);
        }

        private void HandleFlurlError(HttpCall call)
        {
            var task = HandleFlurlErrorAsync(call);
        }

        private async Task HandleFlurlErrorAsync(HttpCall call)
        {
            if (call.Exception.GetType() != typeof(Flurl.Http.FlurlParsingException))
            {
                await LogErrorAsync(call.Exception.Message);
            }
            call.ExceptionHandled = true;
        }

        private async Task LogErrorAsync(String message)
        {
            await Console.Error.WriteLineAsync(message);
        }

        /// <summary>
        /// Attempts to login to the given host.
        /// </summary>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        public void TryLogin(string username, string password, string hostname, ApiVersion version = ApiVersion.V2)
        {
            client = new FlurlClient($"https://{hostname}"
                .AppendPathSegments("api", version));
            var response = client.Request("login")
                .PostJsonAsync(new { username, password })
                .ReceiveJson<JToken>();

            try
            {
                var accessToken = response.Result["accessToken"];
                client.Headers.Add("Authorization", $"Bearer {accessToken}");
            }
            catch (System.NullReferenceException)
            {
                var task = LogErrorAsync("Could not get access token.");
            }
        }

        /// <summary>
        /// Requests a new access token before current token expires.
        /// </summary>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        public void Refresh()
        {
            if (client == null)
            {
                Console.Error.WriteLineAsync(clientUndefinedMessage);
                return;
            }

            var response = client.Request("refreshToken")
                .GetJsonAsync<JToken>();

            try
            {
                var accessToken = response.Result["accessToken"];
                client.Headers.Remove("Authorization");
                client.Headers.Add("Authorization", $"Bearer {accessToken}");
            }
            catch (System.NullReferenceException)
            {
                var task = LogErrorAsync("Could not get access token.");
            }
        }

        /// <summary>
        /// Returns the object identifier (id) of the specified object.
        /// </summary>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        public Guid GetObjectIdentifier(string itemReference)
        {
            Guid empty = new Guid(new Byte[16]);
            if (client == null)
            {
                Console.Error.WriteLineAsync(clientUndefinedMessage);
                return empty;
            }

            var response = client.Request("objectIdentifiers")
                .SetQueryParam("fqr", itemReference)
                .GetStringAsync();

            try
            {
                var id = new Guid(response.Result.Trim('"'));
                return id;
            }
            catch (System.FormatException)
            {
                return empty;
            }
        }

        /// <summary>
        /// Read one attribute value given the Guid of the object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        public ReadPropertyResult ReadProperty(Guid id, string attributeName)
        {
            if (client == null)
            {
                Console.Error.WriteLineAsync(clientUndefinedMessage);
                return null;
            }

            var response = client.Request(new Url("objects")
                .AppendPathSegments(id, "attributes", attributeName))
                .GetJsonAsync<JToken>();

            return new ReadPropertyResult(id, response.Result["item"][attributeName], attributeName);
        }

        /// <summary>
        /// Read many attribute values given the Guids of the objects.
        /// </summary>
        public IEnumerable<ReadPropertyResult> ReadPropertyMultiple(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames)
        {
            if (client == null)
            {
                Console.Error.WriteLineAsync(clientUndefinedMessage);
                return null;
            }

            if (ids == null || attributeNames == null)
            {
                return null;
            }

            return ReadPropertyMultipleAsync(ids, attributeNames).Result;
        }

        /// <summary>
        /// Read many attribute values given the Guids of the objects asynchronously.
        /// </summary>
        private async Task<List<ReadPropertyResult>> ReadPropertyMultipleAsync(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames)
        {
            List<ReadPropertyResult> results = new List<ReadPropertyResult>() { };
            var taskList = new List<Task<(Guid, JToken)>>();

            foreach (var id in ids)
            {
                taskList.Add(ReadObjectAsync(id));
            }

            await Task.WhenAll(taskList);

            foreach (var task in taskList.ToArray())
            {
                foreach (string attributeName in attributeNames)
                {
                    Guid id = task.Result.Item1;
                    JToken value = task.Result.Item2["item"][attributeName];
                    if (value != null)
                    {
                        lock (results)
                        {
                            results.Add(new ReadPropertyResult(id, value, attributeName));
                        }
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Read entire object given the Guid of the object asynchronously.
        /// </summary>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        private async Task<(Guid, JToken)> ReadObjectAsync(Guid id)
        {
            var response = await client.Request(new Url("objects")
                    .AppendPathSegment(id))
                    .GetJsonAsync<JToken>();
            return (id, response);
        }

        /// <summary>
        /// Write a single attribute given the Guid of the object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <param name="newValue"></param>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        /// <exception cref="JsonSerializationException"></exception>
        public void WriteProperty(Guid id, string attributeName, object newValue, string priority = null)
        {
            if (client == null)
            {
                Console.Error.WriteLineAsync(clientUndefinedMessage);
                return;
            }
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add(attributeName, newValue);
            if (priority != null)
            {
                pairs.Add("priority", priority);
            }
            Dictionary<string, Dictionary<string, object>> item = new Dictionary<string, Dictionary<string, object>>();
            item.Add("item", pairs);

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var response = client.Request(new Url("objects")
                    .AppendPathSegment(id))
                    .PatchJsonAsync(json);
            }
            catch (JsonSerializationException)
            {
                var task = LogErrorAsync("Could not format request.");
            }

        }

        /// <summary>
        /// Write to all attributes given the Guids of the objects.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="attributeValues">The (attribute, value) pairs</param>
        /// <exception cref="JsonSerializationException"></exception>
        public void WritePropertyMultiple(IEnumerable<Guid> ids, IEnumerable<(string, object)> attributeValues, string priority = null)
        {
            if (client == null)
            {
                Console.Error.WriteLineAsync(clientUndefinedMessage);
                return;
            }

            Dictionary<string, object> pairs = new Dictionary<string, object>();
            foreach (var attribute in attributeValues)
            {
                pairs.Add(attribute.Item1, attribute.Item2);
            }

            if (priority != null)
            {
                pairs.Add("priority", priority);
            }

            Dictionary<string, Dictionary<string, object>> item = new Dictionary<string, Dictionary<string, object>>();
            item.Add("item", pairs);
            try
            {
                var json = JsonConvert.SerializeObject(item);
                WritePropertyMultipleAsync(ids, json);
            }
            catch (JsonSerializationException)
            {
                var task = LogErrorAsync("Could not format request.");
            }
        }

        /// <summary>
        /// Write many attribute values given the Guids of the objects asynchronously.
        /// </summary>
        private async void WritePropertyMultipleAsync(IEnumerable<Guid> ids,
            string json)
        {
            var taskList = new List<Task>();

            foreach (var id in ids)
            {
                taskList.Add(WritePropertyAsync(id, json));
            }

            await Task.WhenAll(taskList);
        }

        /// <summary>
        /// Write many attribute values in the provided json given the Guid of the object asynchronously.
        /// </summary>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        private async Task WritePropertyAsync(Guid id, string json)
        {
            var response = await client.Request(new Url("objects")
                .AppendPathSegment(id))
                .PatchJsonAsync(json);
        }

        /// <summary>
        /// Get all available commands given the Guid of the object.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        public IEnumerable<Command> GetCommands(Guid id)
        {
            var token = client.Request(new Url("objects")
                .AppendPathSegments(id, "commands"))
                .GetJsonAsync<JToken>();
            
            List<Command> commands = new List<Command>();
            if (token.Result.Type == JTokenType.Array) {
                var array = token.Result as JArray;
                if (array != null) {
                    foreach (JObject command in array) {
                        Command c = new Command(command);
                        commands.Add(c);
                    }
                } else {
                    var task = LogErrorAsync("Could not parse response data.");
                }
            } else {
                var task = LogErrorAsync("Could not parse response data.");
            }
            return commands;
        }

        /// <summary>
        /// Send a command to an object.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="command"></param>
        /// <param name="values"></param>
        /// <exception cref="JsonSerializationException"></exception>
        public void SendCommand(Guid id, string command, IEnumerable<object> values = null)
        {
            if (values == null)
            {
                SendCommandRequest(id, command, new string[0]);
            }
            else
            {
                try
                {
                    var json = JsonConvert.SerializeObject(values);
                    SendCommandRequest(id, command, json);
                }
                catch (JsonSerializationException)
                {
                    var task = LogErrorAsync("Could not format request.");
                }
            }
        }

        /// <summary>
        /// Send a command to an object synchronously.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="command"></param>
        /// <param name="json">The command body</param>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        private void SendCommandRequest(Guid id, string command, object json)
        {
            var response = client.Request(new Url("objects")
                .AppendPathSegments(id, "commands", command))
                .PutJsonAsync(json);
        }
    }
}
