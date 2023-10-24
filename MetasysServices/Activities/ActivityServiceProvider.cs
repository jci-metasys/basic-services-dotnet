﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Provide items for the endpoints of the Metasys Activities API.
    /// </summary>

    class ActivityServiceProvider : BasicServiceProvider, IActivityService
    {
        private readonly CultureInfo _CultureInfo = new CultureInfo("en-US");

        /// <summary>
        /// Initializes a new instance of <see cref="ActivityServiceProvider"/> with supplied data.
        /// </summary>
        /// <param name="client">The FlurlClient to get response from URL.</param>
        /// <param name="version">The server's Api version.</param>
        /// <param name="logClientErrors">Set this flag to false to disable logging of client errors.</param>
        public ActivityServiceProvider(IFlurlClient client, ApiVersion version, bool logClientErrors = true) : base(client, version, logClientErrors)
        {
        }

        //Get ----------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public PagedResult<Activity> Get(ActivityFilter activityFilter)
        {
            return GetAsync(activityFilter).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<PagedResult<Activity>> GetAsync(ActivityFilter activityFilter)
        {
            CheckVersion(Version);

            if (Version > ApiVersion.v4)
            {
                List<Activity> activities = new List<Activity>();
                var response = await GetPagedResultsAsync<Activity>("activities", ToDictionary(activityFilter)).ConfigureAwait(false);
                if (Version == ApiVersion.v5)
                {
                    foreach (var item in response.Items)
                    {
                        activities.Add(CreateItem(item, activityFilter.ActivityType));
                    }
                    response = new PagedResult<Activity>
                    {
                        Items = activities,
                        CurrentPage = response.CurrentPage,
                        PageCount = response.PageCount,
                        PageSize = response.PageSize,
                        Total = response.Total
                    };
                }
                return response;
            }else
            { 
                throw new MetasysUnsupportedApiVersion(Version.ToString());
                return null;
            };
        }

        /// <inheritdoc/>
        public IEnumerable<Result> ActionMultiple(IEnumerable<BatchRequestParam> requests)
        {
            return ActionMultipleAsync(requests).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Result>> ActionMultipleAsync(IEnumerable<BatchRequestParam> requests)
        {
            try
            {
                CheckVersion(Version);

                if (Version > ApiVersion.v4)
                {
                    if (requests == null) { return null; }

                    var response = await PatchBatchRequestAsync("activities", requests, "").ConfigureAwait(false);
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
        private IEnumerable<Result> ToResult(JToken response)
        {
            List<Result> results = new List<Result>();
            foreach (var r in response["responses"])
            {
                var respIds = r["id"].Value<string>().Split('_');

                Result resultItem = new Result();
                resultItem.Id = new Guid(respIds[0]); ;
                resultItem.Status = r["status"].Value<int>();
                resultItem.Annotation = respIds[1];
                results.Add(resultItem);
            }
            return results;
        }

        private Activity CreateItem(Activity item, string activityType)
        {
            try
            {

                //switch (activityType)
                //{
                //    case 'alarm':
                        
                //        break;
                //    case 'audit':
                //        break;
                //}

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
