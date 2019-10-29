using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    [Guid("c810227d-17fa-464e-97cc-868a3257f0de")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class VariantMultiplesContainer:IVariantMultiplesContainer
    { // Note: this structure is needed to correctly retrieve VBA return type, otherwise resulted in a type mismatch array
        public ComVariantMultiple[] Multiples { get; set; }
    }
}
