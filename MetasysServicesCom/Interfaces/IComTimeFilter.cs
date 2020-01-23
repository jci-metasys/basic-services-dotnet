using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices.Interfaces
{
    /// <summary>
    /// Temporal filter for a timeline based request.
    /// </summary>
    [Guid("6389A85D-0390-44C3-A612-0FB45B3276FB")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComTimeFilter
    {
        /// <summary>
        /// Earliest start time.
        /// </summary>
        DateTime StartTime { get; set; }

        /// <summary>
        /// Latest end time.
        /// </summary>
        DateTime EndTime { get; set; }
    }
}
