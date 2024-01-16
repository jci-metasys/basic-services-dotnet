using EvtSource;
using Flurl;
using Flurl.Http;
using JohnsonControls.Metasys.BasicServices.Token;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Timers;


namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provide methods for the endpoints of the Metasys Stream API v4.
    /// </summary>
    public sealed class StreamServiceProvider : BasicServiceProvider, IDisposable,  IStreamService
    {
        private bool _isDisposed = false;

        private readonly IFlurlClient _client;
        private readonly string _serverUrl;

        private readonly HttpClientHandler _handler;
        private readonly Dictionary<Guid, SubscriptionInfo> _requestIdToSubscriptionMap = new Dictionary<Guid, SubscriptionInfo>();
        private readonly Dictionary<string, Guid> _subscriptionIdToRequestIdMap = new Dictionary<string, Guid>();
        private readonly Dictionary<string, List<Guid>> _objectAndAttrToRequestIdsMap = new Dictionary<string, List<Guid>>();
        private readonly List<Subscription> _subscriptionRequest = new List<Subscription>();
        private readonly List<Guid> _requestIds = new List<Guid>();
        private readonly TaskCompletionSource<bool> _initializeStreamTaskSource = new TaskCompletionSource<bool>();
        private readonly Channel<StreamMessage> _channel = Channel.CreateUnbounded<StreamMessage>(new UnboundedChannelOptions()
        {
            SingleReader = true,
            SingleWriter = true
        });
        private string Token { get; set; }
        private EventSourceReader _source;
        private string _streamId;
        private System.Timers.Timer _timer;

        private AccessToken accessToken;

        /// <summary>
        /// Channel result
        /// </summary>
        public ChannelReader<StreamMessage> ResultChannel => _channel.Reader;

        /// <summary>
        /// Access Token
        /// </summary>
        public  AccessToken AccessToken
        {
            get
            {
                return accessToken;
            }
            set
            {
                accessToken = value;
                if (accessToken != null)
                {
                    // set the local variable with the token value
                    Token = AccessToken.Token.Replace("Bearer ", "");
                }
            }
        }

        /// <summary>
        /// Stream Service Provider
        /// </summary>
        public StreamServiceProvider(IFlurlClient client, ApiVersion version, bool logClientErrors = true) : base(client, version, logClientErrors)
        {
            _client = client;
            _serverUrl = client.BaseUrl;
            Version = version;

            FlurlHttp.ConfigureClient(_serverUrl, x => x.Settings.HttpClientFactory = new UntrustedCertClientFactory());
            HttpClientHandler httpClientHandler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            _handler = httpClientHandler;
        }

        /// <inheritdoc/>
        public void LoadCOVSubscriptions(Guid id)
        {
            if (id != null)
            {
                var subscription = new Subscription
                {
                    RelativeUrl = "api/" + Version.ToString() + "/objects/" + id.ToString() + "/attributes/presentValue",
                    Method = "GET",
                    Body = null
                };

                _subscriptionRequest.Clear();
                _subscriptionRequest.Add(subscription);
            }
        }

        /// <inheritdoc/>
        public void LoadCOVSubscriptions(IEnumerable<Guid> ids)
        {
            if ((ids != null) && (ids.Count() > 0)) 
            {
                var body = new Newtonsoft.Json.Linq.JObject
                {
                    { "method", "GET" }
                };
                var requests = new Newtonsoft.Json.Linq.JArray();

                // Concatenate batch segment to use batch request and prepare the list of requests  
                int index = 1;
                foreach (var i in ids)
                {
                    var request = new Newtonsoft.Json.Linq.JObject
                    {
                        { "id", index.ToString() },
                        { "relativeUrl", i.ToString() + "/attributes/presentValue" }
                    };

                    requests.Add(request);
                    index += 1;
                }
                body.Add("requests", requests);

                var subscription = new Subscription
                {
                    RelativeUrl = "api/" + Version.ToString() + "/objects/batch",
                    Method = "POST",
                    Body = body
                };

                _subscriptionRequest.Clear();
                _subscriptionRequest.Add(subscription);
            }
        }

        /// <inheritdoc/>
        public void LoadActivitySubscriptions(string activityType)
        {
            var subscription = new Subscription
            {
                RelativeUrl = "api/" + Version.ToString() + "/activities",
                Method = "GET",
                Params = new Dictionary<string, string> { { "ActivityType", activityType } },
                Body = null
            };

            //_subscriptionRequest.Clear();
            _subscriptionRequest.Add(subscription);
        }

        /// <inheritdoc/>
        public List<Guid> GetRequestIds()
        {
            return _requestIds;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _isDisposed = true;
            try
            {
                // networking issues can cause a delayed exception                
                _source.Dispose();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }

            var subscriptionInfos = _requestIdToSubscriptionMap.Values.ToList();
            _ = Parallel.ForEach(
                subscriptionInfos,
                new ParallelOptions() { MaxDegreeOfParallelism = 5 }, // parallelize, but don't overwhelm the Metasys host
                async (s) =>
                {
                    try
                    {
                        await UnsubscribeInternalAsync(s);
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex.Message);
                    }
                });
            
            _channel.Writer.Complete();
        }

        /// <inheritdoc/>
        public async Task<bool> ConnectAsync()
        {
            if (_isDisposed) throw new ObjectDisposedException($"StreamingClient for server url {_serverUrl}");

            var initializeStreamTask = _initializeStreamTaskSource.Task;
            try
            {
                if (_source != null && !_source.IsDisposed && string.IsNullOrEmpty(_streamId))
                {
                    _initializeStreamTaskSource.TrySetResult(true);
                    return await initializeStreamTask;
                }

                //var tokenResponse = await _tokenProvider.GetAccessTokenAsync();
                //_token = tokenResponse.AccessToken;
                
                if (accessToken != null)
                {
                    var uri = new Uri(_serverUrl.AppendPathSegments("api", Version, "stream").SetQueryParam("access_token", Token));
                    _source = new EventSourceReader(uri, _handler);
                    _source.MessageReceived += Stream_MessageReceived;
                    _source.Disconnected += Stream_Disconnected;
                    _source.Start();
                }
            }
            catch (Exception ex)
            {
                _initializeStreamTaskSource.TrySetException(ex);
            }
            return await initializeStreamTask;
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeAsync(Guid requestId, string method, string relativeUrl, Dictionary<string, string> query = null, dynamic body= null)
        {
            string bodyContent = body != null ? JsonConvert.SerializeObject(body) : null;
            string subscriptionInfoId = "";
            try
            {
                var content = bodyContent != null
                                     ? new StringContent(bodyContent, Encoding.UTF8, "application/json")
                                     : null;

                HttpResponseMessage response = await _serverUrl
                    .AppendPathSegment(relativeUrl)
                    .SetQueryParams(query)
                    .WithHeader("METASYS-SUBSCRIBE", _streamId)
                    .WithOAuthBearerToken(Token)
                    .SendAsync(new HttpMethod(method), content);

                response.EnsureSuccessStatusCode();

                if (response.Headers.TryGetValues("METASYS-SUBSCRIPTION-LOCATION", out IEnumerable<string> streamHeaders))
                {
                    var subscriptionHeader = streamHeaders.First();
                    var subscriptionInfo = new SubscriptionInfo(subscriptionHeader);

                    CreateRequestMapping(requestId, relativeUrl, bodyContent);

                    _requestIdToSubscriptionMap.Add(requestId, subscriptionInfo);
                    _subscriptionIdToRequestIdMap.Add(subscriptionInfo.Id, requestId);
                    subscriptionInfoId = subscriptionInfo.Id;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return subscriptionInfoId;
        }

        /// <inheritdoc/>
        public async Task UnsubscribeAsync(Guid requestId)
        {
            if (_isDisposed) throw new ObjectDisposedException($"StreamingClient for server url {_serverUrl}");

            if (!_requestIdToSubscriptionMap.TryGetValue(requestId, out SubscriptionInfo subscriptionInfo))
            {
               // _logger.LogDebug($"Subscription for request {requestId} not found for server {_serverUrl}.");
                return;
            }

            _requestIdToSubscriptionMap.Remove(requestId);
            _subscriptionIdToRequestIdMap.Remove(subscriptionInfo.Id);
            var objectAttrToRemove = _objectAndAttrToRequestIdsMap.Where(x => x.Value.Contains(requestId));
            if (objectAttrToRemove.Any())
            {
                var key = objectAttrToRemove.First().Key;
                if (_objectAndAttrToRequestIdsMap.TryGetValue(key, out var requestIds))
                {
                    if (requestIds.Count == 1)
                    {
                        _objectAndAttrToRequestIdsMap.Remove(key);
                    }
                    else
                    {
                        requestIds.Remove(requestId);
                    }
                }
            }
            await UnsubscribeInternalAsync(subscriptionInfo);
        }

        /// <inheritdoc/>
        public async Task KeepAlive(AccessToken accessToken)
        {
            if (accessToken != null)
            {
                // set the local variable with the token value
                Token = accessToken.Token.Replace("Bearer ", "");
            }

            HttpResponseMessage response = await _serverUrl
                        .AppendPathSegments("api", Version, "stream", "keepalive")
                        .WithOAuthBearerToken(Token)
                        .SendAsync(HttpMethod.Get);

            response.EnsureSuccessStatusCode();
        }

        #region private methods

        private void KeepStreamAlive_old(AccessTokenResponse tokenResponse)
        {
            DateTime expireTime = tokenResponse.Expires;
            TimeSpan value = expireTime.Subtract(DateTime.UtcNow);
            var delayms = GetDelayMS(tokenResponse.Expires);

            _timer = new System.Timers.Timer(delayms)
            {
                AutoReset = true,
                Enabled = true
            };

            _timer.Elapsed += async (object sender, ElapsedEventArgs e) =>
            {
                // _logger.LogDebug($"Trying to refresh the connection  for the user on server {_serverUrl}");    
                //var refreshToken = await _tokenProvider.GetRefreshTokenAsync(_token);
                //_token = refreshToken.AccessToken;

                HttpResponseMessage response = await _serverUrl
                                        .AppendPathSegments("api", Version, "stream", "keepalive")
                                        .WithOAuthBearerToken(Token)
                                        .SendAsync(HttpMethod.Get);

                response.EnsureSuccessStatusCode();
            };
        }

        private void Stream_Disconnected(object sender, DisconnectEventArgs e)
        {
            var uriWithCurrentToken = new Uri(_serverUrl.AppendPathSegments("api", Version, "stream").SetQueryParam("access_token", Token));
            Reflector.SetField(_source, "Uri", uriWithCurrentToken);

            //_logger.LogDebug(e.Exception, $"Disconnected from server {_serverUrl}. Retrying in: {e.ReconnectDelay}");
            Task.Delay(e.ReconnectDelay);
            _source.Start();
        }

        private void Stream_MessageReceived(object sender, EventSourceMessageEventArgs e)
        {            
            if (!e.Event.ToLower().Equals("message"))
            {
                //_logger.LogDebug($"Received an event on stream for message : [{e.Event}]");
                //_logger.LogDebug("--------------------------------------------------------------------");
            }
            switch (e.Event.ToLower())
            {
                case "hello":
                    _ = HandleHelloEventAsync(e);
                    break;

                case "object.values.update":
                    _ = HandleAttibuteValueSubscriptionAsync(e);
                    break;

                case "activity.audit.new":
                case "activity.alarm.new":
                case "activity.alarm.ack":
                    _ = HandleActivitySubscriptionAsync(e);
                    break;           
                
                case "message": // streaming heartbeat - why does it come through without an "Event"?
                    break;
                
                case "object.values.heartbeat":
                    // _logger.LogDebug($"Heartbeat \"{e.Event}\" received with timestamp {e.Message}.");
                    // todo: act if heartbeat stops
                    OnHeartBeatOccurred(e);
                    break;
                
                default:
                   // _logger.LogWarning($"Got an event we don't handle yet \"{e.Event}\" with data \"{e.Message}\" from server {_serverUrl}.");
                    break;
            }
        }

        private async Task HandleActivitySubscriptionAsync(EventSourceMessageEventArgs e)
        {
            dynamic alarm = JsonConvert.DeserializeObject<ExpandoObject>(e.Message);
            var subscriptionId = alarm.subscriptionIds[0]; // FIX me, could get multiple subscription id on a message
            var newAlarm = new StreamMessage(e.Event, e.Message);
            if (!_subscriptionIdToRequestIdMap.ContainsKey(subscriptionId))
            {
               // _logger.LogWarning($"Got an alarm for subscriptionId that is not associated with a known requestId");
                return;
            }
            newAlarm.RequestId = _subscriptionIdToRequestIdMap[subscriptionId];
            newAlarm.StreamId = e.Id;
            newAlarm.SubscriptionId = subscriptionId;
            _ = JsonConvert.SerializeObject(newAlarm);

            // _logger.LogDebug($"Writing Activity to channel...");

            await _channel.Writer.WriteAsync(newAlarm);
        }

        private async Task HandleAttibuteValueSubscriptionAsync(EventSourceMessageEventArgs e)
        {
            var covObjects = JsonConvert.DeserializeObject<ExpandoObject>(e.Message);
            foreach (KeyValuePair<string, object> kvp in covObjects)
            {
                if (kvp.Key.ToLower().Equals("item"))
                {
                    var expandoDict = kvp.Value as IDictionary<string, object>;
                    var objectId = (expandoDict.ContainsKey("id")) ? expandoDict["id"] : null;
                    var attrId = expandoDict.Keys.FirstOrDefault(propName => propName != "id" && propName != "itemReference");
                    if (!string.IsNullOrEmpty(attrId) && _objectAndAttrToRequestIdsMap.ContainsKey($"{objectId}:{attrId}"))
                    {
                        foreach (var requestId in _objectAndAttrToRequestIdsMap[$"{objectId}:{attrId}"])
                        {
                            var cov = new StreamMessage(e.Event, e.Message)
                            {
                                RequestId = requestId,
                                StreamId = e.Id,
                                AttributeName = attrId
                            }; // messages missing stream id, can't correlate to specific request id
                            if (_requestIdToSubscriptionMap.TryGetValue(requestId, out var subscriptioninfo))
                                cov.SubscriptionId = subscriptioninfo.Id;
                           // _logger.LogDebug("Writing COV to channel...");
                            await _channel.Writer.WriteAsync(cov);
                        }
                    }
                    break;
                }
            }
        }

        private async Task HandleAttibuteValueSubscription2Async(EventSourceMessageEventArgs e)
        {
            String msg = e.Message;
            JObject covObjects = JObject.Parse(msg);
            if (covObjects != null)
            {
                if (covObjects.ContainsKey("item") && (covObjects["item"] != null))
                {
                    String id = GetJObjectValue(covObjects, "item", "id");
                    var objectId = (id != String.Empty) ? new Guid(id) : Guid.Empty;
                    var attrId = "presentValue";
                    if (!string.IsNullOrEmpty(attrId) && _objectAndAttrToRequestIdsMap.ContainsKey($"{objectId}:{attrId}"))
                    {
                        foreach (var requestId in _objectAndAttrToRequestIdsMap[$"{objectId}:{attrId}"])
                        {
                            var cov = new StreamMessage(e.Event, e.Message)
                            {
                                RequestId = requestId,
                                StreamId = e.Id,
                                AttributeName = attrId
                            }; // messages missing stream id, can't correlate to specific request id
                            if (_requestIdToSubscriptionMap.TryGetValue(requestId, out var subscriptioninfo))
                                cov.SubscriptionId = subscriptioninfo.Id;
                            // _logger.LogDebug("Writing COV to channel...");
                            await _channel.Writer.WriteAsync(cov);
                        }
                    }
                }
            }
        }
        private string GetJObjectValue(JObject jObj, string group, string field)
        {
            string res = string.Empty;
            try
            {
                if (jObj != null)
                {
                    if (jObj.ContainsKey(group) && (jObj[group] != null))
                    {
                        JObject grp = (JObject)jObj[group];

                        if ((grp.ContainsKey(field)) && (grp[field] != null))
                        {
                            res = grp[field].Value<string>();
                        }
                    };
                };
            }
            catch (ArgumentNullException e)
            {
                // Something went wrong on object parsing
                throw new MetasysObjectException(e);
            }
            return res;
        }

        private List<StreamMessage> UpdateCOVStreamValuesList(List<StreamMessage> values, StreamMessage msg)
        {
            if (values.Count == 0)
            {
                if (msg.Event == "object.values.update")
                {
                    values.Add(msg);
                };
            }
            else
            {
                var updated = false;
                foreach (StreamMessage m in values)
                {
                    if (m.RequestId == msg.RequestId && m.ObjectId == msg.ObjectId)
                    {
                        m.Data = msg.Data;
                        updated = true;
                        break;
                    }
                }
                if (!updated) values.Add(msg);
            }
            return values;
        }

        private List<StreamMessage> UpdateAlarmStreamValuesList(List<StreamMessage> values, StreamMessage msg, int maxNumber)
        {
            if (values.Count < maxNumber)
            {
                if (msg.Event == "activity.alarm.new" || msg.Event == "activity.alarm.ack") 
                {
                    values.Add(msg);
                };
                //if (msg.Event == "activity.alarm.new") values.Add(msg);
            }
            else
            {
                values.RemoveAt(0);
                values.Add(msg);
            }
            return values;
        }
        private List<StreamMessage> UpdateAuditStreamValuesList(List<StreamMessage> values, StreamMessage msg, int maxNumber)
        {
            if (values.Count < maxNumber)
            {
                if (msg.Event == "activity.audit.new")
                { 
                    values.Add(msg);
                } ;
            }
            else
            {
                values.RemoveAt(0);
                values.Add(msg);
            }
            return values;
        }

        private async Task HandleHelloEventAsync(EventSourceMessageEventArgs e)
        {
           // _logger.LogDebug($"Got a hello with streamId {e.Message} from server {_serverUrl}");
            _streamId = Newtonsoft.Json.Linq.JToken.Parse(e.Message).ToString();
            var st = new StreamMessage(e.Event, e.Message);
            await _channel.Writer.WriteAsync(st);
            SubscribeAllRequest();
            _initializeStreamTaskSource.TrySetResult(true);            
        }

        private void SubscribeAllRequest()
        {
            try
            {
                _subscriptionRequest.ForEach(async request =>
                {
                    var requestId = Guid.NewGuid();
                    _ = await SubscribeAsync(requestId, request.Method, request.RelativeUrl, request.Params, request.Body);
                
                    _requestIds.Add(requestId);
                });

                Thread.Sleep(3000);// wait for subcriptions to complete
                //_initializeStreamTaskSource.TrySetResult(true);

            }catch(Exception ex)
            {
                var e = ex.Message;
            }
        }

        private async Task UnsubscribeInternalAsync(SubscriptionInfo subscriptionInfo)
        {
            _ = await subscriptionInfo.Url
                .WithOAuthBearerToken(Token)
                .SendAsync(HttpMethod.Delete);
        }

        private void CreateRequestMapping(Guid requestId, string relativeUrl, string bodyContent)
        {
            // Some features put subscription id in the streaming messages, but some do not
            // For those, record for what was subscribed correlated to requestId
            if (relativeUrl.StartsWith($"api/{Version}/activities"))
            {
                // no action requred
            }
            else if (relativeUrl.StartsWith($"api/{Version}/objects/batch"))
            {
                if (!string.IsNullOrEmpty(bodyContent))
                {
                    var attributeBatch = JsonConvert.DeserializeObject<AttributeBatchModel>(bodyContent);
                    foreach (var request in attributeBatch.Requests)
                    {
                        var pieces = request.RelativeUrl.Split('/');
                        var combinedId = $"{pieces[0]}:{pieces[2]}";
                        if (!_objectAndAttrToRequestIdsMap.TryGetValue(combinedId, out _))
                        {
                            _objectAndAttrToRequestIdsMap.Add(combinedId, new List<Guid>() { requestId });
                        }
                    }
                }
            }
            else if (relativeUrl.StartsWith($"api/{Version}/objects")) // ex: api/v4/objects/9aa3f0cc-e7bb-59f2-97b1-56ad9d406051/attributes/presentValue
            {
                var pieces = relativeUrl.Split('/');
                var combinedId = $"{pieces[3]}:{pieces[5]}";
                if (!_objectAndAttrToRequestIdsMap.TryGetValue(combinedId, out _))
                {
                    _objectAndAttrToRequestIdsMap.Add(combinedId, new List<Guid>() { requestId });
                }
            }
        }

        private static int GetDelayMS(DateTime expireTime)
        {
            DateTime now = DateTime.UtcNow;
            TimeSpan delay = expireTime - now.AddSeconds(10); // minimum renew gap of 10 sec in advance
            // Renew one minute before expiration if there is more than one minute time 
            if (delay > new TimeSpan(0, 1, 0))
            {
                delay.Subtract(new TimeSpan(0, 1, 0));
            }
            if (delay <= TimeSpan.Zero)
            {
                // Token already expired
                return 0;
            }

            int delayms;
            if (delay.TotalMilliseconds > int.MaxValue)
            {
                // Delay is set to int MaxValue to do not go negative with double to int conversion.
                delayms = int.MaxValue;
            }
            else
            {
                delayms = (int)delay.TotalMilliseconds;
            }
            return delayms;
        }
        #endregion


#region "COV Values" ========================================================================================================
        /// <summary>
        /// Variable to keep the list of current COV stream messages
        /// </summary>
        private List<StreamMessage> COVValues = new List<StreamMessage>();
        /// <summary>
        /// Variable to keep the loop that updated the list of COV Stream values
        /// </summary>
        private bool KeepCOVReading = false;

        //StartReadingCOVAsync -------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public void StartReadingCOV(Guid id)
        {
            StartReadingCOVAsync(id).GetAwaiter().GetResult();
        }
        /// <inheritdoc />
        public async Task StartReadingCOVAsync(Guid id)
        {
            if (!KeepCOVReading)
            {
                COVValues.Clear();
                KeepCOVReading = true;
                LoadCOVSubscriptions(id);
                await ConnectAsync();
                UpdateCOVValues();
            }
        }

        //StartReadingCOVAsync (multiple) ---------------------------------------------------------------------------------------
        /// <inheritdoc />
        public async Task StartReadingCOVAsync(IEnumerable<Guid> ids)
        {
            if (!KeepCOVReading)
            {
                COVValues.Clear();
                KeepCOVReading = true;
                LoadCOVSubscriptions(ids);
                if (_source == null)
                {
                    await ConnectAsync();
                }
                else
                {
                    SubscribeAllRequest();
                }
                UpdateCOVValues();
            }
        }

        //StopReadingCOVValues ------------------------------------------------------------------------------------------------------
        /// <inheritdoc />
        public void StopReadingCOV(Guid requestId)
        {
            if (KeepCOVReading)
            {
                KeepCOVReading = false;
                _ = UnsubscribeAsync(requestId);
            }
        }

        //GetCOVList --------------------------------------------------------------------------------------------------------------
        /// <inheritdoc />
        public List<StreamMessage> GetCOVList()
        {
            return COVValues;
        }

        //GetCOVValue ---------------------------------------------------------------------------------------------------------------
        /// <inheritdoc />
        public StreamMessage GetCOV()
        {
            return COVValues.FirstOrDefault();
        }

        /// <inheritdoc />
        public event EventHandler<StreamEventArgs> COVValueChanged;
        /// <inheritdoc />
        private void OnCOVValueChanged(StreamEventArgs e)
        {
            COVValueChanged?.Invoke(this, e);
        }

        private async void UpdateCOVValues()
        {
            while (KeepCOVReading)
            {
                StreamMessage streamMsg = await ResultChannel.ReadAsync(); ;
                COVValues = UpdateCOVStreamValuesList(COVValues, streamMsg);
                //Raise the event
                StreamEventArgs arg = new StreamEventArgs
                {
                    Value = streamMsg
                };
                OnCOVValueChanged(arg);
            }
        }
#endregion

#region "Alarm Events" ======================================================================================================
        /// <summary>
        /// Variable to keep the list of current Alarm event messages
        /// </summary>
        private List<StreamMessage> AlarmEvents = new List<StreamMessage>();
        /// <summary>
        /// Variable to keep the loop that updated the list of COV Stream values
        /// </summary>
        private bool KeepAlarmCollecting = false;

        //StartCollectingAlarmsAsync ------------------------------------------------------------------------------------------------
        /// <inheritdoc />
        public async Task StartCollectingAlarmsAsync(int maxNumber = 100)
        {
            if (!KeepAlarmCollecting)
            {
                AlarmEvents.Clear();
                KeepAlarmCollecting = true;
                LoadActivitySubscriptions("Alarm");
                if (_source == null)
                {
                    await ConnectAsync();
                }
                else
                {
                    SubscribeAllRequest();
                }
                while (KeepAlarmCollecting)
                {
                    StreamMessage streamMsg = await ResultChannel.ReadAsync(); ;
                    AlarmEvents = UpdateAlarmStreamValuesList(AlarmEvents, streamMsg, maxNumber);
                    //Raise the event
                    StreamEventArgs arg = new StreamEventArgs
                    {
                        Value = streamMsg
                    };
                    OnAlarmOccurred(arg);
                }
            }
        }

        //StopCollectingAlarms ------------------------------------------------------------------------------------------------------
        /// <inheritdoc />
        public void StopCollectingAlarms(Guid requestId)
        {
            if (KeepAlarmCollecting)
            {
                KeepAlarmCollecting = false;
                _ = UnsubscribeAsync(requestId);
            }
        }

        //GetAlarmEvents ------------------------------------------------------------------------------------------------------------
        /// <inheritdoc />
        public List<StreamMessage> GetAlarmEvents()
        {
            return AlarmEvents;
        }

        /// <inheritdoc />
        public event EventHandler<StreamEventArgs> AlarmOccurred;

        /// <inheritdoc />
        void OnAlarmOccurred(StreamEventArgs e)
        {
            AlarmOccurred?.Invoke(this, e);
        }
#endregion

#region "AUDIT EVENTS"
        /// <summary>
        /// Variable to keep the list of current Audit event messages
        /// </summary>
        private List<StreamMessage> AuditEvents = new List<StreamMessage>();
        /// <summary>
        /// Variable to keep the loop that updated the list of COV Stream values
        /// </summary>
        private bool KeepAuditCollecting = false;

        /// <inheritdoc />
        public async Task StartCollectingAuditsAsync(int maxNumber = 100)
        {
            if (!KeepAuditCollecting)
            {
                AuditEvents.Clear();
                KeepAuditCollecting = true;
                LoadActivitySubscriptions("Audit");
                if (_source == null)
                {
                    await ConnectAsync();
                }
                else
                {
                    SubscribeAllRequest();
                }
                while (KeepAuditCollecting)
                {
                    StreamMessage streamMsg = await ResultChannel.ReadAsync(); ;
                    AuditEvents = UpdateAuditStreamValuesList(AuditEvents, streamMsg, maxNumber);
                    //Raise the event
                    StreamEventArgs arg = new StreamEventArgs
                    {
                        Value = streamMsg
                    };
                    OnAuditOccurred(arg);
                }
            }
        }

        /// <inheritdoc />
        public void StopCollectingAudits(Guid requestId)
        {
            if (KeepAuditCollecting)
            {
                KeepAuditCollecting = false;
                _ = UnsubscribeAsync(requestId);
            }
        }

        /// <inheritdoc />
        public List<StreamMessage> GetAuditEvents()
        {
            return AuditEvents;
        }

        /// <inheritdoc />
        public event EventHandler<StreamEventArgs> AuditOccurred;

        /// <inheritdoc />
        void OnAuditOccurred(StreamEventArgs e)
        {
            AuditOccurred?.Invoke(this, e);
        }

        /// <inheritdoc />
        public event EventHandler<EventSourceMessageEventArgs> HeartBeatOccurred;
        /// <inheritdoc />
        void OnHeartBeatOccurred(EventSourceMessageEventArgs e)
        {
            HeartBeatOccurred?.Invoke(this, e);
        }
        #endregion

    }
}
