using Newtonsoft.Json;
using System.Globalization;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// MetasysObjectType is a structure that hold information about a Metasys 
    /// </summary>
    public struct MetasysObjectType
    {
        private CultureInfo _CultureInfo;

        /// <summary>
        /// The translated description of the object type.
        /// </summary>
        /// <value>The translated description of the object type or the default en-US version.</value>
        public string Description { private set; get; }

        /// <summary>
        /// The enumeration key of the description.
        /// </summary>
        /// <value>The enumeration key of the object type or the default en-US version if not found.</value>
        public string DescriptionEnumerationKey { private set; get; }

        /// <summary>
        /// The number id of the object type.
        /// </summary>
        public int Id { private set; get; }

        internal MetasysObjectType(int id, string key, string description, CultureInfo cultureInfo = null)
        {
            _CultureInfo = cultureInfo;
            DescriptionEnumerationKey = key;
            Description = description;
            Id = id;
        }

        /// <summary>
        /// Returns a value indicating whither this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is MetasysObjectType)
            {
                var other = (MetasysObjectType)obj;
                return this.Id.Equals(other.Id) &&
                    ((this.DescriptionEnumerationKey == null && other.DescriptionEnumerationKey == null) ||
                        (this.DescriptionEnumerationKey != null &&
                            this.DescriptionEnumerationKey.Equals(other.DescriptionEnumerationKey)));
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            code = (code * 7) + Id.GetHashCode();
            if (DescriptionEnumerationKey != null)
                code = (code * 7) + DescriptionEnumerationKey.GetHashCode();
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