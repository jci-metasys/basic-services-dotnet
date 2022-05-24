using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Linq;
using System.Linq;
using Newtonsoft.Json;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// MetasysObject is a structure that holds information about a Metasys object.
    /// </summary>
    public class MetasysObject: Utils.ObjectUtil
    {
        private CultureInfo _CultureInfo;

        /// <summary>The item reference of the Metasys object.</summary>
        [JsonProperty(Required = Required.Always)]
        public string ItemReference { set; get; }

        /// <summary>The id of the Metasys object.</summary>
        [JsonProperty(Required = Required.Always)]
        public Guid Id { set; get; }

        /// <summary>The name of the Metasys object.</summary>
        [JsonProperty(Required = Required.Always)]
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
        /// Reference of the Metasys Object uthorization Category.
        /// </summary>
        public string CategoryUrl { get; set; }

        /// <summary>
        /// Metasys Object Authorization Category.
        /// </summary>
        public string ObjectCategory { get; set; }

        /// <summary>The direct children objects of the Metasys object.</summary>
        public IEnumerable<MetasysObject> Children { set;  get; }

        /// <summary>
        /// The number of direct children objects.
        /// </summary>
        /// <value>The number of children or -1 if there is no children data.</value>
        public int ChildrenCount { set; get; }      

        /// <summary>
        /// Default constructor for Metasys Object.
        /// </summary>
        public MetasysObject() { }

        internal MetasysObject(JToken token, ApiVersion version, IEnumerable<MetasysObject> children = null, CultureInfo cultureInfo = null, MetasysObjectTypeEnum? type =null)
        {
            _CultureInfo = cultureInfo;           
            Children = children??new List<MetasysObject>(); // Return empty list by convention for null         
            ChildrenCount = Children?.Count()??0; // Children count is 0 when children is null                                 
            Type = type;

            try
            {
                Id = new Guid(token["id"].Value<string>());
                ItemReference = token["itemReference"].Value<string>();
            }
            catch (Exception e)
            {
                throw new MetasysObjectException(token.ToString(), e);
            }

            try
            {
                Name = token["name"].Value<string>();
            }
            catch
            {
                Name = null;
            }

            try
            {
                Description = token["description"].Value<string>();
            }
            catch
            {
                Description = null;
            }

            try
            {
                // This applies for v2 and v1.
                TypeUrl =  (version < ApiVersion.v4)?  token["typeUrl"].Value<string>() : TypeUrl = String.Empty;
                if (Type == MetasysObjectTypeEnum.Space && TypeUrl.Length > 0)
                //if (Type == MetasysObjectTypeEnum.Space)
                {
                    // Set the specific category for Space
                    var typeId = TypeUrl.Split('/').Last();
                    // Convert space type to enum
                    Category = ((SpaceTypeEnum)int.Parse(typeId)).ToString();
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
                    ObjectType= token["objectType"].Value<string>();
                }
                catch
                {
                    ObjectType = null;
                }
            }
            try
            {
                CategoryUrl = token["categoryUrl"].Value<string>();
            }
            catch
            {
                CategoryUrl = null;
            }
            try
            {
                ObjectCategory = token["objectCategory"].Value<string>();
            }
            catch
            {
                ObjectCategory = null;
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

        /// <summary>
        /// Returns a value indicating whither this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is MetasysObject)
            {
                var other = (MetasysObject)obj;
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
                foreach(var item in Children)
                {
                    arrCode += item.GetHashCode();
                }
                code = (code * 7) + arrCode;
            }
                
            return code;
        }
    }
}
