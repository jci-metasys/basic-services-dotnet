using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Generic class for handling JSON objects with a hierarchical pattern.
/// <remarks> Children is null when the object has no children.</remarks>
/// </summary>
public class TreeObject
{
    /// <summary>
    /// Generic JsonNode Item.
    /// </summary>
    public JsonNode Item { get; set; }
    /// <summary>
    /// List of object's children.
    /// </summary>
    public IEnumerable<TreeObject> Children { get; set; }
}
