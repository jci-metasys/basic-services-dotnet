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
            // Defines a Mapper From Basic Services structure to COM
            Mapper = new MapperConfiguration(cfg => {
                                                    cfg.CreateMap<MetasysObject, ComMetasysObject>();
                                                    cfg.CreateMap<Variant, ComVariant>();
                                                    cfg.CreateMap<VariantMultiple, ComVariantMultiple>();
                                            }).CreateMapper(); 
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
        public ComVariant ReadProperty(string id, string property)
        {
            // Parse Id and generate GUID
            Guid guid = new Guid(id);
            var response = Client.ReadProperty(guid, property).Value;
            return Mapper.Map<ComVariant>(response);
        }

        /// <summary>
        /// Read many attribute values given the references of the objects.
        /// </summary>
        /// <param name="objectIdList"></param>
        /// <param name="propertyList"></param>
        public VariantMultiplesContainer ReadPropertyMultiple([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] objectIdList, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] propertyList)
        {
            // Note: MarshalAs decorator is needed for arrays, otherwise will cause a VBA app crash
            var guidList = new List<Guid>();
            foreach (var id in objectIdList)
            {
                guidList.Add(new Guid(id));
            }
            var response = Client.ReadPropertyMultiple(guidList, propertyList);
            return new VariantMultiplesContainer { Multiples= Mapper.Map<ComVariantMultiple[]>(response) };
        }

        /// <summary>
        /// write attribute values given the references of the objects.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <param name="newValue"></param>
        /// <param name="priority"></param>
        public void WriteProperty(string id, string attributeName, string newValue, string priority=null)
        {        
            Client.WriteProperty(new Guid(id), attributeName, newValue, priority);            
        }

        /// <summary>
        /// write many attribute values given the references of the objects.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="attributes"></param>
        /// <param name="values"></param>
        /// <param name="priority"></param>
        public void WritePropertyMultiple([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] ids, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] attributes, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] values, string priority = null)
        {
            // Note: MarshalAs decorator is needed when return type is void, otherwise will cause a VBA error on Automation type not supported when passing array
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
        }


       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <param name="values"></param>
        public void  SendCommand(string id, string command, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] values=null)
        {
            // Note: MarshalAs decorator is needed when return type is void, otherwise will cause a VBA error on Automation type not supported when passing array
            Guid guid = new Guid(id);          
            Client.SendCommand(guid, command, values?.ToList());           
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
