using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM Command is a specialized structure that holds information about a Command.
    /// </summary>
    [Guid("792EA175-CBA5-4A29-BE9B-9D295BEDE8DC")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComCommand : IComCommand
    {
        /// <inheritdoc/>
        public string Title { set; get; }

        /// <inheritdoc/>
        public string TitleEnumerationKey { set; get; }

        /// <inheritdoc/>
        public string CommandId { set; get; }

        /// <inheritdoc/>
        public object Items { set; get; }
    }
}
