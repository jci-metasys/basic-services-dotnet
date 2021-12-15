using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    public class StreamMessage
    {
        private Guid _requestId = Guid.Empty;
        private string _subscriptionId;
        private string _data;

        /// <summary>
        /// Item or Activity Id
        /// </summary>
        public Guid Id { get; set; }

        public Guid RequestId
        {
            get { return _requestId; }
            set
            {
                if (_requestId != Guid.Empty) throw new InvalidOperationException("RequestId is already set!");
                _requestId = value;
            }
        }

        /// <summary>
        /// Subscription Identifier (String)
        /// </summary>
        public string SubscriptionId
        {
            get { return _subscriptionId; }
            set { _subscriptionId = value; }
        }

        /// <summary>
        /// Stream Identifier (String)
        /// </summary>
        public string StreamId { get; set; }

        /// <summary>
        /// Object Identifier (GUID)
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Guid ObjectId { get; set; }

        /// <summary>
        /// Object Name
        /// </summary>
        public String ObjectName { get; set; }

        /// <summary>
        /// Attribute Name
        /// </summary>
        //[JsonProperty(Required = Required.Always)]
        public String AttributeName { get; set; }

        /// <summary>
        /// Item Reference (FQR)
        /// </summary>
        //[JsonProperty(Required = Required.Always)]
        public String ItemReference { get; set; }

        /// <summary>
        /// Present Value
        /// </summary>
        public String PresentValue { get; set; }

        /// <summary>
        /// Event Creation Time
        /// </summary>
        public String CreationTime { get; set; }

        /// <summary>
        /// Event that generated the stream message
        /// </summary>
        public string Event { get; }

        /// <summary>
        /// Description
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// JSON encoded string containing an object
        /// </summary>
        public string Data
        {
            get { return _data; }
            set
            {
                _data = value;
                ParseData(_data);
            }
        }

        /// <summary>
        /// Constructor of the class
        /// </summary>
        public StreamMessage(string eventType, string data)
        {
            Event = eventType;
            Data = data;
        }

        private void ParseData(string data)
        {
            if ((data.StartsWith("{") && data.EndsWith("}")) || //For object
                    (data.StartsWith("[") && data.EndsWith("]"))) //For array
            {
                var dataObj = JObject.Parse(data);
                switch (Event.ToLower())
                {
                    case "object.values.update":
                        this.PresentValue = GetJObjectValue(dataObj, "item", "presentValue");
                        string objectId = GetJObjectValue(dataObj, "item", "id");
                        this.ObjectId = (objectId == string.Empty) ? Guid.Empty : new Guid(objectId);
                        this.Id = this.ObjectId;
                        this.ItemReference = GetJObjectValue(dataObj, "item", "itemReference");
                        this.ObjectName = GetJObjectValue(dataObj, "item", "objectName");
                        break;
                    case "activity.audit.new":
                    case "activity.alarm.new":
                    case "activity.alarm.ack":

                        string id = GetJObjectValue(dataObj, "activity", "id");
                        this.Id = (id == string.Empty) ? Guid.Empty : new Guid(id);

                        objectId = GetJObjectValue(dataObj, "activity", "objectId");
                        this.ObjectId = (objectId == string.Empty) ? Guid.Empty : new Guid(objectId);
                        this.Id = this.ObjectId;

                        this.ItemReference = GetJObjectValue(dataObj, "activity", "itemReference");
                        this.CreationTime = GetJObjectValue(dataObj, "activity", "creationTime");

                        switch (Event.ToLower())
                        {

                            case "activity.audit.new":
                                if (dataObj.ContainsKey("activity") && (dataObj["activity"] != null))
                                {
                                    JObject grp = (JObject)dataObj["activity"];
                                    this.Description = GetJObjectValue(grp, "audit", "description");
                                };

                                break;
                            case "activity.alarm.new":
                            case "activity.alarm.ack":
                                if (dataObj.ContainsKey("activity") && (dataObj["activity"] != null))
                                {
                                    JObject grp = (JObject)dataObj["activity"];
                                    this.Description = GetJObjectValue(grp, "alarm", "description");
                                };

                                break;
                            default:
                                break;
                        }

                        break;
                    case "message": // streaming heartbeat - why does it come through without an "Event"?
                        break;
                    case "object.values.heartbeat":
                        break;
                    default:
                        break;
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

    }
}
