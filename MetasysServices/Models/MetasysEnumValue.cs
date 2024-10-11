using Newtonsoft.Json;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// MetasysEnumValue is a structure that hold information about a Metasys Enumeration values
    /// </summary>

    public struct MetasysEnumValue
    {
        /// <summary>
        /// Key that identifies the Enumeration Value.
        /// </summary>
        public string Key { private set; get; }

        /// <summary>
        /// Name of the Enumeration Value.
        /// </summary>
        public string Name { private set; get; }

        /// <summary>
        /// Enumeration Value.
        /// </summary>
        public int Value { private set; get; }

        internal MetasysEnumValue(string key, string name, int value)
        {
            Key = key;
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Returns a value indicating whither this instance has values equal to a specified object.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is MetasysEnumValue value)
            {
                var o = value;
                return this.Key == o.Key && this.Name == o.Name && this.Value == o.Value;
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            // Calculate hash on each properties one by one
            if (Key != null)
                code = (code * 7) + Key.GetHashCode();
            if (this.Name != null)
                code = (code * 7) + Name.GetHashCode();
            if (this.Value >= 0)
                code = (code * 7) + Value.GetHashCode();
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
