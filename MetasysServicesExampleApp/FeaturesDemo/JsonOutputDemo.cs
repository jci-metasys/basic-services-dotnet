using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JohnsonControls.Metasys.BasicServices;
using Attribute = JohnsonControls.Metasys.BasicServices.Attribute;
using JohnsonControls.Metasys.BasicServices.Utils;
using Newtonsoft.Json;

namespace MetasysServicesExampleApp.FeaturesDemo
{
    public class JsonOutputDemo
    {
        private MetasysClient client;
        private LogInitializer log;

        public JsonOutputDemo(MetasysClient client)
        {
            this.client = client;
            log = new LogInitializer(typeof(JsonOutputDemo));
        }

        #region LOGIN AND ACCESS TOKENS        
        private void TryLogin_Refresh()
        {

            /* SNIPPET 1: START */
            // Automatically refresh token using plain credentials
            client.TryLogin("username", "password");
            // Do not automatically refresh token using plain credentials
            client.TryLogin("username", "password", false);
            /* SNIPPET 1: END */

            /* SNIPPET 2: START */
            // Read target from Credential Manager and automatically refresh token
            client.TryLogin("metasys-energy-app");
            // Read target from Credential Manager and do not refresh token
            client.TryLogin("metasys-energy-app", false);
            /* SNIPPET 2: END */

            /* SNIPPET 3: START */
            AccessToken accessToken = client.TryLogin("metasys-energy-app");
            Console.WriteLine(accessToken);
            /*        
                {
                  "Issuer": "metasysserver",
                  "IssuedTo": "metasysapiuser",
                  "Token": "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkJzR0lWelVZcjN0MkI0RGRtT1ljMTdBLVZJOCIsImtpZCI6IkJzR0lWelVZcjN0MkI0RGRtT1ljMTdBLVZJOCJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojk1MDYvQVBJLkF1dGhlbnRpY2F0aW9uU2VydmljZSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6OTUwNi9BUEkuQXV0aGVudGljYXRpb25TZXJ2aWNlL3Jlc291cmNlcyIsImV4cCI6MTU4OTI5MzEzMCwibmJmIjoxNTg5MjkxMzMwLCJjbGllbnRfaWQiOiJtZXRhc3lzX3VpIiwic2NvcGUiOlsibWV0YXN5c19hcGkiLCJvZmZsaW5lX2FjY2VzcyIsIm9wZW5pZCJdLCJzdWIiOiI4ZGE4YjE4Yy1lMTk1LTRlMmMtOGU2Zi0zNTE2Zjc0ZWFhNGIiLCJhdXRoX3RpbWUiOjE1ODkyOTEzMzAsImlkcCI6Imlkc3J2IiwiVXNlcklkIjoiMSIsIlVzZXJOYW1lIjoibWV0YXN5c3N5c2FnZW50IiwiSXNBZG1pbiI6IlRydWUiLCJJc1Bhc3N3b3JkQ2hhbmdlUmVxdWlyZWQiOiJGYWxzZSIsIklzVGVybXNBbmRDb25kaXRpb25zUmVxdWlyZWQiOiJGYWxzZSIsIkxpY2Vuc2VJbmZvIjoie1wiSXNMaWNlbnNlZFwiOnRydWUsXCJMaWNlbnNlVHlwZVwiOlwiZ3JhY2VcIn0iLCJDdWx0dXJlIjoiZW4tVVMiLCJhbXIiOlsicGFzc3dvcmQiXX0.egzw1bs1831pEBWWXbBOYWGU5wFsI3sEnL7RgCIHHbHmcxtpPPqLq54znpoUoLFrMUeymZj5rkrt_mF-CNIpCE3halZNAH-CR1U46LTZi5CMaDfYlP-wHxikAGV5GwFjlHjGNOUaFtd7n4yC5sH08pHQfXXD5gKDm_FVMfUJXAo-E8gmrkU0wMn5U2FRyQyj7Yhq6jaj7MPTF__Xz46sG3WtDr45WK2NmuwiLDv408URZ5fJxlMngRpjSIONHVAIwna_H0AguHiIELkvuRVYcRqIH5kb1YdFt-3fsnTV9xwpozZZ44dh-4I7x466I-UGlLHAnScWILUbPcpRNWm0Uw",
                  "Expires": "2020-05-12T14:18:51Z"
                }
             */
            /* SNIPPET 3: END */

            /* SNIPPET 4: START */
            client.Refresh();
            /* SNIPPET 4: END */
        }
        #endregion

        #region GET AN OBJECT ID
        private void GetObjectIdentifier()
        {
            /* SNIPPET 1: START */
            Guid objectId = client.GetObjectIdentifier("Win2016-VM2:vNAE2343996/Field Bus MSTP1.VAV-08.ZN-SP");
            Console.WriteLine(objectId);
            /*        
            d5d96cd3-db4a-52e0-affd-8bc3393c30ec
             */
            /* SNIPPET 1: END */
        }
        #endregion

        #region GET A PROPERTY
        private void ReadProperty(Guid objectId)
        {         
            /* SNIPPET 1: START */
            Variant property = client.ReadProperty(objectId, "presentValue");
            Console.WriteLine(property);
            /*        
               {
                  "StringValue": "72",
                  "StringValueEnumerationKey": null,
                  "NumericValue": 72.0,
                  "BooleanValue": true,
                  "ArrayValue": null,
                  "Attribute": "presentValue",
                  "Id": "f1469e25-c46c-5009-b92e-d82603e742a4",
                  "Reliability": "Reliable",
                  "ReliabilityEnumerationKey": "reliabilityEnumSet.reliable",
                  "Priority": "0 (No Priority)",
                  "PriorityEnumerationKey": "writePriorityEnumSet.priorityNone",
                  "IsReliable": true
                }
             */
            /* SNIPPET 1: END */
        }
        private void ReadPropertyMultiple(Guid id1, Guid id2)
        {
            /* SNIPPET 2: START */
            List<Guid> ids = new List<Guid> { id1, id2 };
            List<string> attributes = new List<string> { "name", "description" };
            IEnumerable<VariantMultiple> results = client.ReadPropertyMultiple(ids, attributes);
            VariantMultiple multiple1 = results.ElementAt(0);
            Console.WriteLine(multiple1);
            /*
                {
                    "Id": "d5d96cd3-db4a-52e0-affd-8bc3393c30ec",
                    "Variants": [
                    {
                        "StringValue": "ZN-T",
                        "StringValueEnumerationKey": "ZN-T",
                        "NumericValue": 0.0,
                        "BooleanValue": false,
                        "ArrayValue": null,
                        "Attribute": "name",
                        "Id": "d5d96cd3-db4a-52e0-affd-8bc3393c30ec",
                        "Reliability": "Reliable",
                        "ReliabilityEnumerationKey": "reliabilityEnumSet.reliable",
                        "Priority": null,
                        "PriorityEnumerationKey": null,
                        "IsReliable": true
                    },
                    {
                        "StringValue": "Zone Temperature",
                        "StringValueEnumerationKey": "Zone Temperature",
                        "NumericValue": 0.0,
                        "BooleanValue": false,
                        "ArrayValue": null,
                        "Attribute": "description",
                        "Id": "d5d96cd3-db4a-52e0-affd-8bc3393c30ec",
                        "Reliability": "Reliable",
                        "ReliabilityEnumerationKey": "reliabilityEnumSet.reliable",
                        "Priority": null,
                        "PriorityEnumerationKey": null,
                        "IsReliable": true
                    }
                    ]
                }
            */
            IEnumerable<Variant> multiple1Variants = multiple1.Variants;
            /* SNIPPET 2: END */
        }
        #endregion

        #region WRITE A PROPERTY
        private void WriteProperty()
        {
            /* SNIPPET 1: START */
            Guid id = client.GetObjectIdentifier("siteName:naeName/Folder1.AV1");
            client.WriteProperty(id, "description", "This is an AV.");
            client.WriteProperty(id, "description", "This is an AV.", "writePriorityEnumSet.priorityNone");
            /* SNIPPET 1: END */
        }
        private void WritePropertyMultiple(Guid id1, Guid id2)
        {
            /* SNIPPET 2: START */
            List<Guid> ids = new List<Guid> { id1, id2 };
            List<(string, object)> attributes = new List<(string, object)> { ("description", "This is an AV.") };
            client.WritePropertyMultiple(ids, attributes);
            /* SNIPPET 2: END */
        }
        #endregion

        #region GET AND SEND COMMANDS
        private void GetCommands(Guid objectId)
        {
            /* SNIPPET 1: START */
            List<Command> commands = client.GetCommands(objectId).ToList();
            Command command = commands[0]; // Adjust
            Console.WriteLine(command);
            /*                        
                {
                  "Title": "Adjust",
                  "TitleEnumerationKey": "commandIdEnumSet.adjustCommand",
                  "CommandId": "Adjust",
                  "Items": [
                    {
                      "Title": "Value",
                      "Type": "number",
                      "EnumerationValues": null,
                      "Minimum": null,
                      "Maximum": null
                    }
                  ]
                }
            */
            /* SNIPPET 1: END */
        }
        private void SendCommands(Guid objectId, List<Command> commands)
        {
            /* SNIPPET 2: START */
            Command adjust = commands[0]; // Adjust
            Command operatorOverride = commands[1]; // OperatorOverride
            Command release = commands[4]; // Release 
            Console.WriteLine(release);
            /*                        
              {
                  "Title": "Release",
                  "TitleEnumerationKey": "commandIdEnumSet.releaseCommand",
                  "CommandId": "Release",
                  "Items": [
                    {
                      "Title": "oneOf",
                      "Type": "enum",
                      "EnumerationValues": [
                        {
                          "Title": "Present Value",
                          "TitleEnumerationKey": "attributeEnumSet.presentValue"
                        }
                      ],
                      "Minimum": 1.0,
                      "Maximum": 1.0
                    },
                    {
                      "Title": "oneOf",
                      "Type": "enum",
                      "EnumerationValues": [
                        {
                          "Title": "0 (No Priority)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priorityNone"
                        },
                        {
                          "Title": "1 (Manual Life Safety)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priorityManualEmergency"
                        },
                        {
                          "Title": "2 (Auto Life Safety)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priorityFireApplications"
                        },
                        {
                          "Title": "3 (Application)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priority3"
                        },
                        {
                          "Title": "4 (Application)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priority4"
                        },
                        {
                          "Title": "5 (Critical Equipment)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priorityCriticalEquipment"
                        },
                        {
                          "Title": "6 (Minimum On Off)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priorityMinimumOnOff"
                        },
                        {
                          "Title": "7 (Heavy Equip Delay)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priorityHeavyEquipDelay"
                        },
                        {
                          "Title": "8 (Operator Override)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priorityOperatorOverride"
                        },
                        {
                          "Title": "9 (Application)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priority9"
                        },
                        {
                          "Title": "10 (Application)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priority10"
                        },
                        {
                          "Title": "11 (Demand Limiting)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priorityDemandLimiting"
                        },
                        {
                          "Title": "12 (Application)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priority12"
                        },
                        {
                          "Title": "13 (Load Rolling)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priorityLoadRolling"
                        },
                        {
                          "Title": "14 (Application)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priority14"
                        },
                        {
                          "Title": "15 (Scheduling)",
                          "TitleEnumerationKey": "writePriorityEnumSet.prioritySchedulingOst"
                        },
                        {
                          "Title": "16 (Default)",
                          "TitleEnumerationKey": "writePriorityEnumSet.priorityDefault"
                        }
                      ],
                      "Minimum": 1.0,
                      "Maximum": 1.0
                    }
                  ]
                }
            */
            var list1 = new List<object> { 70 };
            client.SendCommand(objectId, adjust.CommandId, list1);
            var list2 = new List<object> { 75 };
            client.SendCommand(objectId, operatorOverride.CommandId, list2);
            var list3 = new List<object> { "attributeEnumSet.presentValue", "writePriorityEnumSet.priorityNone" };
            client.SendCommand(objectId, release.CommandId, list3);
            /* SNIPPET 2: END */
        }
        #endregion

        #region GET NETWORK DEVICES AND OBJECT CHILDREN
        private void GetNetworkDeviceTypes_GetNetworkDevices()
        {
            /* SNIPPET 1: START */
            List<MetasysObjectType> types = client.GetNetworkDeviceTypes().ToList();
            Console.WriteLine(types[0]);
            /*                        
            {
              "Description": "NAE55-NIE59",
              "DescriptionEnumerationKey": "objectTypeEnumSet.n50Class",
              "Id": 185
            }
            */
            int type1 = types[0].Id;
            List<MetasysObject> devices = client.GetNetworkDevices(type1.ToString()).ToList();
            MetasysObject device = devices.LastOrDefault();
            Console.WriteLine(device);
            /*                        
                {
                  "ItemReference": "Win2016-VM2:vNAE2343996",
                  "Id": "142558f8-c4c7-5f89-be97-d806adb72053",
                  "Name": "vNAE2343996",
                  "Description": "",
                  "Type": null,
                  "TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/185",
                  "Category": null,
                  "Children": [],
                  "ChildrenCount": 0
                }
            */
            /* SNIPPET 1: END */
        }

        private void GetObjects()
        {
            /* SNIPPET 2: START */
            Guid parentId = client.GetObjectIdentifier("Win2016-VM2:vNAE2343996/Field Bus MSTP1.VAV-08");
            // Get direct children (1 level)
            List<MetasysObject> directChildren = client.GetObjects(parentId).ToList();
            MetasysObject lastChild = directChildren.LastOrDefault();
            Console.WriteLine(lastChild);
            /*                        
                {
                  "ItemReference": "Win2016-VM2:vNAE2343996/Field Bus MSTP1.VAV-08.ZN-T",
                  "Id": "d5d96cd3-db4a-52e0-affd-8bc3393c30ec",
                  "Name": "ZN-T",
                  "Description": null,
                  "Type": null,
                  "TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/601",
                  "Category": null,
                  "Children": [],
                  "ChildrenCount": 0
                }
               */
            Guid twoLevelsParentId = client.GetObjectIdentifier("Win2016-VM2:vNAE2343996/WeatherForecast");
            // Get descendant for 2 levels (it could take long time, depending on the number of objects)
            List<MetasysObject> level2Descendants = client.GetObjects(twoLevelsParentId, 2).ToList();
            MetasysObject level1Parent = level2Descendants.SingleOrDefault(s => s.Name == "Time");
            Console.WriteLine(level1Parent);
            /*                        
              {
                "ItemReference": "Win2016-VM2:vNAE2343996/WeatherForecast.Time",
                "Id": "22bb952e-7557-5de9-b7e5-dce39e21addd",
                "Name": "Time",
                "Description": null,
                "Type": null,
                "TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/176",
                "Category": null,
                "Children": [
                {
                    "ItemReference": "Win2016-VM2:vNAE2343996/WeatherForecast.Time.Day",
                    "Id": "5886a93f-9260-553c-995e-6a65374de85d",
                    "Name": "Day",
                    "Description": null,
                    "Type": null,
                    "TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/165",
                    "Category": null,
                    "Children": [],
                    "ChildrenCount": 0
                },
                {
                    "ItemReference": "Win2016-VM2:vNAE2343996/WeatherForecast.Time.Hour",
                    "Id": "6a50d3af-d0a2-537c-a2f7-9c1b5f271cc5",
                    "Name": "Hour",
                    "Description": null,
                    "Type": null,
                    "TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/165",
                    "Category": null,
                    "Children": [],
                    "ChildrenCount": 0
                },
                {
                    "ItemReference": "Win2016-VM2:vNAE2343996/WeatherForecast.Time.Minute",
                    "Id": "19a53f38-2fd7-5ac3-a12c-f3b9704ac194",
                    "Name": "Minute",
                    "Description": null,
                    "Type": null,
                    "TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/165",
                    "Category": null,
                    "Children": [],
                    "ChildrenCount": 0
                },
                {
                    "ItemReference": "Win2016-VM2:vNAE2343996/WeatherForecast.Time.Year",
                    "Id": "74dfc214-22c1-57a7-ace5-606636d0049c",
                    "Name": "Year",
                    "Description": null,
                    "Type": null,
                    "TypeUrl": "https://win2016-vm2/api/v2/enumSets/508/members/165",
                    "Category": null,
                    "Children": [],
                    "ChildrenCount": 0
                }
                ],
                "ChildrenCount": 4
            }
               */
            /* SNIPPET 2: END */
        }
        #endregion

        #region LOCALIZATION OF METASYS ENUMERATIONS
        private void Localize()
        {
            /* SNIPPET 1: START */
            client.Culture = new CultureInfo("en-US");
            /* SNIPPET 1: END */

            /* SNIPPET 2: START */
            // Access from the client object (uses client.Culture as input)
            string translated = client.Localize("reliabilityEnumSet.reliable");
            Console.WriteLine(translated);
            /*                        
                Reliable
              */
            // Access without instantiating a client
            translated = ResourceManager.Localize("reliabilityEnumSet.reliable",
                new CultureInfo("it-IT"));
            Console.WriteLine(translated);
            /*                        
                Affidabile
              */
            /* SNIPPET 2: END */
        }
        #endregion

        #region SPACES AND EQUIPMENT
        private void GetSpaces()
        {
            /* SNIPPET 1: START */
            // Retrieves the list of Buildings using SpaceTypeEnum helper
            List<MetasysObject> buildings = client.GetSpaces(SpaceTypeEnum.Building).ToList();
            MetasysObject building = buildings.LastOrDefault();
            Console.WriteLine(building);
            /*                        
                {
                  "ItemReference": "Win2016-VM2:Win2016-VM2/JCI.Building 1",
                  "Id": "164aaba2-0fb3-5b5d-bfe9-49cf6b797c93",
                  "Name": "North America (BACnet)",
                  "Description": null,
                  "Type": 2,
                  "TypeUrl": "https://win2016-vm2/api/v2/enumSets/1766/members/1",
                  "Category": "Building",
                  "Children": [],
                  "ChildrenCount": 0
                }
             */
            // Retrieves all the spaces in a flat hierarchy
            List<MetasysObject> spaces = client.GetSpaces().ToList();
            MetasysObject firstSpace = spaces.FirstOrDefault();
            Console.WriteLine(firstSpace);
            /*                        
                {
                  "ItemReference": "Win2016-VM2:Win2016-VM2/JCI.Building 1.Floor 1.Milwaukee.507 E Michigan Street Campus",
                  "Id": "896ba096-db3c-5038-8505-636785906cca",
                  "Name": "507 E Michigan Street Campus",
                  "Description": null,
                  "Type": 2,
                  "TypeUrl": "https://win2016-vm2/api/v2/enumSets/1766/members/3",
                  "Category": "Room",
                  "Children": [],
                  "ChildrenCount": 0
                }
             */
            /* SNIPPET 1: END */
        }

        private void GetSpaceTypes()
        {
            /* SNIPPET 2: START */
            IEnumerable<MetasysObjectType> spaceTypes = client.GetSpaceTypes();
            foreach (var type in spaceTypes)
            {
                Console.WriteLine(type);
            }
            /*                        
                {
                  "Description": "Building",
                  "DescriptionEnumerationKey": "Building",
                  "Id": 1
                }
                {
                  "Description": "Floor",
                  "DescriptionEnumerationKey": "Floor",
                  "Id": 2
                }
                {
                  "Description": "Generic",
                  "DescriptionEnumerationKey": "Generic",
                  "Id": 0
                }
                {
                  "Description": "Room",
                  "DescriptionEnumerationKey": "Room",
                  "Id": 3
                }
             */
            /* SNIPPET 2: END */
        }

        private void GetEquipment()
        {
            /* SNIPPET 3: START */
            List<MetasysObject> equipment = client.GetEquipment().ToList();
            MetasysObject sampleEquipment = equipment.FirstOrDefault();
            Console.WriteLine(sampleEquipment);
            /*                        
                 {
                  "ItemReference": "Win2016-VM2:Win2016-VM2/equipment.vNAE2343947.Field Bus MSTP1.AHU-07",
                  "Id": "6c6e18b8-015f-572a-814c-1e5d66142850",
                  "Name": "AHU-07",
                  "Description": null,
                  "Type": 3,
                  "TypeUrl": null,
                  "Category": null,
                  "Children": [],
                  "ChildrenCount": 0
                }
             */
            /* SNIPPET 3: END */

        }

        private void GetSpaceEquipment_GetSpaceChildren(MetasysObject building)
        {
            /* SNIPPET 4: START */
            IEnumerable<MetasysObject> spaceEquipment = client.GetSpaceEquipment(building.Id);
            IEnumerable<MetasysObject> spaceChildren = client.GetSpaceChildren(building.Id);
            MetasysObject sampleSpaceEquipment = spaceEquipment.FirstOrDefault();
            /* SNIPPET 4: END */
        }

        private void GetEquipmentPoints(MetasysObject sampleEquipment)
        {
            /* SNIPPET 5: START */
            IEnumerable<Point> equipmentPoints = client.GetEquipmentPoints(sampleEquipment.Id);
            Point point = equipmentPoints.FirstOrDefault();
            string presentValue = point.PresentValue?.StringValue;
            Console.WriteLine(point);
            /*                        
                {
                  "EquipmentName": "AHU-07",
                  "ShortName": "CLG-O",
                  "Label": "Cooling Output",
                  "Category": "",
                  "IsDisplayData": true,
                  "ObjectId": "9dd107cf-e8dc-583a-9557-813395ae1971",
                  "AttributeUrl": "https://win2016-vm2/api/v2/enumSets/509/members/85",
                  "ObjectUrl": "https://win2016-vm2/api/v2/objects/9dd107cf-e8dc-583a-9557-813395ae1971",
                  "PresentValue": {
                    "StringValue": "0",
                    "StringValueEnumerationKey": null,
                    "NumericValue": 0.0,
                    "BooleanValue": false,
                    "ArrayValue": null,
                    "Attribute": "presentValue",
                    "Id": "9dd107cf-e8dc-583a-9557-813395ae1971",
                    "Reliability": "Reliable",
                    "ReliabilityEnumerationKey": "reliabilityEnumSet.reliable",
                    "Priority": "0 (No Priority)",
                    "PriorityEnumerationKey": "writePriorityEnumSet.priorityNone",
                    "IsReliable": true
                  }
                }
             */
            /* SNIPPET 5: END */
        }
        #endregion

        #region ALARMS      
        private void GetAlarms()
        {
            /* SNIPPET 1: START */
            AlarmFilter alarmFilter = new AlarmFilter
            {
                StartTime = new DateTime(2019, 12, 12),
                EndTime = new DateTime(2020, 1, 12),
                ExcludeAcknowledged = true
            };
            PagedResult<AlarmItemProvider> alarmsPager = client.Alarms.GetAlarms(alarmFilter);
            // Prints the number of records fetched and paging information
            Console.WriteLine("Total:" + alarmsPager.Total);
            Console.WriteLine("Current page:" + alarmsPager.CurrentPage);
            Console.WriteLine("Page size:" + alarmsPager.PageSize);
            Console.WriteLine("Pages:" + alarmsPager.PageCount);
            /* Console Output: Start                       
                Total:4611
                Current page:1
                Page size:100
                Pages:47
            Console Output: End */
            AlarmItemProvider alarm = alarmsPager.Items.ElementAt(0);
            Console.WriteLine(alarm);
            /* Console Output: Start                       
                {
                  "Self": "https://win2016-vm2/api/v2/alarms/ee7bc537-6b31-44b1-9feb-e4d0dc36f6e7",
                  "Id": "ee7bc537-6b31-44b1-9feb-e4d0dc36f6e7",
                  "ItemReference": "Win2016-VM2:Win2016-VM2",
                  "Name": "WIN2016-VM2",
                  "Message": "ActivityData queue's messages are not getting processed.",
                  "IsAckRequired": true,
                  "TypeUrl": "https://win2016-vm2/api/v2/enumSets/108/members/68",
                  "Priority": 95,
                  "TriggerValue": {
                    "value": "1233",
                    "unitsUrl": "https://win2016-vm2/api/v2/enumSets/507/members/95"
                  },
                  "CreationTime": "2020-01-12T11:54:30Z",
                  "IsAcknowledged": false,
                  "IsDiscarded": false,
                  "CategoryUrl": "https://win2016-vm2/api/v2/enumSets/33/members/12",
                  "ObjectUrl": "https://win2016-vm2/api/v2/objects/28bed6b0-4a0f-5bb0-a16f-57a7200685bb",
                  "AnnotationsUrl": "https://win2016-vm2/api/v2/alarms/ee7bc537-6b31-44b1-9feb-e4d0dc36f6e7/annotations"
                }
             Console Output: End */
            /* SNIPPET 1: END */
        }

        private void GetSingleAlarm_GetAlarmsForAnObject_GetAlarmsForNetworkDevice(AlarmItemProvider alarm, Guid objectId, AlarmFilter alarmFilter, MetasysObject device)
        {
            /* SNIPPET 2: START */
            AlarmItemProvider singleAlarm = client.Alarms.GetSingleAlarm(alarm.Id);
            PagedResult<AlarmItemProvider> objectAlarms = client.Alarms.GetAlarmsForAnObject(objectId, alarmFilter);
            PagedResult<AlarmItemProvider> deviceAlarms = client.Alarms.GetAlarmsForNetworkDevice(device.Id, alarmFilter);
            /* SNIPPET 2: END */
        }

        private void GetAlarmsAnnotation(AlarmItemProvider alarm)
        {
            /* SNIPPET 3: START */
            IEnumerable<AlarmAnnotation> annotations = client.Alarms.GetAlarmAnnotations(alarm.Id);
            AlarmAnnotation firstAnnotation = annotations.FirstOrDefault();
            Console.WriteLine(firstAnnotation);
            /*
            {
                "AlarmUrl": "https://win-ervotujej94/api/v2/alarms/f0f64d5c-b70e-8754-836c-1ac99182f4e4",
                "Text": "Test Annotation 00",
                "User": "metasyssysagent",
                "CreationTime": "2020-05-27T06:21:31Z",
                "Action": "none"
            } 
            */
            /* SNIPPET 3: END */
        }
        #endregion

        #region TRENDS
        private void GetTrendedAttributes_GetSamples()
        {
            /* SNIPPET 1: START */
            Guid trendedObjectId = client.GetObjectIdentifier("Win2016-VM2:vNAE2343701/Field Bus MSTP1.VAV-08.ZN-T");
            // Get attributes where trend extension is configured
            List<Attribute> trendedAttributes = client.Trends.GetTrendedAttributes(trendedObjectId);
            int attributeId = trendedAttributes[0].Id;
            TimeFilter timeFilter = new TimeFilter
            {
                StartTime = new DateTime(2020, 5, 12),
                EndTime = new DateTime(2020, 5, 13)
            };
            PagedResult<Sample> samplesPager = client.Trends.GetSamples(trendedObjectId, attributeId, timeFilter);
            // Prints the number of records fetched and paging information
            Console.WriteLine("Total:" + samplesPager.Total);
            Console.WriteLine("Current page:" + samplesPager.CurrentPage);
            Console.WriteLine("Page size:" + samplesPager.PageSize);
            Console.WriteLine("Pages:" + samplesPager.PageCount);
            /*                        
                Total:145
                Current page:1
                Page size:100
                Pages:2
             */
            Sample firstSample = samplesPager.Items.FirstOrDefault();
            Console.WriteLine(firstSample);
            /*                        
                {
                  "Value": 82.0,
                  "Unit": "deg F",
                  "Timestamp": "2020-05-12T05:00:00Z",
                  "IsReliable": true
                }
              */
            /* SNIPPET 1: END */
        }
        #endregion

        #region AUDITS
        private void GetAudits()
        {
            /* SNIPPET 1: START */
            AuditFilter auditFilter = new AuditFilter
            {
                StartTime = new DateTime(2019, 12, 12),
                EndTime = new DateTime(2020, 1, 12),
                OriginApplications = "6,1",
                ActionTypes = "5,0",
            };
            PagedResult<AuditItemProvider> auditsPager = client.Audits.GetAudits(auditFilter);
            // Prints the number of records fetched and paging information
            Console.WriteLine("Total:" + auditsPager.Total);
            Console.WriteLine("Current page:" + auditsPager.CurrentPage);
            Console.WriteLine("Page size:" + auditsPager.PageSize);
            Console.WriteLine("Pages:" + auditsPager.PageCount);
            /*                        
                Total:323
                Current page:1
                Page size:100
                Pages:4
             */
            AuditItemProvider audit = auditsPager.Items.FirstOrDefault();
            Console.WriteLine(audit);
            /*                        
                 {
                  "Id": "aab3a269-8aec-4be1-b3a6-761853442d56",
                  "CreationTime": "2020-01-10T13:52:53.547Z",
                  "ActionTypeUrl": "https://win2016-vm2/api/v2/enumsets/577/members/5",
                  "Discarded": false,
                  "StatusUrl": null,
                  "PreData": null,
                  "PostData": {
                    "unitUrl": null,
                    "precisionUrl": null,
                    "value": "::1",
                    "typeUrl": "https://win2016-vm2/api/v2/enumsets/501/members/7"
                  },
                  "Parameters": [],
                  "ErrorString": null,
                  "User": "MetasysSysAgent",
                  "Signature": null,
                  "ObjectUrl": "https://win2016-vm2/api/v2/objects/28bed6b0-4a0f-5bb0-a16f-57a7200685bb",
                  "AnnotationsUrl": "https://win2016-vm2/api/v2/audits/aab3a269-8aec-4be1-b3a6-761853442d56/annotations",
                  "Legacy": {
                    "fullyQualifiedItemReference": "Win2016-VM2:Win2016-VM2",
                    "itemName": "Win2016-VM2",
                    "classLevelUrl": "https://win2016-vm2/api/v2/enumsets/568/members/1",
                    "originApplicationUrl": "https://win2016-vm2/api/v2/enumsets/578/members/6",
                    "descriptionUrl": "https://win2016-vm2/api/v2/enumsets/580/members/41"
                  },
                  "Self": "https://win2016-vm2/api/v2/audits/aab3a269-8aec-4be1-b3a6-761853442d56"
                }
             */
            /* SNIPPET 1: END */
        }

        private void GetSingleAudit_GetAuditsForAnObject(AuditItemProvider audit, Guid objectId, AuditFilter auditFilter)
        {
            /* SNIPPET 2: START */
            AuditItemProvider singleAudit = client.Audits.GetSingleAudit(audit.Id);
            PagedResult<AuditItemProvider> objectAudits = client.Audits.GetAuditsForAnObject(objectId, auditFilter);
            /* SNIPPET 2: END */
        }
        #endregion

        public void Run()
        {
            try
            {
                /**** Common vars shared between different snippets: modify the following input according to your testing server *****/
                Guid objectId = new Guid("d5d96cd3-db4a-52e0-affd-8bc3393c30ec");
                Guid id1 = objectId;
                Guid id2 = new Guid("6c999f43-6007-5137-b6d3-c30b93fb70ec");
                List<Command> commands = client.GetCommands(objectId).ToList();
                string jsonSpace = @"{
                  ""ItemReference"": ""Win2016-VM2:Win2016-VM2/JCI.Building1"",
                  ""Id"": ""164aaba2-0fb3-5b5d-bfe9-49cf6b797c93"",
                  ""Name"": ""North America (BACnet)"",
                  ""Description"": null,
                  ""Type"": 2,
                  ""TypeUrl"": ""https://win2016-vm2/api/v2/enumSets/1766/members/1"",
                  ""Category"": ""Building"",
                  ""Children"": [],
                  ""ChildrenCount"": 0
                }";
                MetasysObject building = JsonConvert.DeserializeObject<MetasysObject>(jsonSpace);
                string jsonEquipment = @" {
                  ""ItemReference"": ""Win2016-VM2:Win2016-VM2/equipment.vNAE2343947.FieldBusMSTP1.AHU-07"",
                  ""Id"": ""6c6e18b8-015f-572a-814c-1e5d66142850"",
                  ""Name"": ""AHU-07"",
                  ""Description"": null,
                  ""Type"": 3,
                  ""TypeUrl"": null,
                  ""Category"": null,
                  ""Children"": [],
                  ""ChildrenCount"": 0
                }";
                MetasysObject sampleEquipment = JsonConvert.DeserializeObject<MetasysObject>(jsonEquipment);
                string jsonDevice = @"{
                  ""ItemReference"": ""Win2016-VM2:vNAE2343996"",
                  ""Id"": ""142558f8-c4c7-5f89-be97-d806adb72053"",
                  ""Name"": ""vNAE2343996"",
                  ""Description"": """",
                  ""Type"": null,
                  ""TypeUrl"": ""https://win2016-vm2/api/v2/enumSets/508/members/185"",
                ""Category"": null,
                  ""Children"": [],
                  ""ChildrenCount"": 0
                }";
                MetasysObject device = JsonConvert.DeserializeObject<MetasysObject>(jsonDevice);
                AlarmFilter alarmFilter = new AlarmFilter
                {
                    StartTime = new DateTime(2019, 12, 12),
                    EndTime = new DateTime(2020, 1, 12),
                    ExcludeAcknowledged = true
                };
                string jsonAlarm = @" {
                  ""Self"": ""https://win2016-vm2/api/v2/alarms/ee7bc537-6b31-44b1-9feb-e4d0dc36f6e7"",
                ""Id"": ""ee7bc537-6b31-44b1-9feb-e4d0dc36f6e7"",
                  ""ItemReference"": ""Win2016-VM2:Win2016-VM2"",
                  ""Name"": ""WIN2016-VM2"",
                  ""Message"": ""ActivityData queue's messages are not getting processed."",
                  ""IsAckRequired"": true,
                  ""TypeUrl"": ""https://win2016-vm2/api/v2/enumSets/108/members/68"",
                  ""Priority"": 95,
                  ""TriggerValue"": {
                    ""value"": ""1233"",
                    ""unitsUrl"": ""https://win2016-vm2/api/v2/enumSets/507/members/95""
                  },
                  ""CreationTime"": ""2020-01-12T11:54:30Z"",
                  ""IsAcknowledged"": false,
                  ""IsDiscarded"": false,
                  ""CategoryUrl"": ""https://win2016-vm2/api/v2/enumSets/33/members/12"",
                  ""ObjectUrl"": ""https://win2016-vm2/api/v2/objects/28bed6b0-4a0f-5bb0-a16f-57a7200685bb"",
                  ""AnnotationsUrl"": ""https://win2016-vm2/api/v2/alarms/ee7bc537-6b31-44b1-9feb-e4d0dc36f6e7/annotations""
                }";
                AlarmItemProvider alarm = JsonConvert.DeserializeObject<AlarmItemProvider>(jsonAlarm);
                AuditFilter auditFilter = new AuditFilter
                {
                    StartTime = new DateTime(2019, 12, 12),
                    EndTime = new DateTime(2020, 1, 12),
                    OriginApplications = "6,1",
                    ActionTypes = "5,0",
                };
                string jsonAudit = @"{
                  ""Id"": ""aab3a269-8aec-4be1-b3a6-761853442d56"",
                  ""CreationTime"": ""2020-01-10T13:52:53.547Z"",
                  ""ActionTypeUrl"": ""https://win2016-vm2/api/v2/enumsets/577/members/5"",
                  ""Discarded"": false,
                  ""StatusUrl"": null,
                  ""PreData"": null,
                  ""PostData"": {
                    ""unitUrl"": null,
                    ""precisionUrl"": null,
                    ""value"": ""::1"",
                    ""typeUrl"": ""https://win2016-vm2/api/v2/enumsets/501/members/7""
                  },
                  ""Parameters"": [],
                  ""ErrorString"": null,
                  ""User"": ""MetasysSysAgent"",
                  ""Signature"": null,
                  ""ObjectUrl"": ""https://win2016-vm2/api/v2/objects/28bed6b0-4a0f-5bb0-a16f-57a7200685bb"",
                  ""AnnotationsUrl"": ""https://win2016-vm2/api/v2/audits/aab3a269-8aec-4be1-b3a6-761853442d56/annotations"",
                  ""Legacy"": {
                    ""fullyQualifiedItemReference"": ""Win2016-VM2:Win2016-VM2"",
                    ""itemName"": ""Win2016-VM2"",
                    ""classLevelUrl"": ""https://win2016-vm2/api/v2/enumsets/568/members/1"",
                    ""originApplicationUrl"": ""https://win2016-vm2/api/v2/enumsets/578/members/6"",
                    ""descriptionUrl"": ""https://win2016-vm2/api/v2/enumsets/580/members/41""
                  },
                  ""Self"": ""https://win2016-vm2/api/v2/audits/aab3a269-8aec-4be1-b3a6-761853442d56""
                }";
                AuditItemProvider audit = JsonConvert.DeserializeObject<AuditItemProvider>(jsonAudit);
                /********************************************************************************************************************/
                while (true)
                {
                    PrintMenu();
                    Console.Write("\r\nSelect an option: ");
                    var option = Console.ReadLine();
                    Console.WriteLine();
                    switch (option)
                    {
                        case "1":
                            TryLogin_Refresh();
                            break;
                        case "2":
                            GetObjectIdentifier();
                            break;
                        case "3":
                            ReadProperty(objectId);
                            break;
                        case "4":
                            ReadPropertyMultiple(id1, id2);
                            break;
                        case "5":
                            WriteProperty();
                            break;
                        case "6":
                            WritePropertyMultiple(id1, id2);
                            break;
                        case "7":
                            GetCommands(objectId);
                            break;
                        case "8":
                            SendCommands(objectId, commands);
                            break;
                        case "9":
                            GetNetworkDeviceTypes_GetNetworkDevices();
                            break;
                        case "10":
                            GetObjects();
                            break;
                        case "11":
                            Localize();
                            break;
                        case "12":
                            GetSpaces();
                            break;
                        case "13":
                            GetSpaceTypes();
                            break;
                        case "14":
                            GetEquipment();
                            break;
                        case "15":
                            GetSpaceEquipment_GetSpaceChildren(building);
                            break;
                        case "16":
                            GetEquipmentPoints(sampleEquipment);
                            break;
                        case "17":
                            GetAlarms();
                            break;
                        case "18":
                            GetSingleAlarm_GetAlarmsForAnObject_GetAlarmsForNetworkDevice(alarm, objectId, alarmFilter, device);
                            break;
                        case "19":
                            GetAlarmsAnnotation(alarm);
                            break;
                        case "20":
                            GetTrendedAttributes_GetSamples();
                            break;
                        case "21":
                            GetAudits();
                            break;
                        case "22":
                            GetSingleAudit_GetAuditsForAnObject(audit, objectId, auditFilter);
                            break;
                        case "23":
                            return; // Exit from JSON output demo                            
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to return to the JSON output menu...");
                    Console.ReadLine();
                    Console.WriteLine();
                }
            }
            catch (Exception exception)
            {
                log.Logger.Error(string.Format("{0}", exception.Message));
                Console.WriteLine("\n \nAn Error occurred. Press Enter to return to Main Menu");
                Console.ReadLine();
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) TryLogin, Refresh");
            Console.WriteLine("2) GetObjectIdentifier");
            Console.WriteLine("3) ReadProperty");
            Console.WriteLine("4) ReadPropertyMultiple");
            Console.WriteLine("5) WriteProperty");
            Console.WriteLine("6) WritePropertyMultiple");
            Console.WriteLine("7) GetCommands");
            Console.WriteLine("8) SendCommand");
            Console.WriteLine("9) GetNetworkDeviceTypes, GetNetworkDevices");
            Console.WriteLine("10) GetObjects");
            Console.WriteLine("11) Localize");
            Console.WriteLine("12) GetSpaces");
            Console.WriteLine("13) GetSpaceTypes");
            Console.WriteLine("14) GetEquipment");
            Console.WriteLine("15) GetSpaceEquipment, GetSpaceChildren");
            Console.WriteLine("16) GetEquipmentPoints");
            Console.WriteLine("17) GetAlarms");
            Console.WriteLine("18) GetSingleAlarm, GetAlarmsForAnObject, GetAlarmsForNetworkDevice");
            Console.WriteLine("19) GetAlarmsAnnotation");
            Console.WriteLine("20) GetTrendedAttributes, GetSamples");
            Console.WriteLine("21) GetAudits");
            Console.WriteLine("22) GetSingleAudit, GetAuditsForAnObject");
            Console.WriteLine("23) Exit");
        }
    }
}
