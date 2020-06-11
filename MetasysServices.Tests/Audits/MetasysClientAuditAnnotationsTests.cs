using JohnsonControls.Metasys.BasicServices;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Linq;
using System.Net.Http;

namespace MetasysServices.Tests
{
    /// <summary>
    /// Tests for Audit Annotations.
    /// </summary>

    public class MetasysClientAuditAnnotationsTests : MetasysClientTestsBase
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
        public void TestGetAuditAnnotationsOnePage()
        {
            var response = @"
                {
                    ""total"": 1,
                    ""next"": null,
                    ""previous"": null,
                    ""items"": [" + AuditAnnotation + @"],                                         
                    ""self"": ""https://win-ervotujej94/api/v2/audits/f0f64d5c-b70e-8754-836c-1ac99182f4e4/annotations?pageSize=100&page=1""
                }
            ";
            httpTest.RespondWith(response);

            var annotations = client.Audits.GetAnnotations(mockid);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/audits/{mockid}/annotations")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = JsonConvert.DeserializeObject<AuditAnnotation>(AuditAnnotation);
            Assert.AreEqual(expected, annotations.ElementAt(0));
        }

        [Test]
        public void TestAuditAnnotationMissingValuesThrowsException()
        {
            string AuditAnnotation = string.Concat("{",
                "\"text\": \"", "annotation test", "\",",
                "\"user\": \"metasyssysagent\"}");
            var response = @"
                {
                    ""total"": 1,
                    ""next"": null,
                    ""previous"": null,
                    ""items"": [" + AuditAnnotation + @"],                                         
                    ""self"": ""https://win-ervotujej94/api/v2/audits/f0f64d5c-b70e-8754-836c-1ac99182f4e4/annotations?pageSize=100&page=1""
                }
            ";
            httpTest.RespondWith(response);

            var e = Assert.Throws<MetasysObjectException>(() =>
                client.Audits.GetAnnotations(mockid));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/audits/{mockid}/annotations")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetAuditAnnotationsMissingValuesThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetAuditAnnotationsUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.Audits.GetAnnotations(mockid));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/audits/{mockid}/annotations")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetAuditAnnotationsUnauthorizedThrowsException: {e.Message}", true);
        }

    }
}
