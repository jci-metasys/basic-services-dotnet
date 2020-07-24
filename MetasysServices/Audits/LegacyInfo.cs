using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
   
    /// <summary>
    /// Legacy information for the audit.
    /// </summary>
    public class LegacyInfo
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
        /// Origin Application of the audit.
        /// </summary>
        /// <remarks>Available since Metasys API v3.</remarks>
        public string OriginApplication { get; set; }

        /// <summary>
        /// Description of the audit.
        /// </summary>
        /// <remarks>Available since Metasys API v3.</remarks>
        public string Description { get; set; }

        /// <summary>
        /// Returns a value indicating whether this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is LegacyInfo)
            {
                var o = (LegacyInfo)obj;
                // Compare each properties one by one for better performance
                return this.FullyQualifiedItemReference == o.FullyQualifiedItemReference
                    && this.ItemName == o.ItemName
                    && this.ClassLevel == o.ClassLevel
                    && this.OriginApplication == o.OriginApplication
                    && this.Description == o.Description;
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            // Calculate hash on each properties one by one
            code = (code * 7) + FullyQualifiedItemReference.GetHashCode();
            if (ItemName != null)
                code = (code * 7) + ItemName.GetHashCode();
            if (this.ClassLevel != null)
                code = (code * 7) + ClassLevel.GetHashCode();
            if (this.OriginApplication != null)
                code = (code * 7) + OriginApplication.GetHashCode();
            if (this.Description != null)
                code = (code * 7) + Description.GetHashCode();
            return code;
        }

    }
}