using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using JohnsonControls.Metasys.BasicServices;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Defines method to provide enumeration infos for endpoints of the Metasys Enumerations API.
    /// </summary>
    public interface IEnumerationService : IBasicService
    {
        // Get ---------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Get all the Enumerations
        /// </summary>
        IEnumerable<MetasysEnumeration> Get();
        /// <inheritdoc cref="IEnumerationService.Get()"/>
        Task<IEnumerable<MetasysEnumeration>> GetAsync();

        // GetValues ---------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Get an enumeration values
        /// </summary>
        IEnumerable<MetasysEnumValue> GetValues(String enumerationKey);
        /// <inheritdoc cref="IEnumerationService.Get()"/>
        Task<IEnumerable<MetasysEnumValue>> GetValuesAsync(String enumerationKey);

        // Delete --------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete an enumeration. Only custom enumerations may be deleted.
        /// </summary>
        /// <param name="enumerationId">The identifier of the enumeration.</param>
        void Delete(string enumerationId);
        /// <inheritdoc cref="IEnumerationService.Delete(String)"/>
        Task DeleteAsync(string enumerationId);

    }
}
