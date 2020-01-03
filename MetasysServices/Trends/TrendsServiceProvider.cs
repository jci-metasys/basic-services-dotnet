using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provider Class for Trend Service
    /// </summary>
    public class TrendsServiceProvider : BasicServiceProvider, ITrendsService
    {
        /// <summary>
        /// Initialize a new instance given the Flurl client.
        /// </summary>
        /// <param name="client"></param>
        public TrendsServiceProvider(FlurlClient client):base(client)
        {            
        }

        /// <summary>
        /// Retrieves available samples for the given object attribute, filtered by startTime and endTime.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<Sample> GetSamples(Guid objectId, Guid attributeId, DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the list of trended attributes for the given object. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Guid> GetTrendedAttributes(Guid id)
        {
            throw new NotImplementedException();
            // Perform a generic call using objects resource valid for Network Devices as well
           // ProcessPagedRequestAsync();
        }


    }
}
