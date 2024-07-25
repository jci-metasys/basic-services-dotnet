using JohnsonControls.Metasys.BasicServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetasysServicesExampleApp.FeaturesDemo
{
    public class EquipmentDemo
    {
        private MetasysClient client;
        private LogInitializer log;

        public EquipmentDemo(MetasysClient client)
        {
            this.client = client;
            log = new LogInitializer(typeof(SpacesDemo));
        }
        public void Run()
        {
            try
            {
                // Select a point
                Console.WriteLine("\nPlease enter the equipment ID to retrieve all related points:");
                string equipmentID = Console.ReadLine();
                IEnumerable<MetasysPoint> equipmentPoints = client.GetEquipmentPoints(new Guid(equipmentID));
                Console.WriteLine($"Points found: {equipmentPoints.Count()}");
                foreach (var p in equipmentPoints)
                {
                    Console.WriteLine($"\n{p.ShortName}: {p.Label}, {p.PresentValue?.StringValue}");
                }
            }
            catch (Exception exception)
            {
                log.Logger.Error(string.Format("An error occured while getting space information - {0}", exception.Message));
                Console.WriteLine("\n \nAn Error occurred. Press Enter to return to Main Menu");
            }
            Console.ReadLine();
        }
    }
}
