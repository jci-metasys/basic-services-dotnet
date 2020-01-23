using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Provides attribute to filter alarm.
    /// </summary>
    [ComVisible(true)]
    [Guid("7B88D054-572D-45E7-A0A8-D4B1A8544957")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComAttribute
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
