using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provide Stream values for the endpoints of the Metasys Stream API.
    /// </summary>

    public class StreamServiceProviderOLD
    {
        StreamCOV item = null;
        private StreamCOV CreateItem(StreamMessage msg)
        {
            try
            {
                item = new StreamCOV();

                item.RequestId = msg.RequestId;
                item.SubscriptionId = msg.SubscriptionId;
                item.StreamId = msg.StreamId;
            }
            catch (ArgumentNullException e)
            {
                // Something went wrong on object parsing
                throw new MetasysObjectException(e);
            }
            return item;
        }

    }

    
}
