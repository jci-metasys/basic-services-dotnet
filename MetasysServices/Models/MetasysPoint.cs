using System;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Point is a structure that holds information about an object attribute mapped to a point.
/// </summary>
public class MetasysPoint : Utils.ObjectUtil
{
    /// <summary>
    /// The name of the Equipment that contains the Point
    /// </summary>
    public string EquipmentName { get; set; }
    /// <summary>The Short name of the Point.</summary>
    public string ShortName { set; get; }
    /// <summary>The Label of the Point.</summary>
    public string Label { set; get; }
    /// <summary>
    /// Category of the Point.
    /// </summary>
    public string Category { set; get; }
    /// <summary>
    /// Flag that states when the attribute object contains data suitable to display
    /// </summary>
    public bool IsDisplayData { set; get; }
    /// <summary>
    /// The ID of the object where the point is mapped
    /// </summary>
    public ObjectId ObjectId { get; set; }
    /// <summary>
    /// Full URL of the attribute where the point is mapped
    /// </summary>
    public string AttributeUrl { get; set; }
    /// <summary>
    /// Attribute where the point is mapped
    /// </summary>
    public string Attribute { get; set; }
    /// <summary>
    /// Full URL of the object where the point is mapped
    /// </summary>
    public string ObjectUrl { get; set; }
    /// <summary>
    /// Value of the attribute where the point is mapped
    /// </summary>
    public Variant PresentValue { get; set; }

    /// <summary>
    /// Default Constructor for Point.
    /// </summary>
    public MetasysPoint()
    {
    }

    internal MetasysPoint(JsonNode token)
    {
        try
        {
            EquipmentName = (string)token["equipmentName"];
            ShortName = (string)token["shortName"];
            Label = (string)token["label"];
            Category = (string)token["category"];
            IsDisplayData = (bool)token["isDisplayData"];
            try
            {
                AttributeUrl = (string)token["attributeUrl"];
            }
            catch
            {
                AttributeUrl = null;
            }
            try
            {
                Attribute = (string)token["attribute"];
            }
            catch
            {
                Attribute = null;
            }
            ObjectUrl = (string)token["objectUrl"];
            PresentValue = null;
        }
        catch (Exception e)
        {
            throw new MetasysObjectException(token.ToString(), e);
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
}
