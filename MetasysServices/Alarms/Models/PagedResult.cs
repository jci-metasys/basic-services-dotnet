using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Paged response of Type T
    /// </summary>
    public class PagedResult<T>
    {
        /// <summary>
        /// Total alarms count
        /// </summary>
        [JsonProperty(Order = 1)]
        public int Total { get; set; }

        /// <summary>
        /// Next page link
        /// </summary>
        [JsonProperty(Order = 2)]
        public string Next { get; set; }

        /// <summary>
        /// previous page link
        /// </summary>
        [JsonProperty(Order = 3)]
        public string Previous { get; set; }

        /// <summary>
        /// Pages result of alarm items
        /// </summary>
        [JsonProperty(Order = 4)]
        public T Items { get; set; }

        /// <summary>
        /// Route information for self
        /// </summary>
        [JsonProperty(Order = 5)]
        public string Self { get; set; }


        /// <summary>
        /// Constructor - Initialize default values
        /// </summary>
        public PagedResult()
        {
            Next = null;
            Previous = null;
            Self = null;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="pagedResult"></param>
        public PagedResult(PagedResult<T> pagedResult)
        {
            Total = pagedResult.Total;
            Next = pagedResult.Next;
            Previous = pagedResult.Previous;
            Items = pagedResult.Items;
        }
    }
}
