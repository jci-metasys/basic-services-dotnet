using log4net;
using System;
using System.IO;
using System.Reflection;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Responsible for the Log initialization.
    /// </summary>
    public class LogInitializer
    {
        /// <summary>
        /// Instance implementing ILogger.
        /// </summary>
        public readonly ILog Logger;

        /// <summary>
        /// Initialize Log4Net Logger using Factory.
        /// </summary>
        public LogInitializer(Type source)
        {
            LogFactory logFactory = LogFactory.Instance;
            Logger = logFactory.CreateLogger(source);
        }
    }
}