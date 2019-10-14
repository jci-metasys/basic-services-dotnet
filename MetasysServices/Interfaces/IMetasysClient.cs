using JohnsonControls.Metasys.BasicServices.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices.Interfaces
{
    public interface IMetasysClient
    {
        AccessToken TryLogin(string username, string password, bool refresh = true);
        Task<AccessToken> TryLoginAsync(string username, string password, bool refresh = true);
        AccessToken Refresh();
        Task<Guid> GetObjectIdentifierAsync(string itemReference);
        Task<Variant> ReadPropertyAsync(Guid id, string attributeName, bool throwsNotFoundException = true);       
        Task<IEnumerable<VariantMultiple>> ReadPropertyMultipleAsync(IEnumerable<Guid> ids,
              IEnumerable<string> attributeNames, bool throwsNotFoundException = false);
        Task<AccessToken> RefreshAsync();
        AccessToken GetAccessToken();
        Guid GetObjectIdentifier(string itemReference);
        Variant ReadProperty(Guid id, string attributeName, bool throwsNotFoundException = true);
        IEnumerable<VariantMultiple> ReadPropertyMultiple(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames, bool throwsNotFoundException = false);
        string Localize(string resource, CultureInfo cultureInfo = null );

        CultureInfo Culture { get; set; }
        void WriteProperty(Guid id, string attributeName, object newValue, string priority = null);

        Task WritePropertyAsync(Guid id, string attributeName, object newValue, string priority = null);

        void WritePropertyMultiple(IEnumerable<Guid> ids,

            IEnumerable<(string Attribute, object Value)> attributeValues, string priority = null);

        Task WritePropertyMultipleAsync(IEnumerable<Guid> ids,

            IEnumerable<(string Attribute, object Value)> attributeValues, string priority = null);

        IEnumerable<Command> GetCommands(Guid id);

        Task<IEnumerable<Command>> GetCommandsAsync(Guid id);

        void SendCommand(Guid id, string command, IEnumerable<object> values = null);
    }
}
