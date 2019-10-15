using System;
using System.Collections.Generic;
using System.Globalization;

namespace JohnsonControls.Metasys.BasicServices.Models
{
    /// <summary>
    /// A structure for grouping Variant values with the same id.
    /// </summary>
    public struct VariantMultiple
    {
        /// <summary>The object id.</summary>
        public Guid Id { private set; get; }

        /// <summary>The list of Variants.</summary>
        public IEnumerable<Variant> Variants { private set; get; }

        internal VariantMultiple(Guid id, IEnumerable<Variant> variants)
        {
            Id = id;
            Variants = variants;
        }
    }
}
