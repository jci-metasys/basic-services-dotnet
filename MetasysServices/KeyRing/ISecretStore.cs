using System.Runtime.InteropServices;
using System.Security;

namespace JohnsonControls.Metasys.BasicServices;

public interface ISecretStore
{
    void AddPassword(string server, string username, SecureString password);
    void AddOrReplacePassword(string server, string username, SecureString password);

    bool TryGetPassword(string server, string username, out SecureString password);
}
