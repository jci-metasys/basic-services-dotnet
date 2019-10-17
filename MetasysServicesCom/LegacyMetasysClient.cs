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
    [Guid("0261C5FD-2473-4EC1-A78C-31A5C27C8163")]
    [ClassInterface(ClassInterfaceType.None)]
    public class LegacyMetasysClient : ILegacyMetasysClient
    {
        MetasysClient client;

        /// <summary>
        /// Creates a new LegacyClient.
        /// </summary>
        public LegacyMetasysClient()
        {          
        }

        /// <summary>
        /// Attempts to login to the given host.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void login(string hostname, string username, string password)
        {
            client = new MetasysClient(hostname);
            client.TryLogin(username, password);
        }

        /// <summary>
        /// Returns the object identifier (id) of the specified object.
        /// </summary>
        /// <param name="itemReference"></param>
        public Guid? GetObjectIdentifier(string itemReference)
        {
            Guid? response = client.GetObjectIdentifier(itemReference);
            return response;
        }

        /// <summary>
        /// Read one attribute value given the reference of the object.
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="property"></param>
        /// <param name="stringValue"></param>
        /// <param name="rawValue"></param>
        /// <param name="reliability"></param>
        /// <param name="priority"></param>
        public string ReadProperty(string reference, string property, out double numericValue, out double rawValue, out string reliability, out string priority)
        {
            Guid? fqr = GetObjectIdentifier(reference);
            var response = client.ReadProperty(fqr.Value, property).Value;
            reliability = response.Reliability;
            numericValue = response.NumericValue;
            priority = response.Priority;
            rawValue = response.NumericValue;
            return response.StringValue;
        }

        /// <summary>
        /// Read many attribute values given the references of the objects.
        /// </summary>       
        /// <param name="objectList"></param>
        /// <param name="propertyList"></param>
        /// <param name="values"></param>
        public List<string> ReadPropertyMultiple(string[] objectList, string[] propertyList, out string[] values)
        {
            var guidList = new List<Guid>();
            foreach (var guid in objectList)
            {
                guidList.Add(GetObjectIdentifier(guid).Value);
            }
            var response = client.ReadPropertyMultiple(guidList, propertyList);         
            var valueList = new List<string>();
            foreach (var value in response)
            {
                // Return the response for all attributes in a serialized array, since limited support of custom objects in VBA
                foreach (var attributeValue in value.Variants)
                {
                    valueList.Add(attributeValue.StringValue);
                }
            }
            values = valueList.ToArray(); // Need to use output params, since return value as array is not supported in VBA   
            return valueList;
        }
        
        public int WriteProperty(string reference, string attributeName, string newValue, string priority=null)
        {
            Guid? guid = GetObjectIdentifier(reference);          
            client.WriteProperty(guid.Value, attributeName, newValue, priority);
            return 0;
        }

        public List<string> WritePropertyMultiple(string[] references, string[] attributes, string[] values, string priority = null)
        {
            var guidList = new List<Guid>();
            foreach (var guid in references)
            {
                guidList.Add(GetObjectIdentifier(guid).Value);
            }
            // Convert positional arrays to Enumerable
            var valueList = new List<(string,object)>();          
            for (int i=0; i< attributes.Length;i++)
            {
                valueList.Add((attributes[i],values[i]));
            }
            client.WritePropertyMultiple(guidList, valueList, priority);
            return new List<string>(); // Work around to manage VBA error
        }

        public List<string> SendCommand(string reference, string command, string[] values = null)
        {
            Guid? guid = GetObjectIdentifier(reference);
            // Convert positional arrays to Enumerable
            var valueList = new List<string>();
            foreach (var v in values)
            {
                valueList.Add(v);
            }
            client.SendCommand(guid.Value, command, valueList);
            return new List<string>(); // Work around to manage VBA error
        }
    }
}
