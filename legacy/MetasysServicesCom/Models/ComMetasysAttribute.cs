using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Represents a COM Metasys Attribute
    /// </summary>
    [Guid("c9f668f5-08ab-4454-b43f-5bcc1f001962")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComMetasysAttribute : IComMetasysAttribute
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Description { get; set; }
    }
}
