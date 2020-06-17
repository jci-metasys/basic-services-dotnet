using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Enumeration of possible Action Type for an Audit.
    /// </summary>
    [Flags]
    public enum ActionTypeEnum
    {
        Write = 0,
        Command = 1,
        Create = 2,
        Delete = 3,
        Error = 4,
        Subsystem = 5
    }
}
