using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JohnsonControls.Metasys.BasicServices;

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
        /// <returns>Access Token.</returns>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="refresh">Flag to set automatic access token refreshing to keep session active.</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysTokenException"></exception>
        IComAccessToken TryLogin(string username, string password, bool refresh = true);

        /// <summary>
        /// Attempts to login to the given host.
        /// </summary>
        /// <returns>Token as string.</returns>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="refresh">Flag to set automatic access token refreshing to keep session active.</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysTokenException"></exception>
        string TryLogin2(string username, string password, bool refresh = true);

        /// <summary>
        /// Attempts to login to the given host, using Credential Manager target.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="refresh"></param>
        /// <returns></returns>
        IComAccessToken TryLoginWithCredMan(string target, bool refresh = true);

        /// <summary>
        /// Returns the current session access token.
        /// </summary>
        /// <returns>Current Access Token.</returns>
        IComAccessToken GetAccessToken();

        /// <summary>
        /// Requests a new access token from the server before the current token expires.
        /// </summary>
        /// <returns>Access Token.</returns>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysTokenException"></exception>
        IComAccessToken Refresh();

        /// <summary>
        /// Localizes the specified resource key for the current MetasysClient locale or specified culture.
        /// </summary>
        /// <remarks>
        /// The resource parameter must be the key of a Metasys enumeration resource,
        /// otherwise no translation will be found.
        /// </remarks>
        /// <param name="resource">The key for the localization resource.</param>
        /// <param name="cultureInfo">Optional culture specification.</param>
        /// <returns>
        /// Localized string if the resource was found, the default en-US localized string if not found,
        /// or the resource parameter value if neither resource is found.
        /// </returns>
        string Localize(string resource, string cultureInfo);


        #region "Alarms" //---------------------------------------------------------------------------------------------------------------------------
         /// <summary>
        /// Retrieves a collection of alarms.
        /// </summary>
        /// <param name="alarmFilter">The alarm model to filter alarms.</param>
        /// <returns>The list of alarms with details.</returns>
        IComPagedResult GetAlarms(IComFilterAlarm alarmFilter);

       /// <summary>
        /// Retrieves the specified alarm.
        /// </summary>
        /// <param name="alarmId">The identifier of the alarm.</param>
        /// <returns>The specified alarm details.</returns>
        object GetSingleAlarm(string alarmId);

        /// <summary>
        /// Retrieve a collection of Alarm Annotations.
        /// </summary>
        /// <param name="alarmId"></param>
        /// <returns></returns>
        object GetAlarmAnnotations(string alarmId);

        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <param name="alarmFilter">The alarm model to filter alarms.</param>
        /// <returns>The list of alarms for the specified object.</returns>
        IComPagedResult GetAlarmsForObject(string objectId, IComFilterAlarm alarmFilter);

        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the network device.</param>
        /// <param name="alarmFilter">The alarm model to filter alarms.</param>
        /// <returns>The list of alarms for the specified object.</returns>
        IComPagedResult GetAlarmsForNetworkDevice(string networkDeviceId, IComFilterAlarm alarmFilter);

        /// <summary>
        /// Acknowledge an Alarm.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="annontationText"></param>
        /// <returns></returns>
        void AcknowledgeAlarm(string id, string annontationText);


        /// <summary>
        /// Discard an Alarm.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="annontationText"></param>
        /// <returns></returns>
        void DiscardAlarm(string id, string annontationText);

        #endregion


        #region "Audits" //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves a collection of audits.
        /// </summary>
        /// <param name="auditFilter">The audit model to filter audits.</param>
        /// <returns>The list of audits with details.</returns>
        IComPagedResult GetAudits(IComAuditFilter auditFilter);

        /// <summary>
        /// Retrieves the specified audit.
        /// </summary>
        /// <param name="auditId">The identifier of the audit.</param>
        /// <returns>The specified audit details.</returns>
        object GetSingleAudit(string auditId);

        /// <summary>
        /// Retrieve a collection of Audit Annotations.
        /// </summary>
        /// <param name="auditId"></param>
        /// <returns>The list of Audit Annotations</returns>
        object GetAuditAnnotations(string auditId);

        /// <summary>
        /// Discard an Audit.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="annontationText"></param>
        /// <returns></returns>
        void DiscardAudit(string id, string annontationText);

        /// <summary>
        /// Discard many Audit given a list of requests containing the Id of the Audits and the text for the Annotations.
        /// </summary>
        /// <param name="requests">List of BatchRequestParam to specify the id of the audits and the text of the annotations to discard.</param>
        /// <returns>A list of BatchRequestParam with all the specified attributes.</returns>
        string[] DiscardAuditMultiple([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] requests);

        /// <summary>
        /// Add an Audit Annotation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        void AddAuditAnnotation(string id, string text);

        /// <summary>
        /// Add many Annotations given a list of requests containing the Id of the Audits and the text of the Annotations.
        /// </summary>
        /// <param name="requests">List of BatchRequestParam to specify the id of the audits and the text of the annotations to add.</param>
        /// <returns>A list of BatchRequestParam with all the specified attributes.</returns>
        string[] AddAuditAnnotationMultiple([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] requests);

        /// <summary>
        /// Retrieves a collection of audits for the specified object.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <param name="auditFilter">The filter to be applied to audit list.</param>
        /// <returns>The list of audit with details.</returns>
        IComPagedResult GetAuditsForObject(string objectId, IComAuditFilter auditFilter);
        #endregion


        #region "Enumerations" //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieve the list of all the enumeration names.
        /// </summary>
        /// <returns>The list of enumeration names</returns>
        object GetEnumerations();

        /// <summary>
        /// Create a custom enumeration.
        /// </summary>
        /// <param name="name">The name of the new custom enumeration</param>
        /// <param name="values">Array of string values representing the enumerated set of values of the new custom enumeration</param>
        /// <returns></returns>
        /// <remarks>
        /// The identifier of the new custom enumeration will be set automatically by the API. It can be retrieved using the method 'GetEnumerations()'.
        /// </remarks>
        void CreateCustomEnumeration(string name, string[] values);

        /// <summary>
        /// Retrieve the enumated values of a specific enumeration set.
        /// </summary>
        /// <param name="id">The identifier of the enumeration set</param>
        /// <returns>The list of enumeratee values</returns>
        object GetEnumerationValues(string id);

        /// <summary>
        /// Edit an existing custom enumeration.
        /// </summary>
        /// <param name="id">The identifier of the existing custom enumeration</param>
        /// <param name="name">The new name of the existing custom enumeration</param>
        /// <param name="values">Array of string values representing the new set of values of the existing custom enumeration</param>
        /// <returns></returns>
        void EditCustomEnumeration(string id, string name, string[] values);

        /// <summary>
        /// Replace an existing custom enumeration.
        /// </summary>
        /// <param name="id">The identifier of the existing custom enumeration</param>
        /// <param name="name">The name that replaces the existing one</param>
        /// <param name="values">Array of string values that replace the existing set of values of the existing custom enumeration</param>
        /// <returns></returns>
        void ReplaceCustomEnumeration(string id, string name, string[] values);

        /// <summary>
        /// Delete an enumeration. Only custom enumerations may be deleted.
        /// </summary>
        /// <param name="id">The identifier (name) of the custom enumeration</param>
        /// <returns></returns>
        void DeleteCustomEnumeration(string id);
        #endregion


        #region "Equipments" //-----------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the specified equipment.
        /// </summary>
        /// <param name="equipmentId">The identifier of the specific equipment.</param>
        /// <returns>The specified equipment details.</returns>
        object GetSingleEquipment(string equipmentId);

        /// <summary>
        /// Gets all network devices.
        /// </summary>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        object GetEquipment(int? page = null, int? pageSize = null);

        /// <summary>
        /// Retrieves the collection of equipment instances that are hosted by the specified network device or its children.
        /// </summary>
        /// <param name="networkDeviceId"></param>
        /// <returns></returns>
        object GetEquipmentsHostedByNetworkDevice(string networkDeviceId);

        /// <summary>
        /// Gets all points for the given Equipment
        /// </summary>
        /// <param name="equipmentId">The Guid of the equipment.</param>
        /// <param name="ReadAttributeValue">Set to false if you would not read Points Attribute Value.</param>
        /// <returns></returns>
        object GetEquipmentPoints(string equipmentId, bool ReadAttributeValue = true);

        /// <summary>
        /// Retrieves the equipment served by the specified equipment instance.
        /// </summary>
        /// <param name="equipmentId"></param>
        /// <returns></returns>
        object GetEquipmentsServedByEquipment(string equipmentId);

        /// <summary>
        /// Retrieves the collection of equipments that serve the specified equipment instance.
        /// </summary>
        /// <param name="equipmentId"></param>
        /// <returns></returns>
        object GetEquipmentsServingAnEquipment(string equipmentId);

        /// <summary>
        ///  Retrieves the collection of equipment that serve the specified space.
        /// </summary>
        /// <param name="spaceId"></param>
        /// <returns></returns>
        object GetEquipmentsServingASpace(string spaceId);
        /// <summary>
        /// Retrieves the collection of equipment that serve the specified space.
        /// </summary>
        /// <param name="spaceId"></param>
        /// <returns></returns>
        object GetSpaceEquipment(string spaceId);
        #endregion


        #region "NetworkDevices" //----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the specified network device.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the specific network device.</param>
        /// <returns>The specified network device details.</returns>
        object GetSingleNetworkDevice(string networkDeviceId);

        /// <summary>
        /// Gets all network devices.
        /// </summary>
        /// <param name="type">Optional type number as a string</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        object GetNetworkDevices(string type = null);

        /// <summary>
        /// Retrieves the collection of network devices that are children of the specified network device.
        /// </summary>
        /// <param name="networkDeviceId">The identifier (GUID) of the specified network device</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        object GetNetworkDevicesChildren(string networkDeviceId);

        /// <summary>
        /// Retrieves the collection of network devices that host the specified equipment instance, along with the parents of those network devices.
        /// </summary>
        /// <param name="equipmentId">The identifier (GUID) of the specified equipment instance</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        object GetNetworkDevicesHostingAnEquipment(string equipmentId);

        /// <summary>
        /// Retrieves the collection of network devices that are serving the specified space.
        /// </summary>
        /// <param name="spaceId">The identifier (GUID) of the specified space</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        object GetNetworkDevicesServingASpace(string spaceId);

        /// <summary>
        /// Gets all available network device types.
        /// </summary>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        object GetNetworkDeviceTypes(string type = null);
        #endregion


        #region "Objects" //-------------------------------------------------------------------------------------------------------------------------
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
        object GetObjects(string id, int levels = 1);

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
        string GetObjectIdentifier(string itemReference);

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
        IComVariant ReadProperty(string id, string attributeName);

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
        object ReadPropertyMultiple([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] ids, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] attributeNames);

        /// <summary>
        /// Write a single attribute given the Guid of the object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <param name="newValue"></param>
        /// <exception cref="MetasysHttpException"></exception>
        void WriteProperty(string id, string attributeName, string newValue);

        /// <summary>
        /// Write to many attribute values given the Guids of the objects.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="attributes"></param>
        /// <param name="attributeValues">The (attribute, value) pairs split in a array.</param>
        /// <exception cref="MetasysHttpException"></exception>
        void WritePropertyMultiple([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] ids, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] attributes, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] attributeValues);

        /// <summary>
        /// Get all available commands given the Guid of the object.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of Commands.</returns>
        object GetCommands(string id);

        /// <summary>
        /// Send a command to an object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <param name="values"></param>
        /// <exception cref="MetasysHttpException"></exception>
        void SendCommand(string id, string command, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] values = null);



        /// <summary>
        /// Attempts to get the enumeration key of a given en-US localized command.
        /// </summary>
        /// <remarks>
        /// The resource parameter must be the value of a Metasys commandIdEnumSet en-US value,
        /// otherwise no key will be found.
        /// </remarks>
        /// <param name="resource">The en-US value for the localization resource.</param>
        /// <returns>
        /// The enumeration key of the en-US command if found, original resource if not.
        /// </returns>
        string GetCommandEnumeration(string resource);

        /// <summary>
        /// Attempts to get the enumeration key of a given en-US localized objectType.
        /// </summary>
        /// <remarks>
        /// The resource parameter must be the value of a Metasys objectTypeEnumSet en-US value,
        /// otherwise no key will be found.
        /// </remarks>
        /// <param name="resource">The en-US value for the localization resource.</param>
        /// <returns>
        /// The enumeration key of the en-US objectType if found, original resource if not.
        /// </returns>
        string GetObjectTypeEnumeration(string resource);
        #endregion


        #region "Spaces" //--------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the specified space.
        /// </summary>
        /// <param name="spaceId">The identifier of the specific space.</param>
        /// <returns>The specified space details.</returns>
        object GetSingleSpace(string spaceId);

        /// <summary>
        /// Gets all network devices.
        /// </summary>
        /// <param name="type">Optional type number as a string</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        object GetSpaces(string type = null);

        /// <summary>
        /// Gets children spaces of the given space.
        /// </summary>
        /// <param name="id">The GUID of the parent space.</param>
        object GetSpaceChildren(string id);

        /// <summary>
        /// Retrieves the collection of spaces served by the specified equipment instance.
        /// </summary>
        /// <param name="equipmentId">The GUID of the specified equipment instance.</param>
        object GetSpacesServedByEquipment(string equipmentId);

        /// <summary>
        /// Retrieves the collection of spaces served by the specified network device. 
        /// </summary>
        /// <param name="networkDeviceId">The GUID of the specified network device.</param>
        object GetSpacesServedByNetworkDevice(string networkDeviceId);

        /// <summary>
        /// Gets all space types.
        /// </summary>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysObjectTypeException"></exception>
        object GetSpaceTypes();
        #endregion


        #region "Trends" //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves a collection of attributes under the specified object for which samples are available.
        /// </summary>
        /// <param name="id">The identifier of the object</param>
        /// <returns>The list of attributes for the specified object for which samples are available.</returns>
        object GetTrendedAttributes(string id);

        /// <summary>
        /// Retrieves a collection of samples for the specified object attribute during a particular date and time range.
        /// </summary>
        /// <param name="objectId">The identifier of the object</param>
        /// <param name="attributeId">The identifier of the attribute for which to retrieve sample information</param>
        /// <param name="filter">Filter for a timeline based request</param>
        /// <returns>The list of samples for the specified objectduring a particular date and time range.</returns>
        IComPagedResult GetSamples(string objectId, int attributeId, IComTimeFilter filter);

        /// <summary>
        /// Retrieves a collection of samples for the specified object attribute during a particular date and time range.
        /// </summary>
        /// <param name="objectId">The identifier of the object</param>
        /// <param name="attributeName">Name of the attribute for which to retrieve sample information</param>
        /// <param name="filter">Filter for a timeline based request</param>
        /// <returns>The list of samples for the specified objectduring a particular date and time range.</returns>
        IComPagedResult GetSamples(string objectId, String attributeName, IComTimeFilter filter);

        /// <summary>
        /// Retrieves a collection of attributes under the specified netwok device for which samples are available.
        /// </summary>
        /// <param name="id">The identifier of the network device</param>
        /// <returns>The list of attributes for the specified network device for which samples are available.</returns>
        object GetNetDevTrendedAttributes(string id);

        /// <summary>
        /// Retrieves a collection of samples for the specified network device attribute during a particular date and time range.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the object</param>
        /// <param name="attributeId">The identifier of the attribute for which to retrieve sample information</param>
        /// <param name="filter">Filter for a timeline based request</param>
        /// <returns>The list of samples for the specified objectduring a particular date and time range.</returns>
        IComPagedResult GetNetDevSamples(string networkDeviceId, int attributeId, IComTimeFilter filter);

        /// <summary>
        /// Retrieves a collection of samples for the specified network device attribute during a particular date and time range.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the object</param>
        /// <param name="attributeName">Name of the attribute for which to retrieve sample information</param>
        /// <param name="filter">Filter for a timeline based request</param>
        /// <returns>The list of samples for the specified objectduring a particular date and time range.</returns>
        IComPagedResult GetNetDevSamples(string networkDeviceId, String attributeName, IComTimeFilter filter);
        #endregion


        #region "Streams" //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Return the list of Request IDs.
        /// </summary>
        string[] GetStreamRequestIds();

        /// <summary>
        /// Start the method that reads the COV values using the stream mechanism.
        /// </summary>
        void StartReadingStreamCOV(string id);

        /// <summary>
        /// Start the method that reads multiple COV values using the stream mechanism.
        /// </summary>
        void StartReadingStreamCOVs([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] ids);

        /// <summary>
        /// Stop reading COV stream Values.
        /// </summary>
        void StopReadingStreamCOV(string requestId);

        /// <summary>
        /// Return a single COV values (first of the list)
        /// </summary>
        IComStreamMessage GetStreamCOV();

        /// <summary>
        /// Return the list of COV values
        /// </summary>
        object GetStreamCOVList();

        ///// <summary>
        ///// Event fired when a COV value changes
        ///// </summary>
        //event EventHandler<StreamEventArgs> StreamCOVValueChanged;
        


        /// <summary>
        /// Start the method that collects the Alarms using the stream mechanism.
        /// </summary>
        void StartCollectingStreamAlarms();

        /// <summary>
        /// Stop the method that collects the Alarms using the stream mechanism.
        /// </summary>
        void StopCollectingStreamAlarms(string requestId);

        /// <summary>
        /// Return the list of Alarm events
        /// </summary>
        object GetAlarmStreamEvents();

        ///// <summary>
        ///// Event fired when an Alarm event occurs
        ///// </summary>
        //event EventHandler<StreamEventArgs> StreamAlarmOccurred;



        /// <summary>
        /// Start the method that collects the Audits using the stream mechanism.
        /// </summary>
        void StartCollectingStreamAudits();

        /// <summary>
        /// Stop the method that collects the Audits using the stream mechanism.
        /// </summary>
        void StopCollectingStreamAudits(string requestId);

        /// <summary>
        /// Return the list of Audit events
        /// </summary>
        object GetAuditStreamEvents();

        ///// <summary>
        ///// Event fired when an Alarm event occurs
        ///// </summary>
        //event EventHandler<StreamEventArgs> StreamAuditOccurred;



        /// <summary>
        /// Call the related API to keep the Stream Alive 
        /// </summary>
        void KeepStreamAlive();
        
        #endregion
















        //==================================================================================================================================

    }
}