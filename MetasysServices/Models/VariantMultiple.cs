using System;
using System.Collections.Generic;
using System.Globalization;


namespace JohnsonControls.Metasys.BasicServices.Models
{
    public struct VariantMultiple
    {
        public Guid Id { private set; get; }

        public IEnumerable<Variant> Variants { private set; get; }

        internal VariantMultiple(Guid id, IEnumerable<Variant> variants)
        {
            Id = id;
            Variants = variants;
        }
    }
}
