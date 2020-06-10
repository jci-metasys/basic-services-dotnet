using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// A helper to work with MetasysPoint collections.
    /// </summary>
    public static class MetasysPointCollectionExtension
    {
        /// <summary>
        /// Returns the first MetasysPoint in the collection with the given short name.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="name">The short name of the Metasys point.</param>
        /// <returns></returns>
        public static MetasysPoint FindByShortName(this IEnumerable<MetasysPoint> source, string shortName)
        {
            var point = source.FirstOrDefault(f => f.ShortName == shortName);
            if (point == null)
            {
                throw new Exception($"Metasys Point not found in the collection ({shortName}).");
            }
            return point;
        }
    }
}
