using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    public class LegacyData
    {
        /// <summary>
        /// The fully Qualified Item Reference
        /// </summary>
        public string FullyQualifiedItemReference { get; set; }
        /// <summary>
        /// Item Name
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Class Level URL
        /// </summary>
        /// <remarks> This is available only in Metasys API v2 and v1. </remarks>
        public string ClassLevelUrl { get; set; }
        /// <summary>
        /// Class Level
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string ClassLevel { get; set; }
        /// <summary>
        /// Origin Application URL
        /// </summary>
        /// <remarks> This is available only in Metasys API v2 and v1. </remarks>
        public string OriginApplicationUrl { get; set; }
        /// <summary>
        /// Origin Application
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string OriginApplication { get; set; }
        /// <summary>
        /// Description URL
        /// </summary>
        /// <remarks> This is available only in Metasys API v2 and v1. </remarks>
        public string DescriptionUrl { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string Description { get; set; }
    }
}
