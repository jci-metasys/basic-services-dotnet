using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using JohnsonControls.Metasys.BasicServices;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Defines method to provide space infos for endpoints of the Metasys Spaces API.
    /// </summary>

    public interface ISpaceService : IBasicService
    {

        // Get ---------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all spaces.
        /// </summary>
        /// <param name="type">Optional type ID belonging to SpaceTypeEnum.</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        IEnumerable<MetasysObject> Get(SpaceTypeEnum? type = null);
        /// <inheritdoc cref="IMetasysClient.Get(SpaceTypeEnum?)"/>
        Task<IEnumerable<MetasysObject>> GetAsync(SpaceTypeEnum? type = null);


    }
}
