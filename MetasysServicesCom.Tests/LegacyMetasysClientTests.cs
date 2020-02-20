using JohnsonControls.Metasys.BasicServices;
using JohnsonControls.Metasys.ComServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MetasysServicesCom.Tests
{
    [TestClass]
    public class LegacyMetasysClientTests
    {
        private InitializeMethod InitMethod;
        private const string date = "2030-01-01T00:01:00Z";
        private static readonly DateTime dateTime = DateTime.Parse(date).ToUniversalTime();
        private static readonly string accessToken = "Bearer fakeLoginToken";
        private static readonly Guid mockid = new Guid("11111111-2222-3333-4444-555555555555");
        private static readonly Guid mockid2 = new Guid("11111111-2222-3333-4444-555555555556");
        private const string mockAttributeName = "property";
        private const string mockAttributeName2 = "property2";
        private const string mockAttributeName3 = "property3";
        private const string mockAttributeName4 = "property4";
        private const string mockAttributeName5 = "property5";

        [TestInitialize]
        public void Init()
        {
            InitMethod = new InitializeMethod();
            InitMethod.MethodInitialize();
        }

        #region Login

        [TestMethod]
        [Description("Login with correct credentials")]
        public void TryLogin_ReturnsSuccess()
        {
            //Arrange
            InitMethod.httpTest.RespondWithJson(new { accessToken = "fakeLoginToken", expires = dateTime });

            //Act
            var response = InitMethod.LClient.TryLogin("username", "password");

            //Assert
            Assert.AreEqual(response.Token, accessToken);
            Assert.AreEqual(response.Expires, dateTime);
        }

        [TestMethod]
        [Description("Login returns unauthorised")]
        public void TryLogin_ReturnsUnauthorised()
        {
            //Arrange
            InitMethod.httpTest.RespondWith("Unauthorised", 401);

            //Act
            void Act()
            {
                var response = InitMethod.LClient.TryLogin("username", "badpassword");
            }

            //Assert
            Assert.ThrowsException<MetasysHttpException>(Act, "UnAuthorised");
        }

        [TestMethod]
        [Description("Login returns BadHost")]
        public void TryLogin_ReturnsBadHost()
        {
            //Arrange
            InitMethod.httpTest.RespondWith("Call failed. No such host is known POST https://badhost/api/v2/login", 404);

            //Act
            void Act()
            {
                var response = InitMethod.LClient.TryLogin("username", "password");
            }

            //Assert
            Assert.ThrowsException<MetasysHttpNotFoundException>(Act, "BadHost");
        }

        [TestMethod]
        [Description("Login returns empty token")]
        public void TryLogin_ReturnsEmptyToken()
        {
            //Arrange
            InitMethod.httpTest.RespondWithJson(new { expires = dateTime });

            //Act
            void Act()
            {
                var response = InitMethod.LClient.TryLogin("username", "password");
            }

            //Assert
            Assert.ThrowsException<MetasysTokenException>(Act, "Token Missing");
        }

        [TestMethod]
        [Description("Login returns empty token")]
        public void TryLogin_ReturnsEmptyDateTime()
        {
            //Arrange
            InitMethod.httpTest.RespondWithJson(new { accessToken = "fakeLoginToken" });

            //Act
            void Act()
            {
                var response = InitMethod.LClient.TryLogin("username", "password");
            }

            //Assert
            Assert.ThrowsException<MetasysTokenException>(Act, "Expiry date missing");
        }

        #endregion

        #region GetObjectIdentifier

        [TestMethod]
        public void GetObjectIdentifer_RetursFqr()
        {
            //Arrange
            InitMethod.httpTest.RespondWith($"\"{mockid.ToString()}\"");

            //Act
            var id = InitMethod.LClient.GetObjectIdentifier("fully:qualified/reference1");

            //Assert
            Assert.AreEqual(id, mockid.ToString());
        }

        #endregion

        #region ReadProperty

        [TestMethod]
        public void ReadProperty()
        {
            //Arrange
            string json = "{\"item\": { \"" + mockAttributeName + "\": 1 }}";
            InitMethod.httpTest.RespondWith(json);

            //Act
            dynamic prop = InitMethod.LClient.ReadProperty(mockid.ToString(), mockAttributeName);

            //Assert
            Assert.AreEqual(prop.Attribute, mockAttributeName);
            Assert.AreEqual(prop.Id, mockid.ToString());
        }

        #endregion

        #region ReadPropertyMultiple

        [TestMethod]
        public void ReadPropertyMultiple()
        {
            //Arrange
            InitMethod.httpTest
                .RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }")
                .RespondWith("{\"item\": { \"" + mockAttributeName2 + "\": 1 }}");

            string[] ids = new string[1];
            ids[0] = mockid.ToString();

            string[] attributes = new string[2];
            attributes[0] = mockAttributeName;
            attributes[1] = mockAttributeName2;

            //Act
            dynamic properties = InitMethod.LClient.ReadPropertyMultiple(ids, attributes);

            //Assert
            Assert.IsInstanceOfType(properties, typeof(IComVariantMultiple[]));
            Assert.IsNotNull(properties);
            Assert.AreEqual(properties[0].Variants.Length, attributes.Length);
        }

        #endregion

        #region WriteProperty

        [TestMethod]
        public void WriteProperty()
        {
            //Arrange
            InitMethod.httpTest.RespondWith("Accepted", 202);

            //Act
            InitMethod.LClient.WriteProperty(mockid.ToString(), mockAttributeName, "newValue");
        }

        #endregion

        #region WritePropertyMultiple

        [TestMethod]
        public void WritePropertyMultiple()
        {
            //Arrange
            InitMethod.httpTest.RespondWith("Accepted", 202);

            string[] ids = new string[2];
            ids[0] = mockid.ToString();
            ids[1] = mockid2.ToString();

            string[] attributes = new string[2];
            attributes[0] = mockAttributeName;
            attributes[1] = mockAttributeName2;

            string[] attributeValue = new string[2];
            attributeValue[0] = "New Value1";
            attributeValue[1] = "New Value2";

            //Act
            InitMethod.LClient.WritePropertyMultiple(ids, attributes, attributeValue);
        }

        #endregion

        #region SendCommand

        [TestMethod]
        public void TestSendCommand()
        {
            //Arrange
            InitMethod.httpTest.RespondWith("OK", 200);
            string[] values = { "1", "2", "3" };

            //Act
            InitMethod.LClient.SendCommand(mockid.ToString(), "Adjust", values);
        }

        [TestMethod]
        public void TestSendCommandWithNullValues()
        {
            //Arrange
            InitMethod.httpTest.RespondWith("OK", 200);

            //Act
            InitMethod.LClient.SendCommand(mockid.ToString(), "Adjust", null);
        }

        #endregion

        #region GetCommands

        [TestMethod]
        public void TestGetCommands()
        {
            //Arrange
            string command1 = string.Concat("{\"$schema\": \"http://json-schema.org/schema#\",",
                "\"commandId\": \"Adjust\",",
                "\"title\": \"Adjust\",",
                "\"type\": \"array\",",
                "\"items\": [{",
                    "\"type\": \"number\",",
                    "\"title\": \"Value\",",
                    "\"minimum\": -20.0,",
                    "\"maximum\": 120.0",
                    "}],",
                "\"minItems\": 1,",
                "\"maxItems\": 1 }");
            InitMethod.httpTest.RespondWith(string.Concat("[", command1, "]"));

            //Act
            dynamic command = InitMethod.LClient.GetCommands(mockid.ToString());

            //Assert
            Assert.IsNotNull(command);
            Assert.IsInstanceOfType(command, typeof(IComCommand[]));
        }

        #endregion

        #region GetNetworkDevices

        [TestMethod]
        public void TestGetNetworkDevices()
        {
            //Arrange
            string device = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\",",
                "\"description\": \"none\",",
                "\"firmwareVersion\": \"4.0.0.1105\",",
                "\"ipAddress\": \"\"}");

            InitMethod.httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", device, "],",
                "\"self\": \"https://hostname/api/v2/networkDevices?page=1&pageSize=200&sort=name\"}"));

            //Act
            dynamic devices = InitMethod.LClient.GetNetworkDevices();

            //Assert
            Assert.AreEqual(devices[0].ItemReference, "fully:qualified/reference");
        }

        #endregion

        #region GetNetworkDevicesTypes

        [TestMethod]
        public void TestGetNetworkDeviceTypes()
        {
            //Arrange
            InitMethod.httpTest
               .RespondWith(string.Concat("{",
                   "\"total\": 1,",
                   "\"items\": [{",
                       "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/185\"",
                   "}],",
                   "\"self\": \"https://hostname/api/v2/networkDevices/availableTypes\"}"))
               .RespondWith(string.Concat("{",
                   "\"id\": 185,",
                   "\"description\": \"NAE55-NIE59\",",
                   "\"self\": \"https://hostname/api/v2/enumSets/508/members/185\",",
                   "\"setUrl\": \"https://hostname/api/v2/enumSets/508\"}"));

            //Act
            dynamic types = InitMethod.LClient.GetNetworkDeviceTypes();

            //Assert
            Assert.AreEqual(types[0].Description, "NAE55-NIE59");
        }

        #endregion

        #region GetObjects

        [TestMethod]
        public void TestGetObjects()
        {
            //Arrange
            string obj = string.Concat("{",
               "\"id\": \"", mockid, "\",",
               "\"itemReference\": \"fully:qualified/reference\",",
               "\"name\": \"name\",",
               "\"description\": \"description\",",
               "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\"}");
            InitMethod.httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", obj, "],",
                $"\"self\": \"https://hostname/api/v2/objects/{mockid}/objects?page=1&pageSize=200&sort=name\"}}"));

            //Act
            dynamic objects = InitMethod.LClient.GetObjects(mockid.ToString());

            //Assert
            Assert.AreEqual(objects[0].ItemReference, "fully:qualified/reference");
        }

        #endregion

        #region GetSpaces

        [TestMethod]
        public void TestGetSpaces()
        {
            //Arrange
            string space = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\",",
                $"\"self\": \"https://hostname/api/v2/spaces/{mockid}\"}}");
            InitMethod.httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", space, "],",
                "\"self\": \"https://hostname/api/v2/spaces?page=1&pageSize=200&sort=name\"}"));

            //Act
            dynamic spaces = InitMethod.LClient.GetSpaces();

            //Assert
            Assert.AreEqual(spaces[0].ItemReference, "fully:qualified/reference");
        }

        #endregion

        #region GetSpacesTypes

        [TestMethod]
        public void TestGetSpacesTypes()
        {
            //Arrange
            var item = string.Concat("{",
                    "\"id\": 3,",
                    "\"description\": \"Room\",",
                    "\"self\": \"https://hostname/api/v2/enumSets/1766/members/3\",",
                    "\"setUrl\": \"https://hostname/api/v2/enumSets/1766\"}");
            InitMethod.httpTest
                .RespondWith(string.Concat("{",
                    "\"total\": 1,",
                    $"\"items\": [{item}],",
                    "\"self\": \"https://hostname/api/v2/enumSet/1766\"}"));

            //Act
            dynamic types = InitMethod.LClient.GetSpaceTypes();

            //Assert
            Assert.AreEqual(types[0].Description, "Room");
        }

        #endregion

        #region GetEquipments

        [TestMethod]
        public void TestGetEquipments()
        {
            //Arrange
            string space = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\",",
                $"\"self\": \"https://hostname/api/v2/equipment/{mockid}\"}}");
            InitMethod.httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", space, "],",
                "\"self\": \"https://hostname/api/v2/equipment?page=1&pageSize=200&sort=name\"}"));

            //Act
            dynamic equipments = InitMethod.LClient.GetEquipment();

            //Assert
            Assert.AreEqual(equipments[0].ItemReference, "fully:qualified/reference");
        }

        #endregion
    }
}
