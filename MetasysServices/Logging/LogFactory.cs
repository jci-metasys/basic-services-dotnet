
using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.IO;
using System.Reflection;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Factory to provide <see cref="ILog"/> LogFactoryInstance.
    /// </summary>
    public sealed class LogFactory
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
        /// <param name="sourceType">The specified source type of logger</param>
        /// <returns>An Instance of diagnostic logger</returns>
        public ILog CreateLogger(Type sourceType)
        {
            var assembly = Assembly.GetExecutingAssembly();
            ILoggerRepository repository = LogManager.GetRepository(assembly);
            XmlConfigurator.Configure(repository, new FileInfo(Path.Combine(Path.GetDirectoryName(assembly.Location), "log4net.config")));
            return LogManager.GetLogger(repository.Name, sourceType);
        }

    }
}