using System;
using System.Runtime.InteropServices;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that holds attribute for StreamMessage type object.
    /// </summary>
    [ComVisible(true)]
    [Guid("1248750B-6602-4332-A253-BFAAB67B4438")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComStreamMessage
    {
        /// <summary>
        /// Item or Activity Id
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Request Id
        /// </summary>
        Guid RequestId { get; set; }

        /// <summary>
        /// Subscription Identifier (String)
        /// </summary>
        String SubscriptionId { get; set; }

        /// <summary>
        /// Stream Identifier (String)
        /// </summary>
        String StreamId { get; set; }

        /// <summary>
        /// Object Identifier (GUID)
        /// </summary>
        Guid ObjectId { get; set; }

        /// <summary>
        /// Object Name
        /// </summary>
        String ObjectName { get; set; }

        /// <summary>
        /// Attribute Name
        /// </summary>
        //[JsonProperty(Required = Required.Always)]
        String AttributeName { get; set; }

        /// <summary>
        /// Item Reference (FQR)
        /// </summary>
        //[JsonProperty(Required = Required.Always)]
        String ItemReference { get; set; }

        /// <summary>
        /// Present Value
        /// </summary>
        String PresentValue { get; set; }

        /// <summary>
        /// Event Creation Time
        /// </summary>
        String CreationTime { get; set; }

        /// <summary>
        /// Event that generated the stream message
        /// </summary>
        String Event { get; }

        /// <summary>
        /// Description
        /// </summary>
        String Description { get; set; }

    }
}
