using JohnsonControls.Metasys.BasicServices;
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
    public class ComMetasysClientFactory:IComMetasysClientFactory
    {
        /// <summary>
        /// Create an instance of Legacy Client according to the provided parameters.
        /// </summary>
        /// <remarks>
        /// Ensure compatibility with languages that don't support constructors with parameters, e.g. VBA.
        /// </remarks>
        /// <param name="hostname"></param>
        /// <param name="ignoreCertificateErrors"></param>
        /// <param name="version"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>LegacyMetasysClientInstance</returns>
        public ILegacyMetasysClient GetLegacyClient(string hostname, bool ignoreCertificateErrors = false, string version = "v2", string cultureInfo = null)
        {
            if (!Enum.TryParse(version, out ApiVersion apiVersion))
            {
                // Something went wrong while parsing API Version
                throw new MetasysUnsupportedApiVersion(version);
            }
            CultureInfo culture=null;
            // Init culture parsing string parameters
            if (cultureInfo != null)
            {
                culture = new CultureInfo(cultureInfo);
            }
            // Create instance with the given parameters
            return new LegacyMetasysClient(new MetasysClient(hostname, ignoreCertificateErrors, apiVersion, culture));
        }
    }
}
