using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that holds information about the session access token and expiration in UTC time.
    /// </summary>
    [Guid("129059db-8a39-4b94-bc6a-86c0975e72c9")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComAccessToken : IComAccessToken
    {
        /// <inheritdoc/>
        public string Token { set; get; }

        /// <inheritdoc/>
        public DateTime Expires { set; get; }
    }
}
