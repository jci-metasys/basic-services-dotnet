using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Channels;
using System.Threading.Tasks;
using Flurl.Http;
using JohnsonControls.Metasys.BasicServices;

namespace JohnsonControls.Metasys.BasicServices
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

        void LoadActivitySubscriptions(string activityType);

        List<Guid> GetRequestIds();

        List<StreamMessage> UpdateCOVStreamValuesList(List<StreamMessage> values, StreamMessage msg);

        List<StreamMessage> UpdateAlarmStreamValuesList(List<StreamMessage> values, StreamMessage msg, int maxNumber);

        List<StreamMessage> UpdateAuditStreamValuesList(List<StreamMessage> values, StreamMessage msg, int maxNumber);


        /// <summary>
        /// Start reading a COV value from the stream
        /// </summary>
        Task StartReadingCOVValueAsync(Guid id);

        /// <summary>
        /// Start reading the COV values from the stream
        /// </summary>
        Task StartReadingCOVValuesAsync(IEnumerable<Guid> ids);

        /// <summary>
        /// Stop reading COV Stream Value.
        /// </summary>
        void StopReadingCOVValues(Guid requestId);

        /// <summary>
        /// Return the list of COV values
        /// </summary>
        List<StreamMessage> GetCOVValues();

        /// <summary>
        /// Return the first value of COV values
        /// </summary>
        StreamMessage GetCOVValue();

        /// <summary>
        /// Event fired when a COV value changes
        /// </summary>
        event EventHandler<StreamEventArgs> COVValueChanged;


        /// <summary>
        /// Start collecting the Alarm events from the stream
        /// </summary>
        Task StartCollectingAlarmsAsync(int maxNumber = 100);

        /// <summary>
        /// Stop collecting Alarm events from the stream
        /// </summary>
        void StopCollectingAlarms(Guid requestId);

        /// <summary>
        /// Return the list of Alarm events
        /// </summary>
        List<StreamMessage> GetAlarmEvents();

        /// <summary>
        /// Event fired when an Alarm event occurs
        /// </summary>
        event EventHandler<StreamEventArgs> AlarmOccurred;


        /// <summary>
        /// Start collecting the Audit events from the stream
        /// </summary>
        Task StartCollectingAuditsAsync(int maxNumber = 100);

        /// <summary>
        /// Stop collecting Audit events from the stream
        /// </summary>
        void StopCollectingAudits(Guid requestId);

        /// <summary>
        /// Return the list of Audit events
        /// </summary>
        List<StreamMessage> GetAuditEvents();

        /// <summary>
        /// Event fired when an Audit event occurs
        /// </summary>
        event EventHandler<StreamEventArgs> AuditOccurred;

    }
}
