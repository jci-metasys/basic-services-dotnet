using JohnsonControls.Metasys.BasicServices;
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

        [TestInitialize]
        public void Init()
        {
            InitMethod = new InitializeMethod();
            InitMethod.MethodInitialize();
        }

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
            Assert.ThrowsException<MetasysHttpException>(Act,"UnAuthorised");
        }

        [TestMethod]
        [Description("Login returns BadHost")]
        public void TryLogin_ReturnsBadHost()
        {
            //Arrange
            InitMethod.httpTest.RespondWith("Call failed. No such host is known POST https://badhost/api/V2/login", 404);

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
    }
}
