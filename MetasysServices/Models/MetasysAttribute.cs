﻿using Newtonsoft.Json;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// DTO for the attribute of an Object.
    /// </summary>
    public class MetasysAttribute
    {
        /// <summary>
        /// The integer ID of the attribute.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The description of the attribute.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Returns a value indicating whither this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is MetasysAttribute)
            {
                var o = (MetasysAttribute)obj;
                // Compare each properties one by one for better performance
                return this.Id == o.Id && this.Description == o.Description
                ;
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            // Calculate hash on each properties one by one
            code = (code * 7) + this.Id.GetHashCode();
            if (this.Description != null)
                code = (code * 7) + Description.GetHashCode();
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
