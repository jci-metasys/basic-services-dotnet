using System;
using NUnit.Framework;
using JohnsonControls.Metasys.BasicServices;
using System.Globalization;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Tests
{
    public class MetasysModelTests
    {
        private const string Reliable = "reliabilityEnumSet.reliable";
        private const string PriorityNone = "writePriorityEnumSet.priorityNone";
        private const string Unsupported = "statusEnumSet.unsupportedObjectType";
        private const string Array = "dataTypeEnumSet.arrayDataType";
        private static readonly CultureInfo testCulture = new CultureInfo("en-US");
 
        [Test]
        public void TestAccessToken()
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
        public void TestCommand()
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
                    "}],",
                "\"minItems\": 3,",
                "\"maxItems\": 3 }");
            string commandCopy = String.Copy(command);
            Command cmd = new Command(JToken.Parse(command), testCulture);
            Command cmdCopy = new Command(JToken.Parse(commandCopy), testCulture);

            Assert.AreEqual(cmd.GetHashCode(), cmdCopy.GetHashCode());
            Assert.AreEqual(cmd, cmdCopy);
        }

        [Test]
        public void TestMetasysObject()
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
        }

        [Test]
        public void TestMetasysObjectType()
        {
            MetasysObjectType type = new MetasysObjectType(185, "objectTypeEnumSet.n50Class", 
                "NAE55-NIE59", testCulture);
            MetasysObjectType typeCopy = new MetasysObjectType(185, "objectTypeEnumSet.n50Class", 
                "NAE55-NIE59", testCulture);
            Assert.AreEqual(type.GetHashCode(), typeCopy.GetHashCode());
            Assert.AreEqual(type, typeCopy);
        }

        [Test]
        public void TestVariantArray()
        {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            Guid idCopy = new Guid("11111111-2222-3333-4444-555555555555");

            Variant v = new Variant(id, JArray.Parse("[ 0, 1, 2 ]"), "attr", testCulture);
            Variant vCopy = new Variant(idCopy, JArray.Parse("[ 0, 1, 2 ]"), "attr", testCulture);
            Assert.AreEqual(v.GetHashCode(), vCopy.GetHashCode());
            Assert.AreEqual(v, vCopy);
        }

        [Test]
        public void TestVariant()
        {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            Guid idCopy = new Guid("11111111-2222-3333-4444-555555555555");
            string data = string.Concat("{ ",
                "\"property\": \"stringvalue\",",
                "\"reliability\": \"", Reliable, "\",",
                "\"priority\": \"", PriorityNone, "\"}");
            string dataCopy = String.Copy(data);

            Variant v = new Variant(id, JToken.Parse(data), "attr", testCulture);
            Variant vCopy = new Variant(idCopy, JToken.Parse(dataCopy), "attr", testCulture);
            Assert.AreEqual(v.GetHashCode(), vCopy.GetHashCode());
            Assert.AreEqual(v, vCopy);
        }

        [Test]
        public void TestVariantMultiple()
        {
            Guid id = new Guid("11111111-2222-3333-4444-555555555555");
            Guid idCopy = new Guid("11111111-2222-3333-4444-555555555555");
            Variant v = new Variant(id, JToken.FromObject("stringvalue"), "attr", testCulture);
            Variant vCopy = new Variant(idCopy, JToken.FromObject("stringvalue"), "attr", testCulture);
            List<Variant> vlist = new List<Variant>() { v };
            List<Variant> vlistCopy = new List<Variant>() { vCopy };

            VariantMultiple vm = new VariantMultiple(id, vlist);
            VariantMultiple vmCopy = new VariantMultiple(id, vlistCopy);
            
            Assert.AreEqual(vm.GetHashCode(), vmCopy.GetHashCode());
            Assert.AreEqual(vm, vmCopy);
        }
    }
}