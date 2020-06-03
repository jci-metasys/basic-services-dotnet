using JohnsonControls.Metasys.BasicServices;
using JohnsonControls.Metasys.ComServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MetasysServicesCom.Tests
{
    [TestClass]
    public class ComMetasysClientFactoryTests
    {
        private InitializeMethod InitMethod;

        [TestInitialize]
        public void Init()
        {
            InitMethod = new InitializeMethod();
            InitMethod.MethodInitialize();
        }

        [TestMethod]
        [Description("Method for ComMetasysClientFactory")]
        public void GetLegacyClient_Success()
        {
            //Arrange
            var legacyClientMock = new Mock<ILegacyMetasysClient>();
            var comMetasysClientFactoryMock = new Mock<IComMetasysClientFactory>();
            comMetasysClientFactoryMock.Setup(m => m.GetLegacyClient("hostname", false, "v2", null, true)).Returns(legacyClientMock.Object);

            //Act
            var response = InitMethod.ComMetasysClientFactory.GetLegacyClient("hostname");

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [Description("Method for ComMetasysClientFactory with invalid version")]
        public void GetLegacyClient_InvalidVersion()
        {
            //Arrange
            var legacyClientMock = new Mock<ILegacyMetasysClient>();
            var comMetasysClientFactoryMock = new Mock<IComMetasysClientFactory>();
            comMetasysClientFactoryMock.Setup(m => m.GetLegacyClient("hostname", false, "v1", null, true)).Throws(new MetasysUnsupportedApiVersion("v1"));

            //Act
            void Act()
            {
                var res = InitMethod.ComMetasysClientFactory.GetLegacyClient("hostname", false, "v1", null);
            }

            //Assert
            Assert.ThrowsException<MetasysUnsupportedApiVersion>(Act, "Invalid Version");
        }
    }
}
