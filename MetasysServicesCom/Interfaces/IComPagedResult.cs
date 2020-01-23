using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Provides attribute to filter alarm.
    /// </summary>
    [ComVisible(true)]
    [Guid("2107616B-88BA-4624-9896-5B665B5FD1C4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComPagedResult <T>
    {
        /// <summary>
        /// Total alarms count
        /// </summary>
        int Total { get; set; }

        /// <summary>
        /// Next page link
        /// </summary>
        string Next { get; set; }

        /// <summary>
        /// previous page link
        /// </summary>
        string Previous { get; set; }

        /// <summary>
        /// Pages result of alarm items
        /// </summary>
        object Items { get; set; }

        /// <summary>
        /// Route information for self
        /// </summary>
        string Self { get; set; }


    }
}
