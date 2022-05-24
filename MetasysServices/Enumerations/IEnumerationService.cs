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
        /// <param name="id">The identifier of the enumeration.</param>
        IEnumerable<MetasysEnumValue> GetValues(String id);
        /// <inheritdoc cref="IEnumerationService.GetValues(String)"/>
        Task<IEnumerable<MetasysEnumValue>> GetValuesAsync(String id);

        // Delete --------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete an enumeration. Only custom enumerations may be deleted.
        /// </summary>
        /// <param name="id">The identifier of the enumeration.</param>
        void Delete(string id);
        /// <inheritdoc cref="IEnumerationService.Delete(String)"/>
        Task DeleteAsync(string id);

        // Create --------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Create a new custom enumeration.
        /// </summary>
        /// <param name="name">The name of the new custom enumeration.</param>
        /// <param name="values">The list of values (string) included in the new custom enumeration.</param>
        void Create(string name, IEnumerable<String> values);
        /// <summary>
        /// Create a new custom enumeration.
        /// </summary>
        /// <param name="name">The name of the new custom enumeration.</param>
        /// <param name="values">The list of values (string) included in the new custom enumeration.</param>
        Task CreateAsync(string name, IEnumerable<String> values);

        // Edit --------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Edit and existing custom enumeration.
        /// </summary>
        /// <param name="id">The identifier of the existing custom enumeration.</param>
        /// <param name="name">The new name of the custom enumeration.</param>
        /// <param name="values">The list of new values (string) for the existing custom enumeration.</param>
        void Edit(string id, string name, IEnumerable<String> values);
        /// <summary>
        /// Edit and existing custom enumeration.
        /// </summary>
        /// <param name="id">The identifier of the existing custom enumeration.</param>
        /// <param name="name">The new name of the custom enumeration.</param>
        /// <param name="values">The list of new values (string) for the existing custom enumeration.</param>
        Task EditAsync(string id, string name, IEnumerable<String> values);

        // Replace --------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Replace and existing custom enumeration.
        /// </summary>
        /// <param name="id">The identifier of the existing custom enumeration.</param>
        /// <param name="name">The new name of the custom enumeration.</param>
        /// <param name="values">The list of new values (string) for the existing custom enumeration.</param>
        void Replace(string id, string name, IEnumerable<String> values);
        /// <summary>
        /// Replace and existing custom enumeration.
        /// </summary>
        /// <param name="id">The identifier of the existing custom enumeration.</param>
        /// <param name="name">The new name of the custom enumeration.</param>
        /// <param name="values">The list of new values (string) for the existing custom enumeration.</param>
        Task ReplaceAsync(string id, string name, IEnumerable<String> values);

    }
}
