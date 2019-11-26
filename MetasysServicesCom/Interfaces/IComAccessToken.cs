using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that holds information about the session access token and expiration in UTC time.
    /// </summary>
    [ComVisible(true)]
    [Guid("9bcbc14f-b7a9-45a9-bb1f-cd31d12f214e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComAccessToken
    {
        /// <summary>The session access token for bearer authentication.</summary>
        /// <value>String in the format "Bearer ..."</value>
        string Token { set; get; }

        /// <summary>Expiration date in UTC time.</summary>
        DateTime Expires { set; get; }

    }
}
