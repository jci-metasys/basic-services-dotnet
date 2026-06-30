using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Provides stream COV Item
/// </summary>
class StreamCOV
{
    /// <summary>
    /// Request Identifier (GUID)
    /// </summary>
    [JsonRequired]
    public Guid RequestId { get; set; }

    /// <summary>
    /// Subscription Identifier (String)
    /// </summary>
    [JsonRequired]
    public String SubscriptionId { get; set; }

    /// <summary>
    /// Stream Identifier (String)
    /// </summary>
    [JsonRequired]
    public String StreamId { get; set; }

    /// <summary>
    /// Object Identifier (GUID)
    /// </summary>
    [JsonRequired]
    public Guid ObjectId { get; set; }

    /// <summary>
    /// Attribute Name
    /// </summary>
    [JsonRequired]
    public String AttributeName { get; set; }

    /// <summary>
    /// Stream message
    /// </summary>
    [JsonRequired]
    public StreamMessage Message { get; set; }

    /// <summary>
    /// Return a pretty JSON string of the current object.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }

}
