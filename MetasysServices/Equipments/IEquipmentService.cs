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
        /// <param name="page">Specifies the number of the page to be retrieved (optional).</param>
        /// <param name="pageSize">Specifies the number of items per page. Default is 1000. (optional).</param>
        /// <remarks> If the param 'page' is specified then it will return only the items associated to the specified page number. Otherwise all the items will be returned. </remarks>
        IEnumerable<MetasysObject> Get(int? page = null, int? pageSize = null);
        /// <inheritdoc cref="IEquipmentService.Get(int?, int?)"/>
        Task<IEnumerable<MetasysObject>> GetAsync(int? page = null, int? pageSize = null);

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

        // GetServedByEquipment ----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the equipment served by the specified equipment instance.
        /// </summary>
        IEnumerable<MetasysObject> GetServedByEquipment(Guid equipmentId);
        /// <inheritdoc cref="IEquipmentService.GetServedByEquipment(Guid)"/>
        Task<IEnumerable<MetasysObject>> GetServedByEquipmentAsync(Guid equipmentId);

        // GetServingAnEquipment ------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the collection of equipment that serve the specified equipment instance.
        /// </summary>
        /// <param name="equipmentId"></param>
        IEnumerable<MetasysObject> GetServingAnEquipment(Guid equipmentId);
        /// <inheritdoc cref="IEquipmentService.GetServingAnEquipment(Guid)"/>
        Task<IEnumerable<MetasysObject>> GetServingAnEquipmentAsync(Guid equipmentId);

    }
}
