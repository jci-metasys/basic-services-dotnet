using System;
using JohnsonControls.Metasys.ComServices;

namespace MetasysServicesComExampleApp.FeaturesDemo
{
    public class IComAlarmsDemo
    {
        private LegacyMetasysClient legacyClient;

        public IComAlarmsDemo(LegacyMetasysClient legacyClient)
        {
            this.legacyClient = legacyClient;
        }

        public void Run()
        {
        }
    }
}
