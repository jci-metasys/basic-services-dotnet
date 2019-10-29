using JohnsonControls.Metasys.BasicServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    [ComVisible(true)]
    [Guid("B1AF1A67-42A0-4E4A-8A07-97AA53B42D02")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ILegacyMetasysClient
    {
       void login(string hostname, string username, string password);

       string ReadProperty(string id, string property, out double numericValue,
            out double rawValue, out string reliability, out string priority);

        List<string> ReadPropertyMultiple(string[] objectIdList, string[] propertyList, out string[] values);
        int WriteProperty(string id, string attributeName, string newValue, string priority=null);
        List<string> WritePropertyMultiple(string[] ids, string[] attributes, string[] values, string priority = null);
        List<string> SendCommand(string id, string command, string[] values = null);
        MetasysObjectsContainer GetNetworkDevices();
        MetasysObjectsContainer GetObjects(string id, int levels = 1);
        string GetObjectIdentifier(string itemReference);
    }
}
