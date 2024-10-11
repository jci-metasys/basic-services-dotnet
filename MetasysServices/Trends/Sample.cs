using Newtonsoft.Json;
using System;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// DTO for Sample
    /// </summary>
    public class Sample
    {
        /// <summary>
        /// Value of the Sample.
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// Unit of measurement of the Sample.
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// Timestamp of when the sample was recorded.
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// The sample is reliable if true.
        /// </summary>
        public bool IsReliable { get; set; }

        /// <summary>
        /// Returns a value indicating whither this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
            code = (code * 7) + IsReliable.GetHashCode();
            if (this.Unit != null)
                code = (code * 7) + Unit.GetHashCode();
            if (this.Timestamp != null)
                code = (code * 7) + Timestamp.GetHashCode();
            code = (code * 7) + Value.GetHashCode();
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
