using Flurl;
using Flurl.Http;
using JohnsonControls.Metasys.BasicServices.Enums;
using JohnsonControls.Metasys.BasicServices.Utils;
using log4net.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provide network device item for the endpoints of the Metasys Network Devices API.
    /// </summary>
    public sealed class NetworkDeviceServiceProvider : BasicServiceProvider, INetworkDeviceService
    {
        /// <summary>
        /// Initializes a new instance of <see cref="NetworkDeviceServiceProvider"/> with supplied data.
        /// </summary>
        /// <param name="client">The FlurlClient to get response from URL.</param>
        /// <param name="version">The server's Api version.</param>
        /// <param name="logClientErrors">Set this flag to false to disable logging of client errors.</param>
        public NetworkDeviceServiceProvider(IFlurlClient client, ApiVersion version, bool logClientErrors = true) : base(client, version, logClientErrors)
        {
        }

        // FindById -------------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public MetasysObject FindById(Guid networkDeviceId)
        {
            return FindByIdAsync(networkDeviceId).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<MetasysObject> FindByIdAsync(Guid networkDeviceId)
        {
            CheckVersion(Version);
            var response = await GetRequestAsync("networkDevices", null, networkDeviceId).ConfigureAwait(false);
            return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Equipment);
        }

        // Get ------------------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public IEnumerable<MetasysObject> Get(string type = null)
        {
            return GetAsync(type).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysObject>> GetAsync(NetworkDeviceClassificationEnum classificationEnum)
        {
            return await GetByClassificationAsync(classificationEnum.ToString());
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysObject>> GetAsync(string type = null)
        {
            CheckVersion(Version);
            // Note: the name of the parameter 'Type' changes according to the API version
            string typeParamName = Version > ApiVersion.v3 ? "objectType" : "type";
            var response = await this.GetAllAvailablePagesAsync("networkDevices", new Dictionary<string, string> { { typeParamName, type } }).ConfigureAwait(false);
            return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Object);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysObject>> GetByClassificationAsync(string classification = null)
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
        public async Task<IEnumerable<MetasysObject>> GetAsync(NetworkDeviceTypeEnum networkDevicetype)
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
        public async Task<IEnumerable<MetasysObjectType>> GetTypesAsync()
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
        public async Task<IEnumerable<MetasysObject>> GetChildrenAsync(Guid networkDeviceId)
        {
            CheckVersion(Version);
            var response = await GetAllAvailablePagesAsync("networkDevices", null, networkDeviceId.ToString(), "networkDevices").ConfigureAwait(false);
            return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Object);
        }

        // GetHostingAnEquipment ---------------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public IEnumerable<MetasysObject> GetHostingAnEquipment(Guid equipmentId)
        {
            return GetHostingAnEquipmentAsync(equipmentId).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysObject>> GetHostingAnEquipmentAsync(Guid equipmentId)
        {
            CheckVersion(Version);
            var response = await GetAllAvailablePagesAsync("equipment", null, equipmentId.ToString(), "networkDevices").ConfigureAwait(false);
            return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Object);
        }

        // GetServingASpace ---------------------------------------------------------------------------------------------------------------------------------------------
        /// <inheritdoc/>
        public IEnumerable<MetasysObject> GetServingASpace(Guid spaceId)
        {
            return GetServingASpaceAsync(spaceId).GetAwaiter().GetResult();
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MetasysObject>> GetServingASpaceAsync(Guid spaceId)
        {
            CheckVersion(Version);
            var response = await GetAllAvailablePagesAsync("spaces", null, spaceId.ToString(), "networkDevices").ConfigureAwait(false);
            return ToMetasysObject(response, Version, MetasysObjectTypeEnum.Object);
        }



        private async Task<IEnumerable<MetasysObjectType>> RetrieveNetworkDeviceTypesAsync()
        {
            List<MetasysObjectType> types = new List<MetasysObjectType>() { };
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
}
