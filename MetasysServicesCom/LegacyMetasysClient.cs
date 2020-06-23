﻿using AutoMapper;
using JohnsonControls.Metasys.BasicServices;
using JohnsonControls.Metasys.BasicServices.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using MetasysAttribute = JohnsonControls.Metasys.BasicServices.MetasysAttribute;
using System.Globalization;

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
        /// Local instance of Trends service
        /// </summary>
        public ITrendService Trends;

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
                cfg.CreateMap<Variant, IComVariant>()
                    // This is needed in order to correctly map to generic object reference to array, in order to correctly map to VBA
                    .ForMember(dest => dest.ArrayValue, opt => opt.MapFrom(src => Mapper.Map<IComVariant[]>(src.ArrayValue)));
                cfg.CreateMap<VariantMultiple, IComVariantMultiple>()
                    // This is needed in order to correctly map to generic object reference to array, in order to correctly map to VBA
                    .ForMember(dest => dest.Variants, opt => opt.MapFrom(src => Mapper.Map<IComVariant[]>(src.Values)));
                cfg.CreateMap<AccessToken, IComAccessToken>();
                cfg.CreateMap<Command, IComCommand>();
                cfg.CreateMap<MetasysObjectType, IComMetasysObjectType>();
                cfg.CreateMap<IComFilterAlarm, AlarmFilter>();
                cfg.CreateMap<Alarm, IComProvideAlarmItem>();
                cfg.CreateMap<Sample, IComSample>();
                cfg.CreateMap<IComTimeFilter, TimeFilter>();
                cfg.CreateMap<MetasysAttribute, IComAttribute>();
                cfg.CreateMap<PagedResult<Alarm>, IComPagedResult>()
                    // This is needed in order to correctly map to generic object reference to array, in order to correctly map to VBA
                    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => Mapper.Map<IComProvideAlarmItem[]>(src.Items)));
                cfg.CreateMap<PagedResult<Sample>, IComPagedResult>()
                    // This is needed in order to correctly map to generic object reference to array, in order to correctly map to VBA
                    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => Mapper.Map<IComSample[]>(src.Items)));
                cfg.CreateMap<IComAuditFilter, AuditFilter>();
                cfg.CreateMap<Audit, IComProvideAuditItem>();
                cfg.CreateMap<PagedResult<Audit>, IComPagedResult>()
                    // This is needed in order to correctly map to generic object reference to array, in order to correctly map to VBA
                    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => Mapper.Map<IComProvideAuditItem[]>(src.Items)));
                cfg.CreateMap<MetasysPoint, IComPoint>();
            }).CreateMapper();
        }

        /// <inheritdoc/>
        public IComAccessToken TryLogin(string username, string password, bool refresh = true)
        {
            return Mapper.Map<IComAccessToken>(Client.TryLogin(username, password, refresh));
        }

        /// <inheritdoc/>
        public IComAccessToken Refresh()
        {
            return Mapper.Map<IComAccessToken>(Client.Refresh());
        }

        /// <inheritdoc/>
        public string Localize(string resource, string cultureInfo = "en-US")
        {
            CultureInfo culture = new CultureInfo(cultureInfo);
            return Client.Localize(resource, culture);
        }

        /// <inheritdoc/>
        public string GetCommandEnumeration(string resource)
        {
            // Priority is the cultureInfo parameter if available, otherwise MetasysClient culture.
            return Client.GetCommandEnumeration(resource);
        }

        /// <inheritdoc/>
        public string GetObjectTypeEnumeration(string resource)
        {
            // Priority is the cultureInfo parameter if available, otherwise MetasysClient culture.
            return Client.GetObjectTypeEnumeration(resource);
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

        /// <inheritdoc/>
        public IComVariant ReadProperty(string id, string attributeName)
        {
            // Parse Id and generate GUID
            Guid guid = new Guid(id);
            var response = Client.ReadProperty(guid, attributeName);
            return Mapper.Map<IComVariant>(response);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void WriteProperty(string id, string attributeName, string newValue, string priority = null)
        {
            Client.WriteProperty(new Guid(id), attributeName, newValue, priority);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public object GetCommands(string id)
        {
            Guid guid = new Guid(id);
            var res = Client.GetCommands(guid);
            return Mapper.Map<IComCommand[]>(res);
        }

        /// <inheritdoc/>
        public void SendCommand(string id, string command, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] values = null)
        {
            // Note: MarshalAs decorator is needed when return type is void, otherwise will cause a VBA error on Automation type not supported when passing array
            Guid guid = new Guid(id);
            Client.SendCommand(guid, command, values?.ToList());
        }

        /// <inheritdoc/>
        public object GetObjects(string id, int levels = 1)
        {
            Guid guid = new Guid(id);
            var res = Client.GetObjects(guid, levels).ToList();
            return Mapper.Map<IComMetasysObject[]>(res);
        }

        /// <inheritdoc/>
        public object GetNetworkDevices(string type = null)
        {
            // Note: need a generic object as return type in order to map correctly to VBA type array
            var res = Client.GetNetworkDevices(type).ToList();
            return Mapper.Map<IComMetasysObject[]>(res);
        }

        /// <inheritdoc/>
        public object GetNetworkDeviceTypes(string type = null)
        {
            var res = Client.GetNetworkDeviceTypes();
            return Mapper.Map<IComMetasysObjectType[]>(res);
        }

        /// <inheritdoc/>
        public object GetSpaces(string type = null)
        {
            SpaceTypeEnum? spaceType = null;
            if (type != null)
            {
                // Parse type string to SpaceTypeEnum 
                spaceType = (SpaceTypeEnum)Enum.Parse(typeof(SpaceTypeEnum), type);
            }
            // Note: need a generic object as return type in order to map correctly to VBA type array
            var res = Client.GetSpaces(spaceType);
            return Mapper.Map<IComMetasysObject[]>(res);
        }

        /// <inheritdoc/>
        public object GetSpaceChildren(string id)
        {
            Guid guid = new Guid(id);
            // Note: need a generic object as return type in order to map correctly to VBA type array
            var res = Client.GetSpaceChildren(guid);
            return Mapper.Map<IComMetasysObject[]>(res);
        }

        /// <inheritdoc/>
        public object GetSpaceTypes()
        {
            // Note: need a generic object as return type in order to map correctly to VBA type array
            var res = Client.GetSpaceTypes();
            return Mapper.Map<IComMetasysObjectType[]>(res);
        }

        /// <inheritdoc/>
        public object GetSpaceEquipment(string spaceId)
        {
            Guid guid = new Guid(spaceId);
            var res = Client.GetSpaceEquipment(guid);
            return Mapper.Map<IComMetasysObject[]>(res);
        }

        /// <inheritdoc/>
        public object GetEquipment()
        {
            // Note: need a generic object as return type in order to map correctly to VBA type array
            var res = Client.GetEquipment();
            return Mapper.Map<IComMetasysObject[]>(res);
        }

        /// <inheritdoc />
        public object GetEquipmentPoints(string equipmentId, bool ReadAttributeValue=true)
        {
            Guid guid = new Guid(equipmentId);
            var res = Client.GetEquipmentPoints(guid, ReadAttributeValue);
            return Mapper.Map<IComPoint[]>(res);
        }

        /// <inheritdoc />
        public object GetSingleAlarm(string alarmId)
        {
            Guid guidAlarmId = Guid.Parse(alarmId);
            var alarmItem = Client.Alarms.FindById(guidAlarmId);
            return Mapper.Map<IComProvideAlarmItem>(alarmItem);
        }

        /// <inheritdoc />
        public IComPagedResult GetAlarms(IComFilterAlarm alarmFilter)
        {
            var mapAlarmFilter = Mapper.Map<AlarmFilter>(alarmFilter);
            PagedResult<Alarm> alarmItems = Client.Alarms.Get(mapAlarmFilter);
            return Mapper.Map<IComPagedResult>(alarmItems);
        }

        /// <inheritdoc />
        public object GetAlarmAnnotations(string alarmId)
        {
            Guid guidAlarmId = Guid.Parse(alarmId);
            var response = Client.Alarms.GetAnnotations(guidAlarmId);
            return Mapper.Map<IComAlarmAnnotation[]>(response);
        }

        /// <inheritdoc />
        public IComPagedResult GetAlarmsForAnObject(string objectId, IComFilterAlarm alarmFilter)
        {
            Guid guidObjectId = Guid.Parse(objectId);
            var mapAlarmFilterForAnObject = Mapper.Map<AlarmFilter>(alarmFilter);
            var alarmItems = Client.Alarms.GetForObject(guidObjectId, mapAlarmFilterForAnObject);
            return Mapper.Map<IComPagedResult>(alarmItems);
        }

        /// <inheritdoc />
        public IComPagedResult GetAlarmsForNetworkDevice(string networkDeviceId, IComFilterAlarm alarmFilter)
        {
            Guid guidNetworkDeviceId = Guid.Parse(networkDeviceId);
            var mapAlarmFilterForObject = Mapper.Map<AlarmFilter>(alarmFilter);
            var alarmItems = Client.Alarms.GetForNetworkDevice(guidNetworkDeviceId, mapAlarmFilterForObject);
            return Mapper.Map<IComPagedResult>(alarmItems);
        }

        /// <inheritdoc />
        public object GetTrendedAttributes(string id)
        {
            var res = Client.Trends.GetTrendedAttributes(new Guid(id));
            return Mapper.Map<IComAttribute[]>(res);
        }

        /// <inheritdoc />
        public IComPagedResult GetSamples(string objectId, int attributeId, IComTimeFilter filter)
        {
            var mapTrendedAttributes = Mapper.Map<TimeFilter>(filter);
            PagedResult<Sample> samples = Client.Trends.GetSamples(new Guid(objectId), attributeId, mapTrendedAttributes);
            var map = Mapper.Map<IComPagedResult>(samples);
            return map;
        }

        /// <inheritdoc />
        public object GetSingleAudit(string auditId)
        {
            Guid guidAuditId = Guid.Parse(auditId);
            var auditItem = Client.Audits.FindById(guidAuditId);
            return Mapper.Map<IComProvideAuditItem>(auditItem);
        }

        /// <inheritdoc />
        public IComPagedResult GetAudits(IComAuditFilter auditFilter)
        {
            var mapAuditFilter = Mapper.Map<AuditFilter>(auditFilter);
            PagedResult<Audit> auditItems = Client.Audits.Get(mapAuditFilter);
            return Mapper.Map<IComPagedResult>(auditItems);
        }

        /// <inheritdoc />
        public object GetAuditAnnotations(string auditId)
        {
            Guid guidAuditId = Guid.Parse(auditId);
            var response = Client.Audits.GetAnnotations(guidAuditId);
            return Mapper.Map<IComAuditAnnotation[]>(response);
        }

        /// <inheritdoc />
        public void DiscardAudit(string id)
        {
            // Note: MarshalAs decorator is needed when return type is void, otherwise will cause a VBA error on Automation type not supported when passing array
            Guid guid = new Guid(id);
            Client.Audits.Discard(guid);
        }

        /// <inheritdoc />
        public void AddAuditAnnotation(string id, string text)
        {
            // Note: MarshalAs decorator is needed when return type is void, otherwise will cause a VBA error on Automation type not supported when passing array
            Guid guid = new Guid(id);
            Client.Audits.AddAnnotation(guid, text);
        }

        /// <inheritdoc/>
        public IComPagedResult GetAuditsForAnObject(string objectId, IComAuditFilter auditFilter)
        {
            Guid guidObjectId = Guid.Parse(objectId);
            var mapAuditFilterForAnObject = Mapper.Map<AuditFilter>(auditFilter);
            var auditItems = Client.Audits.GetForObject(guidObjectId, mapAuditFilterForAnObject);
            return Mapper.Map<IComPagedResult>(auditItems);
        }

        /// <inheritdoc/>
        public IComAccessToken TryLoginWithCredMan(string target, bool refresh = true)
        {
            return Mapper.Map<IComAccessToken>(Client.TryLogin(target, refresh));
        }
       
    }
}