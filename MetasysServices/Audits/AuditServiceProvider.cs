using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provide audit item for the endpoints of the Metasys Audit API.
    /// </summary>
    public sealed class AuditServiceProvider : BasicServiceProvider, IAuditService
    {
        private const string BaseParam = "audits";

        /// <summary>
        /// Initializes a new instance of <see cref="AuditServiceProvider"/> with supplied data.
        /// </summary>
        /// <param name="client">The FlurlClient to get response from URL.</param>
        /// <param name="version">The server's Api version.</param>
        /// <param name="logClientErrors">Set this flag to false to disable logging of client errors.</param>
        public AuditServiceProvider(IFlurlClient client, ApiVersion version, bool logClientErrors = true) : base(client, version, logClientErrors)
        {
        }

        /// <inheritdoc/>
        public async Task<Audit> FindByIdAsync(Guid auditId)
        {
            var response = await GetRequestAsync("audits", null, auditId).ConfigureAwait(false);
            if (response["item"] != null) {
                response = response["item"];
            }
            var auditData = JsonConvert.DeserializeObject<Audit>(response.ToString());
            if (Version >= ApiVersion.v3) {
                auditData = CreateItem(auditData);
            }

            return auditData;
        }

        /// <inheritdoc/>
        public async Task<PagedResult<Audit>> GetAsync(AuditFilter auditFilter)
        {
            var dictionary = ToDictionary(auditFilter);
            dictionary["OriginApplications"] = GetEnumCsv<OriginApplicationsEnum>(auditFilter.OriginApplications);
            dictionary["ActionTypes"] = GetEnumCsv<ActionTypeEnum>(auditFilter.ActionTypes);
            var response = await GetPagedResultsAsync<Audit>("audits", dictionary).ConfigureAwait(false);
            if (Version >= ApiVersion.v3) {
                List<Audit> audits = new List<Audit>();
                foreach (var item in response.Items) {
                    audits.Add(CreateItem(item));
                }

                response = new PagedResult<Audit> {
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
        public async Task<PagedResult<Audit>> GetForObjectAsync(Guid objectId, AuditFilter auditFilter)
        {
            var dictionary = ToDictionary(auditFilter);
            dictionary["OriginApplications"] = GetEnumCsv<OriginApplicationsEnum>(auditFilter.OriginApplications);
            dictionary["ActionTypes"] = GetEnumCsv<ActionTypeEnum>(auditFilter.ActionTypes);
            var response = await GetPagedResultsAsync<Audit>("objects", dictionary, objectId, BaseParam).ConfigureAwait(false);
            if (Version >= ApiVersion.v3) {
                List<Audit> audits = new List<Audit>();
                foreach (var item in response.Items) {
                    audits.Add(CreateItem(item));
                }
                response = new PagedResult<Audit> {
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
        public Audit FindById(Guid auditId)
        {
            return FindByIdAsync(auditId).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public PagedResult<Audit> Get(AuditFilter auditFilter)
        {
            return GetAsync(auditFilter).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public PagedResult<Audit> GetForObject(Guid objectId, AuditFilter auditFilter)
        {
            return GetForObjectAsync(objectId, auditFilter).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public IEnumerable<AuditAnnotation> GetAnnotations(Guid auditId)
        {
            return GetAnnotationsAsync(auditId).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AuditAnnotation>> GetAnnotationsAsync(Guid auditId)
        {
            // Retrieve JSON collection of Annotation
            var annotations = await GetAllAvailablePagesAsync("audits", null, auditId.ToString(), "annotations");
            List<AuditAnnotation> annotationsList = new List<AuditAnnotation>();
            // Convert to a collection of AuditAnnotation
            foreach (var token in annotations)
            {
                AuditAnnotation auditAnnotation = new AuditAnnotation();
                // Build AlarmAnnotation object
                try
                {
                    auditAnnotation.Text = token["text"].Value<string>();
                    auditAnnotation.User = token["user"].Value<string>();
                    auditAnnotation.CreationTime = token["creationTime"].Value<DateTime>();
                    auditAnnotation.Action = token["action"].Value<string>();
                    auditAnnotation.AuditUrl = token["auditUrl"].Value<string>();
                    annotationsList.Add(auditAnnotation);
                }
                catch (Exception e)
                {
                    throw new MetasysObjectException(token.ToString(), e);
                }
            }
            return annotationsList;
        }

        /// <inheritdoc/>
        public void Discard(Guid id, string annotationText)
        {
            DiscardAsync(id, annotationText).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DiscardAsync(Guid id, string annotationText)
        {
            try
            {
                if (Version >= ApiVersion.v3)
                {
                    var response = await Client.Request(new Url("audits")
                    .AppendPathSegments(id, "discard"))
                    .PutJsonAsync(new { annotationText })
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
        public void AddAnnotation(Guid id, string text)
        {
            AddAnnotationAsync(id, text).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task AddAnnotationAsync(Guid id, string text)
        {
            try
            {
                if (Version >= ApiVersion.v3)
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
        public async Task<IEnumerable<Result>> AddAnnotationMultipleAsync(IEnumerable<BatchRequestParam> requests)
        {
            try
            {
                if (Version >= ApiVersion.v3)
                {
                    if (requests == null)
                    {
                        return null;
                    }
                    var response = await PostBatchRequestAsync("audits", requests, "annotations").ConfigureAwait(false);
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
        public async Task<IEnumerable<Result>> DiscardMultipleAsync(IEnumerable<BatchRequestParam> requests)
        {
            try
            {
                if (Version >= ApiVersion.v3)
                {
                    if (requests == null)
                    {
                        return null;
                    }
                    var response = await PutBatchRequestAsync("audits", requests, "discard").ConfigureAwait(false);
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
            Audit audit = new Audit();

            try {
                var stringAuditData = item.ToString();
                var data = JObject.Parse(stringAuditData);
                audit.ActionType = data["ActionType"].Value<string>();
                audit.Status = data["Status"].Value<string>();

                if (data["PreData"].ToString() != null) {
                    if (data["PreData"].HasValues) {
                        audit.PreData = new AuditData {
                            Unit = data["PreData"]["unit"].Value<string>(),
                            Precision = data["PreData"]["precision"].Value<string>(),
                            Value = data["PreData"]["value"].Value<string>(),
                            Type = data["PreData"]["type"].Value<string>()
                        };
                    } else {
                        audit.PreData = data["PreData"].Value<string>() != null ? data["PreData"].ToString() : null;
                    }
                }

                if (data["PostData"].ToString() != null) {
                    if (data["PostData"].HasValues) {
                        audit.PostData = new AuditData {
                            Unit = data["PostData"]["unit"].Value<string>(),
                            Precision = data["PostData"]["precision"].Value<string>(),
                            Value = data["PostData"]["value"].Value<string>(),
                            Type = data["PostData"]["type"].Value<string>()
                        };
                    } else {
                        audit.PostData = data["PostData"].Value<string>() != null ? data["PostData"].ToString() : null;
                    }
                }

                if (data["Parameters"].ToString() == "[]") {
                    audit.Parameters = data["Parameters"].ToString();
                } else {
                    if (data["Parameters"].ToString() != null) {
                        if (data["Parameters"].HasValues) {
                            audit.Parameters = new AuditData {
                                Unit = data["Parameters"]["unit"].Value<string>(),
                                Precision = data["Parameters"]["precision"].Value<string>(),
                                Value = data["Parameters"]["value"].Value<string>(),
                                Type = data["Parameters"]["type"].Value<string>()
                            };
                        } else {
                            audit.Parameters = data["Parameters"].Value<string>() != null ? data["Parameters"].ToString() : null;
                        }
                    }
                }

                if (data["Legacy"].ToString() != null) {
                    if (data["Legacy"].HasValues) {
                        audit.Legacy = new LegacyInfo {
                            FullyQualifiedItemReference = data["Legacy"]["fullyQualifiedItemReference"].Value<string>(),
                            ItemName = data["Legacy"]["itemName"].Value<string>(),
                            ClassLevel = data["Legacy"]["classLevel"].Value<string>(),
                            OriginApplication = data["Legacy"]["originApplication"].Value<string>(),
                            Description = data["Legacy"]["description"].Value<string>()
                        };
                    } else {
                        audit.Legacy = data["Legacy"].Value<string>() != null ? data["Legacy"].ToString() : null;
                    }
                }
            }

            catch (ArgumentNullException e) {
                // Something went wrong on object parsing
                throw new MetasysObjectException(e);
            }

            return audit;
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
    }

    /// <summary>
    /// This holds the inofrmation returned as result of a call
    /// </summary>
    public class Result
    {
        /// <summary>The id of the Audit affected by the call.</summary>
        public Guid Id { set; get; }

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
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}