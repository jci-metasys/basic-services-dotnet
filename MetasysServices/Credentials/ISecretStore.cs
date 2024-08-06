using System.Security;
#nullable enable
namespace JohnsonControls.Metasys.BasicServices;

/// <summary>
/// Represents a secret store for passwords
/// </summary>
public abstract class ICredentialManager
{

    /// <summary>
    /// Prefix hostname before storing to avoid collisions and
    /// more importantly to prevent this tool from being able to lookup
    /// credentials that weren't entered by it.
    /// </summary>
    /// <param name="hostName"></param>
    /// <returns></returns>
    protected static string PrefixHostName(string hostName)
    {
        // return $"Metasys:{hostName}";
        return hostName;
    }


    /// <summary>
    /// Adds or replaces a password in the secret store
    /// </summary>
    /// <remarks>
    /// The password will be recorded as being for a specific host and a specific user
    /// The password can later be retrieved by calling <see cref="TryGetPassword(string, string, out SecureString)"/>
    /// passing in the same hostName and userName that was used to save the password.
    /// </remarks>
    /// <param name="hostName"></param>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    public abstract void AddOrReplacePassword(string hostName, string userName, SecureString password);

    /// <summary>
    /// Attempts to retrieve a stored password
    /// </summary>
    /// <param name="hostName"></param>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns><b>true</b> if the password for the user on the specified host exists; <b>false</b> otherwise.</returns>
    public abstract bool TryGetPassword(string hostName, string userName, out SecureString password);


    /// <summary>
    /// Attempts to retrieve username and password for specified host.
    /// </summary>
    /// <remarks>
    /// If more than one entry in the credential manager matches the host name then the first one found is returned.
    /// To avoid this ambiguity use <see cref="TryGetPassword(string, string, out SecureString)"/> instead.
    /// </remarks>
    /// <param name="hostName"></param>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public abstract bool TryGetCredentials(string hostName, out string userName, out SecureString password);

    /// <summary>
    /// Deletes the password with specified hostName and userName if it exists.
    /// </summary>
    /// <remarks>This method does nothing if the password doesn't exist</remarks>
    /// <param name="hostName"></param>
    /// <param name="userName"></param>
    public abstract void DeletePassword(string hostName, string userName);

}
