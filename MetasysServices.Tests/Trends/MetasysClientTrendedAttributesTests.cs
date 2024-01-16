
using JohnsonControls.Metasys.BasicServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using MetasysAttribute = JohnsonControls.Metasys.BasicServices.MetasysAttribute;

namespace MetasysServices.Tests
{
    /// <summary>
    /// Tests for Trends.
    /// </summary>
    public class MetasysClientTrendedAttributesTests : MetasysClientTestsBase
    {      
        [Test]
        public void TestGetTrendedAttributesNone()
        {
            var response = @"{
            ""total"": 0,           
            ""items"": [],
            ""self"": ""https://hostname/api/v2/objects/" + mockid + @"/trendedAttributes""
            }";
            httpTest.RespondWith(response);
            var trendedAttributes = client.Trends.GetTrendedAttributes(mockid); 
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/trendedAttributes")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, trendedAttributes.Count);
        }

        [Test]
        public void TestGetTrendedAttributesNotFoundThrowsException()
        {
            httpTest.RespondWith("Not Found", 404);
            var e = Assert.Throws<MetasysHttpNotFoundException>(() =>
                                                                     client.Trends.GetTrendedAttributes(mockid));
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/trendedAttributes")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetTrendedAttributesNotFoundThrowsException: {e.Message}");
        }
       
        [Test]
        public void TestGetTrendedAttributes()
        {           
            var response = @"{
            ""total"": 1,           
            ""items"": ["+Attribute+ @"],
            ""self"": ""https://hostname/api/v2/objects/"+mockid+@"/trendedAttributes""
            ";
            httpTest.RespondWith(response);
            httpTest.RespondWith(AttributeDetail);
            var trendedAttributes = client.Trends.GetTrendedAttributes(mockid);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/trendedAttributes")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/enumSets/509/members/85")
             .WithVerb(HttpMethod.Get)
             .Times(1);
            // SDK Object matching the responsee
            var attribute = new MetasysAttribute
            {
                Id=85,
                Description="Present Value"
            };
            Assert.AreEqual(attribute, trendedAttributes.ElementAt(0));
        }
      
        
        [Test]
        public void TestGetTrendedAttributesMissingItems()
        {
            var response = @"{
            ""total"": 0,          
            ""items"": [{}],
            ""self"": ""https://hostname/api/v2/objects/" + mockid + @"/trendedAttributes""
            ";
            httpTest.RespondWith(response);
            Assert.Throws<MetasysObjectException>(()=>client.Trends.GetTrendedAttributes(mockid));
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/trendedAttributes")
                 .WithVerb(HttpMethod.Get)
                 .Times(1);        
        }

        [Test]
        public void TestGetTrendedAttributesMissingValuesThrowsException()
        {
            string attr= string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\"}");
            var response = @"{
            ""total"": 1,        
            ""items"": [" + attr + @"],
            ""self"": ""https://hostname/api/v2/objects/" + mockid + @"/trendedAttributes""
            ";
            httpTest.RespondWith(response);           
            var e = Assert.Throws<MetasysObjectException>(() =>
              client.Trends.GetTrendedAttributes(mockid));
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/trendedAttributes")
                 .WithVerb(HttpMethod.Get)
                 .Times(1);
            PrintMessage($"TestGetTrendedAttributesMissingValuesThrowsException: {e.Message}");
        }

        [Test]
        public void TestGetTrendedAttributesUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);
            var e = Assert.Throws<MetasysHttpException>(() =>
                                                             client.Trends.GetTrendedAttributes(mockid));
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/trendedAttributes")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetTrendedAttributesUnauthorizedThrowsException: {e.Message}");
        }
    }
}
