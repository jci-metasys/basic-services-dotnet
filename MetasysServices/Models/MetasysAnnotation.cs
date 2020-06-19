using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Base class for a Metasys Annotation.
    /// </summary>
    public abstract class MetasysAnnotation
    {
        /// <summary>
        /// Text of the annotation.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Text { get; set; }
        /// <summary>
        /// User who made the annotation.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string User { get; set; }
        /// <summary>
        /// Creation time of the annotation.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// Action of the annotation.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string Action { get; set; }       
    }
}
