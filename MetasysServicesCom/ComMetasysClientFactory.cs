using JohnsonControls.Metasys.BasicServices;
using JohnsonControls.Metasys.BasicServices.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A Factory for ILegacyMetasysClient
    /// </summary>
    [ComVisible(true)]
    [Guid("47a9cdca-afa0-4513-b116-0482e939a7c3")]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComMetasysClientFactory : IComMetasysClientFactory
    {
        ///<inheritdoc/>
        public ILegacyMetasysClient GetLegacyClient(string hostname, bool ignoreCertificateErrors = false, string version = "v2", string cultureInfo = null)
        {
            // Comparison is always made in lower case
            if (!Enum.TryParse(version.ToLowerInvariant(), out ApiVersion apiVersion))
            {
                // Something went wrong while parsing API Version
                throw new MetasysUnsupportedApiVersion(version);
            }
            CultureInfo culture = null;
            // Init culture parsing string parameters
            if (cultureInfo != null)
            {
                culture = new CultureInfo(cultureInfo);
            }
            // Create instance with the given parameters
            return new LegacyMetasysClient(new MetasysClient(hostname, ignoreCertificateErrors, apiVersion, culture));
        }

        /// <inheritdoc/>
        public IComUserPass GetCredentials(string credManagerTarget)
        {
            var cred = CredentialUtil.GetCredential(credManagerTarget);
            return new ComUserPass
            {
                Username = CredentialUtil.convertToUnSecureString(cred.Username),
                Password = CredentialUtil.convertToUnSecureString(cred.Password)
            };
        }
    }
}
