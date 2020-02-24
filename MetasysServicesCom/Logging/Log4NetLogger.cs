
using System;
using System.IO;
using log4net;
using log4net.Config;
using ILog4NetLogger = log4net.ILog;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "JohnsonControls.Metasys.ComServices.Log4NetLogger..cctor()")]

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Responsible for logging messages to a common location.
    /// </summary>
    public sealed class Log4NetLogger : ILog
    {
        private readonly ILog4NetLogger log4NetLogger;


        private const string ConfigFileName = "log4Net.config";

        /// <summary>
        /// Initializes an instance of <see cref="Log4NetLogger"/> for the specified source and path.
        /// </summary>
        /// <param name="source">
        /// The source of the log message. Typically the fully-qualified name of the class.
        /// </param>
        /// <param name="path">Config file path location</param>
        public Log4NetLogger(string source, string path)
        {
            if (string.IsNullOrEmpty(source)) throw new ArgumentNullException(nameof(source));
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

            log4NetLogger = LogManager.GetLogger(source);
            XmlConfigurator.Configure(new FileInfo(Path.Combine(path, ConfigFileName)));
            XmlConfigurator.Configure();
        }

        /// <summary>
        /// Initializes an instance of <see cref="Log4NetLogger"/> for the specified source.
        /// </summary>
        /// <param name="source">
        /// The source of the log message. Typically the fully-qualified name of the class.
        /// </param>
        public Log4NetLogger(string source)
        {
            if (string.IsNullOrEmpty(source)) throw new ArgumentNullException(nameof(source));

            log4NetLogger = LogManager.GetLogger(source);
        }

        /// <summary>
        /// Create a message in the log
        /// </summary>
        /// <param name="level">The level of detail associated with this message</param>
        /// <param name="message">Text to be logged</param>
        public void Write(Level level, string message)
        {
            Write(level, message, null);
        }

        /// <summary>
        /// Create a message in the log
        /// </summary>
        /// <param name="level">The level of detail associated with this message</param>
        /// <param name="message">Text to be logged</param>
        /// <param name="exception">The exception that caused us to create this message</param>
        public void Write(Level level, string message, Exception exception)
        {
            switch (level)
            {
                case Level.Error:
                    log4NetLogger.Error(message, exception);
                    break;
                case Level.Warning:
                    log4NetLogger.Warn(message, exception);
                    break;
                case Level.Info:
                    log4NetLogger.Info(message, exception);
                    break;
                case Level.Verbose:
                    log4NetLogger.Debug(message, exception);
                    break;
            }
        }

        /// <summary>
        /// Indicates whether writing at the specified level would result in an 
        /// actual log message being generated.
        /// </summary>
        /// <param name="level">The level to check.</param>
        /// <returns><b>True</b> if a log message would be generated.</returns>
        public bool IsEnabled(Level level)
        {
            switch (level)
            {
                case Level.Error:
                    return log4NetLogger.IsErrorEnabled;
                case Level.Warning:
                    return log4NetLogger.IsWarnEnabled;
                case Level.Info:
                    return log4NetLogger.IsInfoEnabled;
                case Level.Verbose:
                    return log4NetLogger.IsDebugEnabled;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns <b>True</b> if a error messages would actually be generated.
        /// </summary>
        public bool IsError => IsEnabled(Level.Error);

        /// <summary>
        /// Returns <b>True</b> if a warning messages would actually be generated.
        /// </summary>
        public bool IsWarning => IsEnabled(Level.Warning);

        /// <summary>
        /// Returns <b>True</b> if a info messages would actually be generated.
        /// </summary>
        public bool IsInfo => IsEnabled(Level.Info);

        /// <summary>
        /// Returns <b>True</b> if a verbose messages would actually be generated.
        /// </summary>
        public bool IsVerbose => IsEnabled(Level.Verbose);

        /// <summary>
        /// Write a <see cref="Level.Error" /> message in the log.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        public void Error(string message)
        {
            Write(Level.Error, message, null);
        }

        /// <summary>
        /// Write a <see cref="Level.Error" /> message in the log.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="exception">Exception to be logged.</param>
        public void Error(string message, Exception exception)
        {
            Write(Level.Error, message, exception);
        }

        /// <summary>
        /// Write a <see cref="Level.Warning" /> message in the log.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        public void Warning(string message)
        {
            Write(Level.Warning, message, null);
        }

        /// <summary>
        /// Write a <see cref="Level.Warning" /> message in the log.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="exception">Exception to be logged.</param>
        public void Warning(string message, Exception exception)
        {
            Write(Level.Warning, message, exception);
        }

        /// <summary>
        /// Write a <see cref="Level.Info" /> message in the log.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        public void Info(string message)
        {
            Write(Level.Info, message, null);
        }

        /// <summary>
        /// Write a <see cref="Level.Info" /> message in the log.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="exception">Exception to be logged.</param>
        public void Info(string message, Exception exception)
        {
            Write(Level.Info, message, exception);
        }

        /// <summary>
        /// Write a <see cref="Level.Verbose" /> message in the log.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        public void Verbose(string message)
        {
            Write(Level.Verbose, message, null);
        }

        /// <summary>
        /// Write a <see cref="Level.Verbose" /> message in the log.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="exception">Exception to be logged.</param>
        public void Verbose(string message, Exception exception)
        {
            Write(Level.Verbose, message, exception);
        }
    }
}