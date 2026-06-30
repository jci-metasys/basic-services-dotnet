using System;

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
