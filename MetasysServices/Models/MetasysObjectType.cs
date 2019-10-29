using System;
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
    }
}