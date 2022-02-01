using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using JohnsonControls.Metasys.BasicServices;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Defines method to provide network device infos for endpoints of the Metasys Network Devices API.
    /// </summary>

    public interface INetworkDeviceService : IBasicService
    {
        /// <summary>
        /// Retrieves the specified network device.
        /// </summary>
        /// <param name="equipmentId">The identifier of the alarm.</param>
        /// <returns>The specified alarm details.</returns>
        MetasysObject FindById(Guid equipmentId);
        /// <inheritdoc cref="INetworkDeviceService.FindById(Guid)"/>
        Task<MetasysObject> FindByIdAsync(Guid equipmentId);


        /// <summary>
        /// Gets all network devices.
        /// </summary>
        /// <param name="type">Optional type number as a string</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        IEnumerable<MetasysObject> Get(string type = null);
        /// <inheritdoc cref="INetworkDeviceService.Get(string)"/>
        Task<IEnumerable<MetasysObject>> GetAsync(string type = null);


        /// <summary>
        /// Gets all network devices.
        /// </summary>
        /// <param name="networkDevicetype">Network Device Type enum</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        IEnumerable<MetasysObject> Get(NetworkDeviceTypeEnum networkDevicetype);
        /// <inheritdoc cref="INetworkDeviceService.Get(NetworkDeviceTypeEnum)"/>
        Task<IEnumerable<MetasysObject>> GetAsync(NetworkDeviceTypeEnum networkDevicetype);


        /// <summary>
        /// Gets all available network device types.
        /// </summary>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        IEnumerable<MetasysObjectType> GetTypes();
        /// <inheritdoc cref="INetworkDeviceService.GetTypes()"/>
        Task<IEnumerable<MetasysObjectType>> GetTypesAsync();


        /// <summary>
        /// List network device children.
        /// </summary>
        IEnumerable<MetasysObject> GetChildren(Guid networkDeviceId);
        /// <inheritdoc cref="INetworkDeviceService.GetChildren()"/>
        Task<IEnumerable<MetasysObject>> GetChildrenAsync(Guid networkDeviceId);

        /// <summary>
        /// List network devices hosting an equipment instance.
        /// </summary>
        IEnumerable<MetasysObject> GetHostingAnEquipment(Guid equipmentId);
        /// <inheritdoc cref="INetworkDeviceService.GetHostingAnEquipment()"/>
        Task<IEnumerable<MetasysObject>> GetHostingAnEquipmentAsync(Guid equipmentId);

        /// <summary>
        /// List network devices serving a space.
        /// </summary>
        IEnumerable<MetasysObject> GetServingASpace(Guid spaceId);
        /// <inheritdoc cref="INetworkDeviceService.GetServingASpace()"/>
        Task<IEnumerable<MetasysObject>> GetServingASpaceAsync(Guid spaceId);

    }
}
