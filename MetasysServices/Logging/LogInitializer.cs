using JohnsonControls.Metasys.BasicServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace JohnsonControls.Metasys.BasicServices
{
   /// <summary>
   /// Responsible for the Log initialization.
   /// </summary>
   /// <typeparam name="T"></typeparam>
    public class LogInitializer<T>
    {
        /// <summary>
        /// Instance implementing ILogger.
        /// </summary>
        public readonly ILogger<T> Logger;

        /// <summary>
        /// Initialize Log4Net Logger using DI.
        /// </summary>
        public LogInitializer()
        {
            var services = new ServiceCollection()
                .AddLogging(logBuilder => logBuilder.SetMinimumLevel(LogLevel.Debug))
                .BuildServiceProvider();


            Logger = services.GetService<ILoggerFactory>()
                .AddLog4Net("log4Net.config")
                .CreateLogger<T>();
        }
    }
}