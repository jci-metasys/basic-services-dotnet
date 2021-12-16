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
        /// Attempts to login to the given host, using Credential Manager target.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="refresh"></param>
        /// <returns></returns>
        IComAccessToken TryLoginWithCredMan(string target, bool refresh = true);

        /// <summary>
        /// Requests a new access token from the server before the current token expires.
        /// </summary>
        /// <returns>Access Token.</returns>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysTokenException"></exception>
        IComAccessToken Refresh();

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
        object ReadPropertyMultiple([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]string[] ids, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] attributeNames);

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
        /// Gets all network devices.
        /// </summary>
        /// <param name="type">Optional type number as a string</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        object GetNetworkDevices(string type = null);

        /// <summary>
        /// Gets all available network device types.
        /// </summary>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        object GetNetworkDeviceTypes(string type = null);

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
        string GetObjectIdentifier(string itemReference);

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
        /// Gets all space types.
        /// </summary>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysObjectTypeException"></exception>
        object GetSpaceTypes();

        /// <summary>
        ///  Gets all Equipment for the given space
        /// </summary>
        /// <param name="spaceId"></param>
        /// <returns></returns>
        object GetSpaceEquipment(string spaceId);

        /// <summary>
        /// Gets all network devices.
        /// </summary>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        object GetEquipment();

        /// <summary>
        /// Gets all points for the given Equipment
        /// </summary>
        /// <param name="equipmentId">The Guid of the equipment.</param>
        /// <param name="ReadAttributeValue">Set to false if you would not read Points Attribute Value.</param>
        /// <returns></returns>
        object GetEquipmentPoints(string equipmentId, bool ReadAttributeValue = true);


        /// <summary>
        /// Retrieves the specified alarm.
        /// </summary>
        /// <param name="alarmId">The identifier of the alarm.</param>
        /// <returns>The specified alarm details.</returns>
        object GetSingleAlarm(string alarmId);

        /// <summary>
        /// Retrieves a collection of alarms.
        /// </summary>
        /// <param name="alarmFilter">The alarm model to filter alarms.</param>
        /// <returns>The list of alarms with details.</returns>
        IComPagedResult GetAlarms(IComFilterAlarm alarmFilter);

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
        /// Retrieves the specified audit.
        /// </summary>
        /// <param name="auditId">The identifier of the audit.</param>
        /// <returns>The specified audit details.</returns>
        object GetSingleAudit(string auditId);

        /// <summary>
        /// Retrieves a collection of audits.
        /// </summary>
        /// <param name="auditFilter">The audit model to filter audits.</param>
        /// <returns>The list of audits with details.</returns>
        IComPagedResult GetAudits(IComAuditFilter auditFilter);

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

        /// <summary>
        /// Start the method that reads the COV values using the stream mechanism.
        /// </summary>
        void StartReadingStreamCOVValue(string id);

        /// <summary>
        /// Start the method that reads multiple COV values using the stream mechanism.
        /// </summary>
        void StartReadingStreamCOVValues([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] string[] ids);

        /// <summary>
        /// Stop reading COV stream Values.
        /// </summary>
        void StopReadingStreamCOVValues(string requestId);

        /// <summary>
        /// Return the list of COV values
        /// </summary>
        List<StreamMessage> GetCOVValues();
    }
}