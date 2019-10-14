using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JohnsonControls.Metasys.BasicServices.Models
{
    public struct Command
    {
        private CultureInfo _CultureInfo;

        // Translate if specified culture is not US_en
        public string Title { private set; get; }

        public string CommandId { private set; get; }

        public IEnumerable<Item> Items { private set; get; }

        public struct Item
        {
            public string Title;

            // If the Item is a constant this should be "const" otherwise the type specified
            public string Type;

            // Null unless Type is "const"
            public IEnumerable<EnumerationItem> EnumerationValues;

            // If type is not number this value is 1
            public double Minimum;

            // If type is not number this value is 1
            public double Maximum;

            internal Item(string title, string type, double minimum = 1, double maximum = 1, IEnumerable<EnumerationItem> enums = null)
            {
                Title = title;
                Type = type;
                Minimum = minimum;
                Maximum = maximum;
                EnumerationValues = enums;
            }
        }

        public struct EnumerationItem
        {
            public string Title;

            public string Value;

            internal EnumerationItem(string title, string value)
            {
                Title = title;
                Value = value;
            }
        }

        internal Command(JToken token, CultureInfo cultureInfo = null)
        {
            _CultureInfo = cultureInfo;
            Title = token["title"].Value<string>();
            CommandId = token["commandId"].Value<string>();
            Items = null;
            List<Item> itemsList = new List<Item>();
            var items = token["items"] as JArray;

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    // Check if a value or an enum
                    var enumSet = item["oneOf"] as JArray;

                    if (enumSet == null)
                    {
                        string title = item["title"].Value<string>();
                        string type = item["type"].Value<string>();
                        double maximum = item["maximum"].Value<double>();
                        double minimum = item["minimum"].Value<double>();
                        itemsList.Add(new Item(title, type, minimum, maximum));
                    }
                    else
                    {
                        List<EnumerationItem> enumList = new List<EnumerationItem>();

                        foreach (var e in enumSet)
                        {
                            string eTitle = e["title"].Value<string>();
                            string eValue = e["const"].Value<string>();
                            enumList.Add(new EnumerationItem(eTitle, eValue));
                        }
                        itemsList.Add(new Item("oneOf", "enum", 1, 1, enumList));
                    }
                }
                Items = itemsList;
            }
        }

        public override string ToString()
        {
            string str = string.Concat("Title: ", Title, "\nCommandId: ", CommandId, "\nItems: ");
            if (Items != null)
            {
                foreach (var item in Items)
                {
                    str = string.Concat(str, "\n\n  Title: ", item.Title, "\n  Type: ", item.Type);
                    if (item.EnumerationValues != null)
                    {
                        str = string.Concat(str, "\n  Items: ");
                        foreach (var value in item.EnumerationValues)
                        {
                            str = string.Concat(str, "\n\n    Title: ", value.Title, "\n    Value: ", value.Value);
                        }
                    }
                    else
                    {
                        str = string.Concat(str, "\n  Maximum: ", item.Maximum, "\n  Minimum: ", item.Minimum);
                    }
                }
                str = string.Concat(str, "\n");
            }
            return str;
        }
    }
}
