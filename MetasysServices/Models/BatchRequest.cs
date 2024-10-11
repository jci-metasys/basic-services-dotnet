using System;
using System.Collections.Generic;

namespace JohnsonControls.Metasys.BasicServices
{

    /// <summary>
    /// Body class for a Metasys server batch request.
    /// </summary>
    public class BatchRequest
    {
        /// <summary>
        /// Specify the type of the call, e.g. GET, POST etc...
        /// </summary>
        public string Method { get; set; }

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

        /// <summary>
        /// Body to specify extra values related to the request, e.g.""text": "Annotation text""
        /// </summary>
        public Object Body { get; set; }
    }

}
