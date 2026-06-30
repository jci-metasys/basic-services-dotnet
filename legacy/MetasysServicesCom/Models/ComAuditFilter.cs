using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Filters to get Audits
    /// </summary>
    [Guid("02E91329-DA34-446F-9D9C-396D805C6966")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComAuditFilter : IComAuditFilter
    {
        /// <inheritdoc/>
        public string StartTime { get; set; }

        /// <inheritdoc/>
        public string EndTime { get; set; }

        /// <inheritdoc/>
        public string Page { get; set; }

        /// <inheritdoc/>
        public string PageSize { get; set; }

        /// <inheritdoc/>
        public string Sort { get; set; }

        /// <inheritdoc/>
        public string OriginApplications { get; set; }

        /// <inheritdoc/>
        public string ClassLevels { get; set; }

        /// <inheritdoc/>
        public string ActionTypes { get; set; }

        /// <inheritdoc/>
        public bool ExcludeDiscarded { get; set; }
    }
}
