using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Annotation for an audit.
    /// </summary>
    public class AuditAnnotation:MetasysAnnotation
    {
        /// <summary>
        /// URL of the audit related to the annotation.
        /// </summary>
        public string AuditUrl { get; set; }
        /// <summary>
        /// Signature of the annotation.
        /// </summary>
        public string Signature { get; set; }
    }
}
