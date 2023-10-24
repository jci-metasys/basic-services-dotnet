using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetasysServices_TestClient
{
    class Point
    {
        /// <summary>
        /// Name of the Point
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Item Reference of the Point
        /// </summary>
        public string ItemReference { get; set; }

        /// <summary>
        /// Point Unique Identifier (GUID)
        /// </summary>
        public Guid Id { get; set; }

    }
}
