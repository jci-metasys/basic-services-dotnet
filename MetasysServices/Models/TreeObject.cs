using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Generic class for handling JSON object.
    /// <remarks> Children is null when the object has no children.</remarks>
    /// </summary>
    public class TreeObject
    {
        public JToken Item { get; set; }
        public IEnumerable<TreeObject> Children { get; set; }
    }
}
