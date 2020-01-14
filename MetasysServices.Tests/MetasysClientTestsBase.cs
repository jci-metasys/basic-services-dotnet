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

        /// <summary>
        /// Default alarm filter by one month.
        /// </summary>
        protected AlarmFilter AlarmFilter = new AlarmFilter
        {
            StartTime = new DateTime(2019, 12, 12).ToString(),
            EndTime = new DateTime(2020, 1, 12).ToString()
        };

        // Sample alarm response pasted from Postman response
        protected string Alarm = @"{
                ""self"": ""https://win2016-vm2/api/v2/alarms/ddbd866f-687f-41ac-b484-aa52669e7381"",
                ""id"": ""ddbd866f-687f-41ac-b484-aa52669e7381"",
                ""itemReference"": ""Win2016-VM2:vNAE2343947"",
                ""name"": ""vNAE2343947"",
                ""message"": ""Win2016-VM2:vNAE2343947 is offline"",
                ""isAckRequired"": true,
                ""typeUrl"": ""https://win2016-vm2/api/v2/enumSets/108/members/71"",
                ""priority"": 106,
                ""triggerValue"": {
                                ""value"": """",
                    ""unitsUrl"": ""https://win2016-vm2/api/v2/enumSets/507/members/95""
                },
                ""creationTime"": ""2019-08-07T17:47:38Z"",
                ""isAcknowledged"": false,
                ""isDiscarded"": false,
                ""categoryUrl"": ""https://win2016-vm2/api/v2/enumSets/33/members/5"",
                ""objectUrl"": ""https://win2016-vm2/api/v2/objects/4e24edf1-3503-5784-99bc-6bb4707d587d"",
                ""annotationsUrl"": ""https://win2016-vm2/api/v2/alarms/ddbd866f-687f-41ac-b484-aa52669e7381/annotations""
            }";


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
