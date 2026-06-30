using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// MetasysObject is a structure that holds information about a Metasys object.
/// </summary>
public class MetasysObject : Utils.ObjectUtil
{
    /// <summary>The item reference of the Metasys object.</summary>
    [JsonRequired]
    public string ItemReference { set; get; }

    /// <summary>The id of the Metasys object.</summary>
    [JsonRequired]
    public ObjectId Id { set; get; }

    /// <summary>The name of the Metasys object.</summary>
    [JsonRequired]
    public string Name { set; get; }

    /// <summary>The description of the Metasys object.</summary>
    public string Description { set; get; }

    /// <summary>
    /// The actual Metasys Object type.
    /// </summary>
    public MetasysObjectTypeEnum? Type { get; set; }

    /// <summary>
    /// The resource type detail reference.
    /// </summary>
    /// <remarks> This is available only on Metasys API v2 and v1. </remarks>
    public string TypeUrl { get; set; }

    /// <summary>
    /// The resource type detail reference.
    /// </summary>
    /// <remarks> This is available since Metasys API v3. </remarks>
    public string ObjectType { get; set; }

    /// <summary>
    /// The specific category of the Metasys Object Type.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Reference of the Metasys Object Authorization Category.
    /// </summary>
    public string CategoryUrl { get; set; }

    /// <summary>
    /// Metasys Object Authorization Category.
    /// </summary>
    public string ObjectCategory { get; set; }

    /// <summary>The direct children objects of the Metasys object.</summary>
    public IEnumerable<MetasysObject> Children { set; get; }

    /// <summary>
    /// The number of direct children objects.
    /// </summary>
    /// <value>The number of children.</value>
    public int ChildrenCount => Children.Count();

    /// <summary>
    /// Name of the Equipment Definition mapped with the Equipment Instance
    /// </summary>
    public string EquipmentDefinitionName { get; set; }

    /// <summary>
    /// Default constructor for Metasys Object.
    /// </summary>
    public MetasysObject() { }

    /// <summary>
    /// Classification of the object
    /// </summary>
    public string Classification { get; set; }
    private const string DefaultClassification = "object";

    /// <summary>
    /// Create a tree of objects out of a root node
    /// </summary>
    /// <param name="token"></param>
    /// <param name="version"></param>
    internal MetasysObject(JsonNode token, ApiVersion version)
    {
        var root = token;
        var children = root["items"] as JsonArray;
        Initialize(root, version);

        Children = children?.Select(child => new MetasysObject(child, version)).ToList() ?? [];
    }

    internal MetasysObject(JsonNode token, ApiVersion version, IEnumerable<MetasysObject>? children = null, MetasysObjectTypeEnum? type = null)
    {
        Children = children ?? new List<MetasysObject>(); // Return empty list by convention for null
        Type = type;
        Initialize(token, version);
    }

    private void Initialize(JsonNode token, ApiVersion version)
    {
        JsonObject jobj = token as JsonObject;
        try
        {
            Id = new Guid((string)token["id"]);
            ItemReference = (string)token["itemReference"];
            if (ItemReference == null) throw new ArgumentNullException("itemReference");
        }
        catch (Exception e)
        {
            throw new MetasysObjectException(token.ToString(), e);
        }

        try
        {
            Name = jobj?.ContainsKey("name") == true ? (string)token["name"] : null;
        }
        catch
        {
            Name = null;
        }

        try
        {
            Description = jobj?.ContainsKey("description") == true ? (string)token["description"] : null;
        }
        catch
        {
            Description = null;
        }

        try
        {
            if (version >= ApiVersion.v4)
            {
                if (Type == MetasysObjectTypeEnum.Space)
                {
                    // Set the specific category for Space
                    Enum.TryParse(((string)token["type"]).Split('.').Last(), true, out SpaceTypeEnum spaceType);
                    Category = spaceType.ToString();
                }
            }
            else
            {
                // This applies for v2 and v1.
                TypeUrl = (string)token["typeUrl"];
                if (Type == MetasysObjectTypeEnum.Space && TypeUrl?.Length > 0)
                {
                    // Set the specific category for Space
                    var typeId = TypeUrl.Split('/').Last();
                    // Convert space type to enum
                    Category = ((SpaceTypeEnum)int.Parse(typeId)).ToString();
                }
            }
        }
        catch
        {
            TypeUrl = null;
            Category = null;
        }

        if (version > ApiVersion.v2)
        {
            try
            {
                // Object Type is available since API v3 only on object detail.
                ObjectType = jobj?.ContainsKey("objectType") == true ? (string)token["objectType"] : null;
            }
            catch
            {
                ObjectType = null;
            }
        }
        try
        {
            CategoryUrl = jobj?.ContainsKey("categoryUrl") == true ? (string)token["categoryUrl"] : null;
        }
        catch
        {
            CategoryUrl = null;
        }
        try
        {
            ObjectCategory = jobj?.ContainsKey("objectCategory") == true ? (string)token["objectCategory"] : null;
        }
        catch
        {
            ObjectCategory = null;
        }

        try
        {
            EquipmentDefinitionName = jobj?.ContainsKey("type") == true ? (string)token["type"] : null;
        }
        catch
        {
            EquipmentDefinitionName = null;
        }
        try
        {
            if (jobj?.ContainsKey("classification") == true)
            {
                var tokenValue = ((string)token["classification"]).Trim();
                Classification = tokenValue == string.Empty ? DefaultClassification : tokenValue;
            }
            else
            {
                Classification = DefaultClassification;
            }
        }
        catch
        {
            Classification = DefaultClassification;
        }
    }

    /// <summary>
    /// Return a pretty JSON string of the current object.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }

    /// <summary>
    /// Returns a value indicating whither this instance has values equal to a specified object.
    /// </summary>
    /// <param name="obj"></param>
    public override bool Equals(object? obj)
    {
        if (obj != null && obj is MetasysObject @object)
        {
            var other = @object;
            bool areEqual = ((this.Id == null && other.Id == null) || (this.Id != null && this.Id.Equals(other.Id))) &&
                ((this.ItemReference == null && other.ItemReference == null) ||
                    (this.ItemReference != null && this.ItemReference.Equals(other.ItemReference))) &&
                ((this.Description == null && other.Description == null) ||
                    (this.Description != null && this.Description.Equals(other.Description))) &&
                this.ChildrenCount == other.ChildrenCount;

            if (areEqual)
            {
                if (this.Children == null ^ other.Children == null)
                {
                    return false;
                }
                else if (this.Children != null && other.Children != null)
                {
                    return Enumerable.SequenceEqual(this.Children, other.Children);
                }
            }
            return areEqual;
        }
        return false;
    }

    /// <summary></summary>
    public override int GetHashCode()
    {
        var code = 13;
        code = (code * 7) + Id.GetHashCode();
        if (ItemReference != null)
            code = (code * 7) + ItemReference.GetHashCode();
        if (Description != null)
            code = (code * 7) + Description.GetHashCode();
        code = (code * 7) + ChildrenCount.GetHashCode();
        if (Children != null)
        {
            var arrCode = 0;
            foreach (var item in Children)
            {
                arrCode += item.GetHashCode();
            }
            code = (code * 7) + arrCode;
        }

        return code;
    }
}
