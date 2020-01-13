using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Base abstract class to be extended on specific provider implementation.
    /// </summary>
    public abstract class BasicServiceProvider
    {
        /// <summary>The http client.</summary>
        protected FlurlClient Client;

        public BasicServiceProvider()
        {
        }

        public BasicServiceProvider(FlurlClient client)
        {
            Client = client;
        }

        /// <summary>
        /// Return Metasys Object representation from a generic JSON object.
        /// </summary>
        /// <returns></returns>
        protected List<MetasysObject> toMetasysObject(IEnumerable<TreeObject> objects)
        {
            if (objects == null)
            {
                // Exit condition for recursion
                return null;
            }
            List<MetasysObject> metasysObjects= new List<MetasysObject>();
            foreach (var o in objects)
            {
                metasysObjects.Add(new MetasysObject(o.Item,toMetasysObject(o.Children)));
            }
            return metasysObjects;
        }

        /// <summary>
        /// Gets all child objects given a parent Guid asynchronously by requesting each available page.
        /// Level indicates how deep to retrieve objects.
        /// </summary>
        /// <remarks>
        /// A level of 1 only retrieves immediate children of the parent object.
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="levels">The depth of the children to retrieve.</param>    
        /// <param name="parentResource">The parent resource to retrieve children.</param>    
        /// <param name="childResource">The children resource to get related elements</param>    
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        protected  async Task<List<TreeObject>> GetObjectsAsync(Guid id,  string parentResource, string childResource, int levels = 1)
        {
            if (levels < 1)
            {
                return null;
            }

            List<TreeObject> objects = new List<TreeObject>() { }; // Contains the couple of parent/children JToken
            bool hasNext = true;
            int page = 1;

            while (hasNext)
            {
                hasNext = false;
                var response = await GetObjectsRequestAsync(id, parentResource, childResource, page).ConfigureAwait(false);
                if (response == null || response.Type == JTokenType.Null || !response.HasValues)

                {

                    return null;

                }
                try
                {
                    var total = response["total"].Value<int>();
                    if (total > 0)
                    {
                        var list = response["items"] as JArray;

                        foreach (var item in list)
                        {
                            try
                            {
                                List<TreeObject> children = null;
                                if (levels - 1 > 0)
                                {
                                    var objId = ParseObjectIdentifier(item["id"]);
                                    if (objId != null)
                                    {
                                        try
                                        {
                                            children = await GetObjectsAsync(objId, parentResource,childResource, levels - 1).ConfigureAwait(false);
                                        }
                                        catch (Exception e) when (e is MetasysObjectException ||
                                            e is MetasysHttpParsingException)
                                        {
                                            throw new MetasysObjectException(e);
                                        }
                                    }
                                }                        
                                objects.Add(new TreeObject { Item=item, Children=children});
                            }
                            catch (MetasysGuidException)
                            {
                                // Error with this item's id, skip and do not create object
                            }
                            catch (MetasysObjectException e)
                            {
                                // There was an issue creating the object
                                throw e;
                            }
                        }
                        if (response["next"] != null && response["next"].Type != JTokenType.Null)
                        {
                            hasNext = true;
                            page++;
                        }
                    }                 
                }
                catch (System.NullReferenceException e)
                {
                    throw new MetasysHttpParsingException(response.ToString(), e);
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
        /// Gets all child objects given a parent Guid asynchronously with the given page number.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="parentResource">The parent resource to retrieve children.</param>    
        /// <param name="childResource">The children resource to get related elements.</param>    
        /// <exception cref="MetasysHttpException"></exception>
        protected async Task<JToken> GetObjectsRequestAsync(Guid id, string parentResource, string childResource, int page)
        {
            Url url = new Url(parentResource)
                .AppendPathSegments(id, childResource)
                .SetQueryParam("page", page);
            JToken response = null;
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
        /// Generic paged request for the given resource and optional type
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="type"></param>
        /// <param name="page"></param>
        /// <exception cref="MetasysHttpException"></exception>
        protected async Task<JToken> PagedRequestAsync(string resource, string type = null, int page = 1, int pageSize = 100)
        {
            Url url = new Url(resource);
            url.SetQueryParam("page", page);
            url.SetQueryParam("pageSize", page);
            if (type != null)
            {
                url.SetQueryParam("type", type);
            }

            try
            {
                var response = await Client.Request(url)
                    .GetJsonAsync<JToken>()
                    .ConfigureAwait(false);

                return response;
            }
            catch (FlurlHttpException e)
            {
                ThrowHttpException(e);
            }

            return null;
        }

        /// <summary>
        /// Gets all items for the given resource asynchronously by requesting each available page.
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="type">Optional type number as a string</param>
        /// <param name="skip">Optional how many page we skip. 0 by default.</param>
        /// <param name="take">Optional how many page we take. 0 for all.</param>
        /// <exception cref="MetasysHttpException"></exception>
        /// <exception cref="MetasysHttpParsingException"></exception>
        protected async Task<IEnumerable<MetasysObject>> ProcessPagedRequestAsync(string resource, string type = null, PageSettings settings = null)
        {
            List<MetasysObject> items = new List<MetasysObject>() { };
            bool hasNext = true;
            settings = settings ?? new PageSettings { Skip = 0, Take = 0, PageSize = 100 }; // Set default values for paging
            int page = settings.Skip + 1;
            int i = 0;
            while (hasNext && (settings.Take == 0 || i < settings.Take))
            {
                hasNext = false;
                var response = await PagedRequestAsync(resource, type, page, settings.PageSize).ConfigureAwait(false);
                try
                {
                    var total = response["total"].Value<int>();
                    if (total > 0)
                    {
                        var list = response["items"] as JArray;
                        foreach (var item in list)
                        {
                            try
                            {
                                MetasysObject space = new MetasysObject(item);
                                items.Add(space);
                            }
                            catch (MetasysObjectException e)
                            {
                                throw e;
                            }
                        }

                        if (!(response["next"] == null || response["next"].Type == JTokenType.Null))
                        {
                            hasNext = true;
                            page++;
                            i++;
                        }
                    }
                }
                catch (System.NullReferenceException e)
                {
                    throw new MetasysHttpParsingException(response.ToString(), e);
                }
            }
            return items;
        }

        /// <summary>
        /// Throws a Metasys Exception from a Flurl.Http exception.
        /// </summary>
        /// <exception cref="MetasysHttpParsingException"></exception>
        /// <exception cref="MetasysHttpTimeoutException"></exception>
        /// <exception cref="MetasysHttpException"></exception>
        protected void ThrowHttpException(Flurl.Http.FlurlHttpException e)
        {
            if (e.Call.Response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new MetasysHttpNotFoundException(e);
            }
            if (e.GetType() == typeof(Flurl.Http.FlurlParsingException))
            {
                throw new MetasysHttpParsingException((Flurl.Http.FlurlParsingException)e);
            }
            else if (e.GetType() == typeof(Flurl.Http.FlurlHttpTimeoutException))
            {
                throw new MetasysHttpTimeoutException((Flurl.Http.FlurlHttpTimeoutException)e);
            }
            else
            {
                throw new MetasysHttpException(e);
            }
        }

    }
}
