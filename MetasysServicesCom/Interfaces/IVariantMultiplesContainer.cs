using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    [ComVisible(true)]
    [Guid("c5381b08-b32b-42d5-8183-21f2f386b3dd")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IVariantMultiplesContainer
    {
        IComVariantMultiple[] Multiples { get; set; }
    }
}
