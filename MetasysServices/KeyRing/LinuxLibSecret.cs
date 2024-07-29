using System;
using System.Runtime.InteropServices;
using System.Security;

namespace JohnsonControls.Metasys.BasicServices;

public static class LinuxLibSecret
{
    private const string LibSecretLibrary = "libsecret-1.so.0";

    [DllImport(LibSecretLibrary)]
    public static extern IntPtr secret_password_store_sync(
        IntPtr schema,
        IntPtr cancellable,
        string label,
        string password,
        IntPtr error,
        string attribute1Type,
        string attribute1Value,
        string attribute2Type,
        string attribute2Value,
        IntPtr end);

    [DllImport(LibSecretLibrary)]
    public static extern IntPtr secret_password_lookup_sync(
        IntPtr schema,
        IntPtr cancellable,
        IntPtr error,
        string attribute1Type,
        string attribute1Value,
        string attribute2Type,
        string attribute2Value,
        IntPtr end);

    [DllImport(LibSecretLibrary)]
    public static extern void secret_password_free(IntPtr password);
}


public static class SecretSchema
{
    public static readonly IntPtr Schema = Marshal.AllocHGlobal(Marshal.SizeOf<SecretSchemaStruct>());

    static SecretSchema()
    {
        var schema = new SecretSchemaStruct
        {
            name = "com.example.Password",
            flags = 0,
            attributes = new[]
            {
            new SecretSchemaAttribute { name = "service", type = 0 },
            new SecretSchemaAttribute { name = "account", type = 0 },
            new SecretSchemaAttribute { name = null, type = 0 }
        }
        };

        Marshal.StructureToPtr(schema, Schema, false);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SecretSchemaStruct
    {
        public string name;
        public int flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public SecretSchemaAttribute[] attributes;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SecretSchemaAttribute
    {
        public string name;
        public int type;
    }
}
