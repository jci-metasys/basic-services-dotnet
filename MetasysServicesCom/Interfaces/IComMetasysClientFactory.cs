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
        /// <remarks>
        /// Ensure compatibility with languages that don't support constructors with parameters, e.g. VBA.
        /// </remarks>
        /// <param name="hostname"></param>
        /// <param name="ignoreCertificateErrors"></param>
        /// <param name="version"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="logClientErrors">Set this flag to false to disable logging of client errors.</param>
        /// <returns>LegacyMetasysClient Instance</returns>
        ILegacyMetasysClient GetLegacyClient(string hostname, bool ignoreCertificateErrors = false, string version = "v2", string cultureInfo = null, bool logClientErrors = true);

        /// <summary>
        /// Retrieve a Credential Manager object for the given target.
        /// </summary>
        /// <param name="credManagerTarget">Target to read from the Credential Manager.</param>
        /// <returns></returns>
        IComUserPass GetCredentials(string credManagerTarget);
    }
}
