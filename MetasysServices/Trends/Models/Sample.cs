using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// DTO for Sample
    /// </summary>
    public class Sample
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsReliable { get; set; }

        /// Returns a value indicating whither this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Sample)
            {
                var o = (Sample)obj;
                // Compare each properties one by one for better performance
                return this.Value == o.Value && this.Unit == o.Unit && this.Timestamp == o.Timestamp && this.IsReliable == o.IsReliable
                ;
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            // Calculate hash on each properties one by one
            code = (code * 7) + this.Value.GetHashCode();
            if (IsReliable != null)
                code = (code * 7) + IsReliable.GetHashCode();
            if (this.Unit != null)
                code = (code * 7) + Unit.GetHashCode();
            if (this.Timestamp != null)
                code = (code * 7) + Timestamp.GetHashCode();
            if (this.Value != null)
                code = (code * 7) + Value.GetHashCode();           
            return code;
        }
    }
}
