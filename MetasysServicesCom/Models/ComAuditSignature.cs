using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM Audit Signature is a specialized structure that holds information about the signature of the audit.
    /// </summary>
    [Guid("de093c7b-8a30-4a66-802f-6dfbb872398a")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComAuditSignature:IComAuditSignature
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
