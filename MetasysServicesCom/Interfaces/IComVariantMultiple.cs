using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{

    /// <summary>
    /// A structure for grouping Variant values with the same id.
    /// </summary>
    [ComVisible(true)]
    [Guid("3b7dbcd6-f507-4cbe-bd0c-ecd418bed227")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComVariantMultiple
    {
        /// <summary>The object id.</summary>
        string Id { set; get; }
        /// <summary>The list of Variants. </summary>
        object Variants { set; get; } // Note: need a generic object as return type in order to map correctly to VBA type array (can't assign to array error)
    }
}
