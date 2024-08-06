using System.Security;
#nullable enable

namespace JohnsonControls.Metasys.BasicServices;


/// <summary>
/// An implementation of <see cref="ICredentialManager"/> that doesn't do anything
/// </summary>
/// <remarks>
/// This is the instance of ISecretStore used by <see cref="SecretStore"/> if
/// no suitable functional instance can be found.
/// </remarks>
class DummyStore : ICredentialManager
{
    public override void AddOrReplacePassword(string hostName, string userName, SecureString password)
    {
    }


    public override void DeletePassword(string hostName, string userName)
    {
    }

    public override bool TryGetCredentials(string hostName, out string userName, out SecureString password)
    {
        userName = string.Empty;
        password = new();
        return false;
    }

    public override bool TryGetPassword(string hostName, string userName, out SecureString password)
    {
        password = new();
        return false;
    }
}
