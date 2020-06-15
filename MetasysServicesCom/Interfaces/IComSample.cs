using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that gives trend information of an object.
    /// </summary>
    [Guid("51935095-ae9e-4293-a19f-d715a03e745a")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComSample
    {
        /// <summary>
        /// Value
        /// </summary>
        double Value { get; set; }

        /// <summary>
        /// Unit
        /// </summary>
        string Unit { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        DateTime Timestamp { get; set; }

        /// <summary>
        /// Checks the reliability
        /// </summary>
        bool IsReliable { get; set; }

    }
}
