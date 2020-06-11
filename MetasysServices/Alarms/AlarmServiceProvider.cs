using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Resources;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provide alarm item for the endpoints of the Metasys Alarm API.
    /// </summary>
    public sealed class AlarmServiceProvider : BasicServiceProvider, IAlarmsService
    {

        private const string BaseParam = "alarms";
        private readonly IFlurlClient client;


        /// <summary>
        /// Initializes a new instance of <see cref="AlarmServiceProvider"/> with supplied data.
        /// </summary>
        /// <param name="client">The FlurlClient to get response from URL.</param>
        /// <param name="version">The server's Api version.</param>
        /// <param name="logClientErrors">Set this flag to false to disable logging of client errors.</param>
        public AlarmServiceProvider(IFlurlClient client, ApiVersion version, bool logClientErrors=true):base(client, version, logClientErrors)
        {           
        }

        /// <summary>
        /// Retrieves a collection of alarms asynchronously.
        /// </summary>
        /// <param name="alarmFilter">The alarmFilter to be applied to alarms list.</param>
        /// <returns>The list of alarms.</returns>
        public async Task<PagedResult<Alarm>> GetAlarmsAsync(AlarmFilter alarmFilter)
        {                
            return await GetPagedResultsAsync<Alarm>("alarms", ToDictionary(alarmFilter)).ConfigureAwait(false);            
        }

        /// <summary>
        /// Retrieves the specified alarm asynchronously.
        /// </summary>
        /// <param name="alarmId">The identifier of the alarm.</param>
        /// <returns>The alarm details</returns>
        public async Task<Alarm> GetSingleAlarmAsync(Guid alarmId)
        {
            var response=await GetRequestAsync("alarms", null, alarmId).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<Alarm>(response.ToString());
        }

        /// <summary>
        /// Retrieves a collection of alarms for the specified object asynchronously.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <param name="alarmFilter">TThe alarm alarmFilter to get alarms.</param>
        /// <returns>The list of alarms for the specified object.</returns>

        public async Task<PagedResult<Alarm>> GetAlarmsForAnObjectAsync(Guid objectId, AlarmFilter alarmFilter)
        {
            return await GetPagedResultsAsync<Alarm>("objects", ToDictionary(alarmFilter), objectId, "alarms").ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a collection of alarms for the specified network device asynchronously.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the network device.</param>
        /// <param name="alarmFilter">The alarm alarmFilter to get alarms.</param>
        /// <returns>The list of alarms for the specified object.</returns>
        public async Task<PagedResult<Alarm>> GetAlarmsForNetworkDeviceAsync(Guid networkDeviceId, AlarmFilter alarmFilter)
        {
            return await GetPagedResultsAsync<Alarm>("networkDevices", ToDictionary(alarmFilter), networkDeviceId, "alarms").ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the specified alarm.
        /// </summary>
        /// <param name="alarmId">The identifier of the alarm.</param>
        /// <returns>The alarm details</returns>
        public Alarm GetSingleAlarm(Guid alarmId)
        {
            return GetSingleAlarmAsync(alarmId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a collection of alarms.
        /// </summary>
        /// <param name="alarmFilter">The alarm alarmFilter to get alarms.</param>
        /// <returns>The list of alarms.</returns>
        public PagedResult<Alarm> GetAlarms(AlarmFilter alarmFilter)
        {
            return GetAlarmsAsync(alarmFilter).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <param name="alarmFilter">TThe alarm alarmFilter to get alarms.</param>
        /// <returns>The list of alarms for the specified object.</returns>
        public PagedResult<Alarm> GetAlarmsForAnObject(Guid objectId, AlarmFilter alarmFilter)
        {
            return GetAlarmsForAnObjectAsync(objectId, alarmFilter).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a collection of alarms for the specified network device.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the network device.</param>
        /// <param name="alarmFilter">The alarm alarmFilter to get alarms.</param>
        /// <returns>The list of alarms for the specified object.</returns>
        public PagedResult<Alarm> GetAlarmsForNetworkDevice(Guid networkDeviceId, AlarmFilter alarmFilter)
        {
            return GetAlarmsForNetworkDeviceAsync(networkDeviceId, alarmFilter).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public IEnumerable<AlarmAnnotation> GetAlarmAnnotations(Guid alarmId)
        {
            return GetAlarmAnnotationsAsync(alarmId).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AlarmAnnotation>> GetAlarmAnnotationsAsync(Guid alarmId)
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
    }
}