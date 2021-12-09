using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Channels;
using System.Threading.Tasks;
using Flurl.Http;
using JohnsonControls.Metasys.BasicServices.Stream;

namespace JohnsonControls.Metasys.BasicServices.Stream
{
    /// <summary>
    /// Defines methods to provide Streams infos for endpoints of the Metasys Stream API.
    /// </summary>

    public interface IStreamService : IBasicService
    {
        ChannelReader<StreamMessage> ResultChannel { get; }
        Task<bool> ConnectAsync();
        Task<string> SubscribeAsync(Guid requestId, string method, string relativeUrl, Dictionary<string, string> query = null, dynamic body = null);
        Task UnsubscribeAsync(Guid requestId);
        AccessToken AccessToken { get; set; }
        string _token { get; set; }

        void LoadCOVSubscriptions(Guid id);

        void LoadCOVSubscriptions(IEnumerable<Guid> ids);

        List<Guid> GetRequestIds();

        List<StreamMessage> UpdateCOVStremValuesList(List<StreamMessage> values, StreamMessage msg);
    }
}
