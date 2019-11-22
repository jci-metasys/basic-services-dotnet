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
    [Guid("129059db-8a39-4b94-bc6a-86c0975e72c9")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComAccessToken:IComAccessToken
    {
        /// <summary>The session access token for bearer authentication.</summary>
        /// <value>String in the format "Bearer ..."</value>
        public string Token { set; get; }

        /// <summary>Expiration date in UTC time.</summary>
        public DateTime Expires { set; get; }
    }
}
