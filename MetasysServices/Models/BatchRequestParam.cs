using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Body class to pass list of parameters for Metasys server batch request.
    /// </summary>

    public class BatchRequestParam
    {
        /// <summary>
        /// Id to identify the object
        /// </summary>
        public Guid ObjectId { get; set; }

        /// <summary>
        /// String that could represent a text resource as, for instance, a text annotation
        /// </summary>
        public string Resource { get; set; }

    }
}
