using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that holds attribute for alarms type object.
    /// </summary>
    [ComVisible(true)]
    [Guid("8EEACB76-BA34-4217-6DE5-FE623AA90082")]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComAlarmItemProvider : IComProvideAlarmItem
    {
        /// <summary>
        /// URI that points back to this resource
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// Alarm Unique Identifier (GUID)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Item fully qualified reference
        /// </summary>
        public string ItemReference { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Alarm message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Is acknowledge required for alarm
        /// </summary>
        public bool IsAckRequired { get; set; }

        /// <summary>
        /// Alarm type route
        /// </summary>
        public string TypeUrl { get; set; }

        /// <summary>
        /// Alarm priority
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Alarm trigger value details
        /// </summary>
        public object TriggerValue { get; set; }

        /// <summary>
        /// Alarm creation time
        /// </summary>
        public string CreationTime { get; set; }

        /// <summary>
        /// Is alarm already acknowledged
        /// </summary>
        public bool IsAcknowledged { get; set; }

        /// <summary>
        /// Is alarm discarded
        /// </summary>
        public bool IsDiscarded { get; set; }

        /// <summary>
        /// Alarm Category route
        /// </summary>
        public string CategoryUrl { get; set; }

        /// <summary>
        /// Link to Point
        /// </summary>
        public string ObjectUrl { get; set; }

        /// <summary>
        /// Link to annotations
        /// </summary>
        public string AnnotationsUrl { get; set; }
    }
}