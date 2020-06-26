using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// DTO for the AuditSignature model.
    /// </summary>
    public class AuditSignature
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
