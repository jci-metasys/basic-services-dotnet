using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using JohnsonControls.Metasys.BasicServices;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Defines method to provide equipment infos for endpoints of the Metasys Equipments API.
    /// </summary>

    public interface IEquipmentService : IBasicService
    {
        // FindById ----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the specified equipment instance.
        /// </summary>
        MetasysObject FindById(Guid equipmentId);
        /// <inheritdoc cref="IEquipmentService.FindById(Guid)"/>
        Task<MetasysObject> FindByIdAsync(Guid equipmentId);

        // Get ---------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves a collection of equipment instances.
        /// </summary>
        IEnumerable<MetasysObject> Get();
        /// <inheritdoc cref="IEquipmentService.Get()"/>
        Task<IEnumerable<MetasysObject>> GetAsync();

        // GetPoints -----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the collection of points that are defined by the specified equipment instance.
        /// </summary>
        /// <param name="equipmentId">The Guid of the equipment.</param>
        /// <param name="readAttributeValue">Set to false if you would not read Points Attribute Value.</param>
        /// <remarks> Reading the Attribute Value attribute could take time depending on the number of points. </remarks>
        /// <returns></returns>
        IEnumerable<MetasysPoint> GetPoints(Guid equipmentId, bool readAttributeValue = true);
        /// <inheritdoc cref="IEquipmentService.GetPoints(Guid, bool)"/>
        Task<IEnumerable<MetasysPoint>> GetPointsAsync(Guid equipmentId, bool readAttributeValue = true);

        // GetServingASpace ------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the collection of equipment that serve the specified space.
        /// </summary>
        /// <param name="spaceId"></param>
        IEnumerable<MetasysObject> GetServingASpace(Guid spaceId);
        /// <inheritdoc cref="IEquipmentService.GetServingASpace(Guid)"/>
        Task<IEnumerable<MetasysObject>> GetServingASpaceAsync(Guid spaceId);

        // GetHostedByNetworkDevice ------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the collection of equipment instances that are hosted by the specified network device or its children.
        /// </summary>
        /// <param name="networkDeviceId"></param>
        IEnumerable<MetasysObject> GetHostedByNetworkDevice(Guid networkDeviceId);
        /// <inheritdoc cref="IEquipmentService.GetServingASpace(Guid)"/>
        Task<IEnumerable<MetasysObject>> GetHostedByNetworkDeviceAsync(Guid networkDeviceId);

    }
}
