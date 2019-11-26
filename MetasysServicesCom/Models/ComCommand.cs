using JohnsonControls.Metasys.ComServices.Interfaces;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices.Models
{
    /// <summary>
    /// COM Command is a specialized structure that holds information about a Command.
    /// </summary>
    [Guid("792EA175-CBA5-4A29-BE9B-9D295BEDE8DC")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComCommand : IComCommand
    {
        /// <summary>
        /// The translated title of the command.
        /// </summary>
        /// <value>The translated title of the command or the default en-US version.</value>
        public string Title { set; get; }

        /// <summary>
        /// The title enumeration key of the command.
        /// </summary>
        /// <value>An enumeration key from the commandIdEnumSet or the default en-US title if not found .</value>
        public string TitleEnumerationKey { set; get; }

        /// <summary>
        /// The command id used to send command requests.
        /// </summary>
        public string CommandId { set; get; }

        /// <summary>
        /// The list of values that can be modified by the command.
        /// </summary>
        /// <value>A list of Items or null if the command does not accept any parameter values.</value>
        public object Items { set; get; }
    }
}
