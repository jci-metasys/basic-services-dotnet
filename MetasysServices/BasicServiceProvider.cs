using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Net.Http;
using System.Globalization;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Base abstract class to be extended on specific provider implementation.
    /// </summary>
    public abstract class BasicServiceProvider
    {
        /// <summary>The http client.</summary>
        protected IFlurlClient Client;

        /// <inheritdoc/>
        public ApiVersion Version { get; set; }

        /// <summary>
        /// The log initiliazer.
        /// </summary>
        protected LogInitializer Log;

        private bool logClientErrors;
        /// <summary>
        /// Set this flag to false to disable logging of client errors.
        /// </summary>
        public bool LogClientErrors
        {
            get
            {
                return logClientErrors;
            }
            set
            {
                logClientErrors = value;
                if (logClientErrors)
                {
                    // Init logger only when the flag is enabled
                    Log = new LogInitializer(typeof(BasicServiceProvider));
                }
            }
        }        

       
        /// <summary>
        /// Empty constructor.
        /// </summary>
        /// <param name="logErrors">Set this flag to false to disable logging of client errors.</param>
        /// <remarks> Assume Client is initialized by extended class.</remarks>
        public BasicServiceProvider(bool logErrors = true)
        {
            LogClientErrors = logErrors;         
        }

        /// <summary>
        /// Constructor for dedicated services with Flurl client initialization already performed.
        /// </summary>
        /// <param name="client">The Flurl client.</param>
        /// <param name="version">The server's Api version.</param>
        /// <param name="logErrors">Set this flag to false to disable logging of client errors.</param>
        public BasicServiceProvider(IFlurlClient client, ApiVersion version, bool logErrors = true)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client),
                                              "FlurlClient can not be null.");            
            Version = version;                     
            LogClientErrors = logErrors;          
        }

        /// <summary>
        /// Return Metasys Object representation from a generic JSON object tree.
        /// </summary>
        /// <returns></returns>
        protected List<MetasysObject> toMetasysObject(IEnumerable<TreeObject> objects, MetasysObjectTypeEnum? objectType=null)
        {
            if (objects == null)
            {
                // Exit condition for recursion
                return null;
            }
            List<MetasysObject> metasysObjects = new List<MetasysObject>();
            foreach (var o in objects)
            {
                metasysObjects.Add(new MetasysObject(o.Item, Version, toMetasysObject(o.Children), type:objectType));
            }
            return metasysObjects;
        }

        /// <summary>
        /// Return Metasys Object representation from a generic JSON object.
        /// </summary>
        /// <returns></returns>
        protected MetasysObject toMetasysObject(JToken item, MetasysObjectTypeEnum? objectType = null)
        {
            return new MetasysObject(item, Version, null, type:objectType);
        }


        /// <summary>
        /// Return Metasys Object representation from a generic JSON object List.
        /// </summary>
        /// <returns></returns>
        protected List<MetasysObject> toMetasysObject(List<JToken> items, MetasysObjectTypeEnum? type = null)
        {
            List<MetasysObject> objects = new List<MetasysObject>();
            foreach (var i in items)
            {
                objects.Add(toMetasysObject(i, objectType:type));
            }
            return objects;
        }

        /// <summary>
        /// Gets all child objects given a parent Guid asynchronously by requesting each available page.
        /// Level indicates how deep to retrieve objects.
        /// </summary>
        /// <remarks>
        /// A level of 1 only retrieves immediate children of the parent object.
        /// </remarks>
        /// <param name="id">The id of the object.</param>
        /// <param name="parameters">Query string parameters in Key/Value format.</param>    
        /// <param name="levels">The number of levels to retrieve children.</param>         
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        protected async Task<List<TreeObject>> GetObjectChildrenAsync(Guid id, Dictionary<string, string> parameters = null, int levels = 1)
        {
            if (levels < 1)
            {
                return null;
            }
            List<TreeObject> objects = new List<TreeObject>() { }; // Contains the couple of parent/children JToken
            bool hasNext = true;
            int page = 1;
            if (parameters == null)
            {
                // Init dictionary to add page parameter when not already initialized in input parameters.
                parameters = new Dictionary<string, string>();
            }
            while (hasNext)
            {
                hasNext = false;
                parameters["page"] = page.ToString();
                var response = await GetPagedResultsAsync<JToken>("objects", parameters, id, "objects").ConfigureAwait(false);
                foreach (var item in response.Items)
                {
                    List<TreeObject> children = null;
                    if (levels - 1 > 0)
                    {
                        if (item["id"] == null)
                        {
                            throw new MetasysObjectException(response.ToString(), null);
                        }
                        var objId = ParseObjectIdentifier(item["id"]);
                        children = await GetObjectChildrenAsync(objId, null, levels - 1).ConfigureAwait(false);
                    }
                    objects.Add(new TreeObject { Item = item, Children = children });
                }
                if (response.CurrentPage < response.PageCount)
                {
                    hasNext = true;
                    page++;
                }
            }
            return objects;
        }

        /// <summary>
        /// Gets a resource given the full url asynchronously.
        /// </summary>
        /// <param name="url"></param>
        /// <exception cref="MetasysHttpException"></exception>
        protected async Task<JToken> GetWithFullUrl(string url)
        {
            string requestUrl = url.Replace(Client.BaseUrl, "");
            try
            {
                var item = await Client.Request(requestUrl)
                    .GetJsonAsync<JToken>()
                    .ConfigureAwait(false);
                return item;
            }
            catch (FlurlHttpException e)
            {
                ThrowHttpException(e);
            }
            return null;
        }

        /// <summary>
        /// Parses a JToken and creates a Guid.
        /// </summary>
        /// <param name="token"></param>
        /// <exception cref="MetasysGuidException"></exception>
        /// <returns>A Guid representation of the JToken.</returns>
        protected Guid ParseObjectIdentifier(JToken token)
        {
            string str = null;
            try
            {
                str = token.Value<string>();
                var id = new Guid(str);
                return id;
            }
            catch (Exception e) when (e is System.ArgumentNullException ||
                e is System.ArgumentException || e is System.FormatException)
            {
                throw new MetasysGuidException(str, e);
            }
        }

        /// <summary>
        /// Generic request for the given resource asynchronously.
        /// </summary>
        /// <param name="resource">The main resource to read.</param>
        /// <param name="parameters">Query string parameters in Key/Value format.</param>
        /// <param name="pathSegments">Path segments to be used in combination with the main resource.</param>
        /// <returns></returns>
        /// <exception cref="MetasysHttpParsingException"></exception>
        /// <exception cref="MetasysHttpTimeoutException"></exception>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        protected async Task<JToken> GetRequestAsync(string resource, Dictionary<string, string> parameters = null, params object[] pathSegments)
        {

            JToken response = null;
            // Create URL with base resource
            Url url = new Url(resource);
            // Concatenate segments with base resource url 
            url.AppendPathSegments(pathSegments);
            // Set query parameters according to the input dictionary
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    url.SetQueryParam(p.Key, p.Value);
                }
            }

            try
            {
                response = await Client.Request(url)
                .GetJsonAsync<JToken>()
                .ConfigureAwait(false);
            }
            catch (FlurlHttpException e)
            {
                ThrowHttpException(e);
            }
            return response;
        }

        /// <summary>
        /// Get typed items for the given resource asynchronously. 
        /// </summary>
        /// <remarks>Optionally accepts query string parameters and additional path segments.</remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">The main resource to read.</param>
        /// <param name="parameters">Query string parameters in Key/Value format.</param>
        /// <param name="pathSegments">Path segments to be used in combination with the main resource.</param>
        /// <returns></returns>
        protected async Task<PagedResult<T>> GetPagedResultsAsync<T>(string resource, Dictionary<string, string> parameters, params object[] pathSegments)
        {
            var response = await GetRequestAsync(resource, parameters, pathSegments).ConfigureAwait(false);
            return new PagedResult<T>(response);
        }


        /// <summary>
        /// Gets all items for the given resource asynchronously by requesting each available page.      
        /// </summary>
        /// <param name="resource">The main resource to read.</param>
        /// <param name="parameters">Query string parameters in Key Value format.</param>
        /// <param name="pathSegments">Path segments to be used in combination with the main resource.</param>
        /// <returns></returns>
        /// <exception cref="MetasysHttpParsingException"></exception>
        /// <exception cref="MetasysHttpTimeoutException"></exception>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        protected async Task<List<JToken>> GetAllAvailablePagesAsync(string resource, Dictionary<string, string> parameters = null, params string[] pathSegments)
        {
            bool hasNext = true;
            List<JToken> aggregatedResponse = new List<JToken>();
            int page = 1;
            // Init our dictionary for paging
            if (parameters == null)
            {
                parameters = new Dictionary<string, string>();
            }
            if (!parameters.ContainsKey("page"))
            {
                parameters.Add("page", page.ToString());
            }
            while (hasNext)
            {
                hasNext = false;
                // Just overwrite page parameter                 
                parameters["page"] = page.ToString();
                var response = await GetPagedResultsAsync<JToken>(resource, parameters, pathSegments).ConfigureAwait(false);
                var total = response.Total;
                if (total > 0)
                {
                    aggregatedResponse.AddRange(response.Items);
                    if (response.CurrentPage < response.PageCount)
                    {
                        hasNext = true;
                        page++;
                    }
                }
            }
            return aggregatedResponse;
        }

        /// <summary>
        /// Throws a Metasys Exception from a Flurl.Http exception.
        /// </summary>
        /// <exception cref="MetasysHttpParsingException"></exception>
        /// <exception cref="MetasysHttpTimeoutException"></exception>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpNotFoundException"></exception>
        protected void ThrowHttpException(FlurlHttpException e)
        {
            if (LogClientErrors)
            {
                // Perform logging only when enabled by BasicServiceProvider Settings.
                Log.Logger.Error(e.Message);
            }
            if (e.Call.Response != null && e.Call.Response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new MetasysHttpNotFoundException(e);
            }
            if (e.GetType() == typeof(FlurlParsingException))
            {
                throw new MetasysHttpParsingException((FlurlParsingException)e);
            }
            else if (e.GetType() == typeof(FlurlHttpTimeoutException))
            {
                throw new MetasysHttpTimeoutException((FlurlHttpTimeoutException)e);
            }
            else
            {
                throw new MetasysHttpException(e);
            }
        }

        /// <summary>
        /// Convert a generic object to a dictionary
        /// </summary>        
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return dictionary;
        }       

        /// <summary>
        /// Perform multiple requests to the Server with a single HTTP call asynchronously.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="ids"></param>
        /// <param name="resources"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        protected async Task<JToken> PostBatchRequestAsync(string endpoint, IEnumerable<Guid> ids, IEnumerable<string> resources, params string[] paths)
        {         
            // Create URL with base resource
            Url url = new Url(endpoint);
            // Concatenate batch segment to use batch request and prepare the list of requests
            url.AppendPathSegments("batch");
            var objectsRequests = new List<ObjectRequest>();          
            // Concatenate batch segment to use batch request and prepare the list of requests  
            foreach (var id in ids)
            {
                foreach (var r in resources)
                {
                    Url relativeUrl = new Url(id.ToString());
                    relativeUrl.AppendPathSegments(paths); // e.g. "00000000-0000-0000-0000-000000000001/attributes"
                    relativeUrl.AppendPathSegment(r); // e.g. "00000000-0000-0000-0000-000000000001/attributes/presentValue"                    
                    // Use the object id concatenated to the resource to uniquely identify each request
                    objectsRequests.Add(new ObjectRequest { Id = id.ToString()+'_'+r, RelativeUrl = relativeUrl });
                }
            }
            JToken responseToken = null;
            try
            {
                // Post the list of requests and return responses as JToken
                var response= await Client.Request(url)
                                            .PostJsonAsync(new BatchRequest { Requests=objectsRequests})                
                                            .ConfigureAwait(false);
                responseToken= JToken.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
            catch (FlurlHttpException e)
            {
                ThrowHttpException(e);
            }
            return responseToken;
        }

    }
}
