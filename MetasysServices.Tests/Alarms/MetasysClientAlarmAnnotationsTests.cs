using JohnsonControls.Metasys.BasicServices;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MetasysServices.Tests
{
    /// <summary>
    /// Tests for Alarm Annotations.
    /// </summary>
    public class MetasysClientAlarmAnnotationsTests : MetasysClientTestsBase
    {
             
        [Test]
        public void TestGetAlarmAnnotationsNone()
        {
            var response = @"{
                    ""total"": 1,
                    ""next"": null,
                    ""previous"": null,
                    ""items"": [],
                    ""self"": ""https://win-ervotujej94/api/v2/alarms/f0f64d5c-b70e-8754-836c-1ac99182f4e4/annotations?pageSize=100&page=1""
                }";
            httpTest.RespondWith(response);
            var annotations = client.Alarms.GetAnnotations(mockid);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/alarms/{mockid}/annotations")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, annotations.Count());
        }
     
        [Test]
        public void TestGetAlarmAnnotationsOnePage()
        {
            var response = @"
                {
                    ""total"": 1,
                    ""next"": null,
                    ""previous"": null,
                    ""items"": [" + AlarmAnnotation + @"],
                    ""self"": ""https://win-ervotujej94/api/v2/alarms/f0f64d5c-b70e-8754-836c-1ac99182f4e4/annotations?pageSize=100&page=1""
                }
            ";
            httpTest.RespondWith(response);

            var annotations = client.Alarms.GetAnnotations(mockid);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/alarms/{mockid}/annotations")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = JsonConvert.DeserializeObject<AlarmAnnotation>(AlarmAnnotation);
            Assert.AreEqual(expected, annotations.ElementAt(0));
        }             

        [Test]
        public void TestAlarmAnnotationMissingValuesThrowsException()
        {
            string AlarmAnnotation= string.Concat("{",
                "\"text\": \"", "annotation test", "\",",
                "\"user\": \"metasyssysagent\"}");
            var response = @"
                {
                    ""total"": 1,
                    ""next"": null,
                    ""previous"": null,
                    ""items"": [" + AlarmAnnotation + @"],
                    ""self"": ""https://win-ervotujej94/api/v2/alarms/f0f64d5c-b70e-8754-836c-1ac99182f4e4/annotations?pageSize=100&page=1""
                }
            ";
            httpTest.RespondWith(response);
           
            var e = Assert.Throws<MetasysObjectException>(() => 
                client.Alarms.GetAnnotations(mockid));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/alarms/{mockid}/annotations")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetAlarmAnnotationsMissingValuesThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetAlarmAnnotationsUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.Alarms.GetAnnotations(mockid));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/alarms/{mockid}/annotations")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetAlarmAnnotationsUnauthorizedThrowsException: {e.Message}", true);
        }
    }
}
