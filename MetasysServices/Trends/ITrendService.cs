using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITrendService : IBasicService
    {
        /// <summary>
        /// Get the list of trended attributes for the given object.
        /// </summary>    
        /// <param name="id">The indentifier (GUID) of the object.</param>
        /// <returns>The list of trended attributes.</returns>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpTimeoutException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysObjectException"></exception>
        List<MetasysAttribute> GetTrendedAttributes(Guid id);
        /// <inheritdoc cref="ITrendService.GetTrendedAttributes(Guid)"/>
        Task<List<MetasysAttribute>> GetTrendedAttributesAsync(Guid id);

        /// <summary>
        /// Retrieves available samples for the given object attribute, filtered by startTime and endTime.
        /// </summary>
        /// <remarks>StartTime and EndTime are mandatory parameters.</remarks>
        /// <param name="objectId">The identifier (GUID) of the object.</param>
        /// <param name="attributeId">The numeric identifier of the attribute.</param>
        /// <param name="filter">The filter that specifies: startTime, endTime, page, pageSize, sort.</param>
        /// <returns>The list of samples.</returns>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpTimeoutException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysObjectException"></exception>
        PagedResult<Sample> GetSamples(Guid objectId, int attributeId, TimeFilter filter);
        /// <inheritdoc cref="ITrendService.GetSamples(Guid, int, TimeFilter)"/>
        Task<PagedResult<Sample>> GetSamplesAsync(Guid objectId, int attributeId, TimeFilter filter);

        /// <summary>
        /// Retrieves available samples for the given object attribute, filtered by startTime and endTime.
        /// </summary>
        /// <remarks>StartTime and EndTime are mandatory parameters.</remarks>
        /// <param name="objectId">The identifier (GUID) of the object.</param>
        /// <param name="attributeName">The textual identifier of the attribute.</param>
        /// <param name="filter">The filter that specifies: startTime, endTime, page, pageSize, sort.</param>
        /// <returns>The list of samples.</returns>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpTimeoutException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysObjectException"></exception>
        PagedResult<Sample> GetSamples(Guid objectId, AttributeEnumSet attributeName, TimeFilter filter);
        /// <inheritdoc cref="ITrendService.GetSamples(Guid, AttributeEnumSet, TimeFilter)"/>
        Task<PagedResult<Sample>> GetSamplesAsync(Guid objectId, AttributeEnumSet attributeName, TimeFilter filter);

        /// <summary>
        /// Get the list of trended attributes for the given Network Device.
        /// </summary>    
        /// <param name="id">The identifier (GUID) of the network device.</param>
        /// <returns>The list of trended attributes.</returns>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpTimeoutException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysObjectException"></exception>
        List<MetasysAttribute> GetNetDevTrendedAttributes(Guid id);
        /// <inheritdoc cref="ITrendService.GetNetDevTrendedAttributes(Guid)"/>
        Task<List<MetasysAttribute>> GetNetDevTrendedAttributesAsync(Guid id);

        /// <summary>
        /// Retrieves available samples for the given network device attribute, filtered by startTime and endTime.
        /// </summary>
        /// <remarks>StartTime and EndTime are mandatory parameters.</remarks>
        /// <param name="networkDeviceId">The identifier (GUID) of the network device.</param>
        /// <param name="attributeId">The numeric identifier of the attribute.</param>
        /// <param name="filter">The filter that specifies: startTime, endTime, page, pageSize, sort.</param>
        /// <returns>The list of samples.</returns>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpTimeoutException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysObjectException"></exception>
        PagedResult<Sample> GetNetDevSamples(Guid networkDeviceId, int attributeId, TimeFilter filter);
        /// <inheritdoc cref="ITrendService.GetNetDevSamples(Guid, int, TimeFilter)"/>
        Task<PagedResult<Sample>> GetNetDevSamplesAsync(Guid networkDeviceId, int attributeId, TimeFilter filter);

        /// <summary>
        /// Retrieves available samples for the given network device attribute, filtered by startTime and endTime.
        /// </summary>
        /// <remarks>StartTime and EndTime are mandatory parameters.</remarks>
        /// <param name="networkDeviceId">The identifier (GUID) of the network device.</param>
        /// <param name="attributeName">The textual identifier of the attribute.</param>
        /// <param name="filter">The filter that specifies: startTime, endTime, page, pageSize, sort.</param>
        /// <returns>The list of samples.</returns>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpTimeoutException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        /// <exception cref="MetasysObjectException"></exception>
        PagedResult<Sample> GetNetDevSamples(Guid networkDeviceId, AttributeEnumSet attributeName, TimeFilter filter);
        /// <inheritdoc cref="ITrendService.GetNetDevSamples(Guid, AttributeEnumSet, TimeFilter)"/>
        Task<PagedResult<Sample>> GetNetDevSamplesAsync(Guid networkDeviceId, AttributeEnumSet attributeName, TimeFilter filter);

    }
}
