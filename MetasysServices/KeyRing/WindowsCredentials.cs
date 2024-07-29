using System.Runtime.InteropServices;
using System.Security;

namespace JohnsonControls.Metasys.BasicServices
{


    public class WindowsCredentials : ISecretStore
    {
        public void AddOrReplacePassword(string server, string username, SecureString password)
        {
            throw new System.NotImplementedException();
        }

        public void AddPassword(string server, string username, SecureString password)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetPassword(string server, string username, out SecureString password)
        {
            throw new System.NotImplementedException();
        }
    }

}
