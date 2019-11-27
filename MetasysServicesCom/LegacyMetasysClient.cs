using AutoMapper;
using JohnsonControls.Metasys.BasicServices;
using JohnsonControls.Metasys.ComServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// An COM HTTP client for consuming the most commonly used endpoints of the Metasys API.
    /// </summary>
    [ComVisible(true)]
    [Guid("0261C5FD-2473-4EC1-A78C-31A5C27C8163")]
    [ClassInterface(ClassInterfaceType.None)]
    public class LegacyMetasysClient : ILegacyMetasysClient
    {
        /// <summary>
        /// Metasys Basic Services client for underlying API calls
        /// </summary>
        protected IMetasysClient Client;
        /// <summary>
        /// Automapper instance for mapping Basic Services structures to registered COM DTO
        /// </summary>
        protected IMapper Mapper;

        /// <summary>
        /// Creates a new LegacyMetasysClient.
        /// </summary>
        internal LegacyMetasysClient(IMetasysClient client)
        {
            Client = client;
            // Defines a Mapper From Basic Services structure to COM
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MetasysObject, IComMetasysObject>()
                    // This is needed in order to correctly map to generic object reference to array, in order to correctly map to VBA
                    .ForMember(dest => dest.Children, opt => opt.MapFrom(src => Mapper.Map<IComMetasysObject[]>(src.Children)));
                cfg.CreateMap<Variant, IComVariant>();
                cfg.CreateMap<VariantMultiple, IComVariantMultiple>()
                    // This is needed in order to correctly map to generic object reference to array, in order to correctly map to VBA
                    .ForMember(dest => dest.Variants, opt => opt.MapFrom(src => Mapper.Map<IComVariant[]>(src.Variants)));
                cfg.CreateMap<AccessToken, IComAccessToken>();
                cfg.CreateMap<Command, IComCommand>();
                cfg.CreateMap<MetasysObjectType, IComMetasysObjectType>();
            }).CreateMapper();
        }

        /// <summary>
        /// Attempts to login to the given host.
        /// </summary>
        /// <returns>Access Token.</returns>  
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="refresh">Flag to set automatic access token refreshing to keep session active.</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysTokenException"></exception>
        public IComAccessToken TryLogin(string username, string password, bool refresh = true)
        {
            return Mapper.Map<IComAccessToken>(Client.TryLogin(username, password,refresh));
        }

        /// <summary>
        /// Given the Item Reference of an object, returns the object identifier.
        /// </summary>
        /// <remarks>
        /// The itemReference will be automatically URL encoded.
        /// </remarks>
        /// <returns>A Guid representing the id, or an empty Guid if errors occurred.</returns>
        /// <param name="itemReference"></param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysGuidException"></exception>
        public string GetObjectIdentifier(string itemReference)
        {
            Guid? response = Client.GetObjectIdentifier(itemReference);
            return response?.ToString();
        }

        /// <summary>
        /// Read one attribute value given the Guid of the object.
        /// </summary>
        /// <returns>
        /// Variant if the attribute exists, null if does not exist.
        /// </returns>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpTimeoutException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysPropertyException"></exception>
        public IComVariant ReadProperty(string id, string attributeName)
        {
            // Parse Id and generate GUID
            Guid guid = new Guid(id);
            var response = Client.ReadProperty(guid, attributeName);
            return Mapper.Map<IComVariant>(response);
        }

        /// <summary>
        /// Read many attribute values given the Guids of the objects.
        /// </summary>
        /// <returns>
        /// A list of VariantMultiple with all the specified attributes (if existing).
        /// </returns>
        /// <param name="ids"></param>
        /// <param name="attributeNames"></param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysPropertyException"></exception>
        public object ReadPropertyMultiple([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] ids, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] attributeNames)
        {
            // Note: MarshalAs decorator is needed for arrays, otherwise will cause a VBA app crash
            // Note: need a generic object as return type in order to map correctly to VBA type array
            var guidList = new List<Guid>();
            foreach (var id in ids)
            {
                guidList.Add(new Guid(id));
            }
            var response = Client.ReadPropertyMultiple(guidList, attributeNames);
            return Mapper.Map<IComVariantMultiple[]>(response);
        }

        /// <summary>
        /// Write a single attribute given the Guid of the object. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <param name="newValue"></param>
        /// <param name="priority">Write priority as an enumeration from the writePriorityEnumSet.</param>
        /// <exception cref="MetasysHttpException"></exception>
        public void WriteProperty(string id, string attributeName, string newValue, string priority = null)
        {
            Client.WriteProperty(new Guid(id), attributeName, newValue, priority);
        }

        /// <summary>
        /// Write to many attribute values given the Guids of the objects.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="attributes"></param>
        /// <param name="attributeValues">The (attribute, value) pairs split in a array.</param>
        /// <param name="priority">Write priority as an enumeration from the writePriorityEnumSet.</param>
        /// <exception cref="MetasysHttpException"></exception>
        public void WritePropertyMultiple([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] ids, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] attributes, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] attributeValues, string priority = null)
        {
            // Note: MarshalAs decorator is needed when return type is void, otherwise will cause a VBA error on Automation type not supported when passing array
            var guidList = new List<Guid>();
            foreach (var id in ids)
            {
                guidList.Add(new Guid(id));
            }
            // Convert positional arrays to Enumerable
            var valueList = new List<(string, object)>();
            for (int i = 0; i < attributes.Length; i++)
            {
                valueList.Add((attributes[i], attributeValues[i]));
            }
            Client.WritePropertyMultiple(guidList, valueList, priority);
        }

        /// <summary>
        /// Get all available commands given the Guid of the object.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of Commands.</returns>
        public object GetCommands(string id)
        {
            Guid guid = new Guid(id);
            var res = Client.GetCommands(guid);
            return Mapper.Map<IComCommand[]>(res);
        }

        /// <summary>
        /// Send a command to an object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <param name="values"></param>
        /// <exception cref="MetasysHttpException"></exception>
        public void SendCommand(string id, string command, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] values = null)
        {
            // Note: MarshalAs decorator is needed when return type is void, otherwise will cause a VBA error on Automation type not supported when passing array
            Guid guid = new Guid(id);
            Client.SendCommand(guid, command, values?.ToList());
        }

        /// <summary>
        /// Gets all child objects given a parent Guid.
        /// Level indicates how deep to retrieve objects.
        /// </summary>
        /// <remarks>
        /// A level of 1 only retrieves immediate children of the parent object.
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="levels">The depth of the children to retrieve.</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        public object GetObjects(string id, int levels = 1)
        {
            Guid guid = new Guid(id);
            var res = Client.GetObjects(guid, levels).ToList();
            return Mapper.Map<IComMetasysObject[]>(res);
        }

        /// <summary>
        /// Gets all network devices.
        /// </summary>
        /// <param name="type">Optional type number as a string</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        public object GetNetworkDevices(string type=null)
        {
            // Note: need a generic object as return type in order to map correctly to VBA type array
            var res = Client.GetNetworkDevices(type).ToList();
            return Mapper.Map<IComMetasysObject[]>(res);
        }

        /// <summary>
        /// Gets all available network device types.
        /// </summary>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        public object GetNetworkDeviceTypes(string type = null)
        {
            var res = Client.GetNetworkDeviceTypes();
            return Mapper.Map<IComMetasysObjectType[]>(res);
        }

        /// <summary>
        /// Gets all spaces.
        /// </summary>
        /// <param name="type">Optional type number as a string</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        public object GetSpaces(string type = null)
        {
            // Note: need a generic object as return type in order to map correctly to VBA type array
            var res = Client.GetSpaces();
            return Mapper.Map<IComMetasysObject[]>(res);
        }

        /// <summary>
        /// Gets all space types.
        /// </summary>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysObjectTypeException"></exception>
        public object GetSpaceTypes()
        {
            // Note: need a generic object as return type in order to map correctly to VBA type array
            var res = Client.GetSpaceTypes();
            return Mapper.Map<IComMetasysObjectType[]>(res);
        }

        /// <summary>
        /// Gets all equipments by requesting each available page.
        /// </summary>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        public object GetEquipment()
        {
            // Note: need a generic object as return type in order to map correctly to VBA type array
            var res = Client.GetEquipment();
            return Mapper.Map<IComMetasysObject[]>(res);
        }
    }
}
