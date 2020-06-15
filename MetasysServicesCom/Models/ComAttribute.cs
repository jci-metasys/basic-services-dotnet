using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Filters to get alarms
    /// </summary>
    [Guid("E4E3279C-2041-4761-B065-CFFFA362B0DE")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComAttribute : IComAttribute
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Description { get; set; }
    }
}
