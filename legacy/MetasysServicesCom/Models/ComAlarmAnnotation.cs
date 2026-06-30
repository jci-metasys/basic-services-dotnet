using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices.Models
{
    /// <summary>
    /// Filters to get alarms
    /// </summary>
    [Guid("BDFAB9D4-9249-44DF-9837-188FF21C5CF6")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]

    public class ComAlarmAnnotation : IComAlarmAnnotation
    {
        /// <summary>
        /// Text of the annotation.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// User who made the annotation.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Creation time of the annotation.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Action of the annotation.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// URL of the audit related to the annotation.
        /// </summary>
        public string AlarmUrl { get; set; }

    }
}
