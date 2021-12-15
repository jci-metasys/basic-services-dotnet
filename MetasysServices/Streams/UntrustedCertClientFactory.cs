using Flurl.Http.Configuration;
using System.Net.Http;

namespace JohnsonControls.Metasys.BasicServices
{
    public class UntrustedCertClientFactory : DefaultHttpClientFactory
    {
        // https://stackoverflow.com/questions/53853081/flurl-and-untrusted-certificates
        public override HttpMessageHandler CreateMessageHandler()
        {
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (a, b, c, d) => true
            };
        }
    }
}
