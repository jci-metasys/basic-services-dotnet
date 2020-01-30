using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Generic class for handling JSON objects with a hierarchical pattern.
    /// <remarks> Children is null when the object has no children.</remarks>
    /// </summary>
    public class TreeObject
    {
        /// <summary>
        /// Generic JToken Item.
        /// </summary>
        public JToken Item { get; set; }
        /// <summary>
        /// List of object's children.
        /// </summary>
        public IEnumerable<TreeObject> Children { get; set; }
    }
}
