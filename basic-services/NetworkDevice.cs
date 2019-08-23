using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    public struct NetworkDevice
    {
        private CultureInfo _CultureInfo;

        public string ItemReference { private set; get; }

        public Guid Id { private set; get; }

        public string Name { private set; get; }

        public string Type { private set; get; }

        public string Description { private set; get; }

        public string FirmwareVersion { private set; get; }

        public string IpAddress { private set; get; }

        internal NetworkDevice(JToken token, string type = "", CultureInfo cultureInfo = null)
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

            try
            {
                Description = token["description"].Value<string>();
            }
            catch
            {
                Description = placeholder;
            }

            try
            {
                FirmwareVersion = token["firmwareVersion"].Value<string>();
            }
            catch
            {
                FirmwareVersion = placeholder;
            }

            try
            {
                IpAddress = token["ipAddress"].Value<string>();
            }
            catch
            {
                IpAddress = placeholder;
            }
        }
    }
}