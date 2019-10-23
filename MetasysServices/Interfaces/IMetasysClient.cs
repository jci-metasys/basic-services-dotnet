using JohnsonControls.Metasys.BasicServices.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices.Interfaces
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
        /// Given the Item Reference of an object, returns the object identifier.
        /// </summary>
        Guid? GetObjectIdentifier(string itemReference);

        /// <summary>
        /// Given the Item Reference of an object, returns the object identifier asynchronously.
        /// </summary>
        Task<Guid?> GetObjectIdentifierAsync(string itemReference);

        /// <summary>
        /// Read one attribute value given the Guid of the object.
        /// </summary>
        Variant? ReadProperty(Guid id, string attributeName);

        /// <summary>
        /// Read one attribute value given the Guid of the object asynchronously.
        /// </summary>
        Task<Variant?> ReadPropertyAsync(Guid id, string attributeName);

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
    }
}
