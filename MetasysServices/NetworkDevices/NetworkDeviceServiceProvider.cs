using Microsoft.Extensions.Logging;
﻿using Flurl.Http;
using JohnsonControls.Metasys.BasicServices.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Provide network device item for the endpoints of the Metasys Network Devices API.
/// </summary>
public sealed class NetworkDeviceServiceProvider(IFlurlClient client, ApiVersion version, ILogger? logger = null) : BasicServiceProvider(client, version, logger), INetworkDeviceService
{

    // FindById -------------------------------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public MetasysObject FindById(Guid networkDeviceId)
    {
        return FindByIdAsync(networkDeviceId).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<MetasysObject> FindByIdAsync(Guid networkDeviceId, CancellationToken ct = default)
    {
        CheckVersion(Version);
        var response = await GetRequestAsync("networkDevices", null, ct, new object[] { networkDeviceId }).ConfigureAwait(false);
        return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Equipment);
    }

    // Get ------------------------------------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObject> Get(string? type = null)
    {
        return GetAsync(type).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetAsync(NetworkDeviceClassificationEnum classificationEnum, CancellationToken ct = default)
    {
        return await GetByClassificationAsync(classificationEnum.ToString());
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetAsync(string? type = null, CancellationToken ct = default)
    {
        CheckVersion(Version);
        // Note: the name of the parameter 'Type' changes according to the API version
        string typeParamName = Version > ApiVersion.v3 ? "objectType" : "type";
        var response = await this.GetAllAvailablePagesAsync("networkDevices", new Dictionary<string, string> { { typeParamName, type } }).ConfigureAwait(false);
        return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Object);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetByClassificationAsync(string? classification = null, CancellationToken ct = default)
    {
        CheckVersion(Version);
        var response = await this.GetAllAvailablePagesAsync("networkDevices", new Dictionary<string, string> { { "classification", classification } }).ConfigureAwait(false);
        return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Object);
    }

    /// <inheritdoc/>
    public IEnumerable<MetasysObject> Get(NetworkDeviceTypeEnum networkDevicetype)
    {
        return GetAsync(networkDevicetype).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetAsync(NetworkDeviceTypeEnum networkDevicetype, CancellationToken ct = default)
    {
        CheckVersion(Version);
        string type = Convert.ToString((int)networkDevicetype);
        return await GetAsync(type);
    }

    // GetTypes -------------------------------------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObjectType> GetTypes()
    {
        return GetTypesAsync().GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObjectType>> GetTypesAsync(CancellationToken ct = default)
    {
        CheckVersion(Version);
        if (Version < ApiVersion.v4)
        { return await GetResourceTypesAsync("networkDevices", "availableTypes").ConfigureAwait(false); }
        else
        { return await RetrieveNetworkDeviceTypesAsync().ConfigureAwait(false); }
    }

    // GetChildren ---------------------------------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObject> GetChildren(Guid networkDeviceId)
    {
        return GetChildrenAsync(networkDeviceId).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetChildrenAsync(Guid networkDeviceId, CancellationToken ct = default)
    {
        CheckVersion(Version);
        var response = await GetAllAvailablePagesAsync("networkDevices", null, ct, new string[] { networkDeviceId.ToString(), "networkDevices"}).ConfigureAwait(false);
        return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Object);
    }

    // GetHostingAnEquipment ---------------------------------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObject> GetHostingAnEquipment(Guid equipmentId)
    {
        return GetHostingAnEquipmentAsync(equipmentId).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetHostingAnEquipmentAsync(Guid equipmentId, CancellationToken ct = default)
    {
        CheckVersion(Version);
        var response = await GetAllAvailablePagesAsync("equipment", null, ct, new string[] { equipmentId.ToString(), "networkDevices"}).ConfigureAwait(false);
        return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Object);
    }

    // GetServingASpace ---------------------------------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObject> GetServingASpace(Guid spaceId)
    {
        return GetServingASpaceAsync(spaceId).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetServingASpaceAsync(Guid spaceId, CancellationToken ct = default)
    {
        CheckVersion(Version);
        var response = await GetAllAvailablePagesAsync("spaces", null, ct, new string[] { spaceId.ToString(), "networkDevices"}).ConfigureAwait(false);
        return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Object);
    }



    private async Task<IEnumerable<MetasysObjectType>> RetrieveNetworkDeviceTypesAsync(CancellationToken ct = default)
    {
        List<MetasysObjectType> types = new() { };
        try
        {
            //Get the whole list of Network Devices
            var devices = await GetAllAvailablePagesAsync("networkDevices").ConfigureAwait(false);
            List<NetworkDevice> networkDevices = ToNetworkDevice(devices, Version);
            //Get the Object Type enumeration Set (Set ID = 508)

            List<MetasysEnumValue> enums = (List<MetasysEnumValue>)GetEnumValuesAsync("objectTypeEnumSet").GetAwaiter().GetResult();

            //Make the joine of the two lists in order to get only the enum values that are related to the network devices
            //var result = enums.Join(networkDevices, e1 => e1.Key, e2 => e2.ObjectType, (e1, e2) => e1).Distinct();
            var joinedList = (from nd in networkDevices
                              join en in enums on nd.ObjectType equals en.Key into gj
                              from suben in gj
                              select new { Description = suben.Name, DescriptionEnumerationKey = suben.Key, ID = suben.Value }).Distinct();
            //Build the result
            foreach (var i in joinedList)
            {
                types.Add(new MetasysObjectType(i.ID, i.DescriptionEnumerationKey, i.Description));
            }
        }
        catch (FlurlHttpException e)
        {
            ThrowHttpException(e);
        }
        return types;
    }

}
