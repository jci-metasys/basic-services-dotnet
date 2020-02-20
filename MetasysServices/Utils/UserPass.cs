using System.Linq;
using System.Security;

namespace JohnsonControls.Metasys.BasicServices.Utils
{
    /// <summary>
    /// Credentials DTO Class
    /// </summary>
    public class UserPass
    {
        public SecureString Username { get; private set; }
        public SecureString Password { get; private set; }
        public UserPass(string user, string psw)
        {
            Username = new SecureString();
            Password = new SecureString();
            user.ToCharArray().ToList().ForEach(c => Username.AppendChar(c));
            psw.ToCharArray().ToList().ForEach(c => Password.AppendChar(c));           
        }
    }
}