using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    public class AuditData
    {
        /// <summary>
        /// Route to the endpoint for the current unit enumset.
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string Unit { get; set; }

        /// <summary>
        /// Route to the endpoint for the current precision enumset.
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string Precision { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Audit type route
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string Type { get; set; }

        /// <summary>
        /// Returns a value indicating whether this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is AuditData)
            {
                var o = (AuditData)obj;
                // Compare each properties one by one for better performance
                return this.Unit == o.Unit
                    && this.Precision == o.Precision
                    && this.Value == o.Value
                    && this.Type == o.Type;
            }
            return false;
        }

    }
}
