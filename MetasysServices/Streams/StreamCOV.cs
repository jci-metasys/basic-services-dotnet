using JohnsonControls.Metasys.BasicServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provides stream COV Item
    /// </summary>
    class StreamCOV
    {
        /// <summary>
        /// Request Identifier (GUID)
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Guid RequestId { get; set; }

        /// <summary>
        /// Subscription Identifier (String)
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public String SubscriptionId { get; set; }

        /// <summary>
        /// Stream Identifier (String)
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public String StreamId { get; set; }

        /// <summary>
        /// Object Identifier (GUID)
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Guid ObjectId { get; set; }

        /// <summary>
        /// Attribute Name
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public String AttributeName { get; set; }

        /// <summary>
        /// Stream message
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public StreamMessage Message { get; set; }

        /// <summary>
        /// Return a pretty JSON string of the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
