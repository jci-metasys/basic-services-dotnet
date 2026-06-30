using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that provides audit Item
    /// </summary>
    [ComVisible(true)]
    [Guid("e34e058d-88a9-43d5-ae19-693683ad5691")]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComAudit : IComAudit
    {
        /// <inheritdoc/>
        public string Id { get; set; }

        /// <inheritdoc/>
        public string CreationTime { get; set; }

        /// <inheritdoc/>
        public string ActionTypeUrl { get; set; }

        /// <inheritdoc/>
        public bool Discarded { get; set; }

        /// <inheritdoc/>
        public string StatusUrl { get; set; }

        /// <inheritdoc/>
        public dynamic PreData { get; set; }

        /// <inheritdoc/>
        public dynamic PostData { get; set; }

        /// <inheritdoc/>
        public dynamic Parameters { get; set; }

        /// <inheritdoc/>
        public string ErrorString { get; set; }

        /// <inheritdoc/>
        public string User { get; set; }

        /// <inheritdoc/>
        public dynamic Signature { get; set; }

        /// <inheritdoc/>
        public string ObjectUrl { get; set; }

        /// <inheritdoc/>
        public string AnnotationsUrl { get; set; }

        /// <inheritdoc/>
        public dynamic Legacy { get; set; }

        /// <inheritdoc/>
        public string Self { get; set; }
    }
}
