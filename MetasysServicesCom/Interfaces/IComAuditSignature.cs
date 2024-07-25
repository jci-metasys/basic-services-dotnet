using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM Audit Signature is a specialized structure that holds information about the signature of the audit.
    /// </summary>
    [ComVisible(true)]
    [Guid("0df74ebf-39b4-4246-9551-58550b9aaabc")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComAuditSignature
    {
        /// <summary>
        /// Full name of the user who executed the action.
        /// </summary>
        string FullName { get; set; }
        /// <summary>
        /// The reason written by the user.
        /// </summary>
        string Reason { get; set; }
    }
}
