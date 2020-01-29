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
        public AlarmInfoProvider(IFlurlClient client):base(client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client),
                                               "FlurlClient can not be null.");
        }

        /// <inheritdoc />
        public async Task<PagedResult<AlarmItemProvider>> GetAlarmsAsync(AlarmFilter filter)
        {                
            return await GetPagedResultsAsync<AlarmItemProvider>("alarms", ToDictionary(filter));            
        }

        /// <inheritdoc />
        public async Task<AlarmItemProvider> GetSingleAlarmAsync(string alarmId)
        {
            var response=await GetRequestAsync("alarms", null, alarmId);
            return JsonConvert.DeserializeObject<AlarmItemProvider>(response.ToString());
        }

        /// <inheritdoc />
        public async Task<PagedResult<AlarmItemProvider>> GetAlarmsForAnObjectAsync(string objectId, AlarmFilter filter)
        {
            return await GetPagedResultsAsync<AlarmItemProvider>("objects", ToDictionary(filter), objectId, "alarms");
        }

        /// <inheritdoc />
        public async Task<PagedResult<AlarmItemProvider>> GetAlarmsForNetworkDeviceAsync(string networkDeviceId, AlarmFilter filter)
        {
            return await GetPagedResultsAsync<AlarmItemProvider>("networkDevices", ToDictionary(filter), networkDeviceId, "alarms");
        }

        /// <inheritdoc />
        public AlarmItemProvider GetSingleAlarm(string alarmId)
        {
            return GetSingleAlarmAsync(alarmId).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public PagedResult<AlarmItemProvider> GetAlarms(AlarmFilter alarmFilter)
        {
            return GetAlarmsAsync(alarmFilter).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public PagedResult<AlarmItemProvider> GetAlarmsForAnObject(string objectId, AlarmFilter alarmFilter)
        {
            return GetAlarmsForAnObjectAsync(objectId, alarmFilter).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public PagedResult<AlarmItemProvider> GetAlarmsForNetworkDevice(string networkDeviceId, AlarmFilter alarmFilter)
        {
            return GetAlarmsForNetworkDeviceAsync(networkDeviceId, alarmFilter).GetAwaiter().GetResult();
        }
    }
}