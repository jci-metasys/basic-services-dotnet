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
        /// <inheritdoc/>
        public int Total { get; set; }
        /// <inheritdoc/>
        public object Items { get; set; }
        /// <inheritdoc/>
        public int CurrentPage { get; set; }
        /// <inheritdoc/>
        public int PageCount { get; set; }
        /// <inheritdoc/>
        public int PageSize { get; set; }

    }
}
