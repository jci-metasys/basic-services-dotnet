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
            var alarms = client.Alarms.Get(new AlarmFilter { }); // No filter
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/alarms")
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
            ""items"": ["+Alarm+@"],
            ""self"": ""https://hostname/api/v2/alarms?pageSize=100&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=1&sort=creationTime""
            ";
            httpTest.RespondWith(response);

            var alarms = client.Alarms.Get(AlarmFilter);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/alarms")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = JsonConvert.DeserializeObject<Alarm>(Alarm);
            Assert.AreEqual(expected, alarms.Items.ElementAt(0));
        }

        [Test]
        public void TestGetAlarmsManyPages()
        {
            var response = @"{
            ""total"": 2,
            ""next"": ""https://hostname/api/v2/alarms?pageSize=1&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=2&sort=creationTime"",
            ""previous"": null,
            ""items"": [" +Alarm+@"],
            ""self"": ""https://hostname/api/v2/alarms?pageSize=1&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=1&sort=creationTime""
            ";
            httpTest
             .RespondWith(response);
            var alarms = client.Alarms.Get(AlarmFilter);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/alarms")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = JsonConvert.DeserializeObject<Alarm>(Alarm);
            Assert.AreEqual(expected, alarms.Items.ElementAt(0));
        }

        [Test]
        public void TestGetAlarmsWithType()
        {

            var response = @"{
            ""total"": 1,
            ""next"": ""https://hostname/api/v2/alarms?pageSize=1&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=2&sort=creationTime"",
            ""previous"": null,
            ""items"": [" + Alarm + @"],
            ""self"": ""https://hostname/api/v2/alarms?pageSize=1&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=1&sort=creationTime""
            ";
            httpTest.RespondWith(response);

            var alarms = client.Alarms.Get(new AlarmFilter { Type=71});

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/alarms")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = JsonConvert.DeserializeObject<Alarm>(Alarm);
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
            Assert.Throws<MetasysObjectException>(()=>client.Alarms.Get(new AlarmFilter { }));
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/alarms")
                .WithVerb(HttpMethod.Get)
                .Times(1);
        }

        [Test]
        public void TestAlarmMissingValuesThrowsException()
        {
            string Alarm= string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\"}");
            var response = @"{
            ""total"": 1,
            ""next"": null,
            ""previous"": null,
            ""items"": [" + Alarm + @"],
            ""self"": ""https://hostname/api/v2/alarms?pageSize=100&excludePending=false&excludeAcknowledged=false&excludeDiscarded=false&page=1&sort=creationTime""
            ";
            httpTest.RespondWith(response);

            var e = Assert.Throws<MetasysObjectException>(() => 
                client.Alarms.Get(new AlarmFilter { }));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/alarms")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetSpacesMissingValuesThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetAlarmsUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.Alarms.Get(new AlarmFilter { }));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/alarms")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetAlarmsUnauthorizedThrowsException: {e.Message}", true);
        }
    }
}
