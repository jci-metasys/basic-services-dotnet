using System.Runtime.InteropServices;
using System.Security;

namespace JohnsonControls.Metasys.BasicServices;

public interface ISecretStore
{
    void AddPassword(string hostName, string userName, SecureString password);
    void AddOrReplacePassword(string hostName, string userName, SecureString password);

    bool TryGetPassword(string hostName, string userName, out SecureString password);
}
