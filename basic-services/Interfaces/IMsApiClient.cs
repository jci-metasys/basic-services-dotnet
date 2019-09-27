using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices.Interfaces
{
    public interface IMsApiClient
    {
        (string Token, DateTime ExpirationDate) TryLogin(string username, string password, bool refresh = true);
        Task<(string Token, DateTime ExpirationDate)> TryLoginAsync(string username, string password, bool refresh = true);
        (string Token, DateTime ExpirationDate) Refresh();
        Task<Guid> GetObjectIdentifierAsync(string itemReference);
        Task<Variant> ReadPropertyAsync(Guid id, string attributeName);       
        Task<IEnumerable<(Guid Id, IEnumerable<Variant> Variants)>> ReadPropertyMultipleAsync(IEnumerable<Guid> ids,
              IEnumerable<string> attributeNames);
        Task<(string Token, DateTime ExpirationDate)> RefreshAsync();
        (string Token, DateTime ExpirationDate) GetAccessToken();
        Guid GetObjectIdentifier(string itemReference);
        Variant ReadProperty(Guid id, string attributeName);
        IEnumerable<(Guid Id, IEnumerable<Variant> Variants)> ReadPropertyMultiple(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames);
        void WriteProperty(Guid id, string attributeName, object newValue, string priority = null);
        Task WritePropertyAsync(Guid id, string attributeName, object newValue, string priority = null);
        void WritePropertyMultiple(IEnumerable<Guid> ids,
            IEnumerable<(string Attribute, object Value)> attributeValues, string priority = null);
        Task WritePropertyMultipleAsync(IEnumerable<Guid> ids,
            IEnumerable<(string Attribute, object Value)> attributeValues, string priority = null);
        IEnumerable<Command> GetCommands(Guid id);
        Task<IEnumerable<Command>> GetCommandsAsync(Guid id);
        void SendCommand(Guid id, string command, IEnumerable<object> values = null);
        IEnumerable<MetasysObject> GetNetworkDevices(string type = null);
        Task<IEnumerable<MetasysObject>> GetNetworkDevicesAsync(string type = null);
        IEnumerable<(int Id, string Description)> GetNetworkDeviceTypes();
        Task<IEnumerable<(int Id, string Description)>> GetNetworkDeviceTypesAsync();
        IEnumerable<MetasysObject> GetObjects(Guid id);
        Task<IEnumerable<MetasysObject>> GetObjectsAsync(Guid id);
    }
}
