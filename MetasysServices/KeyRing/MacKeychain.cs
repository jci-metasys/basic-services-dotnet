using System.Runtime.InteropServices;
using System;

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
namespace JohnsonControls.Metasys.BasicServices;



public static class Keychain
{
    private const string SecurityLibrary = "/System/Library/Frameworks/Security.framework/Security";

    [DllImport(SecurityLibrary)]
    public static extern int SecKeychainItemDelete(IntPtr itemRef);
    [DllImport(SecurityLibrary)]
    public static extern int SecKeychainAddGenericPassword(
        IntPtr keychain,
        uint serviceNameLength,
        string serviceName,
        uint accountNameLength,
        string accountName,
        uint passwordLength,
        byte[] passwordData,
        IntPtr itemRef);

    [DllImport(SecurityLibrary)]
    public static extern int SecKeychainFindGenericPassword(
        IntPtr keychain,
        uint serviceNameLength,
        string serviceName,
        uint accountNameLength,
        string accountName,
        out uint passwordLength,
        out IntPtr passwordData,
        out IntPtr itemRef);

    [DllImport(SecurityLibrary)]
    public static extern int SecKeychainItemFreeContent(
        IntPtr attrList,
        IntPtr data);

    [DllImport(SecurityLibrary)]
    private static extern int SecKeychainSearchCreateFromAttributes(
        IntPtr keychainOrArray,
        IntPtr itemClass,
        IntPtr attrList,
        out IntPtr searchRef
    );

    [DllImport(SecurityLibrary)]
    private static extern int SecKeychainSearchCopyNext(
        IntPtr searchRef,
        out IntPtr itemRef
    );

    private static void AssertRunningOnMacOS()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            throw new InvalidOperationException("This service is macOS specific.");
        }
    }

    public static void AddPassword(string serviceName, string accountName, SecureString password)
    {
        AssertRunningOnMacOS();

        var passwordData = SecureStringToByteArray(password);
        var status = SecKeychainAddGenericPassword(
            IntPtr.Zero,
            (uint)serviceName.Length,
            serviceName,
            (uint)accountName.Length,
            accountName,
            (uint)passwordData.Length,
            passwordData,
            IntPtr.Zero);

        Array.Clear(passwordData, 0, passwordData.Length);
        if (status != 0)
        {
            throw new InvalidOperationException("Password was not saved. Perhaps a password is already saved for this account.");
        }
    }

    public static bool TryGetPassword(string serviceName, string accountName, out SecureString password)
    {
        AssertRunningOnMacOS();

        uint passwordLength;
        IntPtr passwordData;
        IntPtr itemRef;

        var status = SecKeychainFindGenericPassword(
            IntPtr.Zero,
            (uint)serviceName.Length,
            serviceName,
            (uint)accountName.Length,
            accountName,
            out passwordLength,
            out passwordData,
            out itemRef);

        if (status == 0 && passwordData != IntPtr.Zero)
        {
            // char[] passwordChars = new char[(int)passwordLength / (sizeof(char))];
            // Marshal.Copy(passwordData, passwordChars, 0, (int)passwordLength / sizeof(char));

            // Copy the password data to a byte array
            byte[] passwordBytes = new byte[passwordLength];
            Marshal.Copy(passwordData, passwordBytes, 0, (int)passwordLength);

            // Convert the byte array to a string using UTF-8 encoding
            char[] passwordChars = System.Text.Encoding.UTF8.GetChars(passwordBytes);

            var securePassword = new SecureString();
            passwordChars.ToList().ForEach(securePassword.AppendChar);
            securePassword.MakeReadOnly();

            Array.Clear(passwordBytes, 0, passwordBytes.Length);
            Array.Clear(passwordChars, 0, passwordChars.Length);
            SecKeychainItemFreeContent(IntPtr.Zero, passwordData);
            password = securePassword;
            return true;
        }
        else
        {
            password = new();
            return false;
        }
    }
    public static void AddOrReplacePassword(string serviceName, string accountName, SecureString newPassword)
    {

        AssertRunningOnMacOS();

        IntPtr itemRef = IntPtr.Zero;
        try
        {
            // Find the existing password
            uint passwordLength;
            IntPtr passwordData;
            var status = SecKeychainFindGenericPassword(
                IntPtr.Zero,
                (uint)serviceName.Length,
                serviceName,
                (uint)accountName.Length,
                accountName,
                out passwordLength,
                out passwordData,
                out itemRef);

            if (status == 0 && itemRef != IntPtr.Zero)
            {
                // Delete the existing password
                status = SecKeychainItemDelete(itemRef);
                if (status != 0)
                {
                    throw new InvalidOperationException($"The entry for {serviceName}.{accountName} could not be replaced.");
                }
            }

            // Add the new password
            AddPassword(serviceName, accountName, newPassword);
        }
        finally
        {
            // Free the allocated memory for the existing password
            if (itemRef != IntPtr.Zero)
            {
                SecKeychainItemFreeContent(IntPtr.Zero, itemRef);
            }
        }
    }

    public static void DeleteKeychainEntry(string serviceName, string accountName, bool exceptionIfNotFound = false)
    {
        IntPtr itemRef = IntPtr.Zero;
        uint passwordLength;
        IntPtr passwordData;

        int result = SecKeychainFindGenericPassword(
            IntPtr.Zero,
            (uint)serviceName.Length,
            serviceName,
            (uint)accountName.Length,
            accountName,
            out passwordLength,
            out passwordData,
            out itemRef
        );

        if (result == 0 && itemRef != IntPtr.Zero)
        {
            result = SecKeychainItemDelete(itemRef);
            if (result != 0)
            {
                throw new InvalidOperationException($"The entry for {serviceName}.{accountName} could not be deleted.");
            }

        }
        else if (exceptionIfNotFound)
        {
            throw new InvalidOperationException($"The entry for {serviceName}.{accountName} could not be found.");
        }

        if (passwordData != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(passwordData);
        }
    }

    public static bool HasKeychainEntry(string serviceName)
    {
        IntPtr searchRef = IntPtr.Zero;
        IntPtr itemRef = IntPtr.Zero;

        // Create a search query for the service name
        int result = SecKeychainSearchCreateFromAttributes(
            IntPtr.Zero,
            IntPtr.Zero,
            IntPtr.Zero,
            out searchRef
        );

        if (result == 0 && searchRef != IntPtr.Zero)
        {
            while (SecKeychainSearchCopyNext(searchRef, out itemRef) == 0)
            {
                // Here you can add additional checks if needed
                if (itemRef != IntPtr.Zero)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static byte[] SecureStringToByteArray(SecureString secureString)
    {
        // Convert SecureString to UTF-8 byte array
        IntPtr unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
        string passwordString = Marshal.PtrToStringUni(unmanagedString);
        byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(passwordString);
        return passwordBytes;
    }


}
