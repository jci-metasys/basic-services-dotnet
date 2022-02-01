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

    }
}
