using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Point is a structure that holds information about an object attribute mapped to a point.
    /// </summary>
    public class MetasysPoint
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
        public bool IsDisplayData {  set; get; }
        /// <summary>
        /// The ID of the object where the point is mapped
        /// </summary>
        public Guid ObjectId { get; set; }
        /// <summary>
        /// Full URL of the attribute where the point is mapped
        /// </summary>
        public string AttributeUrl {get;   set; }
        /// <summary>
        /// Full URL of the object where the point is mapped
        /// </summary>
        public string ObjectUrl { get;  set; }
        /// <summary>
        /// Value of the attribute where the point is mapped
        /// </summary>
        public Variant PresentValue { get;  set; }
        
        /// <summary>
        /// Default Constructor for Point.
        /// </summary>
        public MetasysPoint()
        {
        }

        internal MetasysPoint(JToken token)
        {                   
            try
            {          
                EquipmentName = token["equipmentName"].Value<string>();
                ShortName = token["shortName"].Value<string>();
                Label = token["label"].Value<string>();
                Category = token["category"].Value<string>();
                IsDisplayData = token["isDisplayData"].Value<bool>();
                AttributeUrl = token["attributeUrl"].Value<string>();
                ObjectUrl = token["objectUrl"].Value<string>();            
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
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
