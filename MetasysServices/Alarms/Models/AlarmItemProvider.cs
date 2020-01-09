using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provides alarm Item
    /// </summary>
    public class AlarmItemProvider : IProvideAlarmItem
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
        public dynamic TriggerValue { get; set; }

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

        /// <summary>
        /// Link to network device
        /// </summary>
        public string networkDeviceUrl { get; set; }
		
        /// <summary>
        /// Returns a value indicating whither this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is AlarmItemProvider)
            {
                var other = (AlarmItemProvider)obj;
                bool areEqual = ((this.Id == null && other.Id == null) || (this.Id != null && this.Id.Equals(other.Id))) &&
                    ((this.ItemReference == null && other.ItemReference == null) ||
                        (this.ItemReference != null && this.ItemReference.Equals(other.ItemReference)));
                // To do: iterate expression on all the properties
                return areEqual;
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            code = (code * 7) + Id.GetHashCode();
            if (ItemReference != null)
                code = (code * 7) + ItemReference.GetHashCode();
            // To do: iterate expression on all the properties
            return code;
        }
    }
}