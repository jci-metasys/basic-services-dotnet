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
        private const string BaseParam = "alarms";

        private CultureInfo _CultureInfo;

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
            List<Alarm> alarms = new List<Alarm>();
            var response = await GetPagedResultsAsync<JToken>("alarms", ToDictionary(alarmFilter)).ConfigureAwait(false);

            foreach (var item in response.Items)
            {
                alarms.Add(await CreateItem(item));
            }

            return new PagedResult<Alarm>
            {
                Items = alarms,
                CurrentPage = response.CurrentPage,
                PageCount = response.PageCount,
                PageSize = response.PageSize,
                Total = response.Total
            };
        }

        /// <inheritdoc/>
        public async Task<Alarm> FindByIdAsync(Guid alarmId)
        {
            var response=await GetRequestAsync("alarms", null, alarmId).ConfigureAwait(false);
            if (response["items"]!=null)
                {
                response = response["items"];
                }
            return await CreateItem(response);
        }

        /// <inheritdoc/>
        public async Task<PagedResult<Alarm>> GetForObjectAsync(Guid objectId, AlarmFilter alarmFilter)
        {
            List<Alarm> alarms = new List<Alarm>();
            var response = await GetPagedResultsAsync<JToken>("objects", ToDictionary(alarmFilter), objectId, "alarms").ConfigureAwait(false);
            foreach (var item in response.Items)
            {
                alarms.Add(await CreateItem(item));
            }
            return new PagedResult<Alarm>
            {
                Items = alarms,
                CurrentPage = response.CurrentPage,
                PageCount = response.PageCount,
                PageSize = response.PageSize,
                Total = response.Total
            };
        }

        /// <inheritdoc/>
        public async Task<PagedResult<Alarm>> GetForNetworkDeviceAsync(Guid networkDeviceId, AlarmFilter alarmFilter)
        {
            List<Alarm> alarms = new List<Alarm>();
            var response = await GetPagedResultsAsync<JToken>("networkDevices", ToDictionary(alarmFilter), networkDeviceId, "alarms").ConfigureAwait(false);

            foreach (var item in response.Items)
            {
                alarms.Add(await CreateItem(item));
            }

            return new PagedResult<Alarm>
            {
                Items = alarms,
                CurrentPage = response.CurrentPage,
                PageCount = response.PageCount,
                PageSize = response.PageSize,
                Total = response.Total
            };
        }

        /// <inheritdoc/>
        public Alarm FindById(Guid alarmId)
        {
            return FindByIdAsync(alarmId).GetAwaiter().GetResult();
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
            var annotations= await GetAllAvailablePagesAsync("alarms",null,alarmId.ToString(),"annotations");
            List<AlarmAnnotation> annotationsList = new List<AlarmAnnotation>();
            // Convert to a collection of AlarmAnnotation
            foreach (var token in annotations)
            {
                AlarmAnnotation alarmAnnotation = new AlarmAnnotation();
                // Build AlarmAnnotation object
                try
                {
                    alarmAnnotation.Text = token["text"].Value<string>();
                    alarmAnnotation.User = token["user"].Value<string>();
                    alarmAnnotation.CreationTime = token["creationTime"].Value<DateTime>();
                    alarmAnnotation.Action = token["action"].Value<string>();
                    alarmAnnotation.AlarmUrl = token["alarmUrl"].Value<string>();
                    annotationsList.Add(alarmAnnotation);
                }
                catch (Exception e)
                {
                    throw new MetasysObjectException(token.ToString(), e);
                }
            }
            return annotationsList;
        }


        private async Task<Alarm> CreateItem(JToken item)
        {
            Alarm alarm = new Alarm();
            string unitsUrl = string.Empty;
            string typeUrl = string.Empty;
            string categoryUrl = string.Empty;

            try
            {
                alarm.Id = (Guid)item["id"];
                alarm.Self = item["self"].Value<string>();
                alarm.ItemReference = item["itemReference"].Value<string>();
                alarm.Name = item["name"].Value<string>();
                alarm.Message = item["message"].Value<string>();
                alarm.IsAckRequired = item["isAckRequired"].Value<bool>();
                alarm.Priority = item["priority"].Value<int>();
                alarm.CreationTime = item["creationTime"].Value<string>();
                alarm.IsAcknowledged = item["isAcknowledged"].Value<bool>();
                alarm.IsDiscarded = item["isDiscarded"].Value<bool>();
                alarm.ObjectUrl = item["objectUrl"].Value<string>();
                alarm.AnnotationsUrl = item["annotationsUrl"].Value<string>();

                if (Version < ApiVersion.v3)
                {
                    typeUrl = item["typeUrl"].Value<string>();
                    categoryUrl = item["categoryUrl"].Value<string>();
                    var unitValue = item["triggerValue"]["unitsUrl"] ?? item["triggerValue"]["valueEnumMemberUrl"];
                    unitsUrl = unitValue.Value<string>();
                }
                else
                {
                    alarm.Type = item["type"].Value<string>();
                    alarm.Category = item["category"].Value<string>();
                    var unitVar = item["triggerValue"].Contains("units") ? item["triggerValue"]["units"].Value<string>() : null;
                    var measurement = new Measurement
                    {
                        Units = ResourceManager.Localize(unitVar, _CultureInfo),
                        Value = item["triggerValue"]["value"].Value<string>()
                    };

                    alarm.TriggerValue = measurement;
                }
            }
            catch (ArgumentNullException e)
            {
                // Something went wrong on object parsing
                throw new MetasysObjectException(e);
            }
            if (Version < ApiVersion.v3)
            {
                // On Api v2 and v1 there was the url endpoint of the enum instead of the fully qualified enumeration string
                var measurement = new Measurement
                {
                    Units = await GetEnumValue(unitsUrl),
                    Value = item["triggerValue"]["value"].Value<string>()
                };

                alarm.TriggerValue = measurement;
                alarm.Type = await GetEnumValue(typeUrl);
                alarm.Category = await GetEnumValue(categoryUrl);
            }

            return alarm;
        }

        private async Task<string> GetEnumValue(string url)
        {
            Dictionary<string, string> Type = new Dictionary<string, string>();

            var typeId = url.Split('/').Last();
            if (!Type.ContainsKey(typeId))
            {
                var urlValue = await GetWithFullUrl(url).ConfigureAwait(false);
                Type.Add(typeId, urlValue["description"].Value<string>());
            }

            return Type[typeId];
        }

    }
}