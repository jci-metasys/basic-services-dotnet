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
        Task<Variant> ReadPropertyAsync(Guid id, string attributeName);       
        Task<IEnumerable<VariantMultiple>> ReadPropertyMultipleAsync(IEnumerable<Guid> ids,
              IEnumerable<string> attributeNames);
        Task<AccessToken> RefreshAsync();
        AccessToken GetAccessToken();
        Guid GetObjectIdentifier(string itemReference);
        Variant ReadProperty(Guid id, string attributeName);
        IEnumerable<VariantMultiple> ReadPropertyMultiple(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames);
        string Localize(string resource, CultureInfo cultureInfo = null );

        CultureInfo Culture { get; set; }
    }
}
