using Newtonsoft.Json;


namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Annotation for an audit.
    /// </summary>
    public class AuditAnnotation : MetasysAnnotation
    {
        /// <summary>
        /// URL of the audit related to the annotation.
        /// </summary>
        public string AuditUrl { get; set; }
        /// <summary>
        /// Signature of the annotation.
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// Returns a value indicating whether this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is AuditAnnotation)
            {
                var o = (AuditAnnotation)obj;
                // Compare each properties one by one for better performance
                return this.Text == o.Text && this.User == o.User && this.Action == o.Action && this.AuditUrl == o.AuditUrl && this.CreationTime == o.CreationTime && this.Signature == o.Signature;
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            // Calculate hash on each properties one by one
            if (Text != null)
                code = (code * 7) + Text.GetHashCode();
            if (User != null)
                code = (code * 7) + User.GetHashCode();
            if (this.Action != null)
                code = (code * 7) + this.Action.GetHashCode();
            if (this.AuditUrl != null)
                code = (code * 7) + AuditUrl.GetHashCode();
            if (this.CreationTime != null)
                code = (code * 7) + CreationTime.GetHashCode();
            if (this.Signature != null)
                code = (code * 7) + Signature.GetHashCode();
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
