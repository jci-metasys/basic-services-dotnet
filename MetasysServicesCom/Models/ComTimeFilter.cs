using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Temporal filter for a timeline based request.
    /// </summary>
    [Guid("c472bbca-d3ce-4307-9bef-bd58795d76ed")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComTimeFilter : IComTimeFilter
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
