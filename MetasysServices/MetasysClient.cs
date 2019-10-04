using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using JohnsonControls.Metasys.BasicServices.Interfaces;
using JohnsonControls.Metasys.BasicServices.Models;

namespace JohnsonControls.Metasys.BasicServices
{
    public class MetasysClient : IMetasysClient
    {
        protected FlurlClient Client;

        protected string AccessToken;

        protected DateTime TokenExpires;

        protected bool RefreshToken;

        protected const int MAX_PAGE_SIZE = 1000;

        /// <summary>
        /// Creates a new TraditionalClient.
        /// </summary>
        /// <remarks>
        /// Takes an optional CultureInfo which is useful for formatting numbers. If not specified,
        /// the user's current culture is used.
        /// </remarks>
        /// <param name="cultureInfo"></param>
        public MetasysClient(string hostname, bool ignoreCertificateErrors = false, ApiVersion version = ApiVersion.V2, CultureInfo cultureInfo = null)
        {
            var culture = cultureInfo ?? CultureInfo.CurrentCulture;
            AccessToken = null;
            TokenExpires = DateTime.UtcNow;
            FlurlHttp.Configure(settings => settings.OnErrorAsync = HandleFlurlErrorAsync);

            if (ignoreCertificateErrors)
            {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                HttpClient httpClient = new HttpClient(httpClientHandler);
                httpClient.BaseAddress = new Uri($"https://{hostname}"
                    .AppendPathSegments("api", version));
                Client = new FlurlClient(httpClient);
            }
            else
            {
                Client = new FlurlClient($"https://{hostname}"
                    .AppendPathSegments("api", version));
            }
        }

        private async Task HandleFlurlErrorAsync(HttpCall call)
        {
            if (call.Exception.GetType() != typeof(Flurl.Http.FlurlParsingException))
            {
                string error = $"{call.Exception.Message}";
                if (call.RequestBody != null)
                {
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
        public (string Token, DateTime ExpirationDate) TryLogin(string username, string password, bool refresh = true)
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
        public async Task<(string Token, DateTime ExpirationDate)> TryLoginAsync(string username, string password, bool refresh = true)
        {
            this.RefreshToken = refresh;

            var response = await Client.Request("login")
                .PostJsonAsync(new { username, password })
                .ReceiveJson<JToken>()
                .ConfigureAwait(false);

            try
            {
                var accessToken = response["accessToken"];
                var expires = response["expires"];
                this.AccessToken = $"Bearer {accessToken.Value<string>()}";
                this.TokenExpires = expires.Value<DateTime>();
                Client.Headers.Add("Authorization", this.AccessToken);
                if (refresh)
                {
                    ScheduleRefresh();
                }
            }
            catch (System.NullReferenceException)
            {
                await LogErrorAsync("Could not get access token.").ConfigureAwait(false);
                AccessToken = null;
                TokenExpires = DateTime.UtcNow;
            }
            return (Token: this.AccessToken, ExpirationDate: this.TokenExpires);
        }

        /// <summary>
        /// Requests a new access token before current token expires.
        /// </summary>
        /// <returns>
        /// Access token, expiration date.
        /// </returns>
        public (string Token, DateTime ExpirationDate) Refresh()
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
        public async Task<(string Token, DateTime ExpirationDate)> RefreshAsync()
        {
            var response = await Client.Request("refreshToken")
                .GetJsonAsync<JToken>()
                .ConfigureAwait(false);

            try
            {
                var accessToken = response["accessToken"];
                var expires = response["expires"];
                this.AccessToken = $"Bearer {accessToken.Value<string>()}";
                this.TokenExpires = expires.Value<DateTime>();
                Client.Headers.Remove("Authorization");
                Client.Headers.Add("Authorization", this.AccessToken);
                if (RefreshToken)
                {
                    ScheduleRefresh();
                }
            }
            catch (System.NullReferenceException)
            {
                await LogErrorAsync("Refresh could not get access token.").ConfigureAwait(false);
                AccessToken = null;
                TokenExpires = DateTime.UtcNow;
            }
            return (Token: this.AccessToken, ExpirationDate: this.TokenExpires);
        }

        /// <summary>
        /// Will call Refresh() a minute before the token expires.
        /// </summary>
        private void ScheduleRefresh()
        {
            DateTime now = DateTime.UtcNow;
            TimeSpan delay = TokenExpires - now;
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
        public (string Token, DateTime ExpirationDate) GetAccessToken()
        {
            return (Token: this.AccessToken, ExpirationDate: this.TokenExpires);
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
        /// <exception cref="System.ArgumentNullException"></exception>
        public async Task<Guid> GetObjectIdentifierAsync(string itemReference)
        {
            var response = await Client.Request("objectIdentifiers")
                .SetQueryParam("fqr", itemReference)
                .GetJsonAsync<JToken>()
                .ConfigureAwait(false);

            try
            {
                var str = response.Value<string>();
                var id = new Guid(str);
                return id;
            }
            catch (System.ArgumentNullException)
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
        /// <exception cref="System.NullReferenceException"></exception>
        public async Task<Variant> ReadPropertyAsync(Guid id, string attributeName)
        {
            var response = await Client.Request(new Url("objects")
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
        public IEnumerable<(Guid Id, IEnumerable<Variant> Variants)> ReadPropertyMultiple(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames)
        {
            return ReadPropertyMultipleAsync(ids, attributeNames).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Read many attribute values given the Guids of the objects asynchronously.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="attributeNames"></param>
        public async Task<IEnumerable<(Guid Id, IEnumerable<Variant> Variants)>> ReadPropertyMultipleAsync(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames)
        {
            if (ids == null || attributeNames == null)
            {
                return null;
            }
            List<(Guid Id, IEnumerable<Variant> Variants)> results = new List<(Guid Id, IEnumerable<Variant> Variants)>();
            var taskList = new List<Task<Variant>>();
            // Prepare Tasks to Read attributes list. In Metasys 11 this will be implemented server side
            foreach (var id in ids)
            {
                foreach (string attributeName in attributeNames)
                {
                    // Much faster reading single property than the entire object, even though we have more server calls
                    taskList.Add(ReadPropertyAsync(id, attributeName));
                }
            }
            await Task.WhenAll(taskList).ConfigureAwait(false);
            foreach (var id in ids)
            {
                // Get attributes of the specific Id
                List<Task<Variant>> attributeList = taskList.Where(w => w.Result.Id == id).ToList();
                List<Variant> variants = new List<Variant>();
                foreach (var t in attributeList)
                {
                    variants.Add(t.Result); // Prepare variants list
                }
                // Aggregate results
                results.Add((Id: id, Variants: variants));
            }
            return results.AsEnumerable();
        }

        /// <summary>
        /// Read entire object given the Guid of the object asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Flurl.Http.FlurlHttpException"></exception>
        private async Task<(Guid Id, JToken Token)> ReadObjectAsync(Guid id)
        {
            var response = await Client.Request(new Url("objects")
                .AppendPathSegment(id))
                .GetJsonAsync<JToken>()
                .ConfigureAwait(false);
            return (Id: id, Token: response);
        }      
    }
}
