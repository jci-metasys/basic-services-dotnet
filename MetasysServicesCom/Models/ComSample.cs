using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Filters to get alarms
    /// </summary>
    [Guid("2B692BD5-1E9F-47B8-9138-CFDF77995F63")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComSample : IComSample
    {
        /// <inheritdoc/>
        public double Value { get; set; }

        /// <inheritdoc/>
        public string Unit { get; set; }

        /// <inheritdoc/>
        public DateTime Timestamp { get; set; }

        /// <inheritdoc/>
        public bool IsReliable { get; set; }

    }
}
