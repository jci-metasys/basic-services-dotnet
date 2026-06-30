using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Web;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Generic Paged Result Object containing Items along with paging information.
/// </summary>
/// <typeparam name="T"></typeparam>
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

    /// <summary>
    /// Initialize an empty instance of PagedResult.
    /// </summary>
    public PagedResult()
    {
    }

    /// <summary>
    /// Creates a new PagedResult from a JsonNode response.
    /// </summary>
    /// <param name="response"></param>
    public PagedResult(JsonNode response)
    {
        try
        {
            if (response["item"] != null)
            {
                // Since API v3 response is wrapped in an item object
                response = response["item"];
            }
            if (response["result"] != null)
            {
                // Since API v3 response is wrapped in an result object
                response = response["result"];
            }
            if (response["total"] != null)
            {
                Total = (int)response["total"];
            }
            // Retrieve current page and page size from self url
            Uri selfUri = new((string)response["self"]);
            string page = HttpUtility.ParseQueryString(selfUri.Query).Get("page");
            string pageSize = HttpUtility.ParseQueryString(selfUri.Query).Get("pageSize");
            string? nextUrl = null;
            if (response["next"] != null)
            {
                nextUrl = (string)response["next"];
            }
            if (pageSize == null && nextUrl != null)
            {
                Uri nextUri = new(nextUrl);
                pageSize = HttpUtility.ParseQueryString(nextUri.Query).Get("pageSize");
            }
            if (page == null)
            {
                CurrentPage = 1;
            }
            else
            {
                //Revert this change when Audits response doesn't involve redundant entries
                CurrentPage = page.Contains(",") ? int.Parse(page.Split(',')[0]) : int.Parse(page);
            }
            if (pageSize != null)
            {
                //Revert this change when Audits response doesn't involve redundant entries
                PageSize = pageSize.Contains(",") ? int.Parse(pageSize.Split(',')[0]) : int.Parse(pageSize);
            }
            else
            {
                PageSize = 100; // Default value
            }
            PageCount = (int)Math.Ceiling((decimal)Total / PageSize);
            Items = response["items"].Deserialize<List<T>>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        catch (Exception e)
        {
            throw new MetasysObjectException(e);
        }
    }


    /// <summary>
    /// Return a pretty JSON string of the current object.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}
