﻿using EvtSource;
using Flurl.Http;
using JohnsonControls.Metasys.BasicServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Defines methods to provide Streams infos for endpoints of the Metasys Stream API.
    /// </summary>
    public interface IStreamService : IBasicService
    {
        /// <summary>
        /// Stream channel result
        /// </summary>
        ChannelReader<StreamMessage> ResultChannel { get; }

        /// <summary>
        /// Connect method
        /// </summary>
        Task<bool> ConnectAsync();

        /// <summary>
        /// Subscribe method
        /// </summary>
        Task<string> SubscribeAsync(Guid requestId, string method, string relativeUrl, Dictionary<string, string> query = null, dynamic body = null);

        /// <summary>
        /// Unsubscribe method
        /// </summary>
        Task UnsubscribeAsync(Guid requestId);

        /// <summary>
        /// Access Token
        /// </summary>
        AccessToken AccessToken { get; set; }

        /// <summary>
        /// Add a subscription for a COV (presentValue).
        /// </summary>
        void LoadCOVSubscriptions(Guid id);

        /// <summary>
        /// Add a list of subscriptions for COV (presentValue).
        /// </summary>
        void LoadCOVSubscriptions(IEnumerable<Guid> ids);

        /// <summary>
        /// Add a subscription for an Activity according to the ActivityType
        /// </summary>
        void LoadActivitySubscriptions(string activityType);

        /// <summary>
        /// Call the related API (with a new Token) to keep the Stream Alive 
        /// </summary>
        Task KeepAlive(AccessToken accessToken);

        /// <summary>
        /// Return the list of request Ids
        /// </summary>
        List<Guid> GetRequestIds();

        /// <summary>
        /// Dispose method
        /// </summary>
        void Dispose();


        /// <summary>
        /// Start reading a COV value from the stream
        /// </summary>
        void StartReadingCOV(Guid id);

        /// <summary>
        /// Start reading a COV value from the stream
        /// </summary>
        Task StartReadingCOVAsync(Guid id);

        /// <summary>
        /// Start reading multiple COV values from the stream
        /// </summary>
        Task StartReadingCOVAsync(IEnumerable<Guid> ids);

        /// <summary>
        /// Stop reading COV Stream Value.
        /// </summary>
        void StopReadingCOV(Guid requestId);

        /// <summary>
        /// Return the list of COV values
        /// </summary>
        List<StreamMessage> GetCOVList();

        /// <summary>
        /// Return the first value of COV values
        /// </summary>
        StreamMessage GetCOV();

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

        /// <summary>
        /// Event fired when an HeartBeat occurs
        /// </summary>
        event EventHandler<EventSourceMessageEventArgs> HeartBeatOccurred;

    }
}
