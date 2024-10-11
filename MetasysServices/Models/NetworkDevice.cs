using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// NetworkDevice is a structure that hold information about a Metasys Network Device 
    /// </summary>
    public class NetworkDevice
    {
        /// <summary>
        /// Item Unique Identifier (GUID)
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Item fully qualified reference
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string ItemReference { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// The resource type detail reference. 
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string ObjectType { get; set; }

        internal NetworkDevice(Guid id, string itemReference, string name, string objectType)
        {
            Id = id;
            ItemReference = itemReference;
            Name = name;
            ObjectType = objectType;
        }

        internal NetworkDevice(JToken token, ApiVersion version)
        {
            try
            {
                Id = new Guid(token["id"].Value<string>());
                ItemReference = token["itemReference"].Value<string>();
            }
            catch (Exception e)
            {
                throw new MetasysObjectException(token.ToString(), e);
            }

            try
            {
                Name = token["name"].Value<string>();
            }
            catch
            {
                Name = null;
            }

            try
            {
                ObjectType = token["objectType"].Value<string>();
            }
            catch
            {
                ObjectType = null;
            }
        }

        /// <summary>
        /// Returns a value indicating whether this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Alarm)
            {
                var o = (NetworkDevice)obj;
                // Compare each properties one by one for better performance
                return this.Id == o.Id && this.ItemReference == o.ItemReference
                    && this.Name == o.Name && this.ObjectType == o.ObjectType;
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            // Calculate hash on each properties one by one
            code = (code * 7) + Id.GetHashCode();
            if (ItemReference != null)
                code = (code * 7) + ItemReference.GetHashCode();
            if (this.Name != null)
                code = (code * 7) + Name.GetHashCode();
            if (this.ObjectType != null)
                code = (code * 7) + ObjectType.GetHashCode();
            return code;
        }
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
