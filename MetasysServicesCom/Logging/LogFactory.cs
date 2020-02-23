
namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Factory to provide <see cref="ILog"/> LogFactoryInstance.
    /// </summary>
    public sealed class LogFactory : ILogFactory
    {
        private static LogFactory LogFactoryInstance;

        /// <summary>
        /// Gets the instance of <see cref="LogFactory"/>.
        /// </summary>
        public static LogFactory Instance
        {
            get { return LogFactoryInstance = LogFactoryInstance ?? new LogFactory(); }
        }

        /// <summary>
        /// Creates a logger for the specified source.
        /// </summary>
        /// <param name="source">The specified source of logger</param>
        /// <returns>An Instance of diagnostic logger</returns>
        public ILog CreateLogger(string source)
        {
            return new Log4NetLogger(source);
        }

        /// <summary>
        /// Creates a logger for the specified source as per the configurations defined in the specified config file.
        /// </summary>
        /// <param name="source">The specified source of logger.</param>
        /// <param name="configFilePath">Config file path.</param>
        /// <returns>An Instance of diagnostic logger</returns>
        public ILog CreateLogger(string source, string configFilePath)
        {
            return new Log4NetLogger(source, configFilePath);
        }
    }
}