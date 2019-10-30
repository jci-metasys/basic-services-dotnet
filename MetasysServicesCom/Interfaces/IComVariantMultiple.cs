using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{

    /// <summary>
    /// A structure for grouping Variant values with the same id.
    /// </summary>
    ///   [ComVisible(true)]
    [Guid("3b7dbcd6-f507-4cbe-bd0c-ecd418bed227")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComVariantMultiple
    {
        /// <summary>The object id.</summary>
        string Id { set; get; }
        /// <summary>The list of Variants. </summary>
        IComVariant[] Variants { set; get; }
    }
}
