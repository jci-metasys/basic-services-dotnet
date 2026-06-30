using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Base class for a Metasys Annotation.
/// </summary>
public abstract class MetasysAnnotation
{
    /// <summary>
    /// Text of the annotation.
    /// </summary>
    [JsonRequired]
    public string Text { get; set; }
    /// <summary>
    /// User who made the annotation.
    /// </summary>
    [JsonRequired]
    public string User { get; set; }
    /// <summary>
    /// Creation time of the annotation.
    /// </summary>
    [JsonRequired]
    public DateTime CreationTime { get; set; }
    /// <summary>
    /// Action of the annotation.
    /// </summary>
    [JsonRequired]
    public string Action { get; set; }
}
