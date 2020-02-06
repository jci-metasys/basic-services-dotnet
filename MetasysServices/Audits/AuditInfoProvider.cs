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
        public AuditInfoProvider(IFlurlClient client):base(client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client),
                                               "FlurlClient can not be null.");
        }

        /// <summary>
        /// Retrieves the specified audit asynchronously.
        /// </summary>
        /// <param name="auditId">The identifier of the audit.</param>
        /// <returns>The specified audit details.</returns>
        public async Task<AuditItemProvider> GetSingleAuditAsync(Guid auditId)
        {
            var response = await GetRequestAsync("audits", null, auditId);
            return JsonConvert.DeserializeObject<AuditItemProvider>(response.ToString());
        }

        /// <summary>
        /// Retrieves a collection of audits asynchronously.
        /// </summary>
        /// <param name="auditFilter">The audit model to filter audits.</param>
        /// <returns>The list of audits 
        public async Task<PagedResult<AuditItemProvider>> GetAuditsAsync(AuditFilter auditFilter)
        {
            return await GetPagedResultsAsync<AuditItemProvider>(BaseParam, ToDictionary(auditFilter));
        }

        /// <summary>
        /// Retrieves a collection of audits for the specified object asynchronously.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <param name="auditFilter">The filter to be applied to audit list.</param>
        /// <returns>The list of audit with details.</returns>
        public async Task<PagedResult<AuditItemProvider>> GetAuditsForAnObjectAsync(Guid objectId, AuditFilter auditFilter)
        {
            return await GetPagedResultsAsync<AuditItemProvider>("objects", ToDictionary(auditFilter), objectId, BaseParam);
        }

        /// <summary>
        /// Retrieves the specified audit.
        /// </summary>
        /// <param name="auditId">The identifier of the audit.</param>
        /// <returns>The specified audit details.</returns>
        public AuditItemProvider GetSingleAudit(Guid auditId)
        {
            return GetSingleAuditAsync(auditId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a collection of audits.
        /// </summary>
        /// <param name="auditFilter">The audit model to filter audits.</param>
        /// <returns>The list of audits 
        public PagedResult<AuditItemProvider> GetAudits(AuditFilter auditFilter)
        {
            return GetAuditsAsync(auditFilter).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a collection of audits for the specified object.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <param name="auditFilter">The filter to be applied to audit list.</param>
        /// <returns>The list of audit with details.</returns>
        public PagedResult<AuditItemProvider> GetAuditsForAnObject(Guid objectId, AuditFilter auditFilter)
        {
            return GetAuditsForAnObjectAsync(objectId, auditFilter).GetAwaiter().GetResult();
        }
    }
}