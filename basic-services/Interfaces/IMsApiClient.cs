using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices.Interfaces
{
    public interface IMsApiClient
    {
        Task<(string Token, DateTime ExpirationDate)> TryLoginAsync(string username, string password, bool refresh = true);
        Task<Guid> GetObjectIdentifierAsync(string itemReference);
        Task<Variant> ReadPropertyAsync(Guid id, string attributeName);       
        Task<IEnumerable<(Guid Id, IEnumerable<Variant> Variants)>> ReadPropertyMultipleAsync(IEnumerable<Guid> ids,
              IEnumerable<string> attributeNames);
    }
}
