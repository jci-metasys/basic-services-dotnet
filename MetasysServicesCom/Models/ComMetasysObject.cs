using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM MetasysObject is a specialized structure that holds information about a Metasys object.
    /// </summary>
    [Guid("7416d1c5-d8ce-4829-878c-947595444265")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComMetasysObject : IComMetasysObject
    { // Note: in order to correctly work with VBA registered types, class need to implement a defined interface. Neither inheritance nor encapsulation will work when the defined class is in another assembly

        /// <inheritdoc/>
        public string ItemReference { set; get; }

        /// <inheritdoc/>
        public string Id { set; get; }

        /// <inheritdoc/>
        public string Name { set; get; }

        /// <inheritdoc/>
        public string Description { set; get; }

        /// <inheritdoc/>
        public object Children { set; get; } // Note: need a generic object as return type in order to map correctly to VBA type array (can't assign to array error)

        /// <inheritdoc/>
        public int ChildrenCount { set; get; }

    }
}
