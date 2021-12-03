using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices.Stream.Token
{
    public interface IAuthTokenProvider
    {
        Task<AccessTokenResponse> GetAccessTokenAsync();

        Task<AccessTokenResponse> GetRefreshTokenAsync(string oldToken);
    }
}
