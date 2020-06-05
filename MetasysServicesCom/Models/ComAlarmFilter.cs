using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Filters to get alarms
    /// </summary>
    [Guid("129059db-8a39-4c94-bc6a-86c0975e72c9")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComAlarmFilter : IComFilterAlarm
    {
        /// <inheritdoc />
        public string StartTime { get; set; }

        /// <inheritdoc />
        public string EndTime { get; set; }

        /// <inheritdoc />
        public string PriorityRange { get; set; }

        /// <inheritdoc />
        public string Type { get; set; }

        /// <inheritdoc />
        public bool ExcludePending { get; set; }

        /// <inheritdoc />
        public bool ExcludeAcknowledged { get; set; }

        /// <inheritdoc />
        public bool ExcludeDiscarded { get; set; }

        /// <inheritdoc />
        public string Attribute { get; set; }

        /// <inheritdoc />
        public string Category { get; set; }

        /// <inheritdoc />
        public string Page { get; set; }

        /// <inheritdoc />
        public string PageSize { get; set; }

        /// <inheritdoc />
        public string Sort { get; set; }
    }
}