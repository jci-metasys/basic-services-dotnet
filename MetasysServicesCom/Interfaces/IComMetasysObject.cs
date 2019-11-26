using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that holds information about a Metasys object.
    /// </summary>
    [ComVisible(true)]
    [Guid("76d5a2df-8e15-4230-924c-2b8556b2d8e5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComMetasysObject
    {
        /// <summary>The item reference of the Metasys object.</summary>
        string ItemReference { set; get; }

        /// <summary>The id of the Metasys object.</summary>
        string Id { set; get; }

        /// <summary>The name of the Metasys object.</summary>
        string Name { set; get; }

        /// <summary>The description of the Metasys object.</summary>
        string Description { set; get; }

        /// <summary>The direct children objects of the Metasys object.</summary>
        object Children { set; get; }

        /// <summary>
        /// The number of direct children objects.
        /// </summary>
        /// <value>The number of children or -1 if there is no children data.</value>
        // The number of children, -1 if there is no children data
        int ChildrenCount { set; get; }

    }
}
