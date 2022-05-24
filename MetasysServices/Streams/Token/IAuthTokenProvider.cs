using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices.Token
{
    public interface IAuthTokenProvider
    {
        Task<AccessTokenResponse> GetAccessTokenAsync();

        Task<AccessTokenResponse> GetRefreshTokenAsync(string oldToken);
    }
}
