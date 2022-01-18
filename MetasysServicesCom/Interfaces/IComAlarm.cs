using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that holds attribute for alarms type object.
    /// </summary>
    [ComVisible(true)]
    [Guid("3a3e722b-0c1a-4966-9653-9cb1f4bb43bc")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComAlarm
    {
        /// <summary>
        /// URI that points back to this resource
        /// </summary>
        string Self { get; set; }

        /// <summary>
        /// Alarm Unique Identifier (GUID)
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Item fully qualified reference
        /// </summary>
        string ItemReference { get; set; }

        /// <summary>
        /// Alarm description
        /// </summary>
        /// <remarks> This is available since Metasys API v4. </remarks>
        string Description { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Discarded Time
        /// </summary>
        /// <remarks> This is available since Metasys API v4. </remarks>
        string DiscardedTime { get; set; }

        /// <summary>
        /// Alarm message
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Is acknowledge required for alarm
        /// </summary>
        bool IsAckRequired { get; set; }

        /// <summary>
        /// Alarm type route
        /// </summary>
        string TypeUrl { get; set; }

        /// <summary>
        /// Fully qualified enumeration for Alarm Type.
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        string Type { get; set; }

        /// <summary>
        /// Alarm priority
        /// </summary>
        int Priority { get; set; }

        /// <summary>
        /// Alarm trigger value details
        /// </summary>
        object TriggerValue { get; set; }

        /// <summary>
        /// Alarm detection time
        /// </summary>
        string CreationTime { get; set; }

        /// <summary>
        /// Activity Management Status
        /// </summary>
        /// <remarks> This is available since Metasys API v4. </remarks>
        string ActivityManagementStatus { get; set; }

        /// <summary>
        /// Is alarm already acknowledged
        /// </summary>
        /// <remarks> This is not anymore available since Metasys API v4. </remarks>
        bool IsAcknowledged { get; set; }

        /// <summary>
        /// Is alarm already discarded
        /// </summary>
        /// <remarks> This is not anymore available since Metasys API v4. </remarks>
        bool IsDiscarded { get; set; }

        /// <summary>
        /// Alarm Category route
        /// </summary>
        /// <remarks> This is available only with Metasys API v2 and v1. </remarks>
        string CategoryUrl { get; set; }

        /// <summary>
        /// Fully qualified enumeration for Alarm Category.
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        string Category { get; set; }

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
