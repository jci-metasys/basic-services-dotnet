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
    public sealed class AlarmInfoProvider : IProvideAlarmInfo
    {

        /// <inheritdoc />
        public async Task<PagedResult<IEnumerable<AlarmItemProvider>>> GetAlarmsAsync(string resource, FlurlClient client, AlarmFilterModel alarmFilterModel)
        {
            var alarmItems = new PagedResult<IEnumerable<AlarmItemProvider>>();

            try
            {
                var response = await client.Request(new Url(resource)
                    .SetQueryParams(ConvertToUrl(alarmFilterModel)))
                    .GetJsonAsync<JToken>()
                    .ConfigureAwait(false);
                try
                {
                    alarmItems = JsonConvert.DeserializeObject<PagedResult<IEnumerable<AlarmItemProvider>>>(response.ToString(), new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                }
                catch (NullReferenceException e)
                {
                    throw new MetasysHttpParsingException(response.ToString(), e);
                }
            }
            catch (FlurlHttpException e)
            {
                ManageException.ThrowHttpException(e);
            }
            return alarmItems;
        }

        /// <inheritdoc />
        public async Task<AlarmItemProvider> GetSingleAlarmAsync(string alarmId, FlurlClient client, string resource)
        {
            AlarmItemProvider alarmItem = new AlarmItemProvider();

            try
            {
                var response = await client.Request(new Url(resource)
                    .AppendPathSegment(alarmId))
                    .GetJsonAsync<JToken>()
                    .ConfigureAwait(false);
                try
                {
                    alarmItem = JsonConvert.DeserializeObject<AlarmItemProvider>(response.ToString(), new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                }
                catch (NullReferenceException e)
                {
                    throw new MetasysHttpParsingException(response.ToString(), e);
                }
            }
            catch (FlurlHttpException e)
            {
                ManageException.ThrowHttpException(e);
            }
            return alarmItem;
        }

        private static string ConvertToUrl(AlarmFilterModel alarmFilterModel)
        {
            return string.Format("{0}{1}&{2}&{3}&{4}&{5}&{6}&{7}&{8}&{9}&{10}&{11}",
                '?', alarmFilterModel.StartTime, alarmFilterModel.EndTime, alarmFilterModel.PriorityRange, alarmFilterModel.Type,
                alarmFilterModel.ExcludePending, alarmFilterModel.ExcludeAcknowledged, alarmFilterModel.ExcludeAcknowledged, alarmFilterModel.Category,
                alarmFilterModel.Page, alarmFilterModel.PageSize, alarmFilterModel.Sort);
        }
    }
}