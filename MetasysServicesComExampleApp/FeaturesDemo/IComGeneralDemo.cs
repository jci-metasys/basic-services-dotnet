using System;
using JohnsonControls.Metasys.ComServices;

namespace MetasysServicesComExampleApp.FeaturesDemo
{
    public class IComGeneralDemo
    {
        private LegacyMetasysClient legacyClient;

        public IComGeneralDemo(LegacyMetasysClient legacyClient)
        {
            this.legacyClient = legacyClient;
        }

        public void Run()
        {
        }
    }
}
