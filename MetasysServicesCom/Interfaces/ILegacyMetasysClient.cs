using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A COM HTTP client for consuming the most commonly used endpoints of the Metasys API.
    /// </summary>
    [ComVisible(true)]
    [Guid("B1AF1A67-42A0-4E4A-8A07-97AA53B42D02")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ILegacyMetasysClient
    {      
        /// <summary>
        /// Attempts to login to the given host.
        /// </summary>
        IComAccessToken TryLogin(string username, string password, bool refresh = true);

        /// <summary>
        /// Read one attribute value given the Guid of the object.
        /// </summary>
        IComVariant ReadProperty(string id, string attributeName);

        /// <summary>
        /// Read many attribute values given the Guids of the objects.
        /// </summary>
        object ReadPropertyMultiple([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] ids, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] attributeNames);
 
        /// <summary>
        /// Write a single attribute given the Guid of the object. 
        /// </summary>
        void WriteProperty(string id, string attributeName, string newValue, string priority = null);

        /// <summary>
        /// Write to many attribute values given the Guids of the objects.
        /// </summary>
        void WritePropertyMultiple([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] ids, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] attributes, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] attributeValues, string priority = null);
        
        /// <summary>
        /// Get all available commands given the Guid of the object.
        /// </summary>
        object GetCommands(string id);

        /// <summary>
        /// Send a command to an object.
        /// </summary>
        void SendCommand(string id, string command, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] values = null);

        /// <summary>
        /// Gets all network devices.
        /// </summary>
        object GetNetworkDevices(string type=null);

        /// <summary>
        /// Gets all available network device types.
        /// </summary>
        object GetNetworkDeviceTypes(string type=null);

        /// <summary>
        /// Gets all child objects given a parent Guid.
        /// Level indicates how deep to retrieve objects.
        /// </summary>
        object GetObjects(string id, int levels = 1);

        /// <summary>
        /// Given the Item Reference of an object, returns the object identifier.
        /// </summary>
        string GetObjectIdentifier(string itemReference);

        /// <summary>
        /// Gets all network devices.
        /// </summary>
        object GetSpaces(string type = null);

        /// <summary>
        /// Gets all space types.
        /// </summary>
        object GetSpacesTypes();

        /// <summary>
        /// Gets all network devices.
        /// </summary>
        object GetEquipment();
    }
}
