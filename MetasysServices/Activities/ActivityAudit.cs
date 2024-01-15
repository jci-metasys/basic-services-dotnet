using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary> Provides ActivityAudit Item </summary>
    /// <remarks> This is available since Metasys API v5. </remarks>
    public class ActivityAudit
    {
        /// <summary> Fully qualified enumeration for Action Type. </summary>
        public string ActionType { get; set; }

        /// <summary> Fully qualified enumeration for Status. </summary>
        public string Status { get; set; }

        /// <summary> Data value prior to the Audit. </summary>
        public dynamic PreData { get; set; }

        /// <summary> Data value after the Audit. </summary>
        public dynamic PostData { get; set; }

        /// <summary> Parameters for the Audit. </summary>
        public dynamic Parameters { get; set; }

        /// <summary> The error that may have occurred during an audit. </summary>
        public string ErrorString { get; set; }

        /// <summary> The userName of the user that initiated the audit. </summary>
        public string User { get; set; }

        /// <summary> The user who created this audit. </summary>
        public dynamic Signature { get; set; }

        /// <summary> Fully qualified enumeration for Class Level. </summary>
        public string ClassLevel { get; set; }

        /// <summary> Fully qualified enumeration for Origin Application. </summary>
        public string OriginApplication { get; set; }

        /// <summary> Fully qualified enumeration for Audit Description. </summary>
        public string Description { get; set; }

        /// <summary> Link to annotations. </summary>
        public string AnnotationsUrl { get; set; }

        /// <summary> Audit Annotation Count </summary>
        public int AnnotationCount { get; set; }


        /// <summary> Returns a value indicating whether this instance has values equal to a specified object. </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is ActivityAudit activityAudit)
            {
                var o = activityAudit;
                // Compare each properties one by one for better performance
                return this.ActionType == o.ActionType && this.Status == o.Status && this.PreData == o.PreData
                    && this.PostData == o.PostData && this.Parameters == o.Parameters
                    && this.ErrorString == o.ErrorString && this.User == o.User && this.Signature == o.Signature
                    && this.ClassLevel == o.ClassLevel && this.OriginApplication == o.OriginApplication
                    && this.Description == o.Description && this.AnnotationsUrl == o.AnnotationsUrl
                    && this.AnnotationCount == o.AnnotationCount;
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            // Calculate hash on each properties one by one
            if (ActionType != null)
                code = (code * 7) + ActionType.GetHashCode();
            if (this.Status != null)
                code = (code * 7) + Status.GetHashCode();
            if (this.PreData != null)
                code = (code * 7) + PreData.GetHashCode();
            if (this.PostData != null)
                code = (code * 7) + PostData.GetHashCode();
            if (this.Parameters != null)
                code = (code * 7) + Parameters.GetHashCode();
            if (this.ErrorString != null)
                code = (code * 7) + ErrorString.GetHashCode();
            if (this.User != null)
                code = (code * 7) + User.GetHashCode();
            if (this.ClassLevel != null)
                code = (code * 7) + ClassLevel.GetHashCode();
            if (this.Signature != null)
                code = (code * 7) + Signature.GetHashCode();
            if (this.OriginApplication != null)
                code = (code * 7) + OriginApplication.GetHashCode();
            if (this.Description != null)
                code = (code * 7) + Description.GetHashCode();
            if (this.AnnotationsUrl != null)
                code = (code * 7) + AnnotationsUrl.GetHashCode();
                code = (code * 7) + AnnotationCount.GetHashCode();
            return code;
        }

        /// <summary> Return a pretty JSON string of the current object. </summary>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
