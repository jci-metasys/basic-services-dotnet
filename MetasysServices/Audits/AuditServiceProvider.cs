﻿using System;
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
    /// Provide audit item for the endpoints of the Metasys Audit API.
    /// </summary>
    public sealed class AuditServiceProvider : BasicServiceProvider, IAuditService
    {

        private const string BaseParam = "audits";
        private readonly IFlurlClient client;

        /// <summary>
        /// Initializes a new instance of <see cref="AuditServiceProvider"/> with supplied data.
        /// </summary>
        /// <param name="client">The FlurlClient to get response from URL.</param>
        /// <param name="version">The server's Api version.</param>
        /// <param name="logClientErrors">Set this flag to false to disable logging of client errors.</param>
        public AuditServiceProvider(IFlurlClient client, ApiVersion version, bool logClientErrors = true) :base(client, version, logClientErrors)
        {
        }

        /// <inheritdoc/>
        public async Task<Audit> FindByIdAsync(Guid auditId)
        {
            var response = await GetRequestAsync("audits", null, auditId).ConfigureAwait(false);
            return await CreateItem(response);
        }

        /// <inheritdoc/>
        public async Task<PagedResult<Audit>> GetAsync(AuditFilter auditFilter)
        {
            List<Audit> audits = new List<Audit>();
            var response= await GetPagedResultsAsync<JToken>("audits", ToDictionary(auditFilter)).ConfigureAwait(false);
        
            foreach (var item in response.Items)
            {
                audits.Add(await CreateItem(item));
            }

            return new PagedResult<Audit>
            {
                Items = audits,
                CurrentPage = response.CurrentPage,
                PageCount = response.PageCount,
                PageSize = response.PageSize,
                Total = response.Total
            };
        }

        /// <inheritdoc/>
        public async Task<PagedResult<Audit>> GetForObjectAsync(Guid objectId, AuditFilter auditFilter)
        {
            List<Audit> audits = new List<Audit>();
            var response = await GetPagedResultsAsync<JToken>("objects", ToDictionary(auditFilter), objectId, BaseParam).ConfigureAwait(false);
            foreach (var item in response.Items)
            {
                audits.Add(await CreateItem(item));
            }
            return new PagedResult<Audit>
            {
                Items = audits,
                CurrentPage = response.CurrentPage,
                PageCount = response.PageCount,
                PageSize = response.PageSize,
                Total = response.Total
            };
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
        public void Discard(Guid id)
        {
            DiscardAsync(id).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DiscardAsync(Guid id)
        {
            try
            {
                if (Version >= ApiVersion.v3)
                {
                    var response = await Client.Request(new Url("audits")
                    .AppendPathSegments(id, "discard"))
                    .PutJsonAsync(null)
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

        private async Task<Audit> CreateItem(JToken item)
        {
            Audit audit = new Audit();
            string actionTypeUrl = string.Empty;
            string statusUrl = string.Empty;
            string classLevelUrl = string.Empty;
            string originApplicationUrl = string.Empty;
            string descriptionUrl = string.Empty;
            string unitUrl = string.Empty;
            string precisionUrl = string.Empty;
            string value = string.Empty;
            string typeUrl = string.Empty;

            try
            {
                audit.Id = (Guid)item["id"];
                audit.CreationTime = item["creationTime"].Value<string>();
                audit.Discarded = item["discarded"].Value<bool>();
                audit.ErrorString = item["errorString"].Value<string>();
                audit.User = item["user"].Value<string>();
                audit.Signature = item["signature"].Value<string>();
                audit.ObjectUrl = item["objectUrl"].Value<string>();
                audit.AnnotationsUrl = item["annotationsUrl"].Value<string>();
                audit.Self = item["self"].Value<string>();

                if (Version < ApiVersion.v3)
                {
                    actionTypeUrl = item["actionTypeUrl"].Value<string>();
                    statusUrl = item["statusUrl"].Value<string>();
                    unitUrl = item["postData"].Contains("unitUrl") ? item["postData"]["unitUrl"].Value<string>() : null;
                    precisionUrl = item["postData"].Contains("precisionUrl") ? item["postData"]["precisionUrl"].Value<string>() : null;
                    typeUrl = item["postData"].Contains("typeUrl") ? item["postData"]["typeUrl"].Value<string>() : null;
                    classLevelUrl = item["legacy"]["classLevelUrl"].Value<string>();
                    originApplicationUrl = item["legacy"]["originApplicationUrl"].Value<string>();
                    descriptionUrl = item["legacy"]["descriptionUrl"].Value<string>();
                }
                else
                {
                    audit.ActionType = item["actionType"].Value<string>();
                    audit.Status = item["status"].Value<string>();
                    var preData = new AuditData
                    {
                        Unit = item["preData"].Contains("unit") ? item["preData"]["unit"].Value<string>() : null,
                        Precision = item["preData"].Contains("precision") ? item["preData"]["precision"].Value<string>() : null,
                        Value = item["preData"].Contains("precision") ? item["preData"]["value"].Value<string>() : null,
                        Type = item["preData"].Contains("type") ? item["preData"]["type"].Value<string>() : null
                    };
                    var postData = new AuditData
                    {
                        Unit = item["postData"].Contains("unit") ? item["postData"]["unit"].Value<string>() : null,
                        Precision = item["postData"].Contains("precision") ? item["postData"]["precision"].Value<string>() : null,
                        Value = item["preData"].Contains("precision") ? item["preData"]["value"].Value<string>() : null,
                        Type = item["postData"].Contains("type") ? item["postData"]["type"].Value<string>() : null
                    };
                    var parameters = new AuditData
                    {
                        Unit = item["parameters"].Contains("unit") ? item["parameters"]["unit"].Value<string>() : null,
                        Precision = item["parameters"].Contains("precision") ? item["parameters"]["precision"].Value<string>() : null,
                        Value = item["preData"].Contains("precision") ? item["preData"]["value"].Value<string>() : null,
                        Type = item["parameters"].Contains("type") ? item["parameters"]["type"].Value<string>() : null
                    };
                    var legacyData = new LegacyData
                    {
                        FullyQualifiedItemReference = item["legacy"].Contains("FullyQualifiedItemReference") ? item["legacy"]["fullyQualifiedItemReference"].Value<string>() : null,
                        ItemName = item["legacy"].Contains("itemName") ? item["legacy"]["itemName"].Value<string>() : null,
                        ClassLevel = item["legacy"].Contains("classLevel") ? item["legacy"]["classLevel"].Value<string>() : null,
                        OriginApplication = item["legacy"].Contains("originApplication") ? item["legacy"]["originApplication"].Value<string>() : null,
                        Description = item["legacy"].Contains("description") ? item["legacy"]["description"].Value<string>() : null,
                    };

                    audit.PreData = preData;
                    audit.PostData = postData;
                    audit.Parameters = parameters;
                    audit.Legacy = legacyData;
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
                var legacyData = new LegacyData
                {
                    FullyQualifiedItemReference = item["legacy"]["fullyQualifiedItemReference"].Value<string>(),
                    ItemName = item["legacy"]["itemName"].Value<string>(),
                    ClassLevel = await GetEnumValue(classLevelUrl),
                    OriginApplication = await GetEnumValue(originApplicationUrl),
                    Description = await GetEnumValue(descriptionUrl)
                };

                var preData = new AuditData
                {
                    Unit = !string.IsNullOrEmpty(unitUrl) ? await GetEnumValue(unitUrl) : null,
                    Precision = !string.IsNullOrEmpty(precisionUrl) ? await GetEnumValue(precisionUrl) : null,
                    Value = !string.IsNullOrEmpty(value) ? item["postData"]["value"].Value<string>() : null,
                    Type = !string.IsNullOrEmpty(typeUrl) ? await GetEnumValue(typeUrl) : null
                };

                var postData = new AuditData
                {
                    Unit = !string.IsNullOrEmpty(unitUrl) ? await GetEnumValue(unitUrl) : null,
                    Precision = !string.IsNullOrEmpty(precisionUrl) ? await GetEnumValue(precisionUrl) : null,
                    Value = !string.IsNullOrEmpty(value) ? item["postData"]["value"].Value<string>() : null,
                    Type = !string.IsNullOrEmpty(typeUrl) ? await GetEnumValue(typeUrl) : null
                };

                var parameters = new AuditData
                {
                    Unit = !string.IsNullOrEmpty(unitUrl) ? await GetEnumValue(unitUrl) : null,
                    Precision = !string.IsNullOrEmpty(precisionUrl) ? await GetEnumValue(precisionUrl) : null,
                    Value = !string.IsNullOrEmpty(value) ? item["postData"]["value"].Value<string>() : null,
                    Type = !string.IsNullOrEmpty(typeUrl) ? await GetEnumValue(typeUrl) : null
                };

                audit.PreData = preData;
                audit.PostData = postData;
                audit.Parameters = parameters;
                audit.Legacy = legacyData;
                audit.ActionType = !string.IsNullOrEmpty(actionTypeUrl) ? await GetEnumValue(actionTypeUrl) : null;
                audit.Status = !string.IsNullOrEmpty(statusUrl) ? await GetEnumValue(statusUrl) : null;
            }

            return audit;
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