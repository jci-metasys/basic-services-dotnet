using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

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

        private void LogClientUndefinedError()
        {
            var task = LogErrorAsync("Client undefined please login with TryLogin method.");
        }

        /// <summary>
        /// Attempts to login to the given host.
        /// </summary>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        public void TryLogin(string username, string password, string hostname, ApiVersion version = ApiVersion.V2, bool refresh = true)
        {
            this.refresh = true;
            if (client != null)
            {
                client.Dispose();
            }
            client = new FlurlClient($"https://{hostname}"
                .AppendPathSegments("api", version));
            var response = client.Request("login")
                .PostJsonAsync(new { username, password })
                .ReceiveJson<JToken>();

            try
            {
                var accessToken = response.Result["accessToken"];
                var expires = response.Result["expires"];
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
                LogClientUndefinedError();
                return;
            }

            var response = client.Request("refreshToken")
                .GetJsonAsync<JToken>();

            try
            {
                var accessToken = response.Result["accessToken"];
                var expires = response.Result["expires"];
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
                var task = LogErrorAsync("Refresh could not get access token.");
            }
        }

        /// <summary>
        /// Will call Refresh() a minute before the token expires.
        /// </summary>
        private void ScheduleRefresh()
        {
            DateTime now = DateTime.Now;
            TimeSpan delay = tokenExpires - now;
            delay.Subtract(new TimeSpan(0, 1, 0));

            if (delay <= TimeSpan.Zero)
            {
                delay = TimeSpan.Zero;
                var task = LogErrorAsync("Token expires in less than a minute, this may be a mismatch of the server's time and your machine's local time.");
            }

            int delayms = (int)delay.TotalMilliseconds;
            // If the time in milliseconds is greater than max int there will be issues so set time to infinite
            if (delayms < 0)
            {
                delayms = -1;
            }

            System.Threading.Tasks.Task.Delay(delayms).ContinueWith(_ => Refresh());
        }

        /// <summary>
        /// Returns the object identifier (id) of the specified object.
        /// </summary>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        /// <exception cref="System.FormatException"></exception>
        public Guid GetObjectIdentifier(string itemReference)
        {
            if (client == null)
            {
                LogClientUndefinedError();
                return Guid.Empty;
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
                return Guid.Empty;
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
                LogClientUndefinedError();
                return new ReadPropertyResult(id, null, attributeName);
            }

            var response = client.Request(new Url("objects")
                .AppendPathSegments(id, "attributes", attributeName))
                .GetJsonAsync<JToken>();

            try
            {
                var attribute = response.Result["item"][attributeName];
                return new ReadPropertyResult(id, attribute, attributeName);
            }
            catch (System.NullReferenceException)
            {
                return new ReadPropertyResult(id, null, attributeName);
            }
        }

        /// <summary>
        /// Read many attribute values given the Guids of the objects.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="attributeNames"></param>
        public IEnumerable<ReadPropertyResult> ReadPropertyMultiple(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames)
        {
            if (client == null)
            {
                LogClientUndefinedError();
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
        /// <param name="ids"></param>
        /// <param name="attributeNames"></param>
        /// <exception cref="System.NullReferenceException"></exception>
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

            foreach (var task in taskList.ToList())
            {
                foreach (string attributeName in attributeNames)
                {
                    Guid id = task.Result.Item1;
                    try
                    {
                        JToken value = task.Result.Item2["item"][attributeName];
                        results.Add(new ReadPropertyResult(id, value, attributeName));
                    }
                    catch (System.NullReferenceException)
                    {
                        results.Add(new ReadPropertyResult(id, null, attributeName));
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
                    .GetJsonAsync<JToken>();
            return (id, response);
        }
    }
}
