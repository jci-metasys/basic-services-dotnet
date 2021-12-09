using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JohnsonControls.Metasys.BasicServices.Stream
{
    public class StreamMessage
    {
        private Guid _requestId = Guid.Empty;
        private string _subscriptionId;
        private string _data;


        public Guid RequestId
        {
            get { return _requestId; }
            set
            {
                if (_requestId != Guid.Empty) throw new InvalidOperationException("RequestId is already set!");
                _requestId = value;
            }
        }


        public string SubscriptionId
        {
            get { return _subscriptionId; }
            set
            {
                _subscriptionId = value;
            }
        }

        /// <summary>
        /// Stream Identifier (String)
        /// </summary>
        public string StreamId { get; set; }

        /// <summary>
        /// Object Identifier (GUID)
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Guid Id { get; set; }

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
        /// Event that generated the stream message
        /// </summary>
        public string Event { get; }

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
        public StreamMessage(string @event, string data)
        {
            Event = @event;
            Data = data;
        }

        private void ParseData(string data)
        {
            if ((data.StartsWith("{") && data.EndsWith("}")) || //For object
                    (data.StartsWith("[") && data.EndsWith("]"))) //For array
            {
                var dataObj = JObject.Parse(data);
                this.PresentValue = GetJObjectValue(dataObj, "item", "presentValue");
                string id = GetJObjectValue(dataObj, "item", "id");
                this.Id = (id == string.Empty) ? Guid.Empty : new Guid(id);
                this.ItemReference = GetJObjectValue(dataObj, "item", "itemReference");
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
