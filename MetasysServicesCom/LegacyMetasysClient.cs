using AutoMapper;
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
        protected IMetasysClient Client;
        protected IMapper Mapper;

        /// <summary>
        /// Creates a new LegacyClient.
        /// </summary>
        public LegacyMetasysClient()
        {
           Mapper = new MapperConfiguration(cfg => cfg.CreateMap<MetasysObject, ComMetasysObject>()).CreateMapper(); 
        }

        /// <summary>
        /// Attempts to login to the given host.
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void login(string hostname, string username, string password)
        {
            Client = new MetasysClient(hostname);
            Client.TryLogin(username, password);
        }

        /// <summary>
        /// Returns the object identifier (id) of the specified object.
        /// </summary>
        /// <param name="itemReference"></param>
        public string GetObjectIdentifier(string itemReference)
        {
            Guid? response = Client.GetObjectIdentifier(itemReference);
            return response?.ToString();
        }

        /// <summary>
        /// Read one attribute value given the reference of the object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="property"></param>
        /// <param name="numericValue"></param>
        /// <param name="rawValue"></param>
        /// <param name="reliability"></param>
        /// <param name="priority"></param>
        public string ReadProperty(string id, string property, out double numericValue, out double rawValue, out string reliability, out string priority)
        {
            // Parse Id and generate GUID
            Guid guid = new Guid(id);
            var response = Client.ReadProperty(guid, property).Value;
            reliability = response.Reliability;
            numericValue = response.NumericValue;
            priority = response.Priority;
            rawValue = response.NumericValue;
            return response.StringValue;
        }

        /// <summary>
        /// Read many attribute values given the references of the objects.
        /// </summary>
        /// <param name="objectIdList"></param>
        /// <param name="propertyList"></param>
        /// <param name="values"></param>
        public List<string> ReadPropertyMultiple(string[] objectIdList, string[] propertyList, out string[] values)
        {
            var guidList = new List<Guid>();
            foreach (var id in objectIdList)
            {
                guidList.Add(new Guid(id));
            }
            var response = Client.ReadPropertyMultiple(guidList, propertyList);         
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

        /// <summary>
        /// write attribute values given the references of the objects.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <param name="newValue"></param>
        /// <param name="priority"></param>
        public int WriteProperty(string id, string attributeName, string newValue, string priority=null)
        {        
            Client.WriteProperty(new Guid(id), attributeName, newValue, priority);
            return 0;
        }

        /// <summary>
        /// write many attribute values given the references of the objects.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="attributes"></param>
        /// <param name="values"></param>
        /// <param name="priority"></param>
        public List<string> WritePropertyMultiple(string[] ids, string[] attributes, string[] values, string priority = null)
        {
            var guidList = new List<Guid>();
            foreach (var id in ids)
            {
                guidList.Add(new Guid(id));
            }
            // Convert positional arrays to Enumerable
            var valueList = new List<(string,object)>();
            for (int i=0; i< attributes.Length;i++)
            {
                valueList.Add((attributes[i],values[i]));
            }
            Client.WritePropertyMultiple(guidList, valueList, priority);
            return new List<string>(); // Work around to manage VBA error
        }


        /// <summary>
        /// send command to the object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <param name="values"></param>
        public List<string> SendCommand(string id, string command, string[] values = null)
        {
            Guid guid = new Guid(id);
            // Convert positional arrays to Enumerable
            var valueList = new List<string>();
            foreach (var v in values)
            {
                valueList.Add(v);
            }
            Client.SendCommand(guid, command, valueList);
            return new List<string>(); // Work around to manage VBA error
        }


        /// <summary>
        /// Gets all child objects given a reference.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="levels"></param>       
        public MetasysObjectsContainer GetObjects(string id, int levels = 1)
        {
            Guid guid = new Guid(id); 
            var res = Client.GetObjects(guid,levels).ToList();  
            return new MetasysObjectsContainer { Objects = Mapper.Map<ComMetasysObject[]>(res) };     
        }

        /// <summary>
        /// Gets all device list
        /// </summary>
        public MetasysObjectsContainer GetNetworkDevices()
        {                  
            var res = Client.GetNetworkDevices().ToList();
            return new MetasysObjectsContainer { Objects = Mapper.Map<ComMetasysObject[]>(res) };           
        }    
    }
}
