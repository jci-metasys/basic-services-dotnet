using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provides alarm Item
    /// </summary>
    public class Alarm 
    {
        /// <summary>
        /// URI that points back to this resource
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// Alarm Unique Identifier (GUID)
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Item fully qualified reference
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string ItemReference { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        [JsonProperty(Required = Required.Always)]
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
        /// <remarks> This is available only on Metasys API v2 and v1. </remarks>
        public string TypeUrl { get; set; }

        /// <summary>
        /// Fully qualified enumeration for Alarm Type.
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string Type { get; set; }

        /// <summary>
        /// Alarm priority
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Alarm trigger value details
        /// </summary>
        public Measurement TriggerValue { get; set; }

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
        /// <remarks> This is available only on Metasys API v2 and v1. </remarks>
        public string CategoryUrl { get; set; }

        /// <summary>
        /// Fully qualified enumeration for Alarm Category.
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string Category { get; set; }

        /// <summary>
        /// Link to Point
        /// </summary>
        public string ObjectUrl { get; set; }

        /// <summary>
        /// Link to annotations
        /// </summary>
        public string AnnotationsUrl { get; set; }

        /// <summary>
        /// Returns a value indicating whether this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Alarm)
            {
                var o = (Alarm)obj;
                // Compare each properties one by one for better performance
                return this.Id == o.Id && this.IsAcknowledged == o.IsAcknowledged && this.IsAckRequired == o.IsAckRequired
                    && this.IsDiscarded == o.IsDiscarded && this.ItemReference == o.ItemReference && this.Message == o.Message
                    && this.Name == o.Name && this.ObjectUrl == o.ObjectUrl && this.Priority == o.Priority
                    && this.Self == o.Self && this.TypeUrl == o.TypeUrl && this.Type == o.Type && this.AnnotationsUrl == o.AnnotationsUrl
                    && this.CategoryUrl == o.CategoryUrl && this.Category == o.Category && this.CreationTime == o.CreationTime;
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            // Calculate hash on each properties one by one
            code = (code * 7) + Id.GetHashCode();
            if (ItemReference != null)
                code = (code * 7) + ItemReference.GetHashCode();
            if (this.AnnotationsUrl != null)
                code = (code * 7) + AnnotationsUrl.GetHashCode();
            if (this.CategoryUrl != null)
                code = (code * 7) + CategoryUrl.GetHashCode();
            if (this.CreationTime != null)
                code = (code * 7) + CreationTime.GetHashCode();
            code = (code * 7) + IsAckRequired.GetHashCode();
            code = (code * 7) + IsAcknowledged.GetHashCode();
            code = (code * 7) + IsDiscarded.GetHashCode();
            if (this.Message != null)
                code = (code * 7) + Message.GetHashCode();
            if (this.Name != null)
                code = (code * 7) + Name.GetHashCode();
            if (this.ObjectUrl != null)
                code = (code * 7) + ObjectUrl.GetHashCode();
            code = (code * 7) + Priority.GetHashCode();
            if (this.Self != null)
                code = (code * 7) + Self.GetHashCode();
            if (this.TypeUrl != null)
                code = (code * 7) + TypeUrl.GetHashCode();
            if (this.Type != null)
                code = (code * 7) + Type.GetHashCode();
            if (this.Category != null)
                code = (code * 7) + Category.GetHashCode();
            return code;
        }

        /// <summary>
        /// Return a pretty JSON string of the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}