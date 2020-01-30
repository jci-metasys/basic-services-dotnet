using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Filters to get alarms
    /// </summary>
    [Guid("129059db-8a39-4c94-bc6a-86c0975e72c9")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComAlarmFilter : IComFilterAlarm
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
        public string Type { get; set; }

        /// <summary>
        /// The flag to exclude pending alarms Default: false.
        /// </summary>
        public bool ExcludePending { get; set; }

        /// <summary>
        /// The flag to exclude acknowledged alarms Default: false.
        /// </summary>
        public bool ExcludeAcknowledged { get; set; }

        /// <summary>
        /// The flag to exclude discarded alarms Default: false.
        /// </summary>
        public bool ExcludeDiscarded { get; set; }

        /// <summary>
        /// The attribute of the requested alarms.
        /// </summary>
        public string Attribute { get; set; }

        /// <summary>
        /// The system category of the requested alarms.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The page number of items to return Default: 1.
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The maximum number of items to return in the response. 
        /// Valid range is 1-10,000. Default: 100
        /// </summary>
        public string PageSize { get; set; }

        /// <summary>
        /// The criteria to use when sorting results
        /// Accepted Values: itemReference, priority, creationTime
        /// </summary>
        public string Sort { get; set; }
    }
}