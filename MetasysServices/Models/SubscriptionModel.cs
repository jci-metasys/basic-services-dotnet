using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provides Subscription Item
    /// </summary>

    public class Subscription
    {
        /// <summary>
        /// Relative URL of a subscription
        /// </summary>
        public string RelativeUrl { get; set; }

        /// <summary>
        /// Method of a subscription
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Parameters of a subscription
        /// </summary>
        public Dictionary<string, string> Params { get; set; }

        /// <summary>
        /// Body of a subscription
        /// </summary>
        public dynamic Body { get; set; }
    }
}
