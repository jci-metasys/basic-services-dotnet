using System.Linq;
using System.Security;

namespace JohnsonControls.Metasys.BasicServices.Utils
{
    /// <summary>
    /// Credentials DTO Class
    /// </summary>
    public class UserPass
    {
        /// <summary>
        /// Username's credentials
        /// </summary>
        public SecureString Username { get; private set; }
        /// <summary>
        /// Password's credentials
        /// </summary>
        public SecureString Password { get; private set; }
        /// <summary>
        /// Constructor of Secure Strings given plain text string
        /// </summary>
        /// <param name="user"></param>
        /// <param name="psw"></param>
        public UserPass(string user, string psw)
        {
            Username = new SecureString();
            Password = new SecureString();
            user.ToCharArray().ToList().ForEach(c => Username.AppendChar(c));
            psw.ToCharArray().ToList().ForEach(c => Password.AppendChar(c));           
        }
    }
}