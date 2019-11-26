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
        /// <summary>
        /// The description of the Metasys space type object.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The enumeration key of the description.
        /// </summary>
        public string DescriptionEnumerationKey { get; set; }

        /// <summary>
        /// The id of the object.
        /// </summary>
        public int Id { get; set; }
    }
}
