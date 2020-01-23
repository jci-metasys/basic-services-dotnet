using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that gives trend information of an object.
    /// </summary>
    [ComVisible(true)]
    [Guid("1D3DD3F5-67EF-44E9-AD75-0EB68592A26E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]    
    public interface IComSampleTrendFilter
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
        /// The inclusive priority range, from 0 to 255, of the trendable object.
        /// </summary>
        string PriorityRange { get; set; }

        /// <summary>
        /// The type of the requested object.
        /// </summary>
        int? Type { get; set; }

        /// <summary>
        /// The flag to exclude pending objects. Default: false.
        /// </summary>
        bool? ExcludePending { get; set; }

        /// <summary>
        /// The flag to exclude acknowledged objects. Default: false.
        /// </summary>
        bool? ExcludeAcknowledged { get; set; }

        /// <summary>
        /// The flag to exclude discarded objects. Default: false.
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
