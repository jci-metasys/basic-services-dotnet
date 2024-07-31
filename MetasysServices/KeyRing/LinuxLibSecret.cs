using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices;

public class LinuxLibSecret : ISecretStore
{

    private static void AssertRunningOnLinux()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            throw new InvalidOperationException("This service is Linux specific.");
        }
    }

    public void AddPassword(string hostname, string userName, SecureString password)
    {
        AssertRunningOnLinux();
        if (TryGetPassword(hostname, userName, out SecureString _))
        {
            throw new InvalidOperationException($"A password already exists for {userName}@{hostname}");
        }
        AddOrReplacePassword(hostname, userName, password);
    }

    public void AddOrReplacePassword(string service, string userName, SecureString password)
    {
        AssertRunningOnLinux();
        RunSecretToolStore(service, userName, password);
    }
    public bool TryGetPassword(string service, string userName, out SecureString password)
    {
        AssertRunningOnLinux();
        var result = RunSecretToolLookup(service, userName);
        password = result == null ? new() : result;
        return result != null;
    }


    const string HostNameAttribute = "Host Name";
    const string UserNameAttribute = "User Name";


    private static char[] SecureStringToCharArray(SecureString secureString)
    {
        IntPtr unmanagedString = IntPtr.Zero;
        byte[] utf8Bytes;

        try
        {
            unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
            int utf16ByteCount = secureString.Length * 2; // UTF-16 encoding uses 2 bytes per character
            byte[] utf16Bytes = new byte[utf16ByteCount];
            Marshal.Copy(unmanagedString, utf16Bytes, 0, utf16ByteCount);

            utf8Bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, utf16Bytes);
        }
        finally
        {
            Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
        }

        char[] charArray = Encoding.UTF8.GetChars(utf8Bytes);
        return charArray;

    }

    private static void RunSecretToolStore(string service, string username, SecureString password)
    {
        var label = $"Password for {username}@{service}";
        var processStartInfo = new ProcessStartInfo
        {
            FileName = "secret-tool",
            Arguments = $"store -l {label} {HostNameAttribute} {service} {UserNameAttribute} {username}",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        char[]? chars = null;
        try
        {
            using (var process = new Process { StartInfo = processStartInfo })
            {
                process.Start();

                chars = SecureStringToCharArray(password);

                chars.ToList().ForEach(c => process.StandardInput.Write(c));
                process.StandardInput.Close();

                process.WaitForExit();
            }
        }
        finally
        {
            if (chars != null)
            {
                Array.Clear(chars, 0, chars.Length);
            }
        }
    }

    private static SecureString? RunSecretToolLookup(string service, string username)
    {
        var processStartInfo = new ProcessStartInfo
        {
            FileName = "secret-tool",
            Arguments = $"lookup {HostNameAttribute} {service} {UserNameAttribute} {username}",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (var process = new Process { StartInfo = processStartInfo })
        {
            process.Start();

            var password = new SecureString();
            int nextChar;
            int length = 0;
            while ((nextChar = process.StandardOutput.Read()) != -1)
            {
                length++;
                password.AppendChar((char)nextChar);
            }
            password.MakeReadOnly();
            process.WaitForExit();
            return length > 0 ? password : null;
        }
    }

}
