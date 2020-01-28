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
    /// Tests for Trends.
    /// </summary>
    public class MetasysClientSamplesTests : MetasysClientTestsBase
    {      
        [Test]
        public void TestGetSamplesNone()
        {
            var response = @"{
            ""total"": 0,
            ""next"": null,
            ""previous"": null,
            ""items"": [],
            ""self"": ""https://hostname/api/v2/objects/" + mockid + @"/attributes/85/samples?startTime=2020-01-20T15:37:46.413Z&endTime=2020-01-21T15:37:46.413Z&pageSize=1""
            }";
            httpTest.RespondWith(response);
            var samples = client.Trends.GetSamples(mockid, 85, TimeFilter); 
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/85/samples")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, samples.Items.Count());
            Assert.AreEqual(0, samples.Total);
        }

        [Test]
        public void TestGetSamplesNotFoundThrowsException()
        {
            httpTest.RespondWith("Not Found", 404);
            var e = Assert.Throws<MetasysHttpNotFoundException>(() =>
                                                                     client.Trends.GetSamples(mockid, 85, TimeFilter));
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/85/samples")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetSamplesNotFoundThrowsException: {e.Message}", true);
        }
       
        [Test]
        public void TestGetSamplesOnePage()
        {           
            var response = @"{
            ""total"": 1,
            ""next"": null,
            ""previous"": null,
            ""items"": ["+Sample1+ @"],
            ""self"": ""https://hostname/api/v2/objects/"+mockid+@"/attributes/85/samples?startTime=2020-01-20T15:37:46.413Z&endTime=2020-01-21T15:37:46.413Z&pageSize=1""
            ";
            httpTest.RespondWith(response);
            httpTest.RespondWith(Unit);
            var samples = client.Trends.GetSamples(mockid, 85, TimeFilter);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/85/samples")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            // Here the unit response is cached by Mane Page Method
            //httpTest.ShouldHaveCalled($"https://hostname/api/v2/enumSets/507/members/64")
            // .WithVerb(HttpMethod.Get) 
            // .Times(1);
            var responseObject = JToken.Parse(Sample1);
            var sample = new Sample
            {
                Value = responseObject["value"]["value"].Value<double>(),
                Unit = "deg F",
                IsReliable = responseObject["isReliable"].Value<bool>(),
                Timestamp = responseObject["timestamp"].Value<DateTime>()
            };
            Assert.AreEqual(sample, samples.Items.ElementAt(0));
        }

        [Test]
        public void TestGetSamplesManyPages()
        {           
            var response1 = @"{
            ""total"": 2,
            ""next"": ""https://hostname/api/v2/objects/" + mockid + @"/attributes/85/samples?startTime=2020-01-20T15:37:46.413Z&endTime=2020-01-21T15:37:46.413Z&pageSize=1&page=2"",            
            ""previous"": null,
            ""items"": [" +Sample1+ @"],
            ""self"": ""https://hostname/api/v2/objects/" + mockid + @"/attributes/85/samples?startTime=2020-01-20T15:37:46.413Z&endTime=2020-01-21T15:37:46.413Z&pageSize=1&page=1""
            ";
            var response2 = @"{
            ""total"": 2,
            ""next"": null,            
            ""previous"": ""https://hostname/api/v2/objects/" + mockid + @"/attributes/85/samples?startTime=2020-01-20T15:37:46.413Z&endTime=2020-01-21T15:37:46.413Z&pageSize=1&page=1"",
            ""items"": [" + Sample2 + @"],
            ""self"": ""https://hostname/api/v2/objects/" + mockid + @"/attributes/85/samples?startTime=2020-01-20T15:37:46.413Z&endTime=2020-01-21T15:37:46.413Z&pageSize=1&page=2""
            ";     
            httpTest.RespondWith(response1);
            httpTest.RespondWith(Unit);
            httpTest.RespondWith(response2);           
            var samplesPage1 = client.Trends.GetSamples(mockid, 85, TimeFilter);                      
            TimeFilter.Page = 2;
            var samplesPage2 = client.Trends.GetSamples(mockid, 85, TimeFilter);           
            TimeFilter.Page = 1;
            // Compare the two responses in multiple pages
            var responseObject1 = JToken.Parse(Sample1);
            var sample1 = new Sample
            {
                Value = responseObject1["value"]["value"].Value<double>(),
                Unit = "deg F",
                IsReliable = responseObject1["isReliable"].Value<bool>(),
                Timestamp = responseObject1["timestamp"].Value<DateTime>()
            };
            var responseObject2 = JToken.Parse(Sample2);
            var sample2 = new Sample
            {
                Value = responseObject2["value"]["value"].Value<double>(),
                Unit = "deg F",
                IsReliable = responseObject2["isReliable"].Value<bool>(),
                Timestamp = responseObject2["timestamp"].Value<DateTime>()
            };
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/85/samples")
               .WithVerb(HttpMethod.Get)
               .Times(2);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/enumSets/507/members/64")
            .WithVerb(HttpMethod.Get) // This is expected to be called once due to caching
            .Times(1);
            Assert.AreEqual(sample1, samplesPage1.Items.ElementAt(0));
            Assert.AreEqual(sample2, samplesPage2.Items.ElementAt(0));
        }
        
        [Test]
        public void TestGetSamplesMissingItems()
        {
            var response = @"{
            ""total"": 0,
            ""next"": null,
            ""previous"": null,
            ""items"": [{}],
            ""self"": ""https://hostname/api/v2/objects/" + mockid + @"/attributes/85/samples?startTime=2020-01-20T15:37:46.413Z&endTime=2020-01-21T15:37:46.413Z&pageSize=1&page=1""
            ";
            httpTest.RespondWith(response);         
            var e = Assert.Throws<MetasysObjectException>(() =>
            client.Trends.GetSamples(mockid, 85, TimeFilter));
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/85/samples")
                 .WithVerb(HttpMethod.Get)
                 .Times(1);
            PrintMessage($"TestGetSamplesMissingItemsThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetSamplesMissingValuesThrowsException()
        {
            string sample= string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\"}");
            var response = @"{
            ""total"": 1,
            ""next"": null,
            ""previous"": null,
            ""items"": [" + sample + @"],
            ""self"": ""https://hostname/api/v2/objects/" + mockid + @"/attributes/85/samples?startTime=2020-01-20T15:37:46.413Z&endTime=2020-01-21T15:37:46.413Z&pageSize=1&page=1""
            ";
            httpTest.RespondWith(response);           
            var e = Assert.Throws<MetasysObjectException>(() =>
              client.Trends.GetSamples(mockid, 85, TimeFilter));
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/85/samples")
                 .WithVerb(HttpMethod.Get)
                 .Times(1);
            PrintMessage($"TestGetSamplesMissingValuesThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetSamplesUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);
            var e = Assert.Throws<MetasysHttpException>(() =>
                                                             client.Trends.GetSamples(mockid, 85, TimeFilter));
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/85/samples")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetSamplesUnauthorizedThrowsException: {e.Message}", true);
        }
    }
}
