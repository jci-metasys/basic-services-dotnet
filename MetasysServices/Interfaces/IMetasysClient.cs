using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// An HTTP client for consuming the most commonly used endpoints of the Metasys API.
    /// </summary>
    public interface IMetasysClient
    {
        /// <summary>The current Culture Used for Metasys client localization.</summary>
        CultureInfo Culture { get; set; }

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
        string Localize(string resource, CultureInfo cultureInfo = null);

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
        /// Attempts to login to the given host and retrieve an access token.
        /// </summary>
        /// <returns>Access Token.</returns>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="refresh">Flag to set automatic access token refreshing to keep session active.</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysTokenException"></exception>
        AccessToken TryLogin(string username, string password, bool refresh = true);

        /// <summary>
        /// Attempts to login to the given host and retrieve an access token asynchronously.
        /// </summary>
        /// <returns>Asynchronous Task Result as Access Token.</returns>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="refresh">Flag to set automatic access token refreshing to keep session active.</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysTokenException"></exception>
        Task<AccessToken> TryLoginAsync(string username, string password, bool refresh = true);

        /// <summary>
        /// Requests a new access token from the server before the current token expires.
        /// </summary>
        /// <returns>Access Token.</returns>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysTokenException"></exception>
        AccessToken Refresh();

        /// <summary>
        /// Requests a new access token from the server before the current token expires asynchronously.
        /// </summary>
        /// <returns>Asynchronous Task Result as Access Token.</returns>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysTokenException"></exception>
        Task<AccessToken> RefreshAsync();

        /// <summary>
        /// Returns the current session access token.
        /// </summary>
        AccessToken GetAccessToken();

        /// <summary>
        /// Set the current session access token.
        /// </summary>     
        void SetAccessToken(AccessToken accessToken);

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
        Guid GetObjectIdentifier(string itemReference);

        /// <summary>
        /// Given the Item Reference of an object, returns the object identifier asynchronously.
        /// </summary>
        /// <remarks>
        /// The itemReference will be automatically URL encoded. 
        /// For repeated requests will be returned the in-line value.
        /// </remarks>
        /// <param name="itemReference"></param>
        /// <returns>
        /// Asynchronous Task Result as a Guid representing the id, or an empty Guid if errors occurred.
        /// </returns>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysGuidException"></exception>
        Task<Guid> GetObjectIdentifierAsync(string itemReference);

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
        Variant ReadProperty(Guid id, string attributeName);

        /// <summary>
        /// Read one attribute value given the Guid of the object asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>      
        /// <returns>
        /// Asynchronous Task Result as Variant if the attribute exists, null if does not exist.
        /// </returns>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpTimeoutException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysPropertyException"></exception>
        Task<Variant> ReadPropertyAsync(Guid id, string attributeName);

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
        IEnumerable<VariantMultiple> ReadPropertyMultiple(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames);

        /// <summary>
        /// Read many attribute values given the Guids of the objects asynchronously.
        /// </summary>
        /// <remarks>
        /// In order to allow method to run to completion without error, this will ignore properties that do not exist on a given object.         
        /// </remarks>
        /// <returns>
        /// Asynchronous Task Result as list of VariantMultiple with all the specified attributes (if existing).
        /// </returns>
        /// <param name="ids"></param>
        /// <param name="attributeNames"></param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysPropertyException"></exception>
        Task<IEnumerable<VariantMultiple>> ReadPropertyMultipleAsync(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames);

        /// <summary>
        /// Write a single attribute given the Guid of the object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <param name="newValue"></param>
        /// <param name="priority">Write priority as an enumeration from the writePriorityEnumSet.</param>
        /// <exception cref="MetasysHttpException"></exception>
        void WriteProperty(Guid id, string attributeName, object newValue, string priority = null);

        /// <summary>
        /// Write a single attribute given the Guid of the object asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <param name="newValue"></param>
        /// <param name="priority">Write priority as an enumeration from the writePriorityEnumSet.</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <returns>Asynchronous Task Result.</returns>
        Task WritePropertyAsync(Guid id, string attributeName, object newValue, string priority = null);

        /// <summary>
        /// Write to many attribute values given the Guids of the objects.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="attributeValues">The (attribute, value) pairs.</param>
        /// <param name="priority">Write priority as an enumeration from the writePriorityEnumSet.</param>
        /// <exception cref="MetasysHttpException"></exception>
        void WritePropertyMultiple(IEnumerable<Guid> ids,

            IEnumerable<(string Attribute, object Value)> attributeValues, string priority = null);

        /// <summary>
        /// Write to many attribute values given the Guids of the objects asynchronously.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="attributeValues">The (attribute, value) pairs.</param>
        /// <param name="priority">Write priority as an enumeration from the writePriorityEnumSet.</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <returns>Asynchronous Task Result.</returns>
        Task WritePropertyMultipleAsync(IEnumerable<Guid> ids,

            IEnumerable<(string Attribute, object Value)> attributeValues, string priority = null);

        /// <summary>
        /// Get all available commands given the Guid of the object.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of Commands.</returns>
        IEnumerable<Command> GetCommands(Guid id);

        /// <summary>
        /// Get all available commands given the Guid of the object asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <returns>Asynchronous Task Result as list of Commands.</returns>
        Task<IEnumerable<Command>> GetCommandsAsync(Guid id);

        /// <summary>
        /// Send a command to an object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <param name="values"></param>
        /// <exception cref="MetasysHttpException"></exception>
        void SendCommand(Guid id, string command, IEnumerable<object> values = null);

        /// <summary>
        /// Send a command to an object asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <param name="values"></param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <returns>Asynchronous Task Result.</returns>
        Task SendCommandAsync(Guid id, string command, IEnumerable<object> values = null);

        /// <summary>
        /// Gets all network devices.
        /// </summary>
        /// <param name="type">Optional type number as a string</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        IEnumerable<MetasysObject> GetNetworkDevices(string type = null);

        /// <summary>
        /// Gets all network devices asynchronously.
        /// </summary>
        /// <param name="type">Optional type number as a string</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        Task<IEnumerable<MetasysObject>> GetNetworkDevicesAsync(string type = null);

        /// <summary>
        /// Gets all available network device types.
        /// </summary>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        IEnumerable<MetasysObjectType> GetNetworkDeviceTypes();

        /// <summary>
        /// Gets all available network device types asynchronously.
        /// </summary>
        Task<IEnumerable<MetasysObjectType>> GetNetworkDeviceTypesAsync();

        /// <summary>
        /// Gets all child objects given a parent Guid.
        /// Level indicates how deep to retrieve objects.
        /// </summary>
        /// <remarks>
        /// A level of 1 only retrieves immediate children of the parent object.
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="levels">The depth of the children to retrieve.</param>      
        /// <param name="includeInternalObjects">Set it to true to see also internal objects that are not displayed in the Metasys tree. </param>      
        /// <remarks> The flag includeInternalObjects applies since Metasys API v3. </remarks>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        IEnumerable<MetasysObject> GetObjects(Guid id, int levels = 1, bool includeInternalObjects = false);

        /// <summary>
        /// Gets all child objects given a parent Guid asynchronously.
        /// Level indicates how deep to retrieve objects.
        /// </summary>
        Task<IEnumerable<MetasysObject>> GetObjectsAsync(Guid id, int levels = 1, bool includeInternalObjects=false);

        /// <summary>
        /// Gets all spaces.
        /// </summary>
        /// <param name="type">Optional type ID belonging to SpaceTypeEnum.</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        IEnumerable<MetasysObject> GetSpaces(SpaceTypeEnum? type = null);

        /// <summary>
        /// Gets children spaces of the given space.
        /// </summary>
        /// <param name="id">The GUID of the parent space.</param>
        IEnumerable<MetasysObject> GetSpaceChildren(Guid spaceId);


        /// <summary>
        /// Gets all spaces asynchronously.
        /// </summary>
        /// <param name="type">Optional type ID belonging to SpaceTypeEnum.</param>          
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        Task<IEnumerable<MetasysObject>> GetSpacesAsync(SpaceTypeEnum? type = null);

        /// <summary>
        /// Gets children spaces of the given space asynchronously.
        /// </summary>
        /// <param name="id">The GUID of the parent space.</param>
        Task<IEnumerable<MetasysObject>> GetSpaceChildrenAsync(Guid id);

        /// <summary>
        /// Gets all Equipment for the given space
        /// </summary>
        /// <param name="spaceId"></param>
        IEnumerable<MetasysObject> GetSpaceEquipment(Guid id);

        /// <summary>
        /// Gets all spaces asynchronously.
        /// </summary>
        /// <param name="spaceId"></param>
        Task<IEnumerable<MetasysObject>> GetSpaceEquipmentAsync(Guid spaceId);

        /// <summary>
        /// Gets all spaces types.
        /// </summary>
        IEnumerable<MetasysObjectType> GetSpaceTypes();

        /// <summary>
        /// Gets all space types asynchronously.
        /// </summary>
        Task<IEnumerable<MetasysObjectType>> GetSpaceTypesAsync();

        /// <summary>
        /// Gets all equipment.
        /// </summary>
        IEnumerable<MetasysObject> GetEquipment();

        /// <summary>
        /// Gets all equipment asynchronously.
        /// </summary>
        Task<IEnumerable<MetasysObject>> GetEquipmentAsync();

        /// <summary>
        /// Gets all points for the given Equipment
        /// </summary>
        /// <param name="equipmentId">The Guid of the equipment.</param>
        /// <param name="readAttributeValue">Set to false if you would not read Points Attribute Value.</param>
        /// <remarks> Reading the Attribute Value attribute could take time depending on the number of points. </remarks>
        IEnumerable<MetasysPoint> GetEquipmentPoints(Guid equipmentId, bool readAttributeValue = true);

        /// <summary>
        /// Gets all points for the given equipment asynchronously.
        /// </summary>
        /// <remarks> Returned Points List contains PresentValue when available. </remarks>
        /// <param name="equipmentId">The Guid of the equipment.</param>
        /// <param name="readAttributeValue">Set to false if you would not read Points Attribute Value.</param>
        /// <remarks> Reading the Attribute Value could take time depending on the number of points. </remarks>
        Task<IEnumerable<MetasysPoint>> GetEquipmentPointsAsync(Guid equipmentId, bool readAttributeValue = true);

        /// <summary>
        /// Services for Trends and Samples.
        /// </summary>
        ITrendService Trends { get; set; }

        /// <summary>
        /// Services for Alarms.
        /// </summary>
        IAlarmsService Alarms { get; set; }

        /// <summary>
        /// Services for Audits.
        /// </summary>
        IAuditService Audits { get; set; }


        /// <summary>
        /// Attempts to login to the given host using Credential Manager and retrieve an access token.
        /// </summary>
        /// <param name="credManTarget">The Credential Manager target where to pick the credentials.</param>
        /// <param name="refresh">Flag to set automatic access token refreshing to keep session active.</param>
        /// <remarks> This method can be overridden by extended class with other Credential Manager implementations. </remarks>
        AccessToken TryLogin(string credManTarget, bool refresh = true);

        /// <summary>
        /// Attempts to login to the given host using Credential Manager and retrieve an access token asynchronously.
        /// </summary>
        /// <param name="credManTarget">The Credential Manager target where to pick the credentials.</param>
        /// <param name="refresh">Flag to set automatic access token refreshing to keep session active.</param>
        /// <remarks> This method can be overridden by extended class with other Credential Manager implementations. </remarks>
        Task<AccessToken> TryLoginAsync(string credManTarget, bool refresh = true);
    }
}
