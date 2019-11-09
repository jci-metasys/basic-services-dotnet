using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// MetasysObject is a structure that holds information about a Metasys object.
    /// </summary>
    public struct MetasysObject
    {
        private CultureInfo _CultureInfo;

        /// <summary>The item reference of the Metasys object.</summary>
        public string ItemReference { private set; get; }

        /// <summary>The id of the Metasys object.</summary>
        public Guid Id { private set; get; }

        /// <summary>The name of the Metasys object.</summary>
        public string Name { private set; get; }   

        /// <summary>The description of the Metasys object.</summary>
        public string Description { private set; get; }

        /// <summary>The direct children objects of the Metasys object.</summary>
        public IEnumerable<MetasysObject> Children { private set; get; }

        /// <summary>
        /// The number of direct children objects.
        /// </summary>
        /// <value>The number of children or -1 if there is no children data.</value>
        public int ChildrenCount { private set; get; }

        internal MetasysObject(JToken token, IEnumerable<MetasysObject> children = null, CultureInfo cultureInfo = null)
        {
            _CultureInfo = cultureInfo;           
            Children = children;
            if (Children != null)
            {
                ChildrenCount = Children.ToList().Count;
            }
            else
            {
                ChildrenCount = -1;
            }

            try
            {
                Id = new Guid(token["id"].Value<string>());
                ItemReference = token["itemReference"].Value<string>();
                Name = token["name"].Value<string>();
                Description = token["description"].Value<string>();
            }
            catch (Exception e)
            {
                throw new MetasysObjectException(token.ToString(), e);
            }   
        }

        /// <summary>
        /// Overwrites the ToString method to print out an object's information.
        /// </summary>
        /// <returns>A string representation of the Command.</returns>
        public override string ToString()
        {
            return string.Concat("Id: ", Id, "\n",
                "ItemReference: ", ItemReference, "\n",
                "Name: ", Name, "\n",             
                "Description: ", Description, "\n",
                "Number of Children: ", ChildrenCount);
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
