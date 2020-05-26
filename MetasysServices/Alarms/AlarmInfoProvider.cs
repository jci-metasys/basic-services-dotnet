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
    public sealed class AlarmInfoProvider : BasicServiceProvider, IProvideAlarmInfo
    {

        private const string BaseParam = "alarms";
        private readonly IFlurlClient client;


        /// <summary>
        /// Initializes a new instance of <see cref="AlarmInfoProvider"/> with supplied data.
        /// </summary>
        /// <param name="client">The FlurlClient to get response from URL.</param>
        /// <param name="logClientErrors">Set this flag to false to disable logging of client errors.</param>
        public AlarmInfoProvider(IFlurlClient client, bool logClientErrors=true):base(client, logClientErrors)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client),
                                               "FlurlClient can not be null.");
        }

        /// <summary>
        /// Retrieves a collection of alarms asynchronously.
        /// </summary>
        /// <param name="alarmFilter">The alarmFilter to be applied to alarms list.</param>
        /// <returns>The list of alarms.</returns>
        public async Task<PagedResult<AlarmItemProvider>> GetAlarmsAsync(AlarmFilter alarmFilter)
        {                
            return await GetPagedResultsAsync<AlarmItemProvider>("alarms", ToDictionary(alarmFilter)).ConfigureAwait(false);            
        }

        /// <summary>
        /// Retrieves the specified alarm asynchronously.
        /// </summary>
        /// <param name="alarmId">The identifier of the alarm.</param>
        /// <returns>The alarm details</returns>
        public async Task<AlarmItemProvider> GetSingleAlarmAsync(Guid alarmId)
        {
            var response=await GetRequestAsync("alarms", null, alarmId).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AlarmItemProvider>(response.ToString());
        }

        /// <summary>
        /// Retrieves a collection of alarms for the specified object asynchronously.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <param name="alarmFilter">TThe alarm alarmFilter to get alarms.</param>
        /// <returns>The list of alarms for the specified object.</returns>

        public async Task<PagedResult<AlarmItemProvider>> GetAlarmsForAnObjectAsync(Guid objectId, AlarmFilter alarmFilter)
        {
            return await GetPagedResultsAsync<AlarmItemProvider>("objects", ToDictionary(alarmFilter), objectId, "alarms").ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a collection of alarms for the specified network device asynchronously.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the network device.</param>
        /// <param name="alarmFilter">The alarm alarmFilter to get alarms.</param>
        /// <returns>The list of alarms for the specified object.</returns>
        public async Task<PagedResult<AlarmItemProvider>> GetAlarmsForNetworkDeviceAsync(Guid networkDeviceId, AlarmFilter alarmFilter)
        {
            return await GetPagedResultsAsync<AlarmItemProvider>("networkDevices", ToDictionary(alarmFilter), networkDeviceId, "alarms").ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the specified alarm.
        /// </summary>
        /// <param name="alarmId">The identifier of the alarm.</param>
        /// <returns>The alarm details</returns>
        public AlarmItemProvider GetSingleAlarm(Guid alarmId)
        {
            return GetSingleAlarmAsync(alarmId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a collection of alarms.
        /// </summary>
        /// <param name="alarmFilter">The alarm alarmFilter to get alarms.</param>
        /// <returns>The list of alarms.</returns>
        public PagedResult<AlarmItemProvider> GetAlarms(AlarmFilter alarmFilter)
        {
            return GetAlarmsAsync(alarmFilter).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <param name="alarmFilter">TThe alarm alarmFilter to get alarms.</param>
        /// <returns>The list of alarms for the specified object.</returns>
        public PagedResult<AlarmItemProvider> GetAlarmsForAnObject(Guid objectId, AlarmFilter alarmFilter)
        {
            return GetAlarmsForAnObjectAsync(objectId, alarmFilter).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a collection of alarms for the specified network device.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the network device.</param>
        /// <param name="alarmFilter">TThe alarm alarmFilter to get alarms.</param>
        /// <returns>The list of alarms for the specified object.</returns>
        public PagedResult<AlarmItemProvider> GetAlarmsForNetworkDevice(Guid networkDeviceId, AlarmFilter alarmFilter)
        {
            return GetAlarmsForNetworkDeviceAsync(networkDeviceId, alarmFilter).GetAwaiter().GetResult();
        }
    }
}