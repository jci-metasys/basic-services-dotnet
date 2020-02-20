using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM Credentials DTO Class
    /// </summary>
    [Guid("c827405c-beac-435d-a842-8419cec5d5ac")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]    
    public class ComUserPass:IComUserPass
    {
        /// <summary>
        /// Username's credentials
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password's credentials
        /// </summary>
        public string Password { get; set; }       
    }
}
