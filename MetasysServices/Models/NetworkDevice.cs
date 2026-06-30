using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// NetworkDevice is a structure that hold information about a Metasys Network Device
/// </summary>
public class NetworkDevice
{
    /// <summary>
    /// Item Unique Identifier (GUID)
    /// </summary>
    [JsonRequired]
    public Guid Id { get; set; }

    /// <summary>
    /// Item fully qualified reference
    /// </summary>
    [JsonRequired]
    public string ItemReference { get; set; }

    /// <summary>
    /// Item name
    /// </summary>
    [JsonRequired]
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

    internal NetworkDevice(JsonNode token, ApiVersion version)
    {
        try
        {
            Id = new Guid((string)token["id"]);
            ItemReference = (string)token["itemReference"];
        }
        catch (Exception e)
        {
            throw new MetasysObjectException(token.ToString(), e);
        }

        try
        {
            Name = (string)token["name"];
        }
        catch
        {
            Name = null;
        }

        try
        {
            ObjectType = (string)token["objectType"];
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
    public override bool Equals(object? obj)
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
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}
