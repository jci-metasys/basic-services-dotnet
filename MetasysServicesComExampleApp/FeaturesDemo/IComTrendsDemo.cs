using System;
using System.Reflection;
using JohnsonControls.Metasys.BasicServices;
using JohnsonControls.Metasys.ComServices;

namespace MetasysServicesComExampleApp.FeaturesDemo
{
    public class IComTrendsDemo
    {
        private ILegacyMetasysClient legacyClient;
        private LogInitializer log;

        public IComTrendsDemo(ILegacyMetasysClient legacyClient)
        {
            this.legacyClient = legacyClient;
            Type declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            log = new LogInitializer(declaringType);
        }

        public void Run()
        {
            try
            {
                ComTimeFilter getDateTimeForTrend = new ComTimeFilter();
                Console.WriteLine("\nIndicate the object you want to run this example code on.");
                Console.Write("Enter the fully qualified reference of the object (Example: \"site:device/itemReference\"): ");
                string object1 = Console.ReadLine();
                string id1 = legacyClient.GetObjectIdentifier(object1);
                Console.WriteLine($"{object1} id: {id1}");
                IComAttribute[] trendedAttributes = (IComAttribute[])legacyClient.GetTrendedAttributes(id1);
                foreach (IComAttribute trendedAttribute in trendedAttributes)
                {
                    Console.WriteLine($"ID: {trendedAttribute.Id} \nDescription: {trendedAttribute.Description}");
                }

                Console.WriteLine("Please enter Start Date and End Date separated by space: ");
                string getDateTime = Console.ReadLine();
                string[] args;
                args = getDateTime.Split(' ');

                if (args != null)
                {
                    getDateTimeForTrend = ReadUserInputForTrends(args);
                }
                string objId1 = id1.ToString();
                var samplesPager = legacyClient.GetSamples(objId1, 85, getDateTimeForTrend);
                var samples = (IComSample[])samplesPager.Items;
                foreach (IComSample s in samples)
                {
                    Console.WriteLine($"Value: {s.Value} Unit: {s.Unit} Timestamp: {s.Timestamp}");
                }
            }
            catch (Exception exception)
            {
                log.Logger.Error(string.Format("An error occured while getting trend information - {0}", exception.Message));
                Console.WriteLine("\n \nAn Error occurred. Press Enter to return to Main Menu");
            }
            Console.ReadLine();
        }

        private ComTimeFilter ReadUserInputForTrends(string[] args)
        {
            ComTimeFilter timeFilter = new ComTimeFilter
            {
                StartTime = args[0],
                EndTime = args[1]
            };
            return timeFilter;
        }
    }
}
