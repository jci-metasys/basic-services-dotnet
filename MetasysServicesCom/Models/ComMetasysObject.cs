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
    public class ComMetasysObject:IComMetasysObject
    { // Note: in order to correctly work with VBA registered types, class need to implement a defined interface. Neither inheritance nor encapsulation will work when the defined class is in another assembly

        /// <summary>The item reference of the Metasys object.</summary>
        public string ItemReference { set; get; }

        /// <summary>The id of the Metasys object.</summary>
        public string Id { set; get; }

        /// <summary>The name of the Metasys object.</summary>
        public string Name { set; get; }

        /// <summary>The description of the Metasys object.</summary>
        public string Description { set; get; }

        /// <summary>The direct children objects of the Metasys object.</summary>
        public object Children { set; get; } // Note: need a generic object as return type in order to map correctly to VBA type array (can't assign to array error)

        /// <summary>
        /// The number of direct children objects.
        /// </summary>
        /// <value>The number of children or -1 if there is no children data.</value>
        public int ChildrenCount { set; get; }

    }
}
