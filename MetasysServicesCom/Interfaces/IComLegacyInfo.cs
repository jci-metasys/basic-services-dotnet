using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM LegacyInfo is a specialized structure that holds information about Audit.
    /// </summary>
    [Guid("0f0544d3-d993-440b-952a-437c6a5dd5de")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComLegacyInfo
    {
        /// <summary>
        /// FQR of the object related to the audit.
        /// </summary>
         string FullyQualifiedItemReference { get; set; }
        /// <summary>
        /// Name of the item related to the audit.
        /// </summary>
         string ItemName { get; set; }
        /// <summary>
        /// Class Level information of the audit.
        /// </summary>
        /// <remarks>Available since Metasys API v3.</remarks>
         string ClassLevel { get; set; }
        /// <summary>
        /// Class Level information URL of the audit.
        /// </summary>
        /// <remarks>Available only up to Metasys API v2.</remarks>
         string ClassLevelUrl { get; set; }
        /// <summary>
        /// Origin Application of the audit.
        /// </summary>
        /// <remarks>Available since Metasys API v3.</remarks>
         string OriginApplication { get; set; }
        /// <summary>
        /// Origin Application URL of the audit.
        /// </summary>
        /// <remarks>Available up to Metasys API v2.</remarks>
         string OriginApplicationUrl { get; set; }
        /// <summary>
        /// Description of the audit.
        /// </summary>
        /// <remarks>Available since Metasys API v3.</remarks>
         string Description { get; set; }
        /// <summary>
        /// Description URL of the audit.
        /// </summary>
        /// <remarks>Available up to Metasys API v2.</remarks>
         string DescriptionUrl { get; set; }
    }
}
