using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that holds information about a Metasys Enumerated Value.
    /// </summary>
    [ComVisible(true)]
    [Guid("0C8F92BB-C8DF-4906-9F33-41097E73776A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]

    public interface IComMetasysEnumValue
    {
        /// <summary>
        /// Key that identifies the Enumeration Value.
        /// </summary>
        string Key { set; get; }

        /// <summary>
        /// Name of the Enumeration Value.
        /// </summary>
        string Name { set; get; }

        /// <summary>
        /// Enumeration Value.
        /// </summary>
        int Value { set; get; }
    }
}
