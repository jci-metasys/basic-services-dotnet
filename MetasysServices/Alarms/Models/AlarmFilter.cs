using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Filters to get alarms
    /// </summary>
    public class AlarmFilter : IFilterAlarm
    {

        /// <summary>
        /// Earliest start time ISO8601 string
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// Latest end time ISO8601 string
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// The inclusive priority range, from 0 to 255, of the alarm.
        /// </summary>
        public string PriorityRange { get; set; }

        /// <summary>
        /// The type of the requested alarms.
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// The flag to exclude pending alarms Default: false.
        /// </summary>
        public bool? ExcludePending { get; set; }

        /// <summary>
        /// The flag to exclude acknowledged alarms Default: false.
        /// </summary>
        public bool? ExcludeAcknowledged { get; set; }

        /// <summary>
        /// The flag to exclude discarded alarms Default: false.
        /// </summary>
        public bool? ExcludeDiscarded { get; set; }

        /// <summary>
        /// The attribute of the requested alarms.
        /// </summary>
        public int? Attribute { get; set; }

        /// <summary>
        /// The system category of the requested alarms.
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// The page number of items to return Default: 1.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// The maximum number of items to return in the response. 
        /// Valid range is 1-10,000. Default: 100
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// The criteria to use when sorting results
        /// Accepted Values: itemReference, priority, creationTime
        /// </summary>
        public string Sort { get; set; }
    }
}