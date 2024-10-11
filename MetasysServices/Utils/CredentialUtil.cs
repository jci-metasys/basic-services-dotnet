using CredentialManagement;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace JohnsonControls.Metasys.BasicServices.Utils
{
    /// <summary>
    /// Utility that allows to read Credential Manager targets.
    /// </summary>
    public static class CredentialUtil
    {
        /// <summary>
        /// Retrieve the credentials for the given target.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static UserPass GetCredential(string target)
        {
            var cm = new Credential { Target = target };
            if (!cm.Load())
            {
                throw new CredManException(target);
            }
            // UserPass is just a class with two string properties for user and pass
            return new UserPass(cm.Username, cm.Password);
        }

        /// <summary>
        /// Set the credentials for the given target.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="persistenceType"></param>
        /// <returns></returns>
        public static bool SetCredentials(
             string target, string username, string password, PersistanceType persistenceType)
        {
            return new Credential
            {
                Target = target,
                Username = username,
                Password = password,
                PersistanceType = persistenceType
            }.Save();
        }

        /// <summary>
        /// Remove credentials for the given target.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool RemoveCredentials(string target)
        {
            return new Credential { Target = target }.Delete();
        }

        /// <summary>
        /// Returns the plain text of a secure string.
        /// </summary>
        /// <param name="secstrPassword"></param>
        /// <returns></returns>
        public static string convertToUnSecureString(SecureString secstrPassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secstrPassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
