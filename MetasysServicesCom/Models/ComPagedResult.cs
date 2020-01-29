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
    public class ComPagedResult : IComPagedResult
    {
        /// <summary>
        /// The total number of elements. 
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// The items of the current page.
        /// </summary>
        public object Items { get; set; }
        /// <summary>
        /// The actual page.
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Total number of pages.
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// Maximum number of elements on a page.
        /// </summary>
        public int PageSize { get; set; }

    }
}
