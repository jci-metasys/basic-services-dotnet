using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Filters to get alarms when using API v2 or v3.
    /// </summary>
    public class AlarmFilter : TimeFilter
    {       
        /// <summary>
        /// The inclusive priority range, from 0 to 255, of the alarm.
        /// </summary>
        public string PriorityRange { get; set; }

        /// <summary>
        /// The type of the requested alarms.
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// The flag to exclude pending alarms. Default: false.
        /// This is considered when using API v2 and v3
        /// </summary>
        public bool? ExcludePending { get; set; }

        /// <summary>
        /// The flag to exclude acknowledged alarms. Default: false.
        /// This is considered when using API v2 and v3
        /// </summary>
        public bool? ExcludeAcknowledged { get; set; }

        /// <summary>
        /// The flag to exclude discarded alarms. Default: false.
        /// This is considered when using API v2 and v3
        /// </summary>
        public bool? ExcludeDiscarded { get; set; }

        /// <summary>
        /// The attribute of the requested alarms.
        /// This is considered when using API v2 and v3
        /// </summary>
        public int? Attribute { get; set; }

        /// <summary>
        /// The system category of the requested alarms.
        /// </summary>
        public int? Category { get; set; }      
    }
}