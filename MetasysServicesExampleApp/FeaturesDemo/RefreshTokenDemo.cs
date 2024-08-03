using JohnsonControls.Metasys.BasicServices;
using System;


namespace MetasysServicesExampleApp.FeaturesDemo
{
    public class RefreshTokenDemo
    {
        private MetasysClient client;
        private LogInitializer log;

        public RefreshTokenDemo(MetasysClient client)
        {
            this.client = client;
            log = new LogInitializer(typeof(RefreshTokenDemo));
        }
        public void Run()
        {
            try
            {
                Console.WriteLine("\nRefreshing Token...");
                var token = client.Refresh();
                Console.WriteLine($"Access token: {token.Token} expires {token.Expires}.");
            }
            catch (Exception exception)
            {
                log.Logger.Error(string.Format("An error occured while getting refresh token information - {0}", exception.Message));
                Console.WriteLine("\n \nAn Error occurred. Press Enter to return to Main Menu");
            }

            Console.ReadLine();
        }
    }
}
