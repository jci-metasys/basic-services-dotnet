using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM Command is a specialized structure that gives trend information of an object.
    /// </summary>
    [Guid("46BCBF53-9430-48A9-AF9B-7E1BE272671C")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComSampleTrendFilter : IComSampleTrendFilter
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
        /// The inclusive priority range, from 0 to 255, of the trendable object.
        /// </summary>
        public string PriorityRange { get; set; }

        /// <summary>
        /// The type of the requested object.
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// The flag to exclude pending object. Default: false.
        /// </summary>
        public bool? ExcludePending { get; set; }

        /// <summary>
        /// The flag to exclude acknowledged object. Default: false.
        /// </summary>
        public bool? ExcludeAcknowledged { get; set; }

        /// <summary>
        /// The flag to exclude discarded object. Default: false.
        /// </summary>
        public bool? ExcludeDiscarded { get; set; }

        /// <summary>
        /// The attribute of the requested trendable object.
        /// </summary>
        public int? Attribute { get; set; }

        /// <summary>
        /// The system category of the requested trendable object.
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// The page number of items to return. Default: 1.
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
