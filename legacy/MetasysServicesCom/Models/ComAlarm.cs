using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that holds attribute for alarms type object.
    /// </summary>
    [ComVisible(true)]
    [Guid("6f558d4a-4250-4ef4-8c51-3a6507ee844f")]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComAlarm : IComAlarm
    {
        /// <summary>
        /// URI that points back to this resource
        /// </summary>
        public string Self { get; set; }

        /// <inheritdoc/>
        public string Id { get; set; }

        /// <inheritdoc/>
        public string ItemReference { get; set; }

        /// <inheritdoc/>
        public string Description { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public string DiscardedTime { get; set; }

        /// <inheritdoc/>
        public string Message { get; set; }

        /// <inheritdoc/>
        public bool IsAckRequired { get; set; }

        /// <inheritdoc/>
        public string TypeUrl { get; set; }

        /// <inheritdoc/>
        public string Type { get; set; }

        /// <inheritdoc/>
        public int Priority { get; set; }

        /// <inheritdoc/>
        public object TriggerValue { get; set; }

        /// <inheritdoc/>
        public string CreationTime { get; set; }

        /// <inheritdoc/>
        public string ActivityManagementStatus { get; set; }

        /// <inheritdoc/>
        public bool IsAcknowledged { get; set; }

        /// <inheritdoc/>
        public bool IsDiscarded { get; set; }

        /// <inheritdoc/>
        public string CategoryUrl { get; set; }

        /// <inheritdoc/>
        public string Category { get; set; }

        /// <inheritdoc/>
        public string ObjectUrl { get; set; }

        /// <inheritdoc/>
        public string AnnotationsUrl { get; set; }
    }
}