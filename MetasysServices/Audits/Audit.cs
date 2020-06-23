using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provides audit Item
    /// </summary>
    public class Audit 
    {

        /// <summary>
        /// The identifier of the audit(GUID).
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// The dateTime representing the creation time when this audit message was created.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string CreationTime { get; set; }

        /// <summary>
        /// The action performed that initiated the audit.
        /// https://{hostname}/api/v2/enumSets/577/members for possible values.
        /// </summary>
        /// <remarks> This is available only on Metasys API v2 and v1. </remarks>
        public string ActionTypeUrl { get; set; }

        /// <summary>
        /// Fully qualified enumeration for Action Type.
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string ActionType { get; set; }

        /// <summary>
        /// Indicates if the audit has been discarded.
        /// </summary>
        public bool Discarded { get; set; }

        /// <summary>
        /// Enumeration representing status.
        /// https://{hostname}/api/v2/enumSets/516/members for possible values
        /// </summary>
        public string StatusUrl { get; set; }

        /// <summary>
        /// Fully qualified enumeration for Status.
        /// </summary>
        /// <remarks> This is available since Metasys API v3. </remarks>
        public string Status { get; set; }

        /// <summary>
        /// Data value prior to the Audit.
        /// </summary>
        public AuditData PreData { get; set; }

        /// <summary>
        /// Data value after the Audit.
        /// </summary>
        public AuditData PostData { get; set; }

        /// <summary>
        /// Parameters for the Audit.
        /// </summary>
        public AuditData Parameters { get; set; }

        /// <summary>
        /// The error that may have occurred during an audit.
        /// </summary>
        public string ErrorString { get; set; }

        /// <summary>
        /// The userName of the user that initiated the audit.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// The user who created this audit.
        /// </summary>
        public AuditSignature Signature { get; set; }

        /// <summary>
        /// A link to the object on which the activity was generated.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string ObjectUrl { get; set; }

        /// <summary>
        /// Link to annotations.
        /// </summary>
        public string AnnotationsUrl { get; set; }

        /// <summary>
        /// Metasys specific data.
        /// </summary>
        public LegacyInfo Legacy { get; set; }

        /// <summary>
        /// URI that points back to this resource
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// Returns a value indicating whether this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Audit)
            {
                var o = (Audit)obj;
                // Compare each properties one by one for better performance
                return this.Id == o.Id && this.CreationTime == o.CreationTime && this.ActionTypeUrl == o.ActionTypeUrl
                                  && this.Discarded == o.Discarded && this.StatusUrl == o.StatusUrl
                                  && this.ErrorString == o.ErrorString && this.User == o.User
                                  && this.ObjectUrl == o.ObjectUrl && this.AnnotationsUrl == o.AnnotationsUrl
                                  && this.Self == o.Self;
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            // Calculate hash on each properties one by one
            code = (code * 7) + Id.GetHashCode();
            if (CreationTime != null)
                code = (code * 7) + CreationTime.GetHashCode();
            if (this.ActionTypeUrl != null)
                code = (code * 7) + ActionTypeUrl.GetHashCode();
            code = (code * 7) + Discarded.GetHashCode();
            if (this.StatusUrl != null)
                code = (code * 7) + StatusUrl.GetHashCode();
            if (this.ErrorString != null)
                code = (code * 7) + ErrorString.GetHashCode();
            if (this.User != null)
                code = (code * 7) + User.GetHashCode();
            if (this.ObjectUrl != null)
                code = (code * 7) + ObjectUrl.GetHashCode();
            if (this.AnnotationsUrl != null)
                code = (code * 7) + AnnotationsUrl.GetHashCode();
            if (this.Self != null)
                code = (code * 7) + Self.GetHashCode();
            return code;
        }

        /// <summary>
        /// Return a pretty JSON string of the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}