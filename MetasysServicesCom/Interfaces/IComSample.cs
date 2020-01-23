using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that gives trend information of an object.
    /// </summary>
    [Guid("E57764D9-B4B9-4499-AC6D-DEAFD7D98DCE")]
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
