using Microsoft.Extensions.Logging;
﻿using Flurl.Http;
using System;
using System.Text.Json.Nodes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Provide items for the endpoints of the Metasys Activities API.
/// </summary>
class ActivityServiceProvider(IFlurlClient client, ApiVersion version, ILogger? logger = null) : BasicServiceProvider(client, version, logger), IActivityService
{

    // List Activities ----------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public PagedResult<Activity> Get(ActivityFilter activityFilter)
    {
        return GetAsync(activityFilter).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<PagedResult<Activity>> GetAsync(ActivityFilter activityFilter, CancellationToken ct = default)
    {
        CheckVersion(Version);

        if (Version >= ApiVersion.v4)
        {
            List<Activity> activities = new();
            var response = await GetPagedResultsAsync<Activity>("activities", ToDictionary(activityFilter), ct).ConfigureAwait(false);

            foreach (var item in response.Items)
                activities.Add(item);

            response = new PagedResult<Activity>
            {
                Items = activities,
                CurrentPage = response.CurrentPage,
                PageCount = response.PageCount,
                PageSize = response.PageSize,
                Total = response.Total
            };

            return response;
        }
        else
        {
            throw new MetasysUnsupportedApiVersion(Version.ToString());
        };
    }

    // Batch operations ------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<Result> ActionMultiple(IEnumerable<BatchRequestParam> requests)
    {
        return ActionMultipleAsync(requests).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Result>> ActionMultipleAsync(IEnumerable<BatchRequestParam> requests, CancellationToken ct = default)
    {
        try
        {
            CheckVersion(Version);

            if (Version >= ApiVersion.v4)
            {
                if (requests == null)
                    return null;

                var response = await PatchBatchRequestAsync("activities", requests).ConfigureAwait(false);
                return ToResult(response);
            }
            else
            {
                throw new MetasysUnsupportedApiVersion(Version.ToString());
            }
        }
        catch (FlurlHttpException e)
        {
            ThrowHttpException(e);
            return null;
        }
    }


    /// <summary>
    /// Convert a JToken batch request response into VariantMultiple.
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    private IEnumerable<Result> ToResult(JsonNode response)
    {
        List<Result> results = new();
        foreach (var r in response["responses"]!.AsArray())
        {
            var respIds = ((string)r["id"])!.Split('_');

            Result resultItem = new Result
            {
                Id = new Guid(respIds[0]),
                Status = (int)r["status"],
                Annotation = respIds[1]
            };
            results.Add(resultItem);
        }
        return results;
    }

}
