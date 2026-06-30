using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM LegacyInfo is a specialized structure that holds information about Audit.
    /// </summary>
    [Guid("8fb23ac6-4799-4467-9a66-764fb7e4de9e")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComLegacyInfo : IComLegacyInfo
    {
        /// <summary>
        /// FQR of the object related to the audit.
        /// </summary>
        public string FullyQualifiedItemReference { get; set; }
        /// <summary>
        /// Name of the item related to the audit.
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Class Level information of the audit.
        /// </summary>
        /// <remarks>Available since Metasys API v3.</remarks>
        public string ClassLevel { get; set; }
        /// <summary>
        /// Class Level information URL of the audit.
        /// </summary>
        /// <remarks>Available only up to Metasys API v2.</remarks>
        public string ClassLevelUrl { get; set; }
        /// <summary>
        /// Origin Application of the audit.
        /// </summary>
        /// <remarks>Available since Metasys API v3.</remarks>
        public string OriginApplication { get; set; }
        /// <summary>
        /// Origin Application URL of the audit.
        /// </summary>
        /// <remarks>Available up to Metasys API v2.</remarks>
        public string OriginApplicationUrl { get; set; }
        /// <summary>
        /// Description of the audit.
        /// </summary>
        /// <remarks>Available since Metasys API v3.</remarks>
        public string Description { get; set; }
        /// <summary>
        /// Description URL of the audit.
        /// </summary>
        /// <remarks>Available up to Metasys API v2.</remarks>
        public string DescriptionUrl { get; set; }
    }
}
