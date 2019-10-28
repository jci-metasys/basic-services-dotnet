using JohnsonControls.Metasys.ComServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices.Interfaces
{
    [ComVisible(true)]
    [Guid("76d5a2df-8e15-4230-924c-2b8556b2d8e5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
     public interface IComMetasysObject
    {
         string ItemReference {  set; get; }

         string Id {  set; get; }

         string Name {  set; get; }

         string Description {  set; get; }

         ComMetasysObject[] Children {  set; get; }

        // The number of children, -1 if there is no children data
         int ChildrenCount {  set; get; }

    }
}
