using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Enumeration of possible Class Levels for an Audit.
    /// </summary>
    /// <remarks>
    /// The actual values sent to the server are specified in the description.
    /// </remarks>
    [Flags]
    public enum ClassLevelsEnum
    {
        /// <summary>
        /// User action on Audit.
        /// </summary>
        [Description("1")]
        UserAction = 1,

        /// <summary>
        /// Critical system event.
        /// </summary>
        [Description("2")]
        CriticalSystemEvent = 2,

        /// <summary>
        /// Application type.
        /// </summary>
        [Description("3")]
        Application = 4,

        /// <summary>
        /// Non_critical system event.
        /// </summary>
        [Description("4")]
        NonCriticalSystemEvent = 8,

        /// <summary>
        /// Diagnostic
        /// </summary>
        [Description("5")]
        Diagnostic = 16
    }
}
