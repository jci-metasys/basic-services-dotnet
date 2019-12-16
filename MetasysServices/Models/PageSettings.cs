using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Settings for server side paging
    /// </summary>
    public class PageSettings
    {
        /// <summary>
        /// How many pages are skipped.
        /// </summary>
        public int Skip { get; set; }
        /// <summary>
        /// How many pages are returned.
        /// </summary>
        public int Take { get; set; }
        /// <summary>
        /// Size for page. Default is 100.
        /// </summary>
        public int PageSize { get; set; }        
    }
}
