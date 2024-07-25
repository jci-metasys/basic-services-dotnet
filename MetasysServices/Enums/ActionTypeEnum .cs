using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
        /// <summary>
        /// Action: Write
        /// </summary>
        [Description("0")]
        Write = 1,

        /// <summary>
        /// Action: Command
        /// </summary>
        [Description("1")]
        Command = 2,

        /// <summary>
        /// Action: Create
        /// </summary>
        [Description("2")]
        Create = 4,

        /// <summary>
        /// Action: Delete
        /// </summary>
        [Description("3")]
        Delete = 8,

        /// <summary>
        /// Action: Error
        /// </summary>
        [Description("4")]
        Error = 16,

        /// <summary>
        /// Action: Subsystem
        /// </summary>
        [Description("5")]
        Subsystem = 32
    }
}
