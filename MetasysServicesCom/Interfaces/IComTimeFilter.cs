using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Temporal filter for a timeline based request.
    /// </summary>
    [Guid("400c17ea-a9e8-47be-bd65-ee31a512db9b")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComTimeFilter
    {
        /// <summary>
        /// Earliest start time ISO8601 string
        /// </summary>
        string StartTime { get; set; }

        /// <summary>
        /// Latest end time ISO8601 string
        /// </summary>
        string EndTime { get; set; }
        /// <summary>
        /// The page number of items to return Default: 1.
        /// </summary>
        string Page { get; set; }

        /// <summary>
        /// The maximum number of items to return in the response. 
        /// Valid range is 1-10,000. Default: 100
        /// </summary>
        string PageSize { get; set; }

        /// <summary>
        /// The criteria to use when sorting results
        /// Accepted Values: itemReference, priority, creationTime
        /// </summary>
        string Sort { get; set; }
    }
}
