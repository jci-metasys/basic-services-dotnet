using System;
using System.Collections.Generic;
using JohnsonControls.Metasys.ComServices;

namespace MetasysServicesComExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var comMetasysClientFactory = new ComMetasysClientFactory();
            Console.WriteLine("Please enter your credentials." +
                   "\nRefer to the metasys-server/basic-services-dotnet README if you need help getting started.");
            Console.Write("Enter the Hostname:");
            var hostName = Console.ReadLine();
            Console.Write("Enter the Username:");
            var userName = Console.ReadLine();
            Console.Write("Enter the Password:");
            var password = Console.ReadLine();

            var legacyClient = comMetasysClientFactory.GetLegacyClient(hostName);

            #region Login

            legacyClient.TryLogin(userName, password);
            Console.WriteLine("Logging In.....");
            Console.WriteLine("Login Successfull...");

            #endregion

            #region GetObjectIdentifier

            Console.WriteLine("\n\nGetObjectIdentifier...");

            Console.WriteLine("\nIndicate the object you want to run this example code on.");
            Console.Write("Enter the fully qualified reference of the object (Example: \"site:device/itemReference\"): ");
            string object1 = Console.ReadLine();

            Console.WriteLine("\nIndicate the second object you want to run this example code on.");
            Console.Write("Enter the fully qualified reference of the object: ");
            string object2 = Console.ReadLine();

            string object1Id = legacyClient.GetObjectIdentifier(object1);
            string object2Id = legacyClient.GetObjectIdentifier(object2);

            Console.WriteLine($"{object1} id: {object1Id}");
            Console.WriteLine($"{object2} id: {object2Id}");

            string[] ids = new string[2];
            ids[0] = object1Id;
            ids[1] = object2Id;

            #endregion

            #region Trends
            ComTimeFilter getDateTimeForTrend = new ComTimeFilter();
            Guid objId = new Guid(object1Id);
            dynamic trendedAttributes = legacyClient.GetTrendedAttributes(object1Id);
            Console.WriteLine(trendedAttributes[0].Description);

            Console.WriteLine("Please enter Start Date and End Date separated by space: ");
            string getDateTime = Console.ReadLine();
            args = getDateTime.Split(' ');

            if (args != null)
            {
                getDateTimeForTrend = ReadUserInputForTrends(args);
            }

            dynamic samples = legacyClient.GetSamples(objId, 85, getDateTimeForTrend);
            foreach (var s in samples)
            {
                Console.WriteLine($"Value: {s.Value} Unit: {s.Unit} Timestamp: {s.Timestamp}");
            }

            #endregion

            #region Read Property

            Console.Write("\n!!!Please note ReadProperty will return null if the attribute does not exist, and will cause an exception in this example!!!");
            Console.Write("\nEnter an attribute of the objects (Examples: name, description, presentValue): ");
            string attribute1 = Console.ReadLine();

            Console.Write("Enter a second attribute of the objects: ");
            string attribute2 = Console.ReadLine();

            List<string> attributes = new List<string>() { attribute1, attribute2 };

            Console.WriteLine($"Get {attribute1} property...");

            var result1Attr1 = legacyClient.ReadProperty(object1Id, attribute1);
            var result2Attr1 = legacyClient.ReadProperty(object2Id, attribute1);

            Console.WriteLine($"{result1Attr1.Id} {result1Attr1.Attribute} values (string, int, bool, reliability): " +
                $"\n{result1Attr1.StringValue}, {result1Attr1.NumericValue}, {result1Attr1.BooleanValue}, {result1Attr1.Reliability}");
            Console.WriteLine($"{result2Attr1.Id} {result2Attr1.Attribute} values (string, int, bool, reliability): " +
                $"\n{result2Attr1.StringValue}, {result2Attr1.NumericValue}, {result2Attr1.BooleanValue}, {result2Attr1.Reliability}");

            #endregion

            #region ReadPropertyMultiple

            Console.WriteLine("\n\nReadPropertyMultiple...");

            Console.WriteLine($"\nGet {attribute1}, {attribute2} properties for each object...");

            var results = legacyClient.ReadPropertyMultiple(ids, attributes.ToArray());


            foreach (var varMultiple in (dynamic)(results))
            {
                // Grab the list of Variants for each id
                var variants = varMultiple.Variants;
                foreach (var result in variants)
                {
                    Console.WriteLine($"{result.Id} {result.Attribute} values (string, int, bool, reliability): " +
                        $"\n{result.StringValue}, {result.NumericValue},  {result.BooleanValue}, {result.Reliability}");
                }
            }

            #endregion

            #region WriteProperty

            Console.Write("\nEnter an attribute of the objects to change (don't worry, this will be reset to it's original value): ");
            string attribute3 = Console.ReadLine();

            Console.Write("\nEnter one new value for this attribute (this will be applied to both objects): ");
            string change = Console.ReadLine();

            // Get original values, this code will throw an exception if the 
            var result1Attr3 = legacyClient.ReadProperty(object1Id, attribute3);
            var result2Attr3 = legacyClient.ReadProperty(object2Id, attribute3);
            Console.WriteLine($"{result1Attr3.Id} {result1Attr3.Attribute} original value: {result1Attr3.StringValue}");
            Console.WriteLine($"{result2Attr3.Id} {result2Attr3.Attribute} original value: {result2Attr3.StringValue}");

            Console.WriteLine("\nWriteProperty...");

            // Change value
            legacyClient.WriteProperty(object1Id, attribute3, change);
            System.Threading.Thread.Sleep(1000);

            // View changes
            var result1Attr3Updated = legacyClient.ReadProperty(object1Id, attribute3);
            Console.WriteLine($"{result1Attr3Updated.Id} {result1Attr3Updated.Attribute} updated value: {change}");

            // Reset value
            legacyClient.WriteProperty(object1Id, attribute3, result1Attr3.StringValue);
            System.Threading.Thread.Sleep(1000);

            #endregion

            #region Write Property Multiple

            Console.WriteLine("\nWrite Property Multiple...");

            // Change value
            string[] attributes2 = new string[1];
            attributes2[0] = attribute3;
            Console.Write("\nEnter one new value for this attribute (this will be applied to both objects): ");
            string[] changes = new string[2];
            changes[0] = Console.ReadLine();
            changes[1] = changes[0];
            legacyClient.WritePropertyMultiple(ids, attributes2, changes);
            System.Threading.Thread.Sleep(1000);

            // View changes
            var result1Attr3UpdatedM = legacyClient.ReadProperty(object1Id, attribute3);
            var result2Attr3UpdatedM = legacyClient.ReadProperty(object2Id, attribute3);
            Console.WriteLine($"{result1Attr3UpdatedM.Id} {result1Attr3UpdatedM.Attribute} updated value: {changes[0]}");
            Console.WriteLine($"{result2Attr3UpdatedM.Id} {result2Attr3UpdatedM.Attribute} updated value: {changes[1]}");
            System.Threading.Thread.Sleep(1000);

            // Reset Values
            legacyClient.WriteProperty(object1Id, attribute3, result1Attr3.StringValue);
            legacyClient.WriteProperty(object2Id, attribute3, result2Attr3.StringValue);

            #endregion

            #region Commands

            Console.WriteLine("\n\nGetCommands...");

            Console.WriteLine($"{object1Id} Commands:");

            dynamic commands = legacyClient.GetCommands(object1Id);

            if (commands.Length != null)
            {
                // Console.WriteLine($"{commands.Count()}\n");
                foreach (dynamic command in (dynamic)commands)
                {
                    Console.WriteLine($"{command.Title}\n");
                }
            }
            else
            {
                Console.WriteLine("No commands found.");
            }

            #endregion

            #region GetNetworkDevices

            Console.WriteLine("\n\nGetNetworkDevices...");

            var types = legacyClient.GetNetworkDeviceTypes();
            foreach (var type in (dynamic)types)
            {
                Console.WriteLine($"\nAvailable Type {type.Id}: {type.Description}, {type.DescriptionEnumerationKey}");
                string typeId = type.Id.ToString();
                dynamic devices = legacyClient.GetNetworkDevices(typeId);
                Console.WriteLine($"Devices found: {devices.Length}");
                Console.WriteLine($"First Device: {devices[0].Name}");
            }

            #endregion

            #region GetSpaces

            Console.WriteLine("\n\nGetSpaces...");
            dynamic spaceTypes = legacyClient.GetSpaceTypes();
            foreach (var type in (dynamic)spaceTypes)
            {
                Console.WriteLine($"\nType {type.Id}: {type.Description}, ");
            }
            // Select a space type
            Console.WriteLine("\nPlease enter the Space Type ID to retrieve all related spaces:");
            string spaceType = Console.ReadLine();
            dynamic spaces = legacyClient.GetSpaces(spaceType);
            Console.WriteLine($"Spaces found: {spaces.Length}");
            foreach (var space in (dynamic)spaces)
            {
                Console.WriteLine($"\n{space.Id}: {space.Name}, {space.ItemReference}");
            }

            #endregion

            #region Alarms

            Console.WriteLine("Enter alarm id to get alarm details: ");
            string stringAlarmId = Console.ReadLine();
            Guid alarmId = Guid.Parse(stringAlarmId);

            dynamic alarmItem = legacyClient.GetSingleAlarm(alarmId);

            Console.WriteLine(string.Format("\n Alarm details found for {0}", alarmId));
            Console.WriteLine($"\n Id: {alarmItem.Id}, Name: {alarmItem.Name}, ItemReference: {alarmItem.ItemReference}");

            string getAlarms;
            ComAlarmFilter getAlarmsFilter = new ComAlarmFilter();

            Console.WriteLine("Please enter these parameters separated by space: Start Time, End Time, Priority range, Type, Exclude pending, Exclude acknowledged, Exclude discarded, Attribute, Category, Page, Page Size, Sort" +
                "\nRefer to the metasys-server/basic-services-dotnet README if you need help getting started.");
            getAlarms = Console.ReadLine();
            args = getAlarms.Split(' ');

            if (args != null)
            {
                getAlarmsFilter = ReadUserInput(args);
            }

            Console.WriteLine("\n List of alarms with details");

            dynamic alarmItems = legacyClient.GetAlarms(getAlarmsFilter);

            if (alarmItems != null)
            {
                foreach (var item in alarmItems)
                {
                    Console.WriteLine($"\n Id: {item.Id}, Name: {item.Name}, ItemReference: {item.ItemReference}");
                }
            }
            else
            {
                Console.WriteLine("No alarm found.");
            }

            Console.WriteLine("\nEnter object id to get alarm details: ");
            string objectId = Console.ReadLine();

            string getAlarmsForObject;
            ComAlarmFilter alarmFilterForObject = new ComAlarmFilter();

            Console.WriteLine("\nPlease enter these parameters separated by space: Start Time, End Time, Priority range, Type, Exclude pending, Exclude acknowledged, Exclude discarded, Attribute, Category, Page, Page Size, Sort" +
                "\nRefer to the metasys-server/basic-services-dotnet README if you need help getting started.");

            getAlarmsForObject = Console.ReadLine();
            args = getAlarmsForObject.Split(' ');

            if (args != null)
            {
                alarmFilterForObject = ReadUserInput(args);
            }

            Console.WriteLine(string.Format("\nAlarm details found for this object {0}", objectId));

            dynamic alarmItemsForObject = legacyClient.GetAlarmsForAnObject(Guid.Parse(objectId), alarmFilterForObject);

            Console.WriteLine("\nEnter network device id to get alarm details: ");
            string networkDeviceId = Console.ReadLine();

            string getAlarmsForNetworkDevice;
            ComAlarmFilter alarmFilterModelForNetworkDevice = new ComAlarmFilter();

            Console.WriteLine("\nPlease enter these parameters separated by space: Start Time, End Time, Priority range, Type, Exclude pending, Exclude acknowledged, Exclude discarded, Attribute, Category, Page, Page Size, Sort" +
                "\nRefer to the metasys-server/basic-services-dotnet README if you need help getting started.");

            getAlarmsForNetworkDevice = Console.ReadLine();
            args = getAlarmsForNetworkDevice.Split(' ');

            if (args != null)
            {
                alarmFilterModelForNetworkDevice = ReadUserInput(args);
            }

            Console.WriteLine(string.Format("\nAlarm details found for the network device {0}", networkDeviceId));

            dynamic alarmItemsForNetworkDevice = legacyClient.GetAlarmsForNetworkDevice(Guid.Parse(objectId), alarmFilterModelForNetworkDevice);

            #endregion

            Console.ReadLine();
        }

        private static ComAlarmFilter ReadUserInput(string[] args)
        {
            ComAlarmFilter alarmFilter = new ComAlarmFilter
            {
                StartTime = args[0],
                EndTime = args[1],
                PriorityRange = args[2],
                Type = args[3].ToLower() != "null" ? Convert.ToInt32(args[3].ToString()) : 0,
                ExcludePending = args[4].ToLower() != "null" ? Convert.ToBoolean(args[4]) : false,
                ExcludeAcknowledged = !string.IsNullOrEmpty(args[5]) ? Convert.ToBoolean(args[5]) : false,
                ExcludeDiscarded = !string.IsNullOrEmpty(args[6]) ? Convert.ToBoolean(args[6]) : false,
                Attribute = args[7].ToLower() != "null" ? Convert.ToInt32(args[7]) : 0,
                Category = args[8].ToLower() != "null" ? Convert.ToInt32(args[8]) : 0,
                Page = args[9].ToLower() != "null" ? Convert.ToInt32(args[9]) : 0,
                PageSize = args[10].ToLower() != "null" ? Convert.ToInt32(args[10]) : 0,
                Sort = args[11]
            };
            return alarmFilter;
        }

        private static ComTimeFilter ReadUserInputForTrends(string[] args)
        {
            ComTimeFilter timeFilter = new ComTimeFilter
            {
                StartTime = args[0],
                EndTime = args[1],
            };
            return timeFilter;
        }
    }
}
