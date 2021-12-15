using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    public class Stream
    {
        /// <summary>
        /// Returns a value indicating whither this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {           
            return false;
        }

        /// <summary>
        /// Get the hash code
        /// </summary>
        /// <returns>generated hash code</returns>
        public override int GetHashCode()
        {
            var code = 13;
            //// Calculate hash on each properties one by one
            //code = (code * 7) + this.Value.GetHashCode();
            //code = (code * 7) + IsReliable.GetHashCode();
            //if (this.Unit != null)
            //    code = (code * 7) + Unit.GetHashCode();
            //if (this.Timestamp != null)
            //    code = (code * 7) + Timestamp.GetHashCode();
            //code = (code * 7) + Value.GetHashCode();
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
