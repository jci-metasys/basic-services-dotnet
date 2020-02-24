
namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Factory for logger.
    /// </summary>
    public interface ILogFactory
    {
        /// <summary>
        /// Creates a diagnostic logger
        /// </summary>
        /// <param name="source">specified source of logger</param>
        /// <returns>A diagnostic logger</returns>
        ILog CreateLogger(string source);
    }
}
