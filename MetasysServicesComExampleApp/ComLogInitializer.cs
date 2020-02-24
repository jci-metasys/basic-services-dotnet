using System;
using System.IO;
using System.Reflection;
using JohnsonControls.Metasys.ComServices;

namespace MetasysServicesComExampleApp
{
    public class ComLogInitializer
    {
        public readonly ILog logger;

        public ComLogInitializer(Type source)
        {
            LogFactory logFactory = LogFactory.Instance;

            var binPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

            if (!string.IsNullOrEmpty(binPath))
            {
                var logConfigPath = new Uri(binPath).LocalPath;
                logger = logFactory.CreateLogger(source.FullName, logConfigPath);
            }
        }
    }
}