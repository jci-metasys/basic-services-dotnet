using Newtonsoft.Json;
using System;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Annotaion for an alarm.
    /// </summary>
    public class AlarmAnnotation : MetasysAnnotation
    {
        /// <summary>
        /// URL of the audit related to the annotation.
        /// </summary>
        public string AlarmUrl { get; set; }

        /// <summary>
        /// Returns a value indicating whether this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is AlarmAnnotation)
            {
                var o = (AlarmAnnotation)obj;
                // Compare each properties one by one for better performance
                return this.Text == o.Text && this.User == o.User && this.Action == o.Action && this.AlarmUrl == o.AlarmUrl && this.CreationTime == o.CreationTime;
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            // Calculate hash on each properties one by one
            if (Text != null)
                code = (code * 7) + Text.GetHashCode();
            if (User != null)
                code = (code * 7) + User.GetHashCode();
            if (this.Action != null)
                code = (code * 7) + this.Action.GetHashCode();
            if (this.AlarmUrl != null)
                code = (code * 7) + AlarmUrl.GetHashCode();
            if (this.CreationTime != null)
                code = (code * 7) + CreationTime.GetHashCode();
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