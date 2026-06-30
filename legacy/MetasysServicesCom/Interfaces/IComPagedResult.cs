using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Provides attribute to filter alarm.
    /// </summary>
    [ComVisible(true)]
    [Guid("b778bc2d-5eb8-46ba-96e0-a6c3d4a59671")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComPagedResult
    {
        /// <summary>
        /// The total number of elements. 
        /// </summary>
        int Total { get; set; }
        /// <summary>
        /// The items of the current page.
        /// </summary>
        object Items { get; set; }
        /// <summary>
        /// The actual page.
        /// </summary>
        int CurrentPage { get; set; }
        /// <summary>
        /// Total number of pages.
        /// </summary>
        int PageCount { get; set; }
        /// <summary>
        /// Maximum number of elements on a page.
        /// </summary>
        int PageSize { get; set; }
    }
}
