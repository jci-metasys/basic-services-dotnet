using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Filters to get alarms
    /// </summary>
    [Guid("44E4F2A0-0962-4D4A-9A09-29C0A8E56FDC")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComPagedResult : IComPagedResult<object>
    {
        /// <summary>
        /// Total alarms count
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Next page link
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// previous page link
        /// </summary>
        public string Previous { get; set; }

        /// <summary>
        /// Pages result of alarm items
        /// </summary>
        public object Items { get; set; }

        /// <summary>
        /// Route information for self
        /// </summary>
        public string Self { get; set; }

    }
}
