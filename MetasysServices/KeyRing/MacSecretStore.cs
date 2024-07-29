using System.Runtime.InteropServices;
using System.Security;

namespace JohnsonControls.Metasys.BasicServices;

public class MacSecretStore : ISecretStore
{
    public void AddOrReplacePassword(string server, string username, SecureString password)
    {
        Keychain.AddOrReplacePassword(server, username, password);
    }



    public void AddPassword(string server, string username, SecureString password)
    {
        Keychain.AddPassword(server, username, password);
    }

    public bool TryGetPassword(string server, string username, out SecureString password)
    {
        return Keychain.TryGetPassword(server, username, out password);
    }
}
