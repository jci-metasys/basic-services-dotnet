using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Flurl.Http;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Defines method to provide audit infos for endpoints of the Metasys Audit API.
    /// </summary>
    public interface IAuditService:IBasicService
    {
        /// <summary>
        /// Retrieves the specified audit.
        /// </summary>
        /// <param name="auditId">The identifier of the audit.</param>
        /// <returns>The specified audit details.</returns>
        Audit FindById(Guid auditId);

        /// <summary>
        /// Retrieves the specified audit.
        /// </summary>
        /// <param name="auditId">The identifier of the audit.</param>
        /// <returns>The specified audit details.</returns>
        /// <inheritdoc cref="IAuditService.FindById(Guid)"/>
		Task<Audit> FindByIdAsync(Guid auditId);

        /// <summary>
        /// Retrieves a collection of audits.
        /// </summary>
        /// <param name="auditFilter">The audit model to filter audits.</param>
        /// <returns>The list of audits with details.</returns>
        PagedResult<Audit> Get(AuditFilter auditFilter);

        /// <summary>
        /// Retrieves a collection of audits.
        /// </summary>
        /// <param name="auditFilter">The audit model to filter audits.</param>
        /// <returns>The list of audits with details.</returns>
        /// <inheritdoc cref="AuditServiceProvider.Get(AuditFilter)"/>
		Task<PagedResult<Audit>> GetAsync(AuditFilter auditFilter);

        /// <summary>
        /// Retrieve a collection of Audit Annotations.
        /// </summary>
        /// <param name="auditId"></param>
        /// <returns></returns>
        IEnumerable<AuditAnnotation> GetAnnotations(Guid auditId);

        /// <summary>
        /// Retrieve a collection of Audit Annotations asynchronously.
        /// </summary>
        /// <param name="auditId"></param>
        /// <returns></returns>
        Task<IEnumerable<AuditAnnotation>> GetAuditAsync(Guid auditId);

        /// <summary>
        /// Retrieves a collection of audits for the specified object.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <param name="auditFilter">The filter to be applied to audit list.</param>
        /// <returns>The list of audit with details.</returns>
        PagedResult<Audit> GetForObject(Guid objectId, AuditFilter auditFilter);

        /// <summary>
        /// Retrieves a collection of audits for the specified object.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <param name="auditFilter">The filter to be applied to audit list.</param>
        /// <returns>The list of audits with details.</returns>
        /// <inheritdoc cref="AuditServiceProvider.GetForObject(Guid, AuditFilter)"/> 
        Task<PagedResult<Audit>> GetForObjectAsync(Guid objectId, AuditFilter auditFilter);

        /// <summary>
        /// Discard an Audit.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="MetasysUnsupportedApiVersion"></exception>
        void DiscardAudit(Guid id);

        /// <summary>
        /// Discard an Audit asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="MetasysUnsupportedApiVersion"></exception>
        /// <returns>Asynchronous Task Result.</returns>
        Task DiscardAuditAsync(Guid id);

    }
}