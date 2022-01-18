using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// A Trigger Object (specifically for Alarms).
    /// </summary>
    public class TriggerValue
    {
        /// <summary>
        /// The value of measurement.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Route to the endpoind for the current unit enumset.
        /// </summary>
        /// <remarks> This is available only in Metasys API v2 and v1. </remarks>
        public string UnitsUrl { get; set; }

        /// <summary>
        /// Fully qualified enumeration value for the unit.
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string Units { get; set; }

        /// <summary>
        /// Item.
        /// </summary>
        /// <remarks> This is available since Metasys API v4. </remarks>
        public string item { get; set; }

        /// <summary>
        /// Schema.
        /// </summary>
        /// <remarks> This is available since Metasys API v4. </remarks>
        public Schema schema { get; set; }

        /// <summary>
        /// Returns a value indicating whether this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Measurement)
            {
                var o = (Measurement)obj;
                // Compare each properties one by one for better performance
                return this.Value == o.Value && this.UnitsUrl == o.UnitsUrl && this.Units == o.Units;
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            // Calculate hash on each properties one by one
            code = (code * 7) + Value.GetHashCode();
            if (UnitsUrl != null)
                code = (code * 7) + UnitsUrl.GetHashCode();
            if (this.Units != null)
                code = (code * 7) + Units.GetHashCode();
            return code;
        }

        /// <summary></summary>
        public class Schema
        {
            /// <summary></summary>
            public string type { get; set; }
            /// <summary></summary>
            public string metasysType { get; set; }
            /// <summary></summary>
            public SchemaUnits units { get; set; }
        }
        /// <summary></summary>
        public class SchemaUnits
        {
            /// <summary></summary>
            public string id { get; set; }
            /// <summary></summary>
            public string title { get; set; }
        }

    }
}
