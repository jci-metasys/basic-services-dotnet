using Microsoft.Extensions.Logging;
﻿using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Provide space item for the endpoints of the Metasys Spaces API.
/// </summary>
public sealed class SpaceServiceProvider(IFlurlClient client, ApiVersion version, ILogger? logger = null) : BasicServiceProvider(client, version, logger), ISpaceService
{

    // FindById -------------------------------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public MetasysObject FindById(ObjectId spaceId)
    {
        return FindByIdAsync(spaceId).GetAwaiter().GetResult();
    }

    /// <inheritdoc/>
    public async Task<MetasysObject> FindByIdAsync(ObjectId spaceId, CancellationToken ct = default)
    {
        CheckVersion(Version);
        var response = await GetRequestAsync("spaces", null, ct, new object[] { spaceId }).ConfigureAwait(false);
        return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Space);
    }


    // Get ---------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObject> Get(SpaceTypeEnum? type = null, int? page = null, int? pageSize = null, string? sort = null)
    {
        return GetAsync(type, page, pageSize, sort).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetAsync(SpaceTypeEnum? type = null, int? page = null, int? pageSize = null, string? sort = null, CancellationToken ct = default)
    {
        CheckVersion(Version);
        Dictionary<string, string> parameters = new();

        //Add parameters
        if (type != null) parameters.Add("type", ((int)type).ToString());
        if (page != null && page > 0) parameters.Add("page", page.ToString());
        if (pageSize != null && pageSize > 0 && pageSize <= 1000) parameters.Add("pageSize", pageSize.ToString());
        if (sort != null) parameters.Add("sort", sort);

        var spaces = await GetAllAvailablePagesAsync("spaces", parameters).ConfigureAwait(false);
        return ToMetasysObject(spaces, Version, type: MetasysObjectTypeEnum.Space);
    }

    /// <inheritdoc/>
    public IEnumerable<MetasysObject> Get(string type, int? page = null, int? pageSize = null, string? sort = null)
    {
        return GetAsync(type, page, pageSize, sort).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetAsync(string type, int? page = null, int? pageSize = null, string? sort = null, CancellationToken ct = default)
    {
        CheckVersion(Version);
        Dictionary<string, string> parameters = new();

        //Add parameters
        if (type != null) parameters.Add("type", type);
        if (page != null && page > 0 && parameters != null) parameters.Add("page", page.ToString());
        if (pageSize != null && pageSize > 0 && parameters != null) parameters.Add("pageSize", pageSize.ToString());
        if (sort != null) parameters.Add("sort", sort);

        var spaces = await GetAllAvailablePagesAsync("spaces", parameters).ConfigureAwait(false);
        return ToMetasysObject(spaces, Version, type: MetasysObjectTypeEnum.Space);
    }

    // GetChildren ------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObject> GetChildren(ObjectId spaceId)
    {
        return GetChildrenAsync(spaceId).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetChildrenAsync(ObjectId spaceId, CancellationToken ct = default)
    {
        CheckVersion(Version);
        var spaceChildren = await GetAllAvailablePagesAsync("spaces", null, ct, new string[] { spaceId.ToString(), "spaces"}).ConfigureAwait(false);
        return ToMetasysObject(spaceChildren, Version, MetasysObjectTypeEnum.Space);
    }

    // GetTypes ---------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObjectType> GetTypes()
    {
        return GetTypesAsync().GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObjectType>> GetTypesAsync(CancellationToken ct = default)
    {
        if (Version < ApiVersion.v4)
        {
            return await GetResourceTypesAsync("enumSets", "1766/members").ConfigureAwait(false);
        }
        else
        {
            return await GetResourceTypesAsync("enumerations", "spaceTypesEnumSet").ConfigureAwait(false);
        }
    }

    // GetServedByEquipment ------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObject> GetServedByEquipment(ObjectId equipmentId)
    {
        return GetServedByEquipmentAsync(equipmentId).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetServedByEquipmentAsync(ObjectId equipmentId, CancellationToken ct = default)
    {
        CheckVersion(Version);
        var response = await GetAllAvailablePagesAsync("equipment", null, ct, new string[] { equipmentId.ToString(), "spaces"}).ConfigureAwait(false);
        return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Space);
    }

    // GetServedByNetworkDevice ------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObject> GetServedByNetworkDevice(ObjectId networkDeviceId)
    {
        return GetServedByNetworkDeviceAsync(networkDeviceId).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetServedByNetworkDeviceAsync(ObjectId networkDeviceId, CancellationToken ct = default)
    {
        CheckVersion(Version);
        var response = await GetAllAvailablePagesAsync("networkDevices", null, ct, new string[] { networkDeviceId.ToString(), "spaces"}).ConfigureAwait(false);
        return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Space);
    }

}
