using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM Credentials DTO Interface
    /// </summary>
    [ComVisible(true)]
    [Guid("e27dbdfb-3e70-4a68-b4a9-0ca67019f3b9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComUserPass
    {
        /// <summary>
        /// Username's credentials
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Password's credentials
        /// </summary>
        string Password { get; set; }
    }
}
