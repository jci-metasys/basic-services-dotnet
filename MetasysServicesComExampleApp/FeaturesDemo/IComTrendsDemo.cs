using System;
using System.Collections;
using JohnsonControls.Metasys.ComServices;

namespace MetasysServicesComExampleApp.FeaturesDemo
{
    public class IComTrendsDemo
    {
        private ILegacyMetasysClient legacyClient;

        public IComTrendsDemo(ILegacyMetasysClient legacyClient)
        {
            this.legacyClient = legacyClient;
        }

        public void Run()
        {
            #region Trend
            ComTimeFilter getDateTimeForTrend = new ComTimeFilter();
            Console.WriteLine("\nIndicate the object you want to run this example code on.");
            Console.Write("Enter the fully qualified reference of the object (Example: \"site:device/itemReference\"): ");
            string object1 = Console.ReadLine();
            Guid id1 = Guid.Parse(legacyClient.GetObjectIdentifier(object1));            
            Console.WriteLine($"{object1} id: {id1}");
            object trendedAttributes = legacyClient.GetTrendedAttributes(id1);            
            Console.WriteLine(trendedAttributes.Description);

            Console.WriteLine("Please enter Start Date and End Date separated by space: ");
            string getDateTime = Console.ReadLine();
            string[] args;
            args = getDateTime.Split(' ');

            if (args != null)
            {
                getDateTimeForTrend = ReadUserInputForTrends(args);
            }
            string objId1 = id1.ToString();
            var samples = legacyClient.GetSamples(objId1, 85, getDateTimeForTrend).Items;
            foreach (var s in samples)
            {
                Console.WriteLine($"Value: {s.Value} Unit: {s.Unit} Timestamp: {s.Timestamp}");
            }
            Console.ReadLine();
            #endregion
        }

        private ComTimeFilter ReadUserInputForTrends(string[] args)
        {
            ComTimeFilter timeFilter = new ComTimeFilter
            {
                StartTime = DateTime.Parse(args[0]),
                EndTime = DateTime.Parse(args[1]),
            };
            return timeFilter;
        }
    }
}
