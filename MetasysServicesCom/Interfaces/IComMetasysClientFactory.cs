using System;
using System.Runtime.InteropServices;

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
        ILegacyMetasysClient GetLegacyClient(string hostname, bool ignoreCertificateErrors = false, string version = "v2", string cultureInfo = null);
    }
}
