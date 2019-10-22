using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace JohnsonControls.Metasys.BasicServices.Models
{
    public struct MetasysObject
    {
        private CultureInfo _CultureInfo;

        public string ItemReference { private set; get; }

        public Guid Id { private set; get; }

        public string Name { private set; get; }

        public string Type { private set; get; }

        public string Description { private set; get; }

        public IEnumerable<MetasysObject> Children { private set; get; }

        // The number of children, -1 if there is no children data
        public int ChildrenCount { private set; get; }

        internal MetasysObject(JToken token, string type = "", IEnumerable<MetasysObject> children = null, CultureInfo cultureInfo = null)
        {
            _CultureInfo = cultureInfo;
            Type = type;
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
            }
            catch
            {
                Id = Guid.Empty;
            }

            string placeholder = "";
            try
            {
                ItemReference = token["itemReference"].Value<string>();
            }
            catch
            {
                ItemReference = placeholder;
            }

            try
            {
                Name = token["name"].Value<string>();
            }
            catch
            {
                Name = placeholder;
            }

            try
            {
                Description = token["description"].Value<string>();
            }
            catch
            {
                Description = placeholder;
            }
        }

        public override string ToString()
        {
            return string.Concat("Id: ", Id, "\n",
                "ItemReference: ", ItemReference, "\n",
                "Name: ", Name, "\n",
                "Type: ", Type, "\n",
                "Description: ", Description, "\n",
                "Number of Children: ", ChildrenCount);
        }
    }
}
