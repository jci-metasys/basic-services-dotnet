using Microsoft.Extensions.Logging;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Threading;


namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Provide enumeration item for the endpoints of the Metasys Enumerations API.
/// </summary>
public sealed class EnumerationServiceProvider(IFlurlClient client, ApiVersion version, ILogger? logger = null) : BasicServiceProvider(client, version, logger), IEnumerationService
{

    // Get ------------------------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysEnumeration> Get()
    {
        return GetAsync().GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysEnumeration>> GetAsync(CancellationToken ct = default)
    {
        CheckVersion(Version);

        List<MetasysEnumeration> enums = new() { };

        if (Version > ApiVersion.v3)
        {
            try
            {
                var response = await Client.Request(new Url("enumerations"))
                    .GetJsonAsync<JsonNode>()
                    .ConfigureAwait(false);
                try
                {
                    var items = response["items"] as JsonObject;
                    foreach (var kvp in items)
                    {
                        if (kvp.Key.Length > 0)
                        {
                            var itm = kvp.Value as JsonObject;
                            string key = kvp.Key;
                            string name = itm != null && itm.ContainsKey("name") ? (string)itm["name"] : string.Empty;
                            bool isTwoState = itm != null && itm.ContainsKey("isTwoState") && itm["isTwoState"].GetValue<bool>();
                            bool isMultiState = itm != null && itm.ContainsKey("isMultiState") && itm["isMultiState"].GetValue<bool>();
                            int numberOfStates = itm != null && itm.ContainsKey("numberOfStates") ? itm["numberOfStates"].GetValue<int>() : 0;

                            var enumItem = new MetasysEnumeration(key, name, isTwoState, isMultiState, numberOfStates);
                            enums.Add(enumItem);
                        }
                    }
                }
                catch (System.NullReferenceException e)
                { throw new MetasysHttpParsingException(response.ToString(), e); }
            }
            catch (FlurlHttpException e)
            { ThrowHttpException(e); }
        }
        else
        { throw new MetasysUnsupportedApiVersion(Version.ToString()); }

        return enums;
    }

    // Create ----------------------------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public void Create(string name, IEnumerable<string> values)
    {
        CreateAsync(name, values).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task CreateAsync(string name, IEnumerable<string> values, CancellationToken ct = default)
    {
        CheckVersion(Version);
        try
        {
            if (Version > ApiVersion.v3)
            {
                //Check if the name is not blank or the length of the list of members is >= 2
                if (name.Length > 0 && values.Count() >= 2)
                {
                    var members = new JsonArray();
                    foreach (string v in values)
                    {
                        members.Add(JsonValue.Create(v));
                    }
                    var item = new JsonObject { ["name"] = JsonValue.Create(name), ["members"] = members };
                    var body = new JsonObject { ["item"] = item };
                    var response = await Client.Request(new Url("enumerations"))
                                                .PostJsonAsync(body)
                                                .ConfigureAwait(false);
                }
            }
            else
            { throw new MetasysUnsupportedApiVersion(Version.ToString()); }
        }
        catch (FlurlHttpException e)
        { ThrowHttpException(e); }
    }

    // GetValues ------------------------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public IEnumerable<MetasysEnumValue> GetValues(string id)
    {
        return GetEnumValues(id);
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<MetasysEnumValue>> GetValuesAsync(string id, CancellationToken ct = default)
    {
        return await GetEnumValuesAsync(id);
    }

    // Edit ----------------------------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public void Edit(string id, string name, IEnumerable<string> values)
    {
        EditAsync(id, name, values).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task EditAsync(string id, string name, IEnumerable<string> values, CancellationToken ct = default)
    {
        CheckVersion(Version);
        try
        {
            if (Version > ApiVersion.v3)
            {
                //Check if the name is not blank or the length of the list of members is >= 2
                if (name.Length > 0 && values.Count() >= 2)
                {
                    var members = new JsonObject();
                    var valuesList = values.ToList();
                    for (int i = 0; i < valuesList.Count; i++)
                    {
                        members[id + "." + i.ToString()] = new JsonObject { ["name"] = JsonValue.Create(valuesList[i]) };
                    }
                    var item = new JsonObject { ["name"] = JsonValue.Create(name), ["members"] = members };
                    var body = new JsonObject { ["item"] = item };
                    var response = await Client.Request(new Url("enumerations")
                                                .AppendPathSegments(id))
                                                .PatchJsonAsync(body)
                                                .ConfigureAwait(false);
                }
            }
            else
            { throw new MetasysUnsupportedApiVersion(Version.ToString()); }
        }
        catch (FlurlHttpException e)
        { ThrowHttpException(e); }
    }

    // Replace ----------------------------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public void Replace(string id, string name, IEnumerable<string> values)
    {
        ReplaceAsync(id, name, values).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task ReplaceAsync(string id, string name, IEnumerable<string> values, CancellationToken ct = default)
    {
        CheckVersion(Version);
        try
        {
            if (Version > ApiVersion.v3)
            {
                //Check if the name is not blank or the length of the list of members is >= 2
                if (id.Length > 0 && name.Length > 0 && values.Count() >= 2)
                {
                    var members = new JsonArray();
                    foreach (string v in values)
                    {
                        members.Add(JsonValue.Create(v));
                    }
                    var item = new JsonObject { ["name"] = JsonValue.Create(name), ["members"] = members };
                    var body = new JsonObject { ["item"] = item };
                    var response = await Client.Request(new Url("enumerations")
                                                    .AppendPathSegments(id))
                                                    .PutJsonAsync(body)
                                                    .ConfigureAwait(false);
                }
            }
            else
            { throw new MetasysUnsupportedApiVersion(Version.ToString()); }
        }
        catch (FlurlHttpException e)
        { ThrowHttpException(e); }
    }

    // Delete ----------------------------------------------------------------------------------------------------------------------------------------
    /// <inheritdoc/>
    public void Delete(string id)
    {
        DeleteAsync(id).GetAwaiter().GetResult();
    }
    /// <inheritdoc/>
    public async Task DeleteAsync(string id, CancellationToken ct = default)
    {
        CheckVersion(Version);
        try
        {
            if (Version > ApiVersion.v3)
            {
                var response = await Client.Request(new Url("enumerations")
                                                            .AppendPathSegments(id))
                                                            .DeleteAsync()
                                                            .ConfigureAwait(false);
            }
            else
            { throw new MetasysUnsupportedApiVersion(Version.ToString()); }
        }
        catch (FlurlHttpException e)
        { ThrowHttpException(e); }
    }
}
