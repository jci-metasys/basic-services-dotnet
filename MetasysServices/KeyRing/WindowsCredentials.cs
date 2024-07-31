using System.Runtime.InteropServices;
using System.Security;

namespace JohnsonControls.Metasys.BasicServices
{


    public class WindowsCredentials : ISecretStore
    {
        public void AddOrReplacePassword(string hostName, string userName, SecureString password)
        {
            throw new System.NotImplementedException();
        }

        public void AddPassword(string hostName, string userName, SecureString password)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetPassword(string hostName, string userName, out SecureString password)
        {
            throw new System.NotImplementedException();
        }
    }

}
