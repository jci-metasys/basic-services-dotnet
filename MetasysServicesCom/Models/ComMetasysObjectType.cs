using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that holds information about a Metasys spaces type object.
    /// </summary>
    [ComVisible(true)]
    [Guid("8EEACB76-BA34-4217-9DE5-FE623AA90082")]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComMetasysObjectType : IComMetasysObjectType
    {
        /// <inheritdoc/>
        public string Description { get; set; }

        /// <inheritdoc/>
        public string DescriptionEnumerationKey { get; set; }

        /// <inheritdoc/>
        public int Id { get; set; }
    }
}
