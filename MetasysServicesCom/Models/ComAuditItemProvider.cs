using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that provides audit Item
    /// </summary>
    [ComVisible(true)]
    [Guid("C6B20D4F-F1FA-44EB-AF17-3D09FB43D066")]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComAuditItemProvider : IComProvideAuditItem
    {
        /// <inheritdoc />
        public string Id { get; set; }

        /// <inheritdoc />
        public string CreationTime { get; set; }

        /// <inheritdoc />
        public string ActionTypeUrl { get; set; }

        /// <inheritdoc />
        public bool Discarded { get; set; }

        /// <inheritdoc />
        public string StatusUrl { get; set; }

        /// <inheritdoc />
        public dynamic PreData { get; set; }

        /// <inheritdoc />
        public dynamic PostData { get; set; }

        /// <inheritdoc />
        public dynamic Parameters { get; set; }

        /// <inheritdoc />
        public string ErrorString { get; set; }

        /// <inheritdoc />
        public string User { get; set; }

        /// <inheritdoc />
        public dynamic Signature { get; set; }

        /// <inheritdoc />
        public string ObjectUrl { get; set; }

        /// <inheritdoc />
        public string AnnotationsUrl { get; set; }

        /// <inheritdoc />
        public dynamic Legacy { get; set; }

        /// <summary>
        /// URI that points back to this resource
        /// </summary>
        public string Self { get; set; }
    }
}
