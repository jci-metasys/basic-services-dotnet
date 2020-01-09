using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provides attribute for alarms
    /// </summary>
    public interface IProvideAlarmItem
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
        dynamic TriggerValue { get; set; }

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

        /// <summary>
        /// Link to network device
        /// </summary>
        string networkDeviceUrl { get; set; }
    }
}
