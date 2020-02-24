using System;
using System.Reflection;
using JohnsonControls.Metasys.ComServices;

namespace MetasysServicesComExampleApp.FeaturesDemo
{
    public class IComRefreshTokenDemo
    {
        private ILegacyMetasysClient legacyClient;
        private ComLogInitializer log;

        public IComRefreshTokenDemo(ILegacyMetasysClient legacyClient)
        {
            this.legacyClient = legacyClient;
            Type declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            log = new ComLogInitializer(declaringType);
        }

        public void Run()
        {
            try
            {
                Console.WriteLine("\nRefreshing Token...");
                var token = legacyClient.Refresh();
                Console.WriteLine($"Access token: {token.Token} expires {token.Expires}.");
            }
            catch (Exception exception)
            {
                log.logger.Error(string.Format("An error occured while getting refresh token information - {0}", exception.Message));
                Console.WriteLine("\n \nAn Error occurred. Press Enter to return to Main Menu");
            }

            Console.ReadLine();
        }
    }
}
