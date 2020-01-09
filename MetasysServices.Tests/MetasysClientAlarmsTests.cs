using JohnsonControls.Metasys.BasicServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace MetasysServices.Tests
{
    /// <summary>
    /// Tests for Alarms.
    /// </summary>
    public class MetasysClientAlarmsTests : MetasysClientTestsBase
    {
        /// <summary>
        /// Default alarm filter by one month.
        /// </summary>
        protected AlarmFilter alarmFilter = new AlarmFilter
        {
            StartTime = new DateTime(2019, 12, 12).ToString(),
            EndTime = new DateTime(2020, 1, 12).ToString()
        };

        // Sample alarm response pasted from Postman response
        protected string alarm = @"{
                ""self"": ""https://hostname/api/v2/alarms/ddbd866f-687f-41ac-b484-aa52669e7381"",
                ""id"": ""ddbd866f-687f-41ac-b484-aa52669e7381"",
                ""itemReference"": ""Win2016-VM2:vNAE2343947"",
                ""name"": ""vNAE2343947"",
                ""message"": ""Win2016-VM2:vNAE2343947 is offline"",
                ""isAckRequired"": true,
                ""typeUrl"": ""https://hostname/api/v2/enumSets/108/members/71"",
                ""priority"": 106,
                ""triggerValue"": {
                                ""value"": """",
                    ""unitsUrl"": ""https://hostname/api/v2/enumSets/507/members/95""
                },
                ""creationTime"": ""2019-08-07T17:47:38Z"",
                ""isAcknowledged"": false,
                ""isDiscarded"": false,
                ""categoryUrl"": ""https://hostname/api/v2/enumSets/33/members/5"",
                ""objectUrl"": ""https://hostname/api/v2/objects/4e24edf1-3503-5784-99bc-6bb4707d587d"",
                ""annotationsUrl"": ""https://hostname/api/v2/alarms/ddbd866f-687f-41ac-b484-aa52669e7381/annotations""
            }";
      


        [Test]
        public void TestGetAlarmsNone()
        {
            var response = @"{
            ""total"": 0,
            ""next"": null,
            ""previous"": null,
            ""items"": [],
            ""self"": ""https://hostname/api/v2/alarms?pageSize=100&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=1&sort=creationTime""
            ";
            httpTest.RespondWith(response);
            var alarms = client.GetAlarms(new AlarmFilter { }); // No filter
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/alarms")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, alarms.Items.Count());
        }

        [Test]
        public void TestGetAlarmsOnePage()
        {           
            var response = @"{
            ""total"": 1,
            ""next"": null,
            ""previous"": null,
            ""items"": ["+alarm+@"],
            ""self"": ""https://hostname/api/v2/alarms?pageSize=100&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=1&sort=creationTime""
            ";
            httpTest.RespondWith(response);

            var alarms = client.GetAlarms(alarmFilter);
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/alarms")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = JsonConvert.DeserializeObject<AlarmItemProvider>(alarm);
            Assert.AreEqual(expected, alarms.Items.ElementAt(0));
        }

        [Test]
        public void TestGetAlarmsManyPages()
        {           
            var response = @"{
            ""total"": 2,
            ""next"": ""https://hostname/api/v2/alarms?pageSize=1&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=2&sort=creationTime"",
            ""previous"": null,
            ""items"": [" +alarm+@"],
            ""self"": ""https://hostname/api/v2/alarms?pageSize=1&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=1&sort=creationTime""
            ";
            httpTest
             .RespondWith(response);           
            var alarms = client.GetAlarms(alarmFilter);
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/alarms")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = JsonConvert.DeserializeObject<AlarmItemProvider>(alarm);
            Assert.AreEqual(expected, alarms.Items.ElementAt(0));
        }

        [Test]
        public void TestGetAlarmsWithType()
        {

            var response = @"{
            ""total"": 1,
            ""next"": ""https://hostname/api/v2/alarms?pageSize=1&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=2&sort=creationTime"",
            ""previous"": null,
            ""items"": [" + alarm + @"],
            ""self"": ""https://hostname/api/v2/alarms?pageSize=1&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=1&sort=creationTime""
            ";
            httpTest.RespondWith(response);

            var alarms = client.GetAlarms(new AlarmFilter { Type=71});

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/alarms")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = JsonConvert.DeserializeObject<AlarmItemProvider>(alarm);
            Assert.AreEqual(expected, alarms.Items.ElementAt(0));
        }

        [Test]
        public void TestGetAlarmsMissingItems()
        {
            var response = @"{
            ""total"": 0,
            ""next"": null,
            ""previous"": null,
            ""items"": [{}],
            ""self"": ""https://hostname/api/v2/alarms?pageSize=1&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=1&sort=creationTime""
            ";
            httpTest.RespondWith(response);

            var devices = client.GetAlarms(new AlarmFilter { });

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/alarms")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, devices.Items.Count());
        }

        [Test]
        public void TestAlarmMissingValuesThrowsException()
        {
            string alarm= string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"typeUrl\": \"https://hostname/api/V2/enumSets/1766/members/3\"}");
            var response = @"{
            ""total"": 1,
            ""next"": null,
            ""previous"": null,
            ""items"": [" + alarm + @"],
            ""self"": ""https://hostname/api/v2/alarms?pageSize=100&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=1&sort=creationTime""
            ";
            httpTest.RespondWith(response);

            var e = Assert.Throws<MetasysObjectException>(() => // To do: Use Specific Exception for Alarm Item Provider
                client.GetAlarms(new AlarmFilter { }));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/alarms/alarms")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetSpacesMissingValuesThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetAlarmsUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.GetAlarms(new AlarmFilter { }));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/alarms")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetAlarmsUnauthorizedThrowsException: {e.Message}", true);    
        }
    }
}
