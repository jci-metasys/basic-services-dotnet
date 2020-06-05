using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Provides attribute to Audit Annotation.
    /// </summary>
    [ComVisible(true)]
    [Guid("A080A311-349D-4FAF-84F5-CF09FC9E9B6B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]

    public interface IComAuditAnnotation
    {
        /// <summary>
        /// Text of the annotation.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// User who made the annotation.
        /// </summary>
        string User { get; set; }

        /// <summary>
        /// Creation time of the annotation.
        /// </summary>
        DateTime CreationTime { get; set; }

        /// <summary>
        /// Action of the annotation.
        /// </summary>
        string Action { get; set; }

        /// <summary>
        /// URL of the audit related to the annotation.
        /// </summary>
        string AuditUrl { get; set; }

        /// <summary>
        /// Signature of the annotation.
        /// </summary>
         string Signature { get; set; }
    }
}
