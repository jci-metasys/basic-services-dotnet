using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using log4net.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JohnsonControls.Metasys.BasicServices.Utils;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provide space item for the endpoints of the Metasys Spaces API.
    /// </summary>
    public sealed class SpaceServiceProvider : BasicServiceProvider, ISpaceService
    {
        private readonly CultureInfo _CultureInfo = new CultureInfo("en-US");

        /// <summary>
        /// Initializes a new instance of <see cref="NetworkDeviceServiceProvider"/> with supplied data.
        /// </summary>
        /// <param name="client">The FlurlClient to get response from URL.</param>
        /// <param name="version">The server's Api version.</param>
        /// <param name="logClientErrors">Set this flag to false to disable logging of client errors.</param>
        public SpaceServiceProvider(IFlurlClient client, ApiVersion version, bool logClientErrors = true) : base(client, version, logClientErrors)
        {
        }

        // FindById -------------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public MetasysObject FindById(Guid spaceId)
        {
            return FindByIdAsync(spaceId).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<MetasysObject> FindByIdAsync(Guid spaceId)
        {
            //if (Version < ApiVersion.v3) { throw new MetasysUnsupportedApiVersion(Version.ToString()); }
            var response = await GetRequestAsync("spaces", null, spaceId).ConfigureAwait(false);
            return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Space);
        }

        // Get ---------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public IEnumerable<MetasysObject> Get(SpaceTypeEnum? type = null)
        {
            return GetAsync(type).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysObject>> GetAsync(SpaceTypeEnum? type = null)
        {
            Dictionary<string, string> parameters = null;
            if (type != null)
            {
                // Init Dictionary with Space Type parameter
                parameters = new Dictionary<string, string>() { { "type", ((int)type).ToString() } };
            }
            var spaces = await GetAllAvailablePagesAsync("spaces", parameters).ConfigureAwait(false);
            return ToMetasysObject(spaces, Version, type: MetasysObjectTypeEnum.Space);
        }

        /// <inheritdoc/>
        public IEnumerable<MetasysObject> Get(string type)
        {
            return GetAsync(type).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysObject>> GetAsync(string type)
        {
            Dictionary<string, string> parameters = null;
            if (type != null)
            {
                // Init Dictionary with Space Type parameter
                parameters = new Dictionary<string, string>() { { "type", type } };
            }
            var spaces = await GetAllAvailablePagesAsync("spaces", parameters).ConfigureAwait(false);
            return ToMetasysObject(spaces, Version, type: MetasysObjectTypeEnum.Space);
        }

        // GetChildren ------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public IEnumerable<MetasysObject> GetChildren(Guid spaceId)
        {
            return GetChildrenAsync(spaceId).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysObject>> GetChildrenAsync(Guid spaceId)
        {
            var spaceChildren = await GetAllAvailablePagesAsync("spaces", null, spaceId.ToString(), "spaces").ConfigureAwait(false);
            return ToMetasysObject(spaceChildren, Version, MetasysObjectTypeEnum.Space);
        }

        // GetTypes ---------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public IEnumerable<MetasysObjectType> GetTypes()
        {
            return GetTypesAsync().GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysObjectType>> GetTypesAsync()
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
        public IEnumerable<MetasysObject> GetServedByEquipment(Guid equipmentId)
        {
            return GetServedByEquipmentAsync(equipmentId).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysObject>> GetServedByEquipmentAsync(Guid equipmentId)
        {
            if (Version < ApiVersion.v3) { throw new MetasysUnsupportedApiVersion(Version.ToString()); }

            var response = await GetAllAvailablePagesAsync("equipment", null, equipmentId.ToString(), "spaces").ConfigureAwait(false);
            return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Space);
        }

        // GetServedByNetworkDevice ------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public IEnumerable<MetasysObject> GetServedByNetworkDevice(Guid networkDeviceId)
        {
            return GetServedByNetworkDeviceAsync(networkDeviceId).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysObject>> GetServedByNetworkDeviceAsync(Guid networkDeviceId)
        {
            if (Version < ApiVersion.v3) { throw new MetasysUnsupportedApiVersion(Version.ToString()); }

            var response = await GetAllAvailablePagesAsync("networkDevices", null, networkDeviceId.ToString(), "spaces").ConfigureAwait(false);
            return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Space);
        }
    }
}
