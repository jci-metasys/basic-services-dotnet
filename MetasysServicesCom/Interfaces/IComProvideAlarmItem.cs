using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that holds attribute for alarms type object.
    /// </summary>
    [ComVisible(true)]
    [Guid("1ffd9abc-dfa3-4cb9-9872-8ae38de24ce1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComProvideAlarmItem
    {
        /// <summary>
        /// Alarm Unique Identifier (GUID)
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Item fully qualified reference
        /// </summary>
        string ItemReference { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Alarm message
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Is acknowledge required for alarm
        /// </summary>
        bool IsAckRequired { get; set; }

        /// <summary>
        /// Is alarm already acknowledged
        /// </summary>
        bool IsAcknowledged { get; set; }

        /// <summary>
        /// Is alarm discarded
        /// </summary>
        bool IsDiscarded { get; set; }

        /// <summary>
        /// Alarm priority
        /// </summary>
        int Priority { get; set; }

        /// <summary>
        /// Alarm detection time
        /// </summary>
        string CreationTime { get; set; }

        /// <summary>
        /// Alarm type route
        /// </summary>
        string TypeUrl { get; set; }

        /// <summary>
        /// Alarm trigger value details
        /// </summary>
        object TriggerValue { get; set; }

        /// <summary>
        /// Alarm Category route
        /// </summary>
        string CategoryUrl { get; set; }

        /// <summary>
        /// Link to Point
        /// </summary>
        string ObjectUrl { get; set; }

        /// <summary>
        /// Link to annotations
        /// </summary>
        string AnnotationsUrl { get; set; }
    }
}
