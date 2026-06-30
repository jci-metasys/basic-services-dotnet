using System.Net.Http;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Creates an HttpClient that bypasses server certificate validation.
/// </summary>
public class UntrustedCertClientFactory
{
    // https://stackoverflow.com/questions/53853081/flurl-and-untrusted-certificates

    /// <summary>
    /// Creates a message handler that bypasses SSL certificate validation.
    /// </summary>
    public HttpMessageHandler CreateMessageHandler()
    {
        return new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (a, b, c, d) => true
        };
    }
}
