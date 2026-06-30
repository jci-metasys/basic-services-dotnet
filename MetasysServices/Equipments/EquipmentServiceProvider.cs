using Microsoft.Extensions.Logging;
﻿using Flurl;
using Flurl.Http;
using System;
using System.Text.Json.Nodes;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Provide equipment item for the endpoints of the Metasys Equipments API.
/// </summary>
public sealed class EquipmentServiceProvider(IFlurlClient client, ApiVersion version, ILogger? logger = null) : BasicServiceProvider(client, version, logger), IEquipmentService
{
    private readonly CultureInfo _CultureInfo = new CultureInfo("en-US");

    // FindById -----------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public MetasysObject FindById(ObjectId equipmentId)
    {
        return FindByIdAsync(equipmentId).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<MetasysObject> FindByIdAsync(ObjectId equipmentId, CancellationToken ct = default)
    {
        CheckVersion(Version);

        var response = await GetRequestAsync("equipment", null, ct, new object[] { equipmentId }).ConfigureAwait(false);
        return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Equipment);
    }

    // Get ---------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObject> Get(int? page = null, int? pageSize = null)
    {
        return GetAsync(page, pageSize).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetAsync(int? page = null, int? pageSize = null, CancellationToken ct = default)
    {
        CheckVersion(Version);

        Dictionary<string, string>? parameters = null;
        if ((page != null && page > 0) | (pageSize != null && pageSize > 0)) parameters = new Dictionary<string, string>();

        if (page != null && page > 0 && parameters != null) parameters.Add("page", page.ToString());
        if (pageSize != null && pageSize > 0 && parameters != null) parameters.Add("pageSize", pageSize.ToString());

        var equipment = await GetAllAvailablePagesAsync("equipment", parameters).ConfigureAwait(false);
        return ToMetasysObject(equipment, Version, MetasysObjectTypeEnum.Equipment);
    }

    // GetPoints -------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysPoint> GetPoints(ObjectId equipmentId, bool readAttributeValue = true)
    {
        return GetPointsAsync(equipmentId, readAttributeValue).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysPoint>> GetPointsAsync(ObjectId equipmentId, bool readAttributeValue = true, CancellationToken ct = default)
    {
        CheckVersion(Version);

        List<MetasysPoint> points = new() { }; List<Guid> guids = new List<Guid>();
        List<MetasysPoint> pointsWithAttribute = new() { };
        var response = await GetAllAvailablePagesAsync("equipment", null, ct, new string[] { equipmentId.ToString(), "points" }).ConfigureAwait(false);
        try
        {
            foreach (var item in response)
            {
                MetasysPoint point = new(item);
                // Retrieve object Id from full URL
                string objectId = point.ObjectUrl.Split('/').Last();
                point.ObjectId = ParseObjectIdentifier(objectId);
                // Retrieve attribute Id from full URL
                string attributeId = (point.Attribute != null) ? point.Attribute.Split('.').Last() : String.Empty;
                if (attributeId == String.Empty)
                {
                    attributeId = (point.AttributeUrl != null) ? point.AttributeUrl.Split('/').Last() : String.Empty;
                }
                if (point.ObjectId == "") // Sometime can happen that there are empty Guids.
                {
                    continue;
                }
                // Collect Guids to perform read property multiple in "one call" (supporting only presentValue so far)
                if ((attributeId == "85" | attributeId == "presentValue") && readAttributeValue)
                {
                    JsonNode resp = await Client.Request(new Url("objects")
                                        .AppendPathSegments(point.ObjectId, "attributes", "presentValue"))
                                        .GetJsonAsync<JsonNode>()
                                        .ConfigureAwait(false);
                    Variant result = new(point.ObjectId, resp, "presentValue", Culture, Version);
                    point.PresentValue = result;
                    points.Add(point);
                }
                else
                {
                    points.Add(point);
                }
            }
        }
        catch (System.NullReferenceException e)
        {
            throw new MetasysHttpParsingException(response.ToString(), e);
        }
        return points;
    }
    // GetServingASpace --------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObject> GetServingASpace(ObjectId spaceId)
    {
        return GetServingASpaceAsync(spaceId).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetServingASpaceAsync(ObjectId spaceId, CancellationToken ct = default)
    {
        CheckVersion(Version);

        var spaceEquipment = await GetAllAvailablePagesAsync("spaces", null, ct, new string[] { spaceId.ToString(), "equipment"}).ConfigureAwait(false);
        return ToMetasysObject(spaceEquipment, Version, MetasysObjectTypeEnum.Equipment);
    }

    // GetHostedByNetworkDevice --------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObject> GetHostedByNetworkDevice(ObjectId networkDeviceId)
    {
        return GetHostedByNetworkDeviceAsync(networkDeviceId).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetHostedByNetworkDeviceAsync(ObjectId networkDeviceId, CancellationToken ct = default)
    {
        CheckVersion(Version);

        var spaceEquipment = await GetAllAvailablePagesAsync("networkDevices", null, ct, new string[] { networkDeviceId.ToString(), "equipment"}).ConfigureAwait(false);
        return ToMetasysObject(spaceEquipment, Version, MetasysObjectTypeEnum.Equipment);
    }

    // GetServedByEquipment -----------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObject> GetServedByEquipment(ObjectId equipmentId)
    {
        return GetServedByEquipmentAsync(equipmentId).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetServedByEquipmentAsync(ObjectId equipmentId, CancellationToken ct = default)
    {
        CheckVersion(Version);

        var response = await GetAllAvailablePagesAsync("equipment", null, ct, new string[] { equipmentId.ToString(), "equipment"}).ConfigureAwait(false);
        return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Equipment);
    }

    // GetServingAnEquipment --------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysObject> GetServingAnEquipment(ObjectId equipmentId)
    {
        return GetServingAnEquipmentAsync(equipmentId).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysObject>> GetServingAnEquipmentAsync(ObjectId equipmentId, CancellationToken ct = default)
    {
        CheckVersion(Version);

        var spaceEquipment = await GetAllAvailablePagesAsync("equipment", null, ct, new string[] { equipmentId.ToString(), "upstreamEquipment"}).ConfigureAwait(false);
        return ToMetasysObject(spaceEquipment, Version, MetasysObjectTypeEnum.Equipment);
    }

}
