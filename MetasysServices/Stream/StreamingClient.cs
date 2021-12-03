using EvtSource;
using Flurl;
using Flurl.Http;
using JohnsonControls.Metasys.BasicServices.Stream.Token;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
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


namespace JohnsonControls.Metasys.BasicServices.Stream
{
    public class StreamingClient : IDisposable, IStreamService
    {
        private bool _isDisposed = false;

        
        protected IFlurlClient _client;
        private readonly string _serverUrl;
      
        //private readonly IAuthTokenProvider _tokenProvider;
        private readonly HttpClientHandler _handler;

        private readonly Dictionary<Guid, SubscriptionInfo> _requestIdToSubscriptionMap = new Dictionary<Guid, SubscriptionInfo>();
        private readonly Dictionary<string, Guid> _subscriptionIdToRequestIdMap = new Dictionary<string, Guid>();
        private readonly Dictionary<string, List<Guid>> _objectAndAttrToRequestIdsMap = new Dictionary<string, List<Guid>>();

        private readonly List<Guid> _requestIds = new List<Guid>();
        private TaskCompletionSource<bool> _initializeStreamTaskSource = new TaskCompletionSource<bool>();
        private readonly Channel<StreamMessage> _channel = Channel.CreateUnbounded<StreamMessage>(new UnboundedChannelOptions()
        {
            SingleReader = true,
            SingleWriter = true
        });

        public ChannelReader<StreamMessage> ResultChannel => _channel.Reader;

        public ApiVersion Version { get; set; }
        public CultureInfo Culture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AccessToken AccessToken { get; set; }
        public string _token { get; set; }

        private EventSourceReader _source;
        private string _streamId;
        private System.Timers.Timer _timer;


        public StreamingClient(IFlurlClient client, string serverUrl, ApiVersion version)
        {
            _client = client;
            _serverUrl = $"https://{serverUrl}";
            //_tokenProvider = new TokenProvider(_serverUrl, version, "APIUser", "4S!SEurope10");
            Version = version;

            FlurlHttp.ConfigureClient(_serverUrl, x => x.Settings.HttpClientFactory = new UntrustedCertClientFactory());
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            _handler = httpClientHandler;
        }

        public void Dispose()
        {

            _isDisposed = true;

            try
            {
                // networking issues can cause a delayed exception                
                _source.Dispose();
            }
            catch (Exception e)
            {
                
            }

            var subscriptionInfos = _requestIdToSubscriptionMap.Values.ToList();

            _ = Parallel.ForEach(
                subscriptionInfos,
                new ParallelOptions() { MaxDegreeOfParallelism = 5 }, // parallelize, but don't overwhelm the Metasys host
#pragma warning disable VSTHRD101 // Avoid unsupported async delegates
                async (s) =>
                {
                    try
                    {
                        await UnsubscribeInternalAsync(s);
                    }
                    catch (Exception e)
                    {
                       
                    }
                });
#pragma warning restore VSTHRD101 // Avoid unsupported async delegates

            
            _channel.Writer.Complete();
        }

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
                
                if (AccessToken != null)
                {
                    _token = AccessToken.Token.Replace("Bearer ", "");

                    var uri = new Uri(_serverUrl.AppendPathSegments("api", Version, "stream").SetQueryParam("access_token", _token));
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

        public async Task<string> SubscribeAsync(Guid requestId, string method, string relativeUrl,
           Dictionary<string, string> query = null, dynamic body= null)
        {
            string bodyContent = body != null ? JsonConvert.SerializeObject(body) : null;
        
            var content = bodyContent != null
                                 ? new StringContent(bodyContent, Encoding.UTF8, "Json")
                                 : null;
            string token = _token;


            if (String.IsNullOrEmpty(_token))
            {
                //var tokenResponse = await _tokenProvider.GetAccessTokenAsync();
                //token = tokenResponse.AccessToken;

                if (AccessToken != null)
                {
                    _token = AccessToken.Token.Replace("Bearer ", "");
                }
            }

            HttpResponseMessage response = await _serverUrl
                .AppendPathSegment(relativeUrl)
                .SetQueryParams(query)
                .WithHeader("METASYS-SUBSCRIBE", _streamId)
                .WithOAuthBearerToken(token)
                .SendAsync(new HttpMethod(method), content);

            response.EnsureSuccessStatusCode();

            //IFlurlResponse response = await _serverUrl
            //   .AppendPathSegment(relativeUrl)
            //   .SetQueryParams(query)
            //   .WithHeader("METASYS-SUBSCRIBE", _streamId)
            //   .WithOAuthBearerToken(token)
            //   .SendAsync(new HttpMethod(method), content);

            // response.ResponseMessage.EnsureSuccessStatusCode();
            //var subscriptionHeader = response.Headers.GetAll("METASYS-SUBSCRIPTION-LOCATION").First();
            // var subscriptionInfo = new SubscriptionInfo(subscriptionHeader);

            IEnumerable<string> streamHeaders;
            string subscriptionInfoId = "";
            if(response.Headers.TryGetValues("METASYS-SUBSCRIPTION-LOCATION", out streamHeaders))
            {
                var subscriptionHeader = streamHeaders.First();
                var subscriptionInfo = new SubscriptionInfo(subscriptionHeader);

                CreateRequestMapping(requestId, relativeUrl, bodyContent);

                _requestIdToSubscriptionMap.Add(requestId, subscriptionInfo);
                _subscriptionIdToRequestIdMap.Add(subscriptionInfo.Id, requestId);
                subscriptionInfoId = subscriptionInfo.Id;
            }
            return subscriptionInfoId;
        }

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

        #region private methods

        private void KeepStreamAlive(AccessTokenResponse tokenResponse)
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

                if (AccessToken != null)
                {
                    _token = AccessToken.Token.Replace("Bearer ", "");
                }

                HttpResponseMessage response = await _serverUrl
                    .AppendPathSegments("api", Version, "stream", "keepalive")
                    .WithOAuthBearerToken(_token)
                    .SendAsync(HttpMethod.Get);

                // response.ResponseMessage.EnsureSuccessStatusCode();
                response.EnsureSuccessStatusCode();               
            };
        }

        private void Stream_Disconnected(object sender, DisconnectEventArgs e)
        {
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
            string activitydata = JsonConvert.SerializeObject(newAlarm);

           // _logger.LogDebug($"Writing Activity to channel...");
          
           await _channel.Writer.WriteAsync(newAlarm);
        }

        private async Task HandleAttibuteValueSubscriptionAsync(EventSourceMessageEventArgs e)
        {
            var covObjects = JsonConvert.DeserializeObject<ExpandoObject>(e.Message);
            //var covObjects = Newtonsoft.Json.JsonConvert.DeserializeObject(e.Message);
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
                            var cov = new StreamMessage(e.Event, e.Message); // messages missing stream id, can't correlate to specific request id
                            cov.RequestId = requestId;
                            cov.StreamId = e.Id;
                            cov.AttributeName = attrId;
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

        public List<StreamMessage> UpdateCOVStremValuesList(List<StreamMessage> values, StreamMessage msg)
        {
            List<StreamMessage> res = values;
            if (res.Count == 0)
            {
                if (msg.Event != "hello") { res.Add(msg); }           
            }
            else
            {
                var newValues = values.Where(c => c.RequestId == msg.RequestId && c.Id == msg.Id).Select(c => { c.Data = msg.Data; return c; });
                if (newValues is null)
                {
                    res.Add(msg);
                }
                else
                {
                    res = newValues.ToList();
                }
            }
            return res;
        }

        private async Task HandleHelloEventAsync(EventSourceMessageEventArgs e)
        {
           // _logger.LogDebug($"Got a hello with streamId {e.Message} from server {_serverUrl}");
            _streamId = Newtonsoft.Json.Linq.JToken.Parse(e.Message).ToString();
            var st = new StreamMessage(e.Event, e.Message);
            await _channel.Writer.WriteAsync(st);
            _initializeStreamTaskSource.TrySetResult(true);            
        }


        private async Task UnsubscribeInternalAsync(SubscriptionInfo subscriptionInfo)
        {
            string token = _token;
            if (String.IsNullOrEmpty(_token))
            {
                //var tokenResponse = await _tokenProvider.GetAccessTokenAsync();
                //token = tokenResponse.AccessToken;
                if (AccessToken != null)
                    {
                        _token = AccessToken.Token.Replace("Bearer ", "");
                    }
            }
            var response = await subscriptionInfo.Url
                                            .WithOAuthBearerToken(token)
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
                //if (!string.IsNullOrEmpty(bodyContent))
                //{
                //    var attributeBatch = JsonConvert.DeserializeObject<AttributeBatchModel>(bodyContent);
                //    foreach (var request in attributeBatch.requests)
                //    {
                //        var pieces = request.relativeUrl.Split('/');
                //        var combinedId = $"{pieces[0]}:{pieces[2]}";
                //        if (!_objectAndAttrToRequestIdsMap.TryGetValue(combinedId, out var requestIds))
                //        {
                //            _objectAndAttrToRequestIdsMap.Add(combinedId, new List<Guid>() { requestId });
                //        }
                //    }
                //}
            }
            else if (relativeUrl.StartsWith($"api/{Version}/objects")) // ex: api/v4/objects/9aa3f0cc-e7bb-59f2-97b1-56ad9d406051/attributes/presentValue
            {
                var pieces = relativeUrl.Split('/');
                var combinedId = $"{pieces[3]}:{pieces[5]}";
                if (!_objectAndAttrToRequestIdsMap.TryGetValue(combinedId, out var requestIds))
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
    }
}
