using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that holds information about a Metasys spaces type object.
    /// </summary>
    [ComVisible(true)]
    [Guid("6766FB30-77B3-46CA-835C-EEA3563FD5F6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComMetasysObjectType
    {
        /// <summary>The description of the Metasys space type object.</summary>
        string Description { get; set; }

        /// <summary>The enumeration key of the description.</summary>
        string DescriptionEnumerationKey { get; set; }

        /// <summary>The id of the object.</summary>
        int Id { get; set; }
    }
}
