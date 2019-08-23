using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    public struct MetasysObject
    {
        private CultureInfo _CultureInfo;

        public string ItemReference { private set; get; }

        public Guid Id { private set; get; }

        public string Name { private set; get; }

        public string Type { private set; get; }

        internal MetasysObject(JToken token, string type = "", CultureInfo cultureInfo = null)
        {
            _CultureInfo = cultureInfo;
            Type = type;
            
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
        }
    }
}