using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using JohnsonControls.Metasys.BasicServices;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Base Interface for implementing a new service for Metasys Client.
    /// </summary>
    public interface IBasicService
    {
        /// <summary>
        /// The Metasys server's Api version.
        /// </summary>
        ApiVersion Version { get; set; }

        /// <summary>
        /// Value of the CultureInfo usaed to get the localization.
        /// </summary>
        CultureInfo Culture { get; set; }


        /// <summary>
        /// Get all the values of a specified enumeration set
        /// </summary>
        IEnumerable<MetasysEnumValue> GetEnumValues(String enumerationKey);

        /// <summary>
        /// Get all the values of a specified enumeration set (Async)
        /// </summary>
        Task<IEnumerable<MetasysEnumValue>> GetEnumValuesAsync(String enumerationKey);


        /// <summary>
        /// Attempts to get the enumeration key of a given en-US localized objectType.
        /// </summary>
        /// <remarks>
        /// The resource parameter must be the value of a Metasys objectTypeEnumSet en-US value,
        /// otherwise no key will be found.
        /// </remarks>
        /// <param name="resource">The en-US value for the localization resource.</param>
        /// <returns>
        /// The enumeration key of the en-US objectType if found, original resource if not.
        /// </returns>
        string GetObjectTypeEnumeration(string resource);


        /// <summary>
        /// Localizes the specified resource key for the current MetasysClient locale or specified culture.
        /// </summary>
        /// <remarks>
        /// The resource parameter must be the key of a Metasys enumeration resource,
        /// otherwise no translation will be found.
        /// </remarks>
        /// <param name="resource">The key for the localization resource.</param>
        /// <param name="cultureInfo">Optional culture specification.</param>
        /// <returns>
        /// Localized string if the resource was found, the default en-US localized string if not found,
        /// or the resource parameter value if neither resource is found.
        /// </returns>
        string Localize(string resource, CultureInfo cultureInfo = null);

    }
}
