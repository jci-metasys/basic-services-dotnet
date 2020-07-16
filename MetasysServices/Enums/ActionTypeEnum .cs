using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Enumeration of possible Action Type for an Audit.
    /// </summary>
    /// <remarks>
    /// The actual values sent to the server are specified in the description.
    /// </remarks>
    [Flags]
    public enum ActionTypeEnum
    {
        [Description("0")]
        Write = 1,

        [Description("1")]
        Command = 2,

        [Description("2")]
        Create = 4,

        [Description("3")]
        Delete = 8,

        [Description("4")]
        Error = 16,

        [Description("5")]
        Subsystem = 32
    }
}
