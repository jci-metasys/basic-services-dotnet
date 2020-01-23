using System;
using System.Runtime.InteropServices;
using JohnsonControls.Metasys.ComServices.Interfaces;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Temporal filter for a timeline based request.
    /// </summary>
    [Guid("25128644-B808-42E2-987A-6C41B88C9464")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComTimeFilter : IComTimeFilter
    {
        /// <summary>
        /// Earliest start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Latest end time.
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
