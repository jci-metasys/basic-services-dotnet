using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provides attribute for trendISampleTrendFilter.
    /// </summary>
    public interface ISampleTrendFilter
    {
        /// <summary>
        /// Earliest start time ISO8601 
        /// </summary>
        DateTime StartTime { get; set; }

        /// <summary>
        /// Latest end time ISO8601
        /// </summary>
        DateTime EndTime { get; set; }

        /// <summary>
        /// The inclusive priority range, from 0 to 255, of the trendable object.
        /// </summary>
        string PriorityRange { get; set; }

        /// <summary>
        /// The type of the requested object.
        /// </summary>
        int? Type { get; set; }

        /// <summary>
        /// The flag to exclude pending object. Default: false.
        /// </summary>
        bool? ExcludePending { get; set; }

        /// <summary>
        /// The flag to exclude acknowledged object. Default: false.
        /// </summary>
        bool? ExcludeAcknowledged { get; set; }

        /// <summary>
        /// The flag to exclude discarded object. Default: false.
        /// </summary>
        bool? ExcludeDiscarded { get; set; }

        /// <summary>
        /// The attribute of the requested trendable object.
        /// </summary>
        int? Attribute { get; set; }

        /// <summary>
        /// The system category of the requested trendable object.
        /// </summary>
        int? Category { get; set; }

        /// <summary>
        /// The page number of items to return Default: 1.
        /// </summary>
        int? Page { get; set; }

        /// <summary>
        /// The maximum number of items to return in the response. 
        /// Valid range is 1-10,000. Default: 100
        /// </summary>
        int? PageSize { get; set; }

        /// <summary>
        /// The criteria to use when sorting results
        /// Accepted Values: itemReference, priority, creationTime
        /// </summary>
        string Sort { get; set; }
    }
}
