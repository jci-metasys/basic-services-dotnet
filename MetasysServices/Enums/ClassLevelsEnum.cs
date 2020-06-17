using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Enumeration of possible Class Levels for an Audit.
    /// </summary>
    [Flags]
    public enum ClassLevelsEnum
    {
        /// <summary>
        /// User action on Audit.
        /// </summary>
        UserAction = 1,

        /// <summary>
        /// Critical system event.
        /// </summary>
        CriticalSystemEvent = 2,

        /// <summary>
        /// Application type.
        /// </summary>
        Application = 3,

        /// <summary>
        /// Non_critical system event.
        /// </summary>
        NonCriticalSystemEvent = 4,

        /// <summary>
        /// Diagnostic
        /// </summary>
        Diagnostic = 5
    }
}
