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
            var token1 = new AccessToken("Bearer faketoken", dateTime);
            var token2 = new AccessToken("Bearer faketoken", dateTimeCopy);

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
            string commandCopy = String.Copy(command);
            Command cmd = new Command(JToken.Parse(command), testCulture);
            Command cmdCopy = new Command(JToken.Parse(commandCopy), testCulture);
            
            Assert.AreEqual(cmd.GetHashCode(), cmdCopy.GetHashCode());
            Assert.AreEqual(cmd, cmdCopy);
            Assert.NotNull(cmd.ToString());
        }

        [Test]
        public void TestMetasysObjectEqual()
        {
            string obj = string.Concat("{",
                "\"id\": \"11111111-2222-3333-4444-555555555555\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"description\": \"description\",",
                "\"typeUrl\": \"https://hostname/api/V2/enumSets/508/members/197\"}");
            string obj2 = string.Concat("{",
                "\"id\": \"11111111-2222-3333-4444-555555555556\",",
                "\"itemReference\": \"fully:qualified/reference2\",",
                "\"name\": \"name2\",",
                "\"description\": \"description2\",",
                "\"typeUrl\": \"https://hostname/api/V2/enumSets/508/members/197\"}");
            string objCopy = String.Copy(obj);
            MetasysObject child = new MetasysObject(JToken.Parse(obj2), null, testCulture);
            MetasysObject childCopy = new MetasysObject(JToken.Parse(obj2), null, testCulture);
            List<MetasysObject> childlist = new List<MetasysObject>() { child };
            List<MetasysObject> childlistCopy = new List<MetasysObject>() { childCopy };

            MetasysObject metObj = new MetasysObject(JToken.Parse(obj), childlist, testCulture);
            MetasysObject metObjCopy = new MetasysObject(JToken.Parse(objCopy), childlistCopy, testCulture);

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

        [Test]
        public void TestVariantArrayEqual()
        {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            Guid idCopy = new Guid("11111111-2222-3333-4444-555555555555");

            Variant v = new Variant(id, JArray.Parse("[ 0, 1, 2 ]"), "attr", testCulture);
            Variant vCopy = new Variant(idCopy, JArray.Parse("[ 0, 1, 2 ]"), "attr", testCulture);
            Assert.AreEqual(v.GetHashCode(), vCopy.GetHashCode());
            Assert.AreEqual(v, vCopy);
        }

        [Test]
        public void TestVariantEqual()
        {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            Guid idCopy = new Guid("11111111-2222-3333-4444-555555555555");
            string data = string.Concat("{ ",
                "\"value\": 23,",
                "\"reliability\": \"", Reliable, "\",",
                "\"priority\": \"", PriorityNone, "\"}");
            string dataCopy = String.Copy(data);

            Variant v = new Variant(id, JToken.Parse(data), "presentValue", testCulture);
            Variant vCopy = new Variant(idCopy, JToken.Parse(dataCopy), "presentValue", testCulture);
            Assert.AreEqual(v.GetHashCode(), vCopy.GetHashCode());
            Assert.AreEqual(v, vCopy);
        }

        [Test]
        public void TestVariantMultipleEqual()
        {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            Guid idCopy = new Guid("11111111-2222-3333-4444-555555555555");
            Variant v = new Variant(id, JToken.FromObject("stringvalue"), "attr", testCulture);
            Variant vCopy = new Variant(idCopy, JToken.FromObject("stringvalue"), "attr", testCulture);
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
            var token1 = new AccessToken("Bearer faketoken", dateTime1);
            var token2 = new AccessToken("Bearer faketokem", dateTime2);

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
            var token1 = new AccessToken("Bearer faketoken", dateTime1);
            var token2 = new AccessToken("Bearer faketoken", dateTime2);

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
            Command cmd1 = new Command(JToken.Parse(command1), testCulture);
            Command cmd2 = new Command(JToken.Parse(command2), testCulture);
            
            Assert.AreNotEqual(cmd1.GetHashCode(), cmd2.GetHashCode());
            Assert.AreNotEqual(cmd1, cmd2);
            Assert.AreNotEqual(cmd2, cmd1);
        }

        [Test]
        public void TestMetasysObjectDoesNotEqual()
        {
            string obj = string.Concat("{",
                "\"id\": \"11111111-2222-3333-4444-555555555555\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"description\": \"description\",",
                "\"typeUrl\": \"https://hostname/api/V2/enumSets/508/members/197\"}");
            string obj2 = string.Concat("{",
                "\"id\": \"11111111-2222-3333-4444-555555555556\",",
                "\"itemReference\": \"fully:qualified/reference2\",",
                "\"name\": \"name2\",",
                "\"description\": \"description2\",",
                "\"typeUrl\": \"https://hostname/api/V2/enumSets/508/members/197\"}");
            string obj3 = string.Concat("{",
                "\"id\": \"11111111-2222-3333-4444-555555555557\",",
                "\"itemReference\": \"fully:qualified/reference3\",",
                "\"name\": \"name3\",",
                "\"description\": \"description3\",",
                "\"typeUrl\": \"https://hostname/api/V2/enumSets/508/members/197\"}");

            MetasysObject child = new MetasysObject(JToken.Parse(obj3), null, testCulture);
            MetasysObject child2 = new MetasysObject(JToken.Parse(obj3), null, testCulture);
            List<MetasysObject> childlist = new List<MetasysObject>() { child };
            List<MetasysObject> childlist2 = new List<MetasysObject>() { child2 };

            MetasysObject metObj = new MetasysObject(JToken.Parse(obj), childlist, testCulture);
            MetasysObject metObj2 = new MetasysObject(JToken.Parse(obj2), childlist2, testCulture);
            MetasysObject metObj3 = new MetasysObject(JToken.Parse(obj), null, testCulture);
            MetasysObject metObj4 = new MetasysObject(JToken.Parse(obj2), null, testCulture);

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

        [Test]
        public void TestVariantArrayDoesNotEqual()
        {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            Guid id2 = new Guid("11111111-2222-3333-4444-555555555555");

            Variant v = new Variant(id, JArray.Parse("[ 0, 1, 2 ]"), "attr", testCulture);
            Variant v2 = new Variant(id2, JArray.Parse("[ 0, 1, 3 ]"), "attr", testCulture);
            Assert.AreNotEqual(v.GetHashCode(), v2.GetHashCode());
            Assert.AreNotEqual(v, v2);
        }

        [Test]
        public void TestVariantDoesNotEqual()
        {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            string data = string.Concat("{ ",
                "\"value\": 23,",
                "\"reliability\": \"", Reliable, "\",",
                "\"priority\": \"", PriorityNone, "\"}");
            string data2 = string.Concat("{ ",
                "\"value\": 23,",
                "\"reliability\": \"", Reliable, "\"}");
            string data3 = string.Concat("{ ",
                "\"value\": 24,",
                "\"reliability\": \"", Reliable, "\",",
                "\"priority\": \"", PriorityNone, "\"}");

            Variant v = new Variant(id, JToken.Parse(data), "presentValue", testCulture);
            Variant v2 = new Variant(id, JToken.Parse(data2), "presentValue", testCulture);
            Variant v3 = new Variant(id, JToken.Parse(data3), "presentValue", testCulture);
            Assert.AreNotEqual(v.GetHashCode(), v2.GetHashCode());
            Assert.AreNotEqual(v, v2);
            Assert.AreNotEqual(v.GetHashCode(), v3.GetHashCode());
            Assert.AreNotEqual(v, v3);
        }

        [Test]
        public void TestVariantMultipleDoesNotEqual()
        {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            Guid id2 = new Guid("11111111-2222-3333-4444-555555555555");
            Variant v = new Variant(id, JToken.FromObject("stringvalue"), "attr", testCulture);
            Variant v2 = new Variant(id2, JToken.FromObject("stringvalwe"), "attr", testCulture);
            List<Variant> vlist = new List<Variant>() { v };
            List<Variant> vlist2 = new List<Variant>() { v2 };

            VariantMultiple vm = new VariantMultiple(id, vlist);
            VariantMultiple vm2 = new VariantMultiple(id2, vlist2);
            
            Assert.AreNotEqual(vm.GetHashCode(), vm2.GetHashCode());
            Assert.AreNotEqual(vm, vm2);
        }
    }
}