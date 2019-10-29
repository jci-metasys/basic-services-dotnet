using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    [Guid("7416d1c5-d8ce-4829-878c-947595444265")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComMetasysObject:IComMetasysObject
    { // Note: in order to correctly work with VBA registered types, class need to implement a defined interface. Neither inheritance nor encapsulation will work when the defined class is in another assembly


        public string ItemReference { set; get; }

        public string Id { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public ComMetasysObject[] Children { set; get; }

        // The number of children, -1 if there is no children data
        public int ChildrenCount { set; get; }

    }
}
