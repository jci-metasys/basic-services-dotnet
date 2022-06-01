using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using JohnsonControls.Metasys.BasicServices;
using JohnsonControls.Metasys.BasicServices.Enums;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Defines method to provide network device infos for endpoints of the Metasys Network Devices API.
    /// </summary>

    public interface INetworkDeviceService : IBasicService
    {
        // FindById ---------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the specified network device.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the network device.</param>
        /// <returns>The specified alarm details.</returns>
        MetasysObject FindById(Guid networkDeviceId);
        /// <inheritdoc cref="INetworkDeviceService.FindById(Guid)"/>
        Task<MetasysObject> FindByIdAsync(Guid networkDeviceId);

        // FindById ---------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves a collection of network devices.
        /// </summary>
        /// <param name="type">Optional type number as a string</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        IEnumerable<MetasysObject> Get(string type = null);
        /// <inheritdoc cref="INetworkDeviceService.Get(string)"/>
        Task<IEnumerable<MetasysObject>> GetAsync(string type = null);

        /// <summary>
        /// Retrieves a collection of network devices.
        /// </summary>
        /// <param name="classificationEnum"></param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        Task<IEnumerable<MetasysObject>> GetAsync(NetworkDeviceClassificationEnum classificationEnum);

        // Get -------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves a collection of network devices.
        /// </summary>
        /// <param name="networkDevicetype">Network Device Type enum</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        IEnumerable<MetasysObject> Get(NetworkDeviceTypeEnum networkDevicetype);
        /// <inheritdoc cref="INetworkDeviceService.Get(NetworkDeviceTypeEnum)"/>
        Task<IEnumerable<MetasysObject>> GetAsync(NetworkDeviceTypeEnum networkDevicetype);

        // GetTypes --------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the collection of all network device types.
        /// </summary>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        IEnumerable<MetasysObjectType> GetTypes();
        /// <inheritdoc cref="INetworkDeviceService.GetTypes()"/>
        Task<IEnumerable<MetasysObjectType>> GetTypesAsync();

        // GetChildren ------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the collection of network devices that are children of the specified network device.
        /// </summary>
        IEnumerable<MetasysObject> GetChildren(Guid networkDeviceId);
        /// <inheritdoc cref="INetworkDeviceService.GetChildren(Guid)"/>
        Task<IEnumerable<MetasysObject>> GetChildrenAsync(Guid networkDeviceId);

        // GetHostingAnEquipment --------------------------------------------------------------------------------------------------
        /// <summary>
        /// List network devices hosting an equipment instance
        /// </summary>
        IEnumerable<MetasysObject> GetHostingAnEquipment(Guid equipmentId);
        /// <inheritdoc cref="INetworkDeviceService.GetHostingAnEquipment(Guid)"/>
        Task<IEnumerable<MetasysObject>> GetHostingAnEquipmentAsync(Guid equipmentId);

        // GetServingASpace -------------------------------------------------------------------------------------------------------
        /// <summary>
        /// List network devices serving a space.
        /// </summary>
        IEnumerable<MetasysObject> GetServingASpace(Guid spaceId);
        /// <inheritdoc cref="INetworkDeviceService.GetServingASpace(Guid)"/>
        Task<IEnumerable<MetasysObject>> GetServingASpaceAsync(Guid spaceId);

    }
}
