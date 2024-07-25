﻿using JohnsonControls.Metasys.BasicServices.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Command is a class that holds information about a Metasys object command.
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public Command() { }

        private CultureInfo _CultureInfo;

        /// <summary>
        /// The translated title of the command.
        /// </summary>
        /// <value>The translated title of the command or the default en-US version.</value>
        public string Title { set; get; }

        /// <summary>
        /// The title enumeration key of the command.
        /// </summary>
        /// <value>An enumeration key from the commandIdEnumSet or the default en-US title if not found .</value>
        public string TitleEnumerationKey { set; get; }

        /// <summary>
        /// The command id used to send command requests.
        /// </summary>
        public string CommandId { set; get; }

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
                    foreach (var item in EnumerationValues)
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

        internal Command(JToken token, CultureInfo cultureInfo, ApiVersion version)
        {
            if (version > ApiVersion.v3)
            {
                CreateCommand_4(token, cultureInfo);
            }
            else
            {
                CreateCommand_2_3(token, cultureInfo);
            }
        }

        private void CreateCommand_2_3(JToken token, CultureInfo cultureInfo)
        {
            try
            {
                JArray items;
                _CultureInfo = cultureInfo;
                CommandId = token["commandId"].Value<string>();
                Title = token["title"].Value<string>();
                TitleEnumerationKey = ResourceManager.GetCommandEnumeration(Title);
                // Translate the title from en-US to specified culture.
                string translatedTitle = ResourceManager.Localize(TitleEnumerationKey, _CultureInfo);
                if (translatedTitle != TitleEnumerationKey)
                {
                    // A translation was found
                    Title = translatedTitle;
                }

                Items = null;
                items = token["items"] as JArray;

                List<Item> itemsList = new List<Item>();
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
                            double? maximum = (item["maximum"] != null) ? item["maximum"].Value<double?>() : null;
                            double? minimum = (item["minimum"] != null) ? item["minimum"].Value<double?>() : null;
                            //add the item
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
                                string eTranslatedTitle = ResourceManager.Localize(eKey, _CultureInfo);
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

        private void CreateCommand_4(JToken token, CultureInfo cultureInfo)
        {
            try
            {
                JArray items = null;
                List<EnumerationItem> enumList = null;

                _CultureInfo = cultureInfo;
                Title = token["title"].Value<string>();
                //Populate the properties according to the API version
                TitleEnumerationKey = token["id"].Value<string>();
                CommandId = TitleEnumerationKey.Replace("commandIdEnumSet.", "");
                if (token["commandSet"] == null)
                {
                    //This case is valid for analog
                    if ((token["commandBodySchema"]["properties"]["parameters"] != null)
                        && (token["commandBodySchema"]["properties"]["parameters"]["items"] != null))
                    {
                        items = token["commandBodySchema"]["properties"]["parameters"]["items"] as JArray;
                    }
                }
                else
                {
                    //This case IServiceProvider valid for binary
                    if (token["commandSet"] != null)
                    {
                        items = token["commandSet"] as JArray;
                    }
                    enumList = new List<EnumerationItem>();
                }

                // Translate the title from en-US to specified culture.
                string translatedTitle = ResourceManager.Localize(TitleEnumerationKey, _CultureInfo);
                if (translatedTitle != TitleEnumerationKey)
                {
                    // A translation was found
                    Title = translatedTitle;
                }

                Items = null;

                List<Item> itemsList = new List<Item>();
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        if (enumList == null)
                        {
                            string iTitle = item["title"].Value<string>();
                            string type = item["type"].Value<string>();
                            double? maximum = (item["maximum"] != null) ? item["maximum"].Value<double?>() : null;
                            double? minimum = (item["minimum"] != null) ? item["minimum"].Value<double?>() : null;
                            //... there are other properties that could be retrieved
                            itemsList.Add(new Item(iTitle, type, minimum, maximum));
                        }
                        else
                        {
                            string eTitle = item["title"].Value<string>();
                            string eKey = item["id"].Value<string>();
                            enumList.Add(new EnumerationItem(eTitle, eKey));
                        }
                    }
                    if (enumList != null)
                    {
                        itemsList.Add(new Item("oneOf", "enum", 1, 1, enumList));
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
                foreach (var item in Items)
                {
                    arrCode += item.GetHashCode();
                }
                code = (code * 7) + arrCode;
            }
            return code;
        }
    }
}
