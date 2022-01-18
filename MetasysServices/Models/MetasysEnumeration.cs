using Newtonsoft.Json;
using System;
using System.Globalization;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// MetasysEnumeration is a structure that hold information about a Metasys Enumeration definition
    /// </summary>
    public struct MetasysEnumeration
    {
        private CultureInfo _CultureInfo;

        /// <summary>
        /// Key that identifies the Enumeration set.
        /// </summary>
        public string Key { private set; get; }

        /// <summary>
        /// Name of the Enumeration set.
        /// </summary>
        public string Name { private set; get; }

        /// <summary>
        /// Specify if the Enumeration is related to a binary object.
        /// </summary>
        public bool IsTwoState { private set; get; }

        /// <summary>
        /// Specify if the Enumeration is related to a multistate object.
        /// </summary>
        public bool IsMultiState { private set; get; }

        /// <summary>
        /// Specify the number of states when the Enumeration is related to a multistate object.
        /// </summary>
        public int NumberOfStates { private set; get; }

        internal MetasysEnumeration(string key, string name, bool isTwoState, bool isMultiState, int numberOfStates, CultureInfo cultureInfo = null)
        {
            _CultureInfo = cultureInfo;
            Key = key;
            Name = name;
            IsTwoState = isTwoState;
            IsMultiState = isMultiState;
            NumberOfStates = numberOfStates;
        }

        /// <summary>
        /// Returns a value indicating whither this instance has values equal to a specified object.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is MetasysEnumeration)
            {
                var o = (MetasysEnumeration)obj;
                return this.Key == o.Key && this.Name == o.Name && this.IsTwoState == o.IsTwoState
                    && this.IsMultiState == o.IsMultiState && this.NumberOfStates == o.NumberOfStates;
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
            if (this.IsTwoState)
                code = (code * 7) + IsTwoState.GetHashCode();
            if (this.IsMultiState)
                code = (code * 7) + IsMultiState.GetHashCode();
            if (this.NumberOfStates > 0)
                code = (code * 7) + NumberOfStates.GetHashCode();
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
