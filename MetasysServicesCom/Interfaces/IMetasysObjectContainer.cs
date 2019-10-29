using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    [ComVisible(true)]
    [Guid("ac2a1994-7556-48d5-b5b8-8f65b1b1353c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IMetasysObjectsContainer
    {
        ComMetasysObject[] Objects { get; set; }
    }
}
