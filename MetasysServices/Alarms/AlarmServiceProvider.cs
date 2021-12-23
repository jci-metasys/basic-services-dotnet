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

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provide alarm item for the endpoints of the Metasys Alarm API.
    /// </summary>
    public sealed class AlarmServiceProvider : BasicServiceProvider, IAlarmsService
    {
        private readonly CultureInfo _CultureInfo = new CultureInfo("en-US");

        /// <summary>
        /// Initializes a new instance of <see cref="AlarmServiceProvider"/> with supplied data.
        /// </summary>
        /// <param name="client">The FlurlClient to get response from URL.</param>
        /// <param name="version">The server's Api version.</param>
        /// <param name="logClientErrors">Set this flag to false to disable logging of client errors.</param>
        public AlarmServiceProvider(IFlurlClient client, ApiVersion version, bool logClientErrors=true):base(client, version, logClientErrors)
        {
        }

        /// <inheritdoc/>
        public async Task<PagedResult<Alarm>> GetAsync(AlarmFilter alarmFilter)
        {
            CheckVersion(Version);
            
            List<Alarm> alarms = new List<Alarm>();
            var response = await GetPagedResultsAsync<Alarm>("alarms", ToDictionary(alarmFilter)).ConfigureAwait(false);
            if (Version == ApiVersion.v3 || Version == ApiVersion.v4) {
                foreach (var item in response.Items) {
                    alarms.Add(CreateItem(item));
                }

                response = new PagedResult<Alarm> {
                    Items = alarms,
                    CurrentPage = response.CurrentPage,
                    PageCount = response.PageCount,
                    PageSize = response.PageSize,
                    Total = response.Total
                };
            }
            return response;
        }

        /// <inheritdoc/>
        public async Task<Alarm> FindByIdAsync(Guid alarmId)
        {
            CheckVersion(Version);

            var response = await GetRequestAsync("alarms", null, alarmId).ConfigureAwait(false);
            if (response["items"] != null) response = response["items"];
            
            var alarmData = JsonConvert.DeserializeObject<Alarm>(response.ToString());
            if (Version == ApiVersion.v3) {
                alarmData = CreateItem(alarmData);
            }
            else if (Version == ApiVersion.v4) {
                alarmData = JsonConvert.DeserializeObject<Alarm_V4>(response.ToString());
                alarmData = CreateItem_v4((Alarm_V4)alarmData);
            }
            else {
                alarmData = JsonConvert.DeserializeObject<Alarm>(response.ToString());
            }
            return alarmData;
        }
        /// <inheritdoc/>
        public Alarm FindById(Guid alarmId)
        {
            return FindByIdAsync(alarmId).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<Alarm>> GetForObjectAsync(Guid objectId, AlarmFilter alarmFilter)
        {
            CheckVersion(Version);

            List<Alarm> alarms = new List<Alarm>();
            var response = await GetPagedResultsAsync<Alarm>("objects", ToDictionary(alarmFilter), objectId, "alarms").ConfigureAwait(false);
            if (Version == ApiVersion.v3 || Version == ApiVersion.v4) {
                foreach (var item in response.Items) {
                    alarms.Add(CreateItem(item));
                }
                response = new PagedResult<Alarm> {
                    Items = alarms,
                    CurrentPage = response.CurrentPage,
                    PageCount = response.PageCount,
                    PageSize = response.PageSize,
                    Total = response.Total
                };
            }
            return response;
        }

        /// <inheritdoc/>
        public async Task<PagedResult<Alarm>> GetForNetworkDeviceAsync(Guid networkDeviceId, AlarmFilter alarmFilter)
        {
            CheckVersion(Version);

            List<Alarm> alarms = new List<Alarm>();
            var response = await GetPagedResultsAsync<Alarm>("networkDevices", ToDictionary(alarmFilter), networkDeviceId, "alarms").ConfigureAwait(false);
            if (Version == ApiVersion.v3 || Version == ApiVersion.v4) {
                foreach (var item in response.Items) {
                    alarms.Add(CreateItem(item));
                }

                response = new PagedResult<Alarm> {
                    Items = alarms,
                    CurrentPage = response.CurrentPage,
                    PageCount = response.PageCount,
                    PageSize = response.PageSize,
                    Total = response.Total
                };
            }
            return response;
        }


        /// <inheritdoc/>
        public PagedResult<Alarm> Get(AlarmFilter alarmFilter)
        {
            return GetAsync(alarmFilter).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public PagedResult<Alarm> GetForObject(Guid objectId, AlarmFilter alarmFilter)
        {
            return GetForObjectAsync(objectId, alarmFilter).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public PagedResult<Alarm> GetForNetworkDevice(Guid networkDeviceId, AlarmFilter alarmFilter)
        {
            return GetForNetworkDeviceAsync(networkDeviceId, alarmFilter).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public IEnumerable<AlarmAnnotation> GetAnnotations(Guid alarmId)
        {
            return GetAnnotationsAsync(alarmId).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AlarmAnnotation>> GetAnnotationsAsync(Guid alarmId)
        {
            // Retrieve JSON collection of Annotation
            var annotations= await GetAllAvailablePagesAsync("alarms",null,alarmId.ToString(),"annotations").ConfigureAwait(false);
            List<AlarmAnnotation> annotationsList = new List<AlarmAnnotation>();
            // Convert to a collection of AlarmAnnotation
            foreach (var token in annotations) {
                AlarmAnnotation alarmAnnotation = new AlarmAnnotation();
                // Build AlarmAnnotation object
                try {
                    alarmAnnotation.Text = token["text"].Value<string>();
                    alarmAnnotation.User = token["user"].Value<string>();
                    alarmAnnotation.CreationTime = token["creationTime"].Value<DateTime>();
                    alarmAnnotation.Action = token["action"].Value<string>();
                    alarmAnnotation.AlarmUrl = token["alarmUrl"].Value<string>();
                    annotationsList.Add(alarmAnnotation);
                } catch (Exception e) {
                    throw new MetasysObjectException(token.ToString(), e);
                }
            }
            return annotationsList;
        }


        private Alarm CreateItem(Alarm item)
        {
            try
            {
                var triggerValue = new Measurement
                {
                    Units = item.TriggerValue.Units != null ? ResourceManager.Localize(item.TriggerValue.Units, _CultureInfo) : null,
                    Value = item.TriggerValue.Value
                };

                item.TriggerValue = triggerValue;
            }
            catch (ArgumentNullException e)
            {
                // Something went wrong on object parsing
                throw new MetasysObjectException(e);
            }
            return item;
        }
        private Alarm_V4 CreateItem_v4(Alarm_V4 item)
        {
            try
            {
                item.TriggerValue.Value = item.TriggerValue.item;
                item.TriggerValue.Units = item.TriggerValue.Units != null ? ResourceManager.Localize(item.TriggerValue.Units, _CultureInfo) : null;
            }
            catch (ArgumentNullException e)
            {
                // Something went wrong on object parsing
                throw new MetasysObjectException(e);
            }
            return item;
        }

    }
}