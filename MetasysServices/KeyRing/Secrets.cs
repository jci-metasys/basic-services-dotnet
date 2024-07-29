using System.Runtime.InteropServices;
using System.Security;

namespace JohnsonControls.Metasys.BasicServices
{

    public class SecretStore
    {
        static SecretStore()
        {
            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                secretStore = new MacSecretStore();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                secretStore = new LinuxKeyring();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                secretStore = new WindowsCredentials();
            }
            else
            {
                secretStore = new DummyStore();
            }
        }

        static readonly ISecretStore secretStore;
        public static void AddOrReplacePassword(string server, string username, SecureString password)
        {
            secretStore.AddOrReplacePassword(server, username, password);
        }

        public static void AddPassword(string server, string username, SecureString password)
        {
            secretStore.AddPassword(server, username, password);
        }

        public static bool TryGetPassword(string server, string username, out SecureString password)
        {
            return secretStore.TryGetPassword(server, username, out password);
        }
    }

}
