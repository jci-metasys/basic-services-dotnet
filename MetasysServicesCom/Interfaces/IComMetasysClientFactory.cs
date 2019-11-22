using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized factory for COM to get Legacy Client instances
    /// </summary>
    [ComVisible(true)]
    [Guid("eaf228bf-8b1a-4ff6-b054-2e32eaaa16f5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComMetasysClientFactory
    {
        /// <summary>
        /// Create an instance of Legacy Client according to the provided parameters.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="ignoreCertificateErrors"></param>
        /// <param name="version"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        ILegacyMetasysClient GetLegacyClient(string hostname, bool ignoreCertificateErrors = false, string version = "V2", string cultureInfo = null);
    }
}
