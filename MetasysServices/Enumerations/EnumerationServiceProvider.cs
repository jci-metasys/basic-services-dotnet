using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using log4net.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JohnsonControls.Metasys.BasicServices.Utils;
using System.Dynamic;


namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provide enumeration item for the endpoints of the Metasys Enumerations API.
    /// </summary>
    public sealed class EnumerationServiceProvider : BasicServiceProvider, IEnumerationService
    {
        private readonly CultureInfo _CultureInfo = new CultureInfo("en-US");

        /// <summary>
        /// Initializes a new instance of <see cref="NetworkDeviceServiceProvider"/> with supplied data.
        /// </summary>
        /// <param name="client">The FlurlClient to get response from URL.</param>
        /// <param name="version">The server's Api version.</param>
        /// <param name="logClientErrors">Set this flag to false to disable logging of client errors.</param>
        public EnumerationServiceProvider(IFlurlClient client, ApiVersion version, bool logClientErrors = true) : base(client, version, logClientErrors)
        {
        }

        // Get ------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public IEnumerable<MetasysEnumeration> Get()
        {
            return GetAsync().GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysEnumeration>> GetAsync()
        {
            List<MetasysEnumeration> enums = new List<MetasysEnumeration>() { };

            if (Version < ApiVersion.v4) { throw new MetasysUnsupportedApiVersion(Version.ToString()); }
            try
            {
                var response = await Client.Request(new Url("enumerations"))
                    .GetJsonAsync<JToken>()
                    .ConfigureAwait(false);
                try
                {
                    var items = response["items"];
                    dynamic kvpList = JsonConvert.DeserializeObject<ExpandoObject>(items.ToString());
                    foreach (KeyValuePair<string, object> kvp in kvpList)
                    {
                        if (kvp.Key.Length > 0)
                        {
                            var itm = kvp.Value as IDictionary<string, object>;
                            String key = kvp.Key;
                            String name = (itm.ContainsKey("name")) ? itm["name"].ToString() : String.Empty;
                            bool isTwoState = bool.Parse((itm.ContainsKey("isTwoState")) ? itm["isTwoState"].ToString() : Convert.ToString(false));
                            bool isMultiState = bool.Parse((itm.ContainsKey("isMultiState")) ? itm["isMultiState"].ToString() : Convert.ToString(false));
                            int numberOfStates = int.Parse((itm.ContainsKey("numberOfStates")) ? itm["numberOfStates"].ToString() : Convert.ToString(0));

                            var enumItem = new MetasysEnumeration(key, name, isTwoState, isMultiState, numberOfStates, Culture);
                            enums.Add(enumItem);
                        }
                    }
                }
                catch (System.NullReferenceException e)
                {
                    throw new MetasysHttpParsingException(response.ToString(), e);
                }
            }
            catch (FlurlHttpException e)
            {
                ThrowHttpException(e);
            }
            return enums;
        }

        // GetValues ------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public IEnumerable<MetasysEnumValue> GetValues(String enumerationKey)
        {
            return GetEnumValues(enumerationKey);
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysEnumValue>> GetValuesAsync(String enumerationKey)
        {
            return await GetEnumValuesAsync(enumerationKey);
        }

        // Delete ----------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public void Delete(string enumerationId)
        {
            DeleteAsync(enumerationId).GetAwaiter().GetResult();
        }

        public async Task DeleteAsync(string enumerationId)
        {
            try
            {
                if (Version < ApiVersion.v4) { throw new MetasysUnsupportedApiVersion(Version.ToString());}
               var response = await Client.Request(new Url("enumerations")
                                                            .AppendPathSegments(enumerationId))
                                                            .DeleteAsync()
                                                            .ConfigureAwait(false);
            }
            catch (FlurlHttpException e)
            {
                ThrowHttpException(e);
            }
        }

    }
}
