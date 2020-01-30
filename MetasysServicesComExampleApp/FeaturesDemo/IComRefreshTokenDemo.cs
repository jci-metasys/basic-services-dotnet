using System;
using JohnsonControls.Metasys.ComServices;

namespace MetasysServicesComExampleApp.FeaturesDemo
{
    public class IComRefreshTokenDemo
    {
        private ILegacyMetasysClient legacyClient;

        public IComRefreshTokenDemo(ILegacyMetasysClient legacyClient)
        {
            this.legacyClient = legacyClient;
        }

        public void Run()
        {
            #region Refresh
            Console.WriteLine("\nRefreshing Token...");
            var token = legacyClient.Refresh();
            Console.WriteLine($"Access token: {token.Token} expires {token.Expires}.");
            Console.ReadLine();
            #endregion
        }
    }
}
