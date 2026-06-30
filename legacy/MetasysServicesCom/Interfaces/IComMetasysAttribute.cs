using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Provides attribute to filter alarm.
    /// </summary>
    [ComVisible(true)]
    [Guid("61eb5c62-3f17-49f3-bd20-7ea1ec8dcbf0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComMetasysAttribute
    {
        /// <summary>
        /// unique identifier
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        string Description { get; set; }
    }
}
