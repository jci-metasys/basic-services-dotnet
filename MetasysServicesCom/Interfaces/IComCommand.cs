using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM Command is a specialized structure that holds information about a Command.
    /// </summary>
    [Guid("CD164EFF-0B18-43FE-9CB8-11253342FD36")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComCommand
    {
        /// <summary>
        /// The translated title of the command.
        /// </summary>
        /// <value>The translated title of the command or the default en-US version.</value>
        string Title { set; get; }

        /// <summary>
        /// The title enumeration key of the command.
        /// </summary>
        /// <value>An enumeration key from the commandIdEnumSet or the default en-US title if not found .</value>
        string TitleEnumerationKey { set; get; }

        /// <summary>
        /// The command id used to send command requests.
        /// </summary>
        string CommandId { set; get; }

        /// <summary>
        /// The list of values that can be modified by the command.
        /// </summary>
        /// <value>A list of Items or null if the command does not accept any parameter values.</value>
        object Items { set; get; }
    }
}
