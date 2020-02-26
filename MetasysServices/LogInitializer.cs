using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace JohnsonControls.Metasys.BasicServices
{
    public class LogInitializer<T>
    {
        public readonly ILogger<T> logger;

        public LogInitializer()
        {
            var services = new ServiceCollection()
                .AddLogging(logBuilder => logBuilder.SetMinimumLevel(LogLevel.Debug))
                .BuildServiceProvider();


            logger = services.GetService<ILoggerFactory>()
                .AddLog4Net("log4Net.config")
                .CreateLogger<T>();
        }
    }
}