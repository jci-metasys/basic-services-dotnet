using System;
using NUnit.Framework;
using JohnsonControls.Metasys.BasicServices;
using System.Globalization;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections;

namespace MetasysServices.Tests
{
    public class MetasysModelTests
    {
        private const string Reliable = "reliabilityEnumSet.reliable";
        private const string PriorityNone = "writePriorityEnumSet.priorityNone";
        private const string Unsupported = "statusEnumSet.unsupportedObjectType";
        private const string Array = "dataTypeEnumSet.arrayDataType";
        private static readonly CultureInfo testCulture = new CultureInfo("en-US");

        [Test]
        public void TestAccessTokenEqual()
        {
            string date = "2030-01-01T00:00:00Z";
            DateTime dateTime = DateTime.Parse(date).ToUniversalTime();
            DateTime dateTimeCopy = DateTime.Parse(date).ToUniversalTime();
            var token1 = new AccessToken("fake_issuer", "fake_issued_to", "Bearer faketoken", dateTime);
            var token2 = new AccessToken("fake_issuer", "fake_issued_to", "Bearer faketoken", dateTimeCopy);

            Assert.AreEqual(token1.GetHashCode(), token2.GetHashCode());
            Assert.AreEqual(token1, token2);
        }

        [Test]
        public void TestCommandEqual()
        {
            string command = string.Concat("{\"$schema\": \"http://json-schema.org/schema#\",",
                "\"commandId\": \"Release\",",
                "\"title\": \"Release\",",
                "\"type\": \"array\",",
                "\"items\": [{",
                    "\"oneOf\": [{",
                        "\"const\": \"attributeEnumSet.presentValue\",",
                        "\"title\": \"Present Value\"}]",
                    "},",
                    "{\"oneOf\": [{",
                        "\"const\": \"writePriorityEnumSet.priorityNone\",",
                        "\"title\": \"0 (No Priority)\"},",
                        "{\"const\": \"writePriorityEnumSet.priorityManualEmergency\",",
                        "\"title\": \"1 (Manual Life Safety)\"}],",
                    "},",
                    "{\"type\": \"number\",",
                    "\"title\": \"Value\",",
                    "\"minimum\": -20.0,",
                    "\"maximum\": 120.0",
                    "},",
                    "{\"type\": \"number\",",
                    "\"title\": \"Value\",",
                    "\"minimum\": null,",
                    "\"maximum\": 120.0",
                    "},",
                    "{\"type\": \"number\",",
                    "\"title\": \"Value\",",
                    "\"minimum\": -20.0,",
                    "\"maximum\": null",
                    "},",
                    "{\"type\": \"number\",",
                    "\"title\": \"Value\",",
                    "\"minimum\": null,",
                    "\"maximum\": null",
                    "}],",
                "\"minItems\": 6,",
                "\"maxItems\": 6 }");
            string commandCopy = command.Clone().ToString();
            Command cmd = new Command(JToken.Parse(command), testCulture, ApiVersion.v2);
            Command cmdCopy = new Command(JToken.Parse(commandCopy), testCulture, ApiVersion.v2);

            Assert.AreEqual(cmd.GetHashCode(), cmdCopy.GetHashCode());
            Assert.AreEqual(cmd, cmdCopy);
            Assert.NotNull(cmd.ToString());
        }

        [TestCase(ApiVersion.v2)]
        [TestCase(ApiVersion.v3)]
        public void TestMetasysObjectEqual(ApiVersion version) {
            string obj, obj2;
            if (version < ApiVersion.v3) {
                obj = string.Concat("{",
                    "\"id\": \"11111111-2222-3333-4444-555555555555\",",
                    "\"itemReference\": \"fully:qualified/reference\",",
                    "\"name\": \"name\",",
                    "\"description\": \"description\",",
                    $"\"typeUrl\": \"https://hostname/api/{version}/enumSets/508/members/197\"}}");
                obj2 = string.Concat("{",
                    "\"id\": \"11111111-2222-3333-4444-555555555556\",",
                    "\"itemReference\": \"fully:qualified/reference2\",",
                    "\"name\": \"name2\",",
                    "\"description\": \"description2\",",
                    $"\"typeUrl\": \"https://hostname/api/{version}/enumSets/508/members/197\"}}");
            } else {
                obj = string.Concat("{",
                    "\"id\": \"11111111-2222-3333-4444-555555555555\",",
                    "\"itemReference\": \"fully:qualified/reference\",",
                    "\"name\": \"name\",",
                    "\"description\": \"description\",",
                    $"\"type\": \"https://hostname/api/{version}/enumSets/508/members/197\"}}");
                obj2 = string.Concat("{",
                    "\"id\": \"11111111-2222-3333-4444-555555555556\",",
                    "\"itemReference\": \"fully:qualified/reference2\",",
                    "\"name\": \"name2\",",
                    "\"description\": \"description2\",",
                    $"\"type\": \"https://hostname/api/{version}/enumSets/508/members/197\"}}");
            }
            string objCopy = obj.Clone().ToString();
            MetasysObject child = new MetasysObject(JToken.Parse(obj2), version, null, testCulture);
            MetasysObject childCopy = new MetasysObject(JToken.Parse(obj2), version, null, testCulture);
            List<MetasysObject> childlist = new List<MetasysObject>() { child };
            List<MetasysObject> childlistCopy = new List<MetasysObject>() { childCopy };

            MetasysObject metObj = new MetasysObject(JToken.Parse(obj), version, childlist, testCulture);
            MetasysObject metObjCopy = new MetasysObject(JToken.Parse(objCopy), version, childlistCopy, testCulture);

            Assert.AreEqual(metObj.GetHashCode(), metObjCopy.GetHashCode());
            Assert.AreEqual(metObj, metObjCopy);
            Assert.NotNull(metObj.ToString());
        }

        [Test]
        public void TestMetasysObjectTypeEqual()
        {
            MetasysObjectType type = new MetasysObjectType(185, "objectTypeEnumSet.n50Class",
                "NAE55-NIE59", testCulture);
            MetasysObjectType typeCopy = new MetasysObjectType(185, "objectTypeEnumSet.n50Class",
                "NAE55-NIE59", testCulture);
            Assert.AreEqual(type.GetHashCode(), typeCopy.GetHashCode());
            Assert.AreEqual(type, typeCopy);
        }

        [TestCase(ApiVersion.v2)]
        [TestCase(ApiVersion.v3)]
        public void TestVariantArrayEqual(ApiVersion version) {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            Guid idCopy = new Guid("11111111-2222-3333-4444-555555555555");
            string json1, json2;
            if (version < ApiVersion.v3) {
                json1 = "{\"item\": { \"" + "attr" + "\": [ 0, 1, 2 ] }}";
                json2 = "{\"item\": { \"" + "attr" + "\": [ 0, 1, 2 ] }}";
            } else {
                json1 = "{\"item\": { \"" + "attr" + "\": [ 0, 1, 2 ] }}";
                json2 = "{\"item\": { \"" + "attr" + "\": [ 0, 1, 2 ] }}";
            }
            Variant v = new Variant(id, JToken.Parse(json1), "attr", testCulture, version);
            Variant vCopy = new Variant(idCopy, JToken.Parse(json2), "attr", testCulture, version);
            Assert.AreEqual(v.GetHashCode(), vCopy.GetHashCode());
            Assert.AreEqual(v, vCopy);
        }

        [TestCase(ApiVersion.v2)]
        [TestCase(ApiVersion.v3)]
        public void TestVariantEqual(ApiVersion version) {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            Guid idCopy = new Guid("11111111-2222-3333-4444-555555555555");
            string data;
            if (version < ApiVersion.v3) {
                data = @"{
                    ""item"": {
                        ""presentValue"": {
                                ""value"": 23,
                            ""reliability"": ""reliabilityEnumSet.reliable"",
                            ""priority"": ""writePriorityEnumSet.priorityDefault""
                        }
                        }
                    }";
            } else {
                data = @"{
                    ""item"": {
                        ""presentValue"": {
                                ""value"": 23,
                            ""reliability"": ""reliabilityEnumSet.reliable"",
                            ""priority"": ""writePriorityEnumSet.priorityDefault""
                        }
                        }
                    }";
            }
            string dataCopy = data.Clone().ToString();

            Variant v = new Variant(id, JToken.Parse(data), "presentValue", testCulture, version);
            Variant vCopy = new Variant(idCopy, JToken.Parse(dataCopy), "presentValue", testCulture, version);
            Assert.AreEqual(v.GetHashCode(), vCopy.GetHashCode());
            Assert.AreEqual(v, vCopy);
        }

        [TestCase(ApiVersion.v2)]
        [TestCase(ApiVersion.v3)]
        public void TestVariantMultipleEqual(ApiVersion version) {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            Guid idCopy = new Guid("11111111-2222-3333-4444-555555555555");
            string json;
            if (version < ApiVersion.v3) {
                json = @"{
                    ""item"": {
                        ""attr"": ""stringvalue""
                        }
                    }";
            } else {
                json = @"{
                    ""item"": {
                        ""attr"": ""stringvalue""
                        }
                    }";
            }
            Variant v = new Variant(id, JToken.Parse(json), "attr", testCulture, version);
            Variant vCopy = new Variant(idCopy, JToken.Parse(json), "attr", testCulture, version);
            List<Variant> vlist = new List<Variant>() { v };
            List<Variant> vlistCopy = new List<Variant>() { vCopy };

            VariantMultiple vm = new VariantMultiple(id, vlist);
            VariantMultiple vmCopy = new VariantMultiple(idCopy, vlistCopy);

            Assert.AreEqual(vm.GetHashCode(), vmCopy.GetHashCode());
            Assert.AreEqual(vm, vmCopy);
        }

        [Test]
        public void TestAccessTokenDoesNotEqualToken()
        {
            string date = "2030-01-01T00:00:00Z";
            DateTime dateTime1 = DateTime.Parse(date).ToUniversalTime();
            DateTime dateTime2 = DateTime.Parse(date).ToUniversalTime();
            var token1 = new AccessToken("fake_issuer1", "fake_issued_to1","Bearer faketoken", dateTime1);
            var token2 = new AccessToken("fake_issuer2", "fake_issued_to2","Bearer faketokem", dateTime2);
            Assert.AreNotEqual(token1.GetHashCode(), token2.GetHashCode());
            Assert.AreNotEqual(token1, token2);
        }

        [Test]
        public void TestAccessTokenDoesNotEqualTime()
        {
            string date1 = "2030-01-01T00:00:00Z";
            string date2 = "2030-01-01T00:00:01Z";
            DateTime dateTime1 = DateTime.Parse(date1).ToUniversalTime();
            DateTime dateTime2 = DateTime.Parse(date2).ToUniversalTime();
            var token1 = new AccessToken("fake_issuer", "fake_issued_to","Bearer faketoken", dateTime1);
            var token2 = new AccessToken("fake_issuer", "fake_issued_to","Bearer faketoken", dateTime2);

            Assert.AreNotEqual(token1.GetHashCode(), token2.GetHashCode());
            Assert.AreNotEqual(token1, token2);
        }

        [Test]
        public void TestCommandDoesNotEqualValue()
        {
            string command1 = string.Concat("{\"$schema\": \"http://json-schema.org/schema#\",",
                "\"commandId\": \"Release\",",
                "\"title\": \"Release\",",
                "\"type\": \"array\",",
                "\"items\": [{",
                    "\"type\": \"number\",",
                    "\"title\": \"Value\",",
                    "\"minimum\": 0,",
                    "\"maximum\": 100",
                    "}],",
                "\"minItems\": 1,",
                "\"maxItems\": 1 }");
            string command2 = string.Concat("{\"$schema\": \"http://json-schema.org/schema#\",",
                "\"commandId\": \"Release\",",
                "\"title\": \"Release\",",
                "\"type\": \"array\",",
                "\"items\": [{",
                    "\"type\": \"number\",",
                    "\"title\": \"Value\",",
                    "\"minimum\": null,",
                    "\"maximum\": null",
                    "}],",
                "\"minItems\": 1,",
                "\"maxItems\": 1 }");
            Command cmd1 = new Command(JToken.Parse(command1), testCulture, ApiVersion.v2);
            Command cmd2 = new Command(JToken.Parse(command2), testCulture, ApiVersion.v2);

            Assert.AreNotEqual(cmd1.GetHashCode(), cmd2.GetHashCode());
            Assert.AreNotEqual(cmd1, cmd2);
            Assert.AreNotEqual(cmd2, cmd1);
        }

        [TestCase(ApiVersion.v2)]
        [TestCase(ApiVersion.v3)]
        public void TestMetasysObjectDoesNotEqual(ApiVersion version) {
            string obj, obj2, obj3;
            if (version < ApiVersion.v3) {
                obj = string.Concat("{",
                    "\"id\": \"11111111-2222-3333-4444-555555555555\",",
                    "\"itemReference\": \"fully:qualified/reference\",",
                    "\"name\": \"name\",",
                    "\"description\": \"description\",",
                    $"\"typeUrl\": \"https://hostname/api/{version}/enumSets/508/members/197\"}}");
                obj2 = string.Concat("{",
                    "\"id\": \"11111111-2222-3333-4444-555555555556\",",
                    "\"itemReference\": \"fully:qualified/reference2\",",
                    "\"name\": \"name2\",",
                    "\"description\": \"description2\",",
                    $"\"typeUrl\": \"https://hostname/api/{version}/enumSets/508/members/197\"}}");
                obj3 = string.Concat("{",
                    "\"id\": \"11111111-2222-3333-4444-555555555557\",",
                    "\"itemReference\": \"fully:qualified/reference3\",",
                    "\"name\": \"name3\",",
                    "\"description\": \"description3\",",
                    $"\"typeUrl\": \"https://hostname/api/{version}/enumSets/508/members/197\"}}");
            } else {
                obj = string.Concat("{",
                    "\"id\": \"11111111-2222-3333-4444-555555555555\",",
                    "\"itemReference\": \"fully:qualified/reference\",",
                    "\"name\": \"name\",",
                    "\"description\": \"description\",",
                    $"\"type\": \"https://hostname/api/{version}/enumSets/508/members/197\"}}");
                obj2 = string.Concat("{",
                    "\"id\": \"11111111-2222-3333-4444-555555555556\",",
                    "\"itemReference\": \"fully:qualified/reference2\",",
                    "\"name\": \"name2\",",
                    "\"description\": \"description2\",",
                    $"\"type\": \"https://hostname/api/{version}/enumSets/508/members/197\"}}");
                obj3 = string.Concat("{",
                    "\"id\": \"11111111-2222-3333-4444-555555555557\",",
                    "\"itemReference\": \"fully:qualified/reference3\",",
                    "\"name\": \"name3\",",
                    "\"description\": \"description3\",",
                    $"\"type\": \"https://hostname/api/{version}/enumSets/508/members/197\"}}");
            }
            MetasysObject child = new MetasysObject(JToken.Parse(obj3), version, null, testCulture);
            MetasysObject child2 = new MetasysObject(JToken.Parse(obj3), version, null, testCulture);
            List<MetasysObject> childlist = new List<MetasysObject>() { child };
            List<MetasysObject> childlist2 = new List<MetasysObject>() { child2 };

            MetasysObject metObj = new MetasysObject(JToken.Parse(obj), version, childlist, testCulture);
            MetasysObject metObj2 = new MetasysObject(JToken.Parse(obj2), version, childlist2, testCulture);
            MetasysObject metObj3 = new MetasysObject(JToken.Parse(obj), version, null, testCulture);
            MetasysObject metObj4 = new MetasysObject(JToken.Parse(obj2), version, null, testCulture);

            Assert.AreNotEqual(metObj.GetHashCode(), metObj2.GetHashCode());
            Assert.AreNotEqual(metObj, metObj2);
            Assert.AreNotEqual(metObj3.GetHashCode(), metObj4.GetHashCode());
            Assert.AreNotEqual(metObj3, metObj4);
        }

        [Test]
        public void TestMetasysObjectTypeDoesNotEqual()
        {
            MetasysObjectType type = new MetasysObjectType(185, "objectTypeEnumSet.n50Class",
                "NAE55-NIE59", testCulture);
            MetasysObjectType type2 = new MetasysObjectType(195, "objectTypeEnumSet.fieldBusClass",
                "Field Bus MSTP", testCulture);
            Assert.AreNotEqual(type.GetHashCode(), type2.GetHashCode());
            Assert.AreNotEqual(type, type2);
        }

        [TestCase(ApiVersion.v2)]
        [TestCase(ApiVersion.v3)]
        public void TestVariantArrayDoesNotEqual(ApiVersion version) {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            Guid id2 = new Guid("11111111-2222-3333-4444-555555555555");

            string json1, json2;
            if (version < ApiVersion.v3) {
                json1 = "{\"item\": { \"" + "attr" + "\": [ 0, 1, 2 ] }}";
                json2 = "{\"item\": { \"" + "attr" + "\": [ 0, 1, 3 ] }}";
            } else {
                json1 = "{\"item\": { \"" + "attr" + "\": [ 0, 1, 2 ] }}";
                json2 = "{\"item\": { \"" + "attr" + "\": [ 0, 1, 3 ] }}";
            }
            Variant v = new Variant(id, JToken.Parse(json1), "attr", testCulture, version);
            Variant v2 = new Variant(id2, JToken.Parse(json2), "attr", testCulture, version);
            Assert.AreNotEqual(v.GetHashCode(), v2.GetHashCode());
            Assert.AreNotEqual(v, v2);
        }

        [TestCase(ApiVersion.v2)]
        [TestCase(ApiVersion.v3)]
        public void TestVariantDoesNotEqual(ApiVersion version) {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            string data, data2, data3;
            if (version < ApiVersion.v3) {
                data = @"{
                ""item"": {
                    ""presentValue"": {
                            ""value"": 23,
                        ""reliability"": ""reliabilityEnumSet.reliable"",
                        ""priority"": ""writePriorityEnumSet.priorityDefault""
                    }
                    }
                }";
                data2 = @"{
                    ""item"": {
                        ""presentValwe"": {
                                ""value"": 23,
                            ""reliability"": ""reliabilityEnumSet.reliable""
                        }
                        }
                    }";
                data3 = @"{
                    ""item"": {
                        ""presentValwe"": {
                                ""value"": 24,
                            ""reliability"": ""reliabilityEnumSet.reliable"",
                            ""priority"": ""writePriorityEnumSet.priorityDefault""
                        }
                        }
                    }";
            } else {
                data = @"{
                ""item"": {
                    ""presentValue"": {
                            ""value"": 23,
                        ""reliability"": ""reliabilityEnumSet.reliable"",
                        ""priority"": ""writePriorityEnumSet.priorityDefault""
                    }
                    }
                }";
                data2 = @"{
                    ""item"": {
                        ""presentValwe"": {
                                ""value"": 23,
                            ""reliability"": ""reliabilityEnumSet.reliable""
                        }
                        }
                    }";
                data3 = @"{
                    ""item"": {
                        ""presentValwe"": {
                                ""value"": 24,
                            ""reliability"": ""reliabilityEnumSet.reliable"",
                            ""priority"": ""writePriorityEnumSet.priorityDefault""
                        }
                        }
                    }";
            }

            Variant v = new Variant(id, JToken.Parse(data), "presentValue", testCulture, version);
            Variant v2 = new Variant(id, JToken.Parse(data2), "presentValue", testCulture, version);
            Variant v3 = new Variant(id, JToken.Parse(data3), "presentValue", testCulture, version);
            Assert.AreNotEqual(v.GetHashCode(), v2.GetHashCode());
            Assert.AreNotEqual(v, v2);
            Assert.AreNotEqual(v.GetHashCode(), v3.GetHashCode());
            Assert.AreNotEqual(v, v3);
        }

        [TestCase(ApiVersion.v2)]
        [TestCase(ApiVersion.v3)]
        public void TestVariantMultipleDoesNotEqual(ApiVersion version) {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            Guid id2 = new Guid("11111111-2222-3333-4444-555555555555");
            string json1, json2;
            if (version < ApiVersion.v3) {
                json1 = @"{
                    ""item"": {
                        ""attr"": ""stringvalue""
                        }
                    }";
                json2 = @"{
                    ""item"": {
                        ""attr"": ""stringvalwe""
                        }
                    }";
            } else {
                json1 = @"{
                    ""item"": {
                        ""attr"": ""stringvalue""
                        }
                    }";
                json2 = @"{
                    ""item"": {
                        ""attr"": ""stringvalwe""
                        }
                    }";
            }
            Variant v = new Variant(id, JToken.Parse(json1), "attr", testCulture, version);
            Variant v2 = new Variant(id2, JToken.Parse(json2), "attr", testCulture, version);
            List<Variant> vlist = new List<Variant>() { v };
            List<Variant> vlist2 = new List<Variant>() { v2 };

            VariantMultiple vm = new VariantMultiple(id, vlist);
            VariantMultiple vm2 = new VariantMultiple(id2, vlist2);

            Assert.AreNotEqual(vm.GetHashCode(), vm2.GetHashCode());
            Assert.AreNotEqual(vm, vm2);
        }
    }
}