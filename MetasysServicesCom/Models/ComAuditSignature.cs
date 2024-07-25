using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM Audit Signature is a specialized structure that holds information about the signature of the audit.
    /// </summary>
    [Guid("de093c7b-8a30-4a66-802f-6dfbb872398a")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComAuditSignature : IComAuditSignature
    {
        /// <summary>
        /// Full name of the user who executed the action.
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// The reason written by the user.
        /// </summary>
        public string Reason { get; set; }
    }
}
