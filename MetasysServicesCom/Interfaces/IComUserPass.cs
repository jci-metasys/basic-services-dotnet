using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM Credentials DTO Interface
    /// </summary>
    [Guid("e27dbdfb-3e70-4a68-b4a9-0ca67019f3b9")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]    
    public interface IComUserPass
    {
        /// <summary>
        /// Username's credentials
        /// </summary>
        string Username { get;  set; }
        /// <summary>
        /// Password's credentials
        /// </summary>
        string Password { get; set; }
    }
}
