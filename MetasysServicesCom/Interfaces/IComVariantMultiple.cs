using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{

    /// <summary>
    /// A structure for grouping Variant values with the same id.
    /// </summary>
    [ComVisible(true)]
    [Guid("b5e6f102-c95c-484c-857f-6507c604c27e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComVariantMultiple
    {
        /// <summary>The object id.</summary>
        string Id { set; get; }

        /// <summary>The list of Variants. </summary>
        object Values { set; get; } // Note: need a generic object as return type in order to map correctly to VBA type array (can't assign to array error)
    }
}
