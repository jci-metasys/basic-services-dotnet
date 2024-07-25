using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized COM structure that holds information about an attribute/property
    /// value from a single Metasys object.
    /// </summary>
    [Guid("e4df7bb3-3be4-420d-8a73-f93ddad4681f")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComVariant : IComVariant
    {
        // Note: in order to correctly work with VBA registered types, class need to implement a defined interface. Neither inheritance nor encapsulation will work when the defined class is in another assembly

        /// <inheritdoc/>
        public string StringValue { set; get; }

        /// <inheritdoc/>
        public string StringValueEnumerationKey { set; get; }

        /// <inheritdoc/>
        public double NumericValue { set; get; }

        /// <inheritdoc/>
        public bool BooleanValue { set; get; }

        /// <inheritdoc/>
        public object ArrayValue { set; get; }

        /// <inheritdoc/>
        public string Attribute { set; get; }

        /// <inheritdoc/>
        public string Id { set; get; }

        /// <inheritdoc/>
        public string Reliability { set; get; }

        /// <inheritdoc/>
        public string ReliabilityEnumerationKey { set; get; }

        /// <inheritdoc/>
        public string Priority { set; get; }

        /// <inheritdoc/>
        public string PriorityEnumerationKey { set; get; }
    }
}
