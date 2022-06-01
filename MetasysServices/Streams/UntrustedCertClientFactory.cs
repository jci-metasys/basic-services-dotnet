using Flurl.Http.Configuration;
using System.Net.Http;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provide Untrusted Certificate Client Factory.
    /// </summary>
    public class UntrustedCertClientFactory : DefaultHttpClientFactory
    {
        // https://stackoverflow.com/questions/53853081/flurl-and-untrusted-certificates

        /// <summary>
        /// Create Message Handler.
        /// </summary>
        public override HttpMessageHandler CreateMessageHandler()
        {
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (a, b, c, d) => true
            };
        }
    }
}
