using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// A measurement expressed in terms of value and unit.
    /// </summary>
    public class Measurement
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
    }
}
