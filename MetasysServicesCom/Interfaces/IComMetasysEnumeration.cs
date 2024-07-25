using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that holds information about a Metasys Enumeration object.
    /// </summary>
    [ComVisible(true)]
    [Guid("54F9AC07-0549-4BC8-8609-E3296F298E51")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]

    public interface IComMetasysEnumeration
    {
        /// <summary>
        /// Key that identifies the Enumeration set.
        /// </summary>
        string Key { set; get; }

        /// <summary>
        /// Name of the Enumeration set.
        /// </summary>
        string Name { set; get; }

        /// <summary>
        /// Specify if the Enumeration is related to a binary object.
        /// </summary>
        bool IsTwoState { set; get; }

        /// <summary>
        /// Specify if the Enumeration is related to a multistate object.
        /// </summary>
        bool IsMultiState { set; get; }

        /// <summary>
        /// Specify the number of states when the Enumeration is related to a multistate object.
        /// </summary>
        int NumberOfStates { set; get; }
    }
}
