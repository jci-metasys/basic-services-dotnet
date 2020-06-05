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
    /// Provide audit item for the endpoints of the Metasys Audit API.
    /// </summary>
    public sealed class AuditInfoProvider : BasicServiceProvider, IProvideAuditInfo
    {

        private const string BaseParam = "audits";
        private readonly IFlurlClient client;

        /// <summary>
        /// Initializes a new instance of <see cref="AuditInfoProvider"/> with supplied data.
        /// </summary>
        /// <param name="client">The FlurlClient to get response from URL.</param>
        /// <param name="logClientErrors">Set this flag to false to disable logging of client errors.</param>
        public AuditInfoProvider(IFlurlClient client, bool logClientErrors = true) :base(client, logClientErrors)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client),
                                               "FlurlClient can not be null.");
        }

        /// <inheritdoc/>
        public async Task<AuditItemProvider> GetSingleAuditAsync(Guid auditId)
        {
            var response = await GetRequestAsync("audits", null, auditId).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AuditItemProvider>(response.ToString());
        }

        /// <inheritdoc/>
        public async Task<PagedResult<AuditItemProvider>> GetAuditsAsync(AuditFilter auditFilter)
        {
            return await GetPagedResultsAsync<AuditItemProvider>("audits", ToDictionary(auditFilter)).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<PagedResult<AuditItemProvider>> GetAuditsForAnObjectAsync(Guid objectId, AuditFilter auditFilter)
        {
            return await GetPagedResultsAsync<AuditItemProvider>("objects", ToDictionary(auditFilter), objectId, BaseParam).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public AuditItemProvider GetSingleAudit(Guid auditId)
        {
            return GetSingleAuditAsync(auditId).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public PagedResult<AuditItemProvider> GetAudits(AuditFilter auditFilter)
        {
            return GetAuditsAsync(auditFilter).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public PagedResult<AuditItemProvider> GetAuditsForAnObject(Guid objectId, AuditFilter auditFilter)
        {
            return GetAuditsForAnObjectAsync(objectId, auditFilter).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public IEnumerable<AuditAnnotation> GetAuditAnnotations(Guid auditId)
        {
            return GetAuditAnnotationsAsync(auditId).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AuditAnnotation>> GetAuditAnnotationsAsync(Guid auditId)
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

    }
}