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
        /// <remarks> This is available only in Metasys API v2 and v1. </remarks>
        public string UnitsUrl { get; set; }
        /// <summary>
        /// Route to the endpoint for the current unit enumset.
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string Unit { get; set; }
        /// <summary>
        /// Route to the endpoint for the current precision enumset.
        /// </summary>
        /// <remarks> This is available only in Metasys API v2 and v1. </remarks>
        public string PrecisionUrl { get; set; }
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
        /// <remarks> This is available only in Metasys API v2 and v1. </remarks>
        public string TypeUrl { get; set; }
        /// <summary>
        /// Audit type route
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string Type{ get; set; }
    }
}
