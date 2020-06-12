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
        /// <inheritdoc />
        public string StartTime { get; set; }

        /// <inheritdoc />
        public string EndTime { get; set; }
        /// <inheritdoc />
        public string Page { get; set; }

        /// <inheritdoc />
        public string PageSize { get; set; }

        /// <inheritdoc />
        public string Sort { get; set; }
    }
}
