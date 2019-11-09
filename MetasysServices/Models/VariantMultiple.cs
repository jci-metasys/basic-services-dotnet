using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JohnsonControls.Metasys.BasicServices
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

        /// <summary>
        /// Returns a value indicating whither this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is VariantMultiple)
            {
                var other = (VariantMultiple)obj;
                bool areEqual = this.Id.Equals(other.Id);
                if (areEqual)
                {
                    if (this.Variants == null ^ other.Variants == null)
                    {
                        return false;
                    } 
                    else if (this.Variants != null && other.Variants != null)
                    {
                        return Enumerable.SequenceEqual(this.Variants, other.Variants);
                    }
                }
                return areEqual;                
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            code = (code * 7) + Id.GetHashCode();
            if (Variants != null)
            {
                var arrCode = 0;
                foreach(var item in Variants)
                {
                    arrCode += item.GetHashCode();
                }
                code = (code * 7) + arrCode;
            }
            return code;
        }
    }
}
