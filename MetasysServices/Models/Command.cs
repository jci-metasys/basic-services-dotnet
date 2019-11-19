using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            public double? Minimum;

            /// <summary>
            /// The maximum value the number can be if a number.
            /// </summary>
            /// <value>The maximum value of the number or 1 if not a number.</value>
            public double? Maximum;

            internal Item(string title, string type, double? minimum = 1, double? maximum = 1, IEnumerable<EnumerationItem> enums = null)
            {
                Title = title;
                Type = type;
                Minimum = minimum;
                Maximum = maximum;
                EnumerationValues = enums;
            }

            /// <summary>
            /// Returns a value indicating whither this instance has values equal to a specified object.
            /// </summary>
            /// <param name="obj"></param>
            public override bool Equals(object obj)
            {
                if (obj != null && obj is Item)
                {
                    var other = (Item)obj;
                    bool areEqual = (((this.Type == null && other.Type == null) || 
                        (this.Type != null && this.Type.Equals(other.Type))) &&
                        ((this.Title == null && other.Title == null) || 
                            (this.Title != null && this.Title.Equals(other.Title))) &&
                        ((!this.Maximum.HasValue && !other.Maximum.HasValue) || 
                            (this.Maximum.HasValue && other.Maximum.HasValue && 
                            this.Maximum.Value.Equals(other.Maximum.Value))) &&
                        ((!this.Minimum.HasValue && !other.Minimum.HasValue) || 
                            (this.Minimum.HasValue && other.Minimum.HasValue && 
                            this.Minimum.Value.Equals(other.Minimum.Value))));
                    if (areEqual)
                    {
                        if (this.EnumerationValues == null ^ other.EnumerationValues == null)
                        {
                            return false;
                        } 
                        else if (this.EnumerationValues != null && other.EnumerationValues != null)
                        {
                            return Enumerable.SequenceEqual(this.EnumerationValues, other.EnumerationValues);
                        }
                    }
                    return areEqual;                        
                }
                return false;
            }

            /// <summary></summary>
            public override int GetHashCode()
            {
                var code = 13 * 13;
                if (Type != null)
                    code = (code * 7) + Type.GetHashCode();
                if (Title != null)
                    code = (code * 7) + Title.GetHashCode();
                if (Maximum.HasValue)
                    code = (code * 7) + Maximum.Value.GetHashCode();
                if (Minimum.HasValue)
                    code = (code * 7) + Minimum.Value.GetHashCode();
                if (EnumerationValues != null)
                {
                    var arrCode = 0;
                    foreach(var item in EnumerationValues)
                    {
                        arrCode += item.GetHashCode();
                    }
                    code = (code * 7) + arrCode;
                }
                return code;
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

            /// <summary>
            /// Returns a value indicating whither this instance has values equal to a specified object.
            /// </summary>
            /// <param name="obj"></param>
            public override bool Equals(object obj)
            {
                if (obj != null && obj is EnumerationItem)
                {
                    var other = (EnumerationItem)obj;
                    return this.TitleEnumerationKey.Equals(other.TitleEnumerationKey);
                }
                return false;
            }

            /// <summary></summary>
            public override int GetHashCode()
            {
                if (TitleEnumerationKey != null)
                    return TitleEnumerationKey.GetHashCode();
                return 17;
            }
        }

        internal Command(JToken token, CultureInfo cultureInfo)
        {
            try
            {
                _CultureInfo = cultureInfo;
                Title = token["title"].Value<string>();
                // Translate the title from en-US to specified culture.
                TitleEnumerationKey = MetasysClient.StaticGetCommandEnumeration(Title);
                string translatedTitle = MetasysClient.StaticLocalize(TitleEnumerationKey, _CultureInfo);
                if (translatedTitle != TitleEnumerationKey)
                {
                    // A translation was found
                    Title = translatedTitle;
                }

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
                            double? maximum = item["maximum"].Value<double?>();
                            double? minimum = item["minimum"].Value<double?>();
                            itemsList.Add(new Item(iTitle, type, minimum, maximum));
                        }
                        else
                        {
                            List<EnumerationItem> enumList = new List<EnumerationItem>();

                            foreach (var e in enumSet)
                            {
                                string eTitle = e["title"].Value<string>();
                                string eKey = e["const"].Value<string>();
                                // The title returned is an en-US value, translate the key
                                string eTranslatedTitle = MetasysClient.StaticLocalize(eKey, _CultureInfo);
                                if (eTranslatedTitle != eKey)
                                {
                                    // A translation was found
                                    eTitle = eTranslatedTitle;
                                }
                                enumList.Add(new EnumerationItem(eTitle, eKey));
                            }
                            itemsList.Add(new Item("oneOf", "enum", 1, 1, enumList));
                        }
                    }
                    Items = itemsList;
                }
            } 
            catch (Exception e)
            {
                throw new MetasysCommandException(token.ToString(), e);
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
                        if (item.Maximum.HasValue)
                            str = string.Concat(str, "\n  Maximum: ", item.Maximum.Value.ToString());

                        if (item.Minimum.HasValue)
                            str = string.Concat(str, "\n  Minimum: ", item.Minimum.Value.ToString());
                    }
                }
                str = string.Concat(str, "\n");
            }
            return str;
        }

        /// <summary>
        /// Returns a value indicating whither this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Command)
            {
                var other = (Command)obj;
                bool areEqual = this.CommandId.Equals(other.CommandId) && 
                    this.TitleEnumerationKey.Equals(other.TitleEnumerationKey);
                if (areEqual)
                {
                    if (this.Items == null ^ other.Items == null)
                    {
                        return false;
                    } 
                    else if (this.Items != null && other.Items != null)
                    {
                        return Enumerable.SequenceEqual(this.Items, other.Items);
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
            code = (code * 7) + CommandId.GetHashCode();
            if (TitleEnumerationKey != null)
                code = (code * 7) + TitleEnumerationKey.GetHashCode();
            if (Items != null)
            {
                var arrCode = 0;
                foreach(var item in Items)
                {
                    arrCode += item.GetHashCode();
                }
                code = (code * 7) + arrCode;
            }
            return code;
        }
    }
}
