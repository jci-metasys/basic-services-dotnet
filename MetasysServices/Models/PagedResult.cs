using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace JohnsonControls.Metasys.BasicServices
{
    public class PagedResult<T>
    {
        /// <summary>
        /// The total number of elements. 
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// The items of the current page.
        /// </summary>
        public List<T> Items { get; set; }
        /// <summary>
        /// The actual page.
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Total number of pages.
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// Maximum number of elements on a page.
        /// </summary>
        public int PageSize { get; set; }

        public PagedResult()
        {

        }

        /// <summary>
        /// Creates a new PagedResult from a JToken response.
        /// </summary>
        /// <param name="response"></param>
        public PagedResult(JToken response)
        {
            try
            {
                Total = response["total"].Value<int>();
                // Retrieve current page and page size from self url
                Uri selfUri = new Uri(response["self"].Value<string>());
                string page = HttpUtility.ParseQueryString(selfUri.Query).Get("page");
                string pageSize = HttpUtility.ParseQueryString(selfUri.Query).Get("pageSize");
                // Try to get from next url if it is not specified in the self url
                if (PageSize == null)
                {
                    Uri nextUri = new Uri(response["next"].Value<string>());
                    pageSize = HttpUtility.ParseQueryString(nextUri.Query).Get("pageSize");
                }
                if (page == null)
                {
                    CurrentPage = 1;
                }
                else
                {
                    CurrentPage = Int32.Parse(page);
                }
                if (pageSize != null)
                {
                    PageSize = Int32.Parse(pageSize);
                }
                else
                {
                    PageSize = 100; // Default value
                }
                PageCount =(int) Math.Ceiling((decimal)Total / PageSize);                       
                Items = JsonConvert.DeserializeObject<List<T>>(response["items"].ToString());
            }
            catch (Exception e)
            {
                throw new MetasysObjectException(e);
            }
        }
    }
}
