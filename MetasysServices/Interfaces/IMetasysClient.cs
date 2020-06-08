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
        string Localize(string resource, CultureInfo cultureInfo = null);

        /// <summary>
        /// Attempts to get the enumeration key of a given en-US localized command.
        /// </summary>
        string GetCommandEnumeration(string resource);

        /// <summary>
        /// Attempts to get the enumeration key of a given en-US localized objectType.
        /// </summary>
        string GetObjectTypeEnumeration(string resource);

        /// <summary>
        /// Attempts to login to the given host and retrieve an access token.
        /// </summary>
        AccessToken TryLogin(string username, string password, bool refresh = true);

        /// <summary>
        /// Attempts to login to the given host and retrieve an access token asynchronously.
        /// </summary>
        Task<AccessToken> TryLoginAsync(string username, string password, bool refresh = true);

        /// <summary>
        /// Requests a new access token from the server before the current token expires.
        /// </summary>
        AccessToken Refresh();

        /// <summary>
        /// Requests a new access token from the server before the current token expires asynchronously.
        /// </summary>
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
        Guid GetObjectIdentifier(string itemReference);

        /// <summary>
        /// Given the Item Reference of an object, returns the object identifier asynchronously.
        /// </summary>
        Task<Guid> GetObjectIdentifierAsync(string itemReference);

        /// <summary>
        /// Read one attribute value given the Guid of the object.
        /// </summary>
        Variant ReadProperty(Guid id, string attributeName);

        /// <summary>
        /// Read one attribute value given the Guid of the object asynchronously.
        /// </summary>
        Task<Variant> ReadPropertyAsync(Guid id, string attributeName);

        /// <summary>
        /// Read many attribute values given the Guids of the objects.
        /// </summary>
        IEnumerable<VariantMultiple> ReadPropertyMultiple(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames);

        /// <summary>
        /// Read many attribute values given the Guids of the objects asynchronously.
        /// </summary>
        Task<IEnumerable<VariantMultiple>> ReadPropertyMultipleAsync(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames);

        /// <summary>
        /// Write a single attribute given the Guid of the object. 
        /// </summary>
        void WriteProperty(Guid id, string attributeName, object newValue, string priority = null);

        /// <summary>
        /// Write a single attribute given the Guid of the object asynchronously.
        /// </summary>
        Task WritePropertyAsync(Guid id, string attributeName, object newValue, string priority = null);

        /// <summary>
        /// Write to many attribute values given the Guids of the objects.
        /// </summary>
        void WritePropertyMultiple(IEnumerable<Guid> ids,

            IEnumerable<(string Attribute, object Value)> attributeValues, string priority = null);

        /// <summary>
        /// Write to many attribute values given the Guids of the objects asynchronously.
        /// </summary>
        Task WritePropertyMultipleAsync(IEnumerable<Guid> ids,

            IEnumerable<(string Attribute, object Value)> attributeValues, string priority = null);

        /// <summary>
        /// Get all available commands given the Guid of the object.
        /// </summary>
        IEnumerable<Command> GetCommands(Guid id);

        /// <summary>
        /// Get all available commands given the Guid of the object asynchronously.
        /// </summary>
        Task<IEnumerable<Command>> GetCommandsAsync(Guid id);

        /// <summary>
        /// Send a command to an object.
        /// </summary>
        void SendCommand(Guid id, string command, IEnumerable<object> values = null);

        /// <summary>
        /// Send a command to an object asynchronously.
        /// </summary>
        Task SendCommandAsync(Guid id, string command, IEnumerable<object> values = null);

        /// <summary>
        /// Gets all network devices.
        /// </summary>
        IEnumerable<MetasysObject> GetNetworkDevices(string type = null);

        /// <summary>
        /// Gets all network devices asynchronously.
        /// </summary>
        Task<IEnumerable<MetasysObject>> GetNetworkDevicesAsync(string type = null);

        /// <summary>
        /// Gets all available network device types.
        /// </summary>
        IEnumerable<MetasysObjectType> GetNetworkDeviceTypes();

        /// <summary>
        /// Gets all available network device types asynchronously.
        /// </summary>
        Task<IEnumerable<MetasysObjectType>> GetNetworkDeviceTypesAsync();

        /// <summary>
        /// Gets all child objects given a parent Guid.
        /// Level indicates how deep to retrieve objects.
        /// </summary>
        IEnumerable<MetasysObject> GetObjects(Guid id, int levels = 1, bool includeInternalObjects = false);

        /// <summary>
        /// Gets all child objects given a parent Guid asynchronously.
        /// Level indicates how deep to retrieve objects.
        /// </summary>
        Task<IEnumerable<MetasysObject>> GetObjectsAsync(Guid id, int levels = 1, bool includeInternalObjects=false);

        /// <summary>
        /// Gets all spaces.
        /// </summary>
        IEnumerable<MetasysObject> GetSpaces(SpaceTypeEnum? type = null);

        /// <summary>
        /// Gets children spaces of the given space.
        /// </summary>
        IEnumerable<MetasysObject> GetSpaceChildren(Guid spaceId);


        /// <summary>
        /// Gets all spaces asynchronously.
        /// </summary>
        Task<IEnumerable<MetasysObject>> GetSpacesAsync(SpaceTypeEnum? type = null);

        /// <summary>
        /// Gets children spaces of the given space asynchronously.
        /// </summary>
        Task<IEnumerable<MetasysObject>> GetSpaceChildrenAsync(Guid id);

        /// <summary>
        /// Gets all Equipment for the given space
        /// </summary>
        IEnumerable<MetasysObject> GetSpaceEquipment(Guid id);

        /// <summary>
        /// Gets all spaces asynchronously.
        /// </summary>
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
        IEnumerable<MetasysPoint> GetEquipmentPoints(Guid equipmentId, bool readAttributeValue = true);

        /// <summary>
        /// Gets all points for the given equipment asynchronously.
        /// </summary>
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
        AccessToken TryLogin(string credManTarget, bool refresh = true);

        /// <summary>
        /// Attempts to login to the given host using Credential Manager and retrieve an access token asynchronously.
        /// </summary>
        Task<AccessToken> TryLoginAsync(string credManTarget, bool refresh = true);
    }
}
