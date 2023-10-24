using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace JohnsonControls.Metasys.BasicServices
{
    public class ActivityAlarm
    {
        /// <summary> Alarm message </summary>
        public string Message { get; set; }

        /// <summary> Is acknowledge required for alarm </summary>
        public bool IsAckRequired { get; set; }

        /// <summary> Fully qualified enumeration for Alarm Type. </summary>
        public string Type { get; set; }

        /// <summary> Alarm priority </summary>
        public int Priority { get; set; }

        /// <summary> Fully qualified enumeration for Alarm Category. </summary>
        public string Category { get; set; }

        /// <summary> Link to annotations </summary>
        public string AnnotationsUrl { get; set; }

        /// <summary> Alarm Annotation Count </summary>
        public int AnnotationCount { get; set; }

        /// <summary> URI that points back to this resource </summary>
        public string Self { get; set; }

        /// <summary> Alarm trigger value details </summary>
        public TriggerValue TriggerValue { get; set; }

        /// <summary> Alarm description </summary>
        public string Description { get; set; }



        /// <summary> Returns a value indicating whether this instance has values equal to a specified object. </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is ActivityAlarm activityAlarm)
            {
                var o = activityAlarm;
                // Compare each properties one by one for better performance
                return this.Message == o.Message && this.IsAckRequired == o.IsAckRequired && this.Type == o.Type
                    && this.Priority == o.Priority && this.Category == o.Category
                    && this.AnnotationsUrl == o.AnnotationsUrl && this.AnnotationCount == o.AnnotationCount && this.Self == o.Self
                    && this.TriggerValue == o.TriggerValue && this.Description == o.Description;
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            // Calculate hash on each properties one by one
            if (Message != null)
                code = (code * 7) + Message.GetHashCode();
            if (this.IsAckRequired != null)
                code = (code * 7) + IsAckRequired.GetHashCode();
            if (this.Type != null)
                code = (code * 7) + Type.GetHashCode();
            if (this.Priority != null)
                code = (code * 7) + Priority.GetHashCode();
            if (this.Category != null)
                code = (code * 7) + Category.GetHashCode();
            if (this.AnnotationsUrl != null)
                code = (code * 7) + AnnotationsUrl.GetHashCode();
            if (this.AnnotationCount != null)
                code = (code * 7) + AnnotationCount.GetHashCode();
            if (this.Self != null)
                code = (code * 7) + Self.GetHashCode();
            if (this.TriggerValue != null)
                code = (code * 7) + TriggerValue.GetHashCode();
            if (this.Description != null)
                code = (code * 7) + Description.GetHashCode();
            return code;
        }

        /// <summary> Return a pretty JSON string of the current object. </summary>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
