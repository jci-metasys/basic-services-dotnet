using System;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// An exception that is thrown when something went wrong while reading a target from Credential Manger.
    /// </summary>
    [System.Serializable]
    public class CredManException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the CredentialManagerException with a predefined message given the target.
        /// </summary>
        /// <param name="target"></param>
        public CredManException(string target) : base($"Error while accessing Credential Manager target \"{target}\".")
        {
        }
    }
}
