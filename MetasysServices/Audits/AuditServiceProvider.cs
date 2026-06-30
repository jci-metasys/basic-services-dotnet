using Microsoft.Extensions.Logging;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Threading;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Provide audit item for the endpoints of the Metasys Audit API.
/// </summary>
public sealed class AuditServiceProvider(IFlurlClient client, ApiVersion version, ILogger? logger = null) : BasicServiceProvider(client, version, logger), IAuditService
{
    private const string BaseParam = "audits";

    /// <inheritdoc/>
    public async Task<Audit> FindByIdAsync(ActivityId auditId, CancellationToken ct = default)
    {
        CheckVersion(Version);

        var response = await GetRequestAsync("audits", null, ct, new object[] { auditId }).ConfigureAwait(false);
        if (response["item"] != null)
        {
            response = response["item"];
        }

        var auditData = JsonSerializer.Deserialize<Audit>(response.ToJsonString());
        if (Version > ApiVersion.v2)
        {
            auditData = CreateItem(auditData);
        }
        return auditData;
    }

    /// <inheritdoc/>
    public async Task<PagedResult<Audit>> GetAsync(AuditFilter auditFilter, CancellationToken ct = default)
    {
        CheckVersion(Version);

        var dictionary = GetParameters(auditFilter);

        var response = await GetPagedResultsAsync<Audit>("audits", dictionary, ct).ConfigureAwait(false);
        if (Version > ApiVersion.v2)
        {
            List<Audit> audits = new();
            foreach (var item in response.Items)
            {
                audits.Add(CreateItem(item));
            }

            response = new PagedResult<Audit>
            {
                Items = audits,
                CurrentPage = response.CurrentPage,
                PageCount = response.PageCount,
                PageSize = response.PageSize,
                Total = response.Total
            };
        }
        return response;
    }

    /// <inheritdoc/>
    public async Task<PagedResult<Audit>> GetForObjectAsync(ObjectId objectId, AuditFilter auditFilter, CancellationToken ct = default)
    {
        CheckVersion(Version);

        var dictionary = GetParameters(auditFilter);

        var response = await GetPagedResultsAsync<Audit>("objects", dictionary, ct, new object[] { objectId, BaseParam }).ConfigureAwait(false);
        if (Version > ApiVersion.v2)
        {
            List<Audit> audits = new();
            foreach (var item in response.Items)
            {
                audits.Add(CreateItem(item));
            }
            response = new PagedResult<Audit>
            {
                Items = audits,
                CurrentPage = response.CurrentPage,
                PageCount = response.PageCount,
                PageSize = response.PageSize,
                Total = response.Total
            };
        }
        return response;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<AuditAnnotation>> GetAnnotationsAsync(ActivityId auditId, CancellationToken ct = default)
    {
        CheckVersion(Version);

        // Retrieve JSON collection of Annotation
        var annotations = await GetAllAvailablePagesAsync("audits", null, ct, new string[] { auditId.ToString(), "annotations"}).ConfigureAwait(false);
        List<AuditAnnotation> annotationsList = new();
        // Convert to a collection of AuditAnnotation
        foreach (var token in annotations)
        {
            AuditAnnotation auditAnnotation = new();
            // Build AlarmAnnotation object
            try
            {
                auditAnnotation.Text = (string)token["text"];
                auditAnnotation.User = (string)token["user"];
                auditAnnotation.CreationTime = token["creationTime"].GetValue<DateTime>();
                auditAnnotation.Action = (string)token["action"];
                auditAnnotation.AuditUrl = (string)token["auditUrl"];
                annotationsList.Add(auditAnnotation);
            }
            catch (Exception e)
            {
                throw new MetasysObjectException(token.ToJsonString(), e);
            }
        }
        return annotationsList;
    }

    /// <inheritdoc/>
    public Audit FindById(ActivityId auditId)
    {
        return FindByIdAsync(auditId).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    public PagedResult<Audit> Get(AuditFilter auditFilter)
    {
        return GetAsync(auditFilter).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    public PagedResult<Audit> GetForObject(ObjectId objectId, AuditFilter auditFilter)
    {
        return GetForObjectAsync(objectId, auditFilter).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    public IEnumerable<AuditAnnotation> GetAnnotations(ActivityId auditId)
    {
        return GetAnnotationsAsync(auditId).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    public void Discard(ActivityId id, string annotationText)
    {
        DiscardAsync(id, annotationText).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    public async Task DiscardAsync(ActivityId id, string annotationText, CancellationToken ct = default)
    {
        try
        {
            CheckVersion(Version);

            if (Version < ApiVersion.v3) { throw new MetasysUnsupportedApiVersion(Version.ToString()); };

            if (Version == ApiVersion.v3)
            {
                //This is valid for API v3
                var response_v3 = await Client.Request(new Url("audits")
                .AppendPathSegments(id, "discard"))
                .PutJsonAsync(new { annotationText })
                .ConfigureAwait(false);

            }
            else if (Version > ApiVersion.v3)
            {
                //For API v4, v5 the endpoint and the body are different
                string activityManagementStatus = "discarded";
                var response_v4 = await Client.Request(new Url("audits")
                .AppendPathSegments(id))
                .PatchJsonAsync(new { annotationText, activityManagementStatus })
                .ConfigureAwait(false);
            }
        }
        catch (FlurlHttpException e)
        {
            ThrowHttpException(e);
        }
    }

    /// <inheritdoc/>
    public void AddAnnotation(ActivityId id, string text)
    {
        AddAnnotationAsync(id, text).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    public async Task AddAnnotationAsync(ActivityId id, string text, CancellationToken ct = default)
    {
        try
        {
            CheckVersion(Version);

            if (Version > ApiVersion.v2)
            {
                var response = await Client.Request(new Url("audits")
                .AppendPathSegments(id, "annotations"))
                .PostJsonAsync(new { text })
                .ConfigureAwait(false);
            }
            else
            {
                throw new MetasysUnsupportedApiVersion(Version.ToString());
            }
        }
        catch (FlurlHttpException e)
        {
            ThrowHttpException(e);
        }
    }

    /// <inheritdoc/>
    public IEnumerable<Result> AddAnnotationMultiple(IEnumerable<BatchRequestParam> requests)
    {
        return AddAnnotationMultipleAsync(requests).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Result>> AddAnnotationMultipleAsync(IEnumerable<BatchRequestParam> requests, CancellationToken ct = default)
    {
        try
        {
            CheckVersion(Version);

            if (Version > ApiVersion.v2)
            {
                if (requests == null) { return null; }

                var response = await PostBatchRequestAsync("audits", requests, ct, new string[] { "annotations"}).ConfigureAwait(false);
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

    /// <inheritdoc/>
    public IEnumerable<Result> DiscardMultiple(IEnumerable<BatchRequestParam> requests)
    {
        return DiscardMultipleAsync(requests).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Result>> DiscardMultipleAsync(IEnumerable<BatchRequestParam> requests, CancellationToken ct = default)
    {
        try
        {
            CheckVersion(Version);

            if (Version > ApiVersion.v2)
            {
                if (requests == null) { return null; }

                var response = await PutBatchRequestAsync("audits", requests, ct, new string[] { "discard"}).ConfigureAwait(false);
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

    private Audit CreateItem(Audit item)
    {
        try
        {
            var stringAuditData = item.ToString();
            var data = JsonNode.Parse(stringAuditData) as JsonObject;
            item.ActionType = (string)data["ActionType"];
            item.Status = (string)data["Status"];

            if (data["PreData"] != null)
            {
                if (data["PreData"] is JsonObject preDataObj && preDataObj.Count > 0)
                {
                    item.PreData = new AuditData
                    {
                        Unit = GetJsonObjectValue(data, "PreData", "unit"),
                        Precision = GetJsonObjectValue(data, "PreData", "precision"),
                        Value = GetJsonObjectValue(data, "PreData", "value"),
                        Type = GetJsonObjectValue(data, "PreData", "type")
                    };
                }
                else
                {
                    item.PreData = (string)data["PreData"] != null ? (string)data["PreData"] : null;
                }
            }

            if (data["PostData"] != null)
            {
                if (data["PostData"] is JsonObject postDataObj && postDataObj.Count > 0)
                {
                    item.PostData = new AuditData
                    {
                        Unit = GetJsonObjectValue(data, "PostData", "unit"),
                        Precision = GetJsonObjectValue(data, "PostData", "precision"),
                        Value = GetJsonObjectValue(data, "PostData", "value"),
                        Type = GetJsonObjectValue(data, "PostData", "type")
                    };
                }
                else
                {
                    item.PostData = (string)data["PostData"] != null ? (string)data["PostData"] : null;
                }
            }

            if (data["Parameters"] != null && data["Parameters"].ToJsonString() == "[]")
            {
                item.Parameters = data["Parameters"].ToJsonString();
            }
            else
            {
                if (data["Parameters"] != null)
                {
                    if (data["Parameters"] is JsonObject parametersObj && parametersObj.Count > 0)
                    {
                        item.Parameters = new AuditData
                        {
                            Unit = GetJsonObjectValue(data, "Parameters", "unit"),
                            Precision = GetJsonObjectValue(data, "Parameters", "precision"),
                            Value = GetJsonObjectValue(data, "Parameters", "value"),
                            Type = GetJsonObjectValue(data, "Parameters", "type")
                        };
                    }
                    else
                    {
                        item.Parameters = (string)data["Parameters"] != null ? (string)data["Parameters"] : null;
                    }
                }
            }

            if (data["Legacy"] != null)
            {
                if (data["Legacy"] is JsonObject legacyObj && legacyObj.Count > 0)
                {
                    item.Legacy = new LegacyInfo
                    {
                        FullyQualifiedItemReference = (string)data["Legacy"]["fullyQualifiedItemReference"],
                        ItemName = (string)data["Legacy"]["itemName"],
                        ClassLevel = (string)data["Legacy"]["classLevel"],
                        OriginApplication = (string)data["Legacy"]["originApplication"],
                        Description = (string)data["Legacy"]["description"]
                    };
                }
                else
                {
                    item.Legacy = (string)data["Legacy"] != null ? (string)data["Legacy"] : null;
                }
            }
        }

        catch (ArgumentNullException e)
        {
            // Something went wrong on object parsing
            throw new MetasysObjectException(e);
        }
        return item;
    }

    /// <summary>
    /// Convert a JsonNode batch request response into VariantMultiple.
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    private IEnumerable<Result> ToResult(JsonNode response)
    {
        List<Result> results = new();
        foreach (var r in response["responses"].AsArray())
        {
            var respIds = ((string)r["id"]).Split('_');

            Result resultItem = new();
            resultItem.Id = new ActivityId(respIds[0]); ;
            resultItem.Status = (int)r["status"];
            resultItem.Annotation = respIds[1];
            results.Add(resultItem);
        }
        return results;
    }

    private string GetEnumCsv<T>(Enum enumerableItem)
    {
        var csvString = string.Empty;
        Type enumList = typeof(T);

        foreach (Enum item in Enum.GetValues(enumList))
        {
            if (enumerableItem.HasFlag(item))
            {
                if (!string.IsNullOrEmpty(csvString))
                {
                    csvString += ",";
                }
                csvString += GetEnumDescription(item);
            }
        }
        return csvString;
    }

    private static string GetEnumDescription(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        if (attributes != null && attributes.Any())
        {
            return attributes.First().Description;
        }
        return value.ToString();
    }

    private string GetJsonObjectValue(JsonObject jObj, string group, string field)
    {
        string res = string.Empty;
        try
        {
            if (jObj != null)
            {
                if ((jObj.ContainsKey(group)) && (jObj[group] != null))
                {
                    if (jObj[group] is JsonObject grp && grp.ContainsKey(field) && grp[field] != null)
                    {
                        res = (string)grp[field];
                    }
                };
            };
        }
        catch (ArgumentNullException e)
        {
            // Something went wrong on object parsing
            throw new MetasysObjectException(e);
        }
        return res;
    }
    private Dictionary<string, string> GetParameters(AuditFilter auditFilter)
    {
        var dictionary = ToDictionary(auditFilter);

        try
        {
            //Check the value of the param 'OriginApplication', If blank remove the parameter
            string originApplications = GetEnumCsv<OriginApplicationsEnum>(auditFilter.OriginApplications);
            if (string.IsNullOrEmpty(originApplications))
            { dictionary.Remove("OriginApplications"); }
            else
            { dictionary["OriginApplications"] = originApplications; }

            //Check the value of the param 'ActionTypes', If blank remove the parameter
            string actionTypes = GetEnumCsv<ActionTypeEnum>(auditFilter.ActionTypes);
            if (string.IsNullOrEmpty(actionTypes))
            { dictionary.Remove("ActionTypes"); }
            else
            { dictionary["ActionTypes"] = actionTypes; }

            //Check the value of the param 'ActionTypes', If blank remove the parameter
            string classesLevels = GetEnumCsv<ClassLevelsEnum>(auditFilter.ClassesLevels);
            if (string.IsNullOrEmpty(classesLevels))
            { dictionary.Remove("ClassesLevels"); }
            else
            { dictionary["ClassesLevels"] = classesLevels; }

            if (Version == ApiVersion.v4)
            {
                // IMPORTANT:
                // In v4 it seems that the value of the params 'OriginApplications', 'ActionTypes'
                // are NOT a string containing the numeric enum values, but they must be the string
                // of the enum value.
                // Example (Origin Applications = set 578): 3 -> auditOriginAppEnumSet.mceAuditOriginApp
            };
        }
        catch (ArgumentNullException e)
        {
            // Something went wrong on object parsing
            throw new MetasysObjectException(e);
        }
        return dictionary;
    }

}

/// <summary>
/// This holds the inofrmation returned as result of a call
/// </summary>
public class Result
{
    /// <summary>The id of the Audit affected by the call.</summary>
    public ActivityId Id { set; get; }

    /// <summary>The Status of the call.</summary>
    public int Status { set; get; }

    /// <summary>Text of the Audit Annotation set according to the call.</summary>
    public string Annotation { set; get; }

    /// <summary>
    /// Return a pretty JSON string of the current object.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}
