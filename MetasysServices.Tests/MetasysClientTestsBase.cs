using Flurl.Http.Testing;
using JohnsonControls.Metasys.BasicServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MetasysServices.Tests
{
    public abstract class MetasysClientTestsBase
    {
        protected static readonly Guid mockid = new Guid("11111111-2222-3333-4444-555555555555");
        protected const string date1 = "2030-01-01T00:00:00Z";
        protected static readonly DateTime dateTime1 = DateTime.Parse(date1).ToUniversalTime();
        protected const string date2 = "2030-01-01T00:01:00Z";
        protected static readonly DateTime dateTime2 = DateTime.Parse(date2).ToUniversalTime();
        protected static readonly CultureInfo testCulture = new CultureInfo("en-US");

        protected MetasysClient client;
        protected HttpTest httpTest;

        [OneTimeSetUp]
        public void Init()
        {
            client = new MetasysClient("hostname", false, ApiVersion.V2, testCulture);
        }

        [SetUp]
        public void CreateHttpTest()
        {
            httpTest = new HttpTest();
        }

        [TearDown]
        public void DisposeHttpTest()
        {
            httpTest.Dispose();
        }

        /// <summary>
        /// Use this method to control the "dotnet test" console message printing.
        /// </summary>
        protected void PrintMessage(string message, bool isException)
        {
            Console.Error.WriteLine(message);
        }

        /// <summary>
        /// Use to setup client when the AccessToken is being tested.
        /// </summary>
        protected void CleanLogin()
        {
            httpTest.RespondWithJson(new { accessToken = "cleanfaketoken", expires = date1 });
            client.TryLogin("cleanusername", "cleanpassword");
        }
    }
}
