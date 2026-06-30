using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM Credentials DTO Class
    /// </summary>
    [Guid("c827405c-beac-435d-a842-8419cec5d5ac")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComUserPass : IComUserPass
    {
        /// <inheritdoc/>
        public string Username { get; set; }

        /// <inheritdoc/>
        public string Password { get; set; }
    }
}
