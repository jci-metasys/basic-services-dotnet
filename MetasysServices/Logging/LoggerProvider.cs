
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.IO;
using System.Xml;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Implemention of ILoggerProvider using Log4Net
    /// </summary>
    public class LoggerProvider : ILoggerProvider
    {
        private readonly string log4NetConfig;
        private readonly ConcurrentDictionary<string, Log4NetLogger> loggers = new ConcurrentDictionary<string, Log4NetLogger>();

        /// <summary>
        /// Create instance of <see cref="LoggerProvider"/>
        /// </summary>
        /// <param name="log4NetConfigFile">Path of log4net config file</param>
        public LoggerProvider(string log4NetConfigFile)
        {
            log4NetConfig = log4NetConfigFile;
        }

        /// <summary>
        /// Add Log4Net logger to loggers dictionary
        /// </summary>
        /// <param name="categoryName">The category name for messages produced by the logger.</param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        /// <summary>
        /// Clears the loggers dictionary
        /// </summary>
        public void Dispose()
        {
            loggers.Clear();
        }

        private Log4NetLogger CreateLoggerImplementation(string name)
        {
            return new Log4NetLogger(name, Parselog4NetConfigFile(log4NetConfig));
        }

        private static XmlElement Parselog4NetConfigFile(string filename)
        {
            XmlDocument log4NetConfig = new XmlDocument();
            using (var fileStream = File.OpenRead(filename))
            {
                log4NetConfig.Load(fileStream);
                return log4NetConfig["log4net"];
            }
        }
    }
}