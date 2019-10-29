using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Command is a structure that holds information about a Metasys object command.
    /// </summary>
    public struct Command
    {
        private CultureInfo _CultureInfo;

        /// <summary>
        /// The translated title of the command.
        /// </summary>
        /// <value>The translated title of the command or the default en-US version.</value>
        public string Title { private set; get; }

        /// <summary>
        /// The title enumeration key of the command.
        /// </summary>
        /// <value>An enumeration key from the commandIdEnumSet or the default en-US title if not found .</value>
        public string TitleEnumerationKey { private set; get; }

        /// <summary>
        /// The command id used to send command requests.
        /// </summary>
        public string CommandId { private set; get; }

        /// <summary>
        /// The list of values that can be modified by the command.
        /// </summary>
        /// <value>A list of Items or null if the command does not accept any parameter values.</value>
        public IEnumerable<Item> Items { private set; get; }

        /// <summary>
        /// A value that can be changed by a command.
        /// </summary>
        public struct Item
        {
            /// <summary>
            /// The title of the value to change when sending the command request.
            /// </summary>
            /// <value>The title or "oneOf" if the Item is an enumeration.</value>
            public string Title;

            /// <summary>
            /// The type of the Item.
            /// </summary>
            /// <value>Possible values include "number", "enum".</value>
            public string Type;

            /// <summary>
            /// The possible enumeration values the Item can be.
            /// </summary>
            /// <value>A list of EnumerationItems or null if not an enumeration.</value>
            public IEnumerable<EnumerationItem> EnumerationValues;

            /// <summary>
            /// The minimum value the number can be if a number.
            /// </summary>
            /// <value>The minimum value of the number or 1 if not a number.</value>
            public double Minimum;

            /// <summary>
            /// The maximum value the number can be if a number.
            /// </summary>
            /// <value>The maximum value of the number or 1 if not a number.</value>
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

        /// <summary>
        /// The value and translated title of an enumeration item.
        /// </summary>
        public struct EnumerationItem
        {
            /// <summary>
            /// The translated string of the enumeration value.
            /// </summary>
            /// <value>Translated title or default en-US value if not found.</value>
            public string Title;

            /// <summary>
            /// The title enumeration key used when sending the command request.
            /// </summary>
            /// <value>An enumeration key.</value>
            public string TitleEnumerationKey { private set; get; }

            internal EnumerationItem(string title, string key)
            {
                Title = title;
                TitleEnumerationKey = key;
            }
        }

        internal Command(JToken token, CultureInfo cultureInfo)
        {
            _CultureInfo = cultureInfo;
            TitleEnumerationKey = token["title"].Value<string>();
            // Translate the title from en-US to specified culture.
            Title = MetasysClient.StaticLocalize(TitleEnumerationKey, _CultureInfo);
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
                        string iTitle = item["title"].Value<string>();
                        string type = item["type"].Value<string>();
                        double maximum = item["maximum"].Value<double>();
                        double minimum = item["minimum"].Value<double>();
                        itemsList.Add(new Item(iTitle, type, minimum, maximum));
                    }
                    else
                    {
                        List<EnumerationItem> enumList = new List<EnumerationItem>();

                        foreach (var e in enumSet)
                        {
                            string eTitle = e["title"].Value<string>();
                            string eKey = e["const"].Value<string>();
                            // The title returned is an en-US value, translate the enum
                            string translatedTitle = MetasysClient.StaticLocalize(eKey, _CultureInfo);
                            if (translatedTitle != eKey)
                            {
                                // A translation was found
                                enumList.Add(new EnumerationItem(translatedTitle, eKey));
                            }
                            else
                            {
                                // A translation could not be found
                                enumList.Add(new EnumerationItem(eTitle, eKey));
                            }
                            
                        }
                        itemsList.Add(new Item("oneOf", "enum", 1, 1, enumList));
                    }
                }
                Items = itemsList;
            }
        }

        /// <summary>
        /// Overwrites the ToString method to print out a command and all items it contains.
        /// </summary>
        /// <returns>A string representation of the Command.</returns>
        public override string ToString()
        {
            string str = string.Concat("Title: ", Title, "\nKey: ", TitleEnumerationKey, "\nCommandId: ", CommandId, "\nItems: ");
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
                            str = string.Concat(str, "\n\n    Title: ", value.Title, "\n    Key: ", value.TitleEnumerationKey);
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
