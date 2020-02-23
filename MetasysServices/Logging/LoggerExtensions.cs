
using Microsoft.Extensions.Logging;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Define extension methods for ILoggerFactory
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Add log4Net as the logging provider
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="logConfigPath">Path to log configuration file</param>
        /// <returns></returns>
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string logConfigPath)
        {
            var logProvider = new LoggerProvider(logConfigPath);
            factory.AddProvider(logProvider);
            return factory;
        }
    }
}