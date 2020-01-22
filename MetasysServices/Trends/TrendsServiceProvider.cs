using Flurl.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provider Class for Trend Service
    /// </summary>
    public class TrendsServiceProvider : BasicServiceProvider, ITrendsService
    {
        /// <summary>
        /// Caching about read units.
        /// </summary>
        protected Dictionary<string, string> Units = new Dictionary<string, string>();
        /// <summary>
        /// Initialize a new instance given the Flurl client.
        /// </summary>
        /// <param name="client"></param>
        public TrendsServiceProvider(FlurlClient client) : base(client)
        {
        }

        /// <inheritdoc/>
        public List<Sample> GetSamples(Guid objectId, int attributeId, TimeFilter filter)
        {
            return GetSamplesAsync(objectId, attributeId, filter).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<List<Sample>> GetSamplesAsync(Guid objectId, int attributeId, TimeFilter filter)
        {
            List<Sample> objectSamples = new List<Sample>();
            // Set the timeline parameters first for the query string
            Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    {"startTime", filter.StartTime.ToString("o") }, // Convert to UTC DateTime string
                    {"endTime", filter.EndTime.ToString("o") }
                };
            // Perform a generic call using objects resource valid for Network Devices as well
            var samples = await GetObjectsAsync(objectId, "objects", $"attributes/{attributeId}/samples", parameters);
            // Read full attribute from url
            foreach (var s in samples)
            {
                Sample sample = new Sample();
                string unitsUrl;
                try
                {
                    sample.Timestamp = s.Item["timestamp"].Value<DateTime>();
                    sample.IsReliable = s.Item["isReliable"].Value<Boolean>();
                    sample.Value = s.Item["value"]["value"].Value<double>();
                    unitsUrl = s.Item["value"]["units"].Value<string>();
                }
                catch (ArgumentNullException e)
                {
                    // Something went wrong on object parsing
                    throw new MetasysObjectException(e);
                }
                // Extract ID from units url
                var unitId=unitsUrl.Split('/').Last();
                string desc;
                // Read full url if not cached previously
                if (!Units.ContainsKey(unitId))
                {                    
                    var unit = await GetWithFullUrl(unitsUrl);
                    Units.Add(unitId, unit["description"].Value<string>());                    
                }
                sample.Unit = Units[unitId];
                objectSamples.Add(sample);
            }
            return objectSamples;
        }      

        /// <inheritdoc/>
        public List<Attribute> GetTrendedAttributes(Guid id)
        {
            return GetTrendedAttributesAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<List<Attribute>> GetTrendedAttributesAsync(Guid id)
        {
            List<Attribute> objectAttributes = new List<Attribute>();
            // Perform a generic call using objects resource valid for Network Devices as well
            var attributes = await GetObjectsAsync(id, "objects", "trendedAttributes");
            // Read full attribute from url
            foreach (var a in attributes)
            {
                try
                {
                    var attributeUrl = a.Item["attributeUrl"].Value<string>();
                    var attribute = await GetWithFullUrl(attributeUrl);               
                    objectAttributes.Add(new Attribute
                    {
                        Id = attribute["id"].Value<int>(),
                        Description = attribute["description"].Value<string>()
                    });
                }
                catch (ArgumentNullException e)
                {
                    // Something went wrong on object parsing
                    throw new MetasysObjectException(e);
                }
            }
            return objectAttributes;
        }
    }
}
