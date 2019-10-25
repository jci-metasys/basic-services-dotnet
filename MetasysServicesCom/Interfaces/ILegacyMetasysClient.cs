using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices.Interfaces
{
    /// <summary>
    /// A Interface used by LegacyMetasysClient
    /// </summary>
    [ComVisible(true)]
    [Guid("B1AF1A67-42A0-4E4A-8A07-97AA53B42D02")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ILegacyMetasysClient
    {

        /// <summary>
        /// Attempts to login to the given host.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        void login(string hostname, string username, string password);

        /// <summary>
        /// Read one attribute value given the reference of the object.
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="property"></param>
        /// <param name="numericValue"></param>
        /// <param name="rawValue"></param>
        /// <param name="reliability"></param>
        /// <param name="priority"></param>

        string ReadProperty(string reference, string property, out double numericValue,
            out double rawValue, out string reliability, out string priority);

        /// <summary>
        /// Read many attribute values given the references of the objects.
        /// </summary>
        /// <param name="objectList"></param>
        /// <param name="propertyList"></param>
        /// <param name="values"></param>

        List<string> ReadPropertyMultiple(string[] objectList, string[] propertyList, out string[] values);

        /// <summary>
        /// Write attribute values given the references of the objects.
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="attributeName"></param>
        /// <param name="newValue"></param>
        /// <param name="priority"></param>
        int WriteProperty(string reference, string attributeName, string newValue, string priority=null);

        /// <summary>
        /// Write many attribute values given the references of the objects.
        /// </summary>
        /// <param name="references"></param>
        /// <param name="attributes"></param>
        /// <param name="values"></param>
        /// <param name="priority"></param>
        List<string> WritePropertyMultiple(string[] references, string[] attributes, string[] values, string priority = null);

        /// <summary>
        /// Send command to the object.
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="command"></param>
        /// <param name="values"></param>
        List<string> SendCommand(string reference, string command, string[] values = null);

        /// <summary>
        /// Gets all device list
        /// </summary>
        /// <param name="deviceList"></param>
        List<string> GetNetworkDevices(out string[] deviceList);

        /// <summary>
        /// Gets all child objects given a reference.
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="objectList"></param>
        List<string> GetObjectList(string reference, out string[] objectList);
    }
}
