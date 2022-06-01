using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices.Token
{
    /// <summary>
    /// Interface for Authorization Token Provider.
    /// </summary>
    public interface IAuthTokenProvider
    {
        /// <summary>
        /// Get Access Token (async).
        /// </summary>
        Task<AccessTokenResponse> GetAccessTokenAsync();

        /// <summary>
        /// Get Refresh Token (async).
        /// </summary>
        Task<AccessTokenResponse> GetRefreshTokenAsync(string oldToken);
    }
}
