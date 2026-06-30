using Microsoft.Extensions.Logging;
using Flurl;
using Flurl.Http;
using JohnsonControls.Metasys.BasicServices.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Threading;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Provide alarm item for the endpoints of the Metasys Alarm API.
/// </summary>
public sealed class AlarmServiceProvider(IFlurlClient client, ApiVersion version, ILogger? logger = null) : BasicServiceProvider(client, version, logger), IAlarmsService
{
    private readonly CultureInfo _CultureInfo = new CultureInfo("en-US");

    //Get ----------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public PagedResult<Alarm> Get(AlarmFilter alarmFilter)
    {
        return GetAsync(alarmFilter).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<PagedResult<Alarm>> GetAsync(AlarmFilter alarmFilter, CancellationToken ct = default)
    {
        CheckVersion(Version);
        // This method is valid only for API v2 or v3.
        if (Version == ApiVersion.v2 || Version == ApiVersion.v3)
        {
            List<Alarm> alarms = new();
            var response = await GetPagedResultsAsync<Alarm>("alarms", ToDictionary(alarmFilter), ct).ConfigureAwait(false);
            if (Version > ApiVersion.v2)
            {
                foreach (var item in response.Items)
                {
                    alarms.Add(CreateItem(item));
                }
                response = new PagedResult<Alarm>
                {
                    Items = alarms,
                    CurrentPage = response.CurrentPage,
                    PageCount = response.PageCount,
                    PageSize = response.PageSize,
                    Total = response.Total
                };
            }
            return response;
        }
        else
        {
            throw new MetasysUnsupportedApiVersion(Version.ToString());
        };
    }

    /// <inheritdoc/>
    public PagedResult<Alarm> Get(AlarmFilterV4Plus alarmFilter)
    {
        return GetAsync(alarmFilter).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<PagedResult<Alarm>> GetAsync(AlarmFilterV4Plus alarmFilter, CancellationToken ct = default)
    {
        CheckVersion(Version);
        // This method is valid only from API v4 on.
        if (Version >= ApiVersion.v4)
        {
            List<Alarm> alarms = new();
            var response = await GetPagedResultsAsync<Alarm>("alarms", ToDictionary(alarmFilter), ct).ConfigureAwait(false);
            if (Version > ApiVersion.v2)
            {
                foreach (var item in response.Items)
                {
                    alarms.Add(CreateItem(item));
                }
                response = new PagedResult<Alarm>
                {
                    Items = alarms,
                    CurrentPage = response.CurrentPage,
                    PageCount = response.PageCount,
                    PageSize = response.PageSize,
                    Total = response.Total
                };
            }
            return response;
        }
        else
        {
            throw new MetasysUnsupportedApiVersion(Version.ToString());
        };
    }


    //FindById ------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public Alarm FindById(ActivityId alarmId)
    {
        return FindByIdAsync(alarmId).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<Alarm> FindByIdAsync(ActivityId alarmId, CancellationToken ct = default)
    {
        CheckVersion(Version);

        var response = await GetRequestAsync("alarms", null, ct, new object[] { alarmId }).ConfigureAwait(false);
        if (response["items"] != null) response = response["items"];

        var alarmData = JsonSerializer.Deserialize<Alarm>(response.ToJsonString());
        if (Version > ApiVersion.v2)
        {
            alarmData = CreateItem(alarmData);
        }
        return alarmData;
    }

    /// <inheritdoc/>
    public PagedResult<Alarm> GetForObject(ObjectId objectId, AlarmFilter alarmFilter)
    {
        return GetForObjectAsync(objectId, alarmFilter).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<PagedResult<Alarm>> GetForObjectAsync(ObjectId objectId, AlarmFilter alarmFilter, CancellationToken ct = default)
    {
        CheckVersion(Version);

        List<Alarm> alarms = new();
        var response = await GetPagedResultsAsync<Alarm>("objects", ToDictionary(alarmFilter), ct, new object[] { objectId, "alarms" }).ConfigureAwait(false);
        if (Version > ApiVersion.v2)
        {
            foreach (var item in response.Items)
            {
                alarms.Add(CreateItem(item));
            }
            response = new PagedResult<Alarm>
            {
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
    public PagedResult<Alarm> GetForNetworkDevice(ObjectId networkDeviceId, AlarmFilter alarmFilter)
    {
        return GetForNetworkDeviceAsync(networkDeviceId, alarmFilter).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<PagedResult<Alarm>> GetForNetworkDeviceAsync(ObjectId networkDeviceId, AlarmFilter alarmFilter, CancellationToken ct = default)
    {
        CheckVersion(Version);

        List<Alarm> alarms = new();
        var response = await GetPagedResultsAsync<Alarm>("networkDevices", ToDictionary(alarmFilter), ct, new object[] { networkDeviceId, "alarms" }).ConfigureAwait(false);
        if (Version > ApiVersion.v2)
        {
            foreach (var item in response.Items)
            {
                alarms.Add(CreateItem(item));
            }

            response = new PagedResult<Alarm>
            {
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
    private void Edit(ActivityId alarmId, ActivityManagementStatusEnum action, string? annotationText = null)
    {
        EditAsync(alarmId, action, annotationText).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    private async Task EditAsync(ActivityId alarmId, ActivityManagementStatusEnum action, string? annotationText = null, CancellationToken ct = default)
    {
        CheckVersion(Version);

        if (Version > ApiVersion.v3)
        {
            var body = new JsonObject();
            body["activityManagementStatus"] = action.ToString();
            if (annotationText != null)
            {
                body["annotationText"] = annotationText;
            }

            var response = await Client.Request(new Url("alarms")
            .AppendPathSegments(alarmId))
            .PatchJsonAsync(body)
            .ConfigureAwait(false);
        }
        else
        {
            throw new MetasysUnsupportedApiVersion(Version.ToString());
        }
    }

    /// <inheritdoc/>
    public void Discard(ActivityId alarmId, string? annotationText = null)
    {
        DiscardAsync(alarmId, annotationText).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    public async Task DiscardAsync(ActivityId alarmId, string? annotationText = null, CancellationToken ct = default)
    {
        CheckVersion(Version);

        if (Version > ApiVersion.v3)
        {
            var body = new JsonObject();
            body["activityManagementStatus"] = ActivityManagementStatusEnum.discarded.ToString();
            if (annotationText != null)
            {
                body["annotationText"] = annotationText;
            }

            var response = await Client.Request(new Url("alarms")
            .AppendPathSegments(alarmId))
            .PatchJsonAsync(body)
            .ConfigureAwait(false);
        }
        else
        {
            throw new MetasysUnsupportedApiVersion(Version.ToString());
        }
    }

    /// <inheritdoc/>
    public void Acknowledge(ActivityId alarmId, string? annotationText = null)
    {
        AcknowledgeAsync(alarmId, annotationText).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    public async Task AcknowledgeAsync(ActivityId alarmId, string? annotationText = null, CancellationToken ct = default)
    {
        CheckVersion(Version);

        if (Version > ApiVersion.v3)
        {
            var body = new JsonObject();
            body["activityManagementStatus"] = ActivityManagementStatusEnum.acknowledged.ToString();
            if (annotationText != null)
            {
                body["annotationText"] = annotationText;
            }

            var response = await Client.Request(new Url("alarms")
            .AppendPathSegments(alarmId))
            .PatchJsonAsync(body)
            .ConfigureAwait(false);
        }
        else
        {
            throw new MetasysUnsupportedApiVersion(Version.ToString());
        }
    }

    /// <inheritdoc/>
    public IEnumerable<AlarmAnnotation> GetAnnotations(ActivityId alarmId)
    {
        return GetAnnotationsAsync(alarmId).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<AlarmAnnotation>> GetAnnotationsAsync(ActivityId alarmId, CancellationToken ct = default)
    {
        CheckVersion(Version);

        // Retrieve JSON collection of Annotation
        var annotations = await GetAllAvailablePagesAsync("alarms", null, ct, new string[] { alarmId.ToString(), "annotations" }).ConfigureAwait(false);
        List<AlarmAnnotation> annotationsList = new();
        // Convert to a collection of AlarmAnnotation
        foreach (var token in annotations)
        {
            annotationsList.Add(CreateAlarmAnnotation(token));
        }
        return annotationsList;
    }

    private Alarm CreateItem(Alarm item)
    {
        try
        {
            if (Version > ApiVersion.v2)
            {
                var triggerValue = new TriggerValue
                {
                    Units = item.TriggerValue.Units != null ? ResourceManager.Localize(item.TriggerValue.Units, _CultureInfo) : null,
                    Value = item.TriggerValue.Value
                };
                item.TriggerValue = triggerValue;
            }

        }
        catch (ArgumentNullException e)
        {
            // Something went wrong on object parsing
            throw new MetasysObjectException(e);
        }
        return item;
    }

    private AlarmAnnotation CreateAlarmAnnotation(JsonNode token)
    {
        // Build AlarmAnnotation object
        AlarmAnnotation res = new();
        try
        {
            //res.Text = GetJTokenValue(token, "text");
            //res.User = GetJTokenValue(token, "User");
            //res.CreationTime = GetJTokenDate(token, "creationTime");
            //res.Action = GetJTokenValue(token, "action");
            //res.AlarmUrl = GetJTokenValue(token, "alarmUrl");

            res.Text = (string)token["text"];
            res.User = (string)token["user"];
            res.CreationTime = token["creationTime"].GetValue<DateTime>();
            res.Action = (string)token["action"];
            res.AlarmUrl = (string)token["alarmUrl"];
        }
        catch (Exception e)
        {
            throw new MetasysObjectException(token.ToJsonString(), e);
        }
        return res;
    }

}
