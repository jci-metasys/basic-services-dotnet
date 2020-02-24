using System;
using System.Reflection;
using JohnsonControls.Metasys.ComServices;

namespace MetasysServicesComExampleApp.FeaturesDemo
{
    public class IComSpacesDemo
    {
        private ILegacyMetasysClient legacyClient;
        private ComLogInitializer log;

        public IComSpacesDemo(ILegacyMetasysClient legacyClient)
        {
            this.legacyClient = legacyClient;
            Type declaringType = MethodBase.GetCurrentMethod().DeclaringType;
            log = new ComLogInitializer(declaringType);
        }
        public void Run()
        {
            try
            {
                Console.WriteLine("\n\nGetSpaceTypes...");

                dynamic spaceTypes = legacyClient.GetSpaceTypes();
                foreach (var type in spaceTypes)
                {
                    Console.WriteLine($"\nType {type.Id}: {type.Description}, ");
                }
                // Select a space type
                Console.WriteLine("\nPlease enter the Space Type ID to retrieve all related spaces:");
                string spaceType = Console.ReadLine();
                dynamic spaces = legacyClient.GetSpaces(spaceType);
                Console.WriteLine($"Spaces found: {spaces.Count()}");
                foreach (var space in spaces)
                {
                    Console.WriteLine($"\n{space.Id}: {space.Name}, {space.ItemReference}");
                }
                // Select a space            
                Console.WriteLine("\nPlease enter the Space ID to retrieve all related equipment:");
                string spaceID = Console.ReadLine();
                dynamic spaceEquipment = legacyClient.GetSpaceEquipment(spaceID);
                Console.WriteLine($"Equipment found: {spaceEquipment.Count()}");
                foreach (var o in spaceEquipment)
                {
                    Console.WriteLine($"\n{o.Id}: {o.Name}, {o.ItemReference}");
                }
                // Select a point
                Console.WriteLine("\nPlease enter the equipment ID to retrieve all related points:");
                string equipmentID = Console.ReadLine();
                dynamic equipmentPoints = legacyClient.GetEquipmentPoints(equipmentID);
                Console.WriteLine($"Equipment found: {equipmentPoints.Count()}");
                foreach (var p in equipmentPoints)
                {
                    Console.WriteLine($"\n{p.ShortName}: {p.Label}, {p.PresentValue?.StringValue}");
                }
            }
            catch (Exception exception)
            {
                log.logger.Error(string.Format("An error occured while getting space information - {0}", exception.Message));
                Console.WriteLine("\n \nAn Error occurred. Press Enter to return to Main Menu");
            }

            Console.ReadLine();
        }
    }
}
