using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Basic filter for a general API request.
    /// </summary>
    public class BasicFilter
    {
        /// <summary>
        /// The page number of items to return Default: 1.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// The maximum number of items to return in the response. 
        /// Valid range is 1-10,000. Default: 1000
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// The criteria to use when sorting results
        /// Accepted Values: itemReference, priority, creationTime
        /// </summary>
        public string Sort { get; set; }
    }
}
