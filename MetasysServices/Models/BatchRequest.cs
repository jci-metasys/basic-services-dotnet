using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{

    /// <summary>
    /// Body class for a Metasys server batch request.
    /// </summary>
    public class BatchRequest
    {
        /// <summary>
        /// List of requests.
        /// </summary>
        public List<ObjectRequest> Requests { get; set; }
    }

    /// <summary>
    /// Request related to an object
    /// </summary>
    public class ObjectRequest
    {
        /// <summary>
        /// Choosen ID to indentify the request/response.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Relative Url to read from the endpoint, e.g."00000000-0000-0000-0000-000000000001/attributes/presentValue"
        /// </summary>
        public string RelativeUrl { get; set; }
    }

}
