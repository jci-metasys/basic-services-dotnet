using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices.Token
{
    /// <summary>
    /// Access Token Response
    /// </summary>
    public class AccessTokenResponse
    {
        /// <summary>
        /// Access Token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Expiration Date Time
        /// </summary>
        public DateTime Expires { get; set; }
    }

    internal class TokenProvider : IAuthTokenProvider
    {
        private readonly string _serverUrl;
        private readonly ApiVersion _version;
        private readonly string _username;
        private readonly string _password;

        public TokenProvider(string serverUrl, ApiVersion version, string username, string password)
        {
            _serverUrl = serverUrl;
            _version = version;
            _username = username;
            _password = password;
        }
        public async Task<AccessTokenResponse> GetAccessTokenAsync()
        {
            var loginResponse = await _serverUrl.AppendPathSegments("api", _version, "login")
                                             .PostJsonAsync(new
                                             {
                                                 username = _username,
                                                 password = _password
                                             })
                                             .ReceiveJson<AccessTokenResponse>();

            return loginResponse;
        }

        public async Task<AccessTokenResponse> GetRefreshTokenAsync(string oldToken)
        {
            var response = await _serverUrl
                .AppendPathSegments("api", _version, "refreshToken")
                .WithOAuthBearerToken(oldToken)
                .GetJsonAsync<AccessTokenResponse>();

            return response;
        }
    }
}
