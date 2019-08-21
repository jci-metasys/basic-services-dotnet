using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using Flurl.Http.Testing;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using JohnsonControls.Metasys.BasicServices;

namespace Tests
{
    public class TraditionalClientTests
    {
        Guid mockid;
        Guid mockid2;
        string mockAttributeName;
        string mockAttributeName2;
        string mockAttributeName3;
        string mockAttributeName4;
        string mockAttributeName5;
        TraditionalClient traditionalClient;

        [SetUp]
        public void Init()
        {
            traditionalClient = new TraditionalClient();
            mockAttributeName = "property";
            mockAttributeName2 = "property2";
            mockAttributeName3 = "property3";
            mockAttributeName4 = "property4";
            mockAttributeName5 = "property5";
            mockid = new Guid("11111111-2222-3333-4444-555555555555");
            mockid2 = new Guid("11111111-2222-3333-4444-555555555556");
        }

        #region Login Tests

        [Test]
        public void TestLogin()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
                    .WithVerb(HttpMethod.Post)
                    .WithContentType("application/json")
                    .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                    .Times(1);
            }
        }

        [Test]
        public void TestUnauthorizedLoginHandlesException()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("unauthorized", 401);

                try
                {
                    traditionalClient.TryLogin("username", "badpassword", "hostname");

                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
                        .WithVerb(HttpMethod.Post)
                        .WithContentType("application/json")
                        .WithRequestBody("{\"username\":\"username\",\"password\":\"badpassword\"")
                        .Times(1);
                }
                catch
                {
                    Assert.Fail();
                }

            }
        }

        [Test]
        public void TestBadHostLoginHandlesException()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("Call failed. No such host is known POST https://badhost/api/V2/login", 404);

                try
                {
                    traditionalClient.TryLogin("username", "password", "badhost");

                    httpTest.ShouldHaveCalled($"https://badhost/api/V2/login")
                        .WithVerb(HttpMethod.Post)
                        .WithContentType("application/json")
                        .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                        .Times(1);
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        // [Test]
        // public void TestBadVersionLogin()
        // {
        //     using (var httpTest = new HttpTest())
        //     {
        //         httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
        //         traditionalClient.TryLogin("username", "password", "hostname");
        //         httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
        //             .WithVerb(HttpMethod.Post)
        //             .WithContentType("application/json")
        //             .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
        //             .Times(1);
        //     }
        // }

        #endregion

        #region Refresh Tests

        [Test]
        public void TestRefresh()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.Refresh();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/refreshToken")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
            }
        }

        [Test]
        public void TestRefreshNullClient()
        {
            using (var httpTest = new HttpTest())
            {
                try
                {
                    traditionalClient.Refresh();
                    httpTest.ShouldNotHaveCalled($"https://hostname/api/V2/refreshToken");
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public void TestRefreshHandlesException()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("unauthorized", 401);

                try
                {
                    traditionalClient.Refresh();
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/refreshToken")
                        .WithVerb(HttpMethod.Get)
                        .Times(1);
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        #endregion

        #region GetObjectIdentifier Tests

        [Test]
        public void TestGetObjectIdentifier()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith($"\"{mockid.ToString()}\"");
                var id = traditionalClient.GetObjectIdentifier("fully:qualified/reference");
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
                Assert.AreEqual(typeof(Guid), id.GetType());
            }
        }

        [Test]
        public void TestGetObjectIdentifierBadRequestReturnsEmpty()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Bad Request", 400);

                var id = traditionalClient.GetObjectIdentifier("fully:qualified/reference");
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
                Assert.AreEqual(Guid.Empty, id);
            }
        }

        [Test]
        public void TestGetBadObjectIdentifierReturnsEmpty()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Bad Request", 400);

                var id = traditionalClient.GetObjectIdentifier("fully:qualified/reference");
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
                Assert.AreEqual(Guid.Empty, id);
            }
        }

        [Test]
        public void TestGetObjectIdentifierNullClient()
        {
            using (var httpTest = new HttpTest())
            {
                try
                {
                    var id = traditionalClient.GetObjectIdentifier("fully:qualified/reference");
                    httpTest.ShouldNotHaveCalled($"https://hostname/api/V2/objectIdentifiers");
                    Assert.AreEqual(Guid.Empty, id);
                }
                catch
                {
                    Assert.Fail();
                }

            }
        }

        #endregion

        #region ReadProperty Tests

        [Test]
        public void TestReadPropertyInteger()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": 1 }}");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1, result.NumericValue);
                Assert.AreEqual("1", result.StringValue);
                Assert.AreEqual(true, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyFloat()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": 1.1 }}");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1.1, result.NumericValue);
                Assert.AreEqual("1.1", result.StringValue);
                Assert.AreEqual(true, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyString()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": \"stringvalue\" }}");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("stringvalue", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyBooleanTrue()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": true }}");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1, result.NumericValue);
                Assert.AreEqual("True", result.StringValue);
                Assert.AreEqual(true, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyBooleanFalse()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": false }}");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("False", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyObjectWithReliabilityPriorityInteger()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": {" +
                "\"value\": 60, \"reliability\": \"reliabilityEnumSet.reliable\", \"priority\": \"writePriorityEnumSet.priorityNone\"} } }");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(60, result.NumericValue);
                Assert.AreEqual("60", result.StringValue);
                Assert.AreEqual(true, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual("writePriorityEnumSet.priorityNone", result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyObjectWithReliabilityPriorityString()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": {" +
                "\"value\": \"stringvalue\", \"reliability\": \"reliabilityEnumSet.reliable\", \"priority\": \"writePriorityEnumSet.priorityNone\"} } }");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("stringvalue", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual("writePriorityEnumSet.priorityNone", result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyObjectWithReliabilityPriorityStringNoValueField()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": { " +
                "\"property\": \"stringvalue\", \"property2\": \"stringvalue2\", " +
                "\"reliability\": \"reliabilityEnumSet.noInput\", \"priority\": \"writePriorityEnumSet.priorityDefault\"} } }");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("stringvalue", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual("writePriorityEnumSet.priorityDefault", result.Priority);
                Assert.AreEqual("reliabilityEnumSet.noInput", result.Reliability);
                Assert.AreEqual(false, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyArrayIntegers()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": [ " +
                "1, 2 ] } }");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("Array", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(("1", 1, true), result.ArrayValue[0]);
                Assert.AreEqual(("2", 2, true), result.ArrayValue[1]);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyArrayStrings()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": [ " +
                "\"stringvalue1\", \"stringvalue2\" ] } }");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("Array", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(("stringvalue1", 0, false), result.ArrayValue[0]);
                Assert.AreEqual(("stringvalue2", 0, false), result.ArrayValue[1]);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyArrayObjectUnsupported()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": [ " +
                "{ \"item1\": \"stringvalue1\", \"item2\": \"stringvalue2\" }," +
                "{ \"item1\": \"stringvalue3\", \"item2\": \"stringvalue4\" } ] } }");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("Array", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(("Unsupported Data Type", 1, false), result.ArrayValue[0]);
                Assert.AreEqual(("Unsupported Data Type", 1, false), result.ArrayValue[1]);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyDoesNotExist()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Not Found", 404);
                try
                {
                    ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);
                    Assert.Fail();
                }
                catch
                {
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                }
            }
        }

        [Test]
        public void TestReadPropertyUnsupportedEmptyObject()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": {}");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1, result.NumericValue);
                Assert.AreEqual("Unsupported Data Type", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyNullClient()
        {
            using (var httpTest = new HttpTest())
            {
                try
                {
                    ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);
                    httpTest.ShouldNotHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}");
                    Assert.AreEqual(1, result.NumericValue);
                    Assert.AreEqual("Unsupported Data Type", result.StringValue);
                    Assert.AreEqual(false, result.BooleanValue);
                    Assert.AreEqual(null, result.ArrayValue);
                    Assert.AreEqual(null, result.Priority);
                    Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
                    Assert.AreEqual(true, result.IsReliable);
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        #endregion

        #region ReadPropertyMultiple Tests

        [Test]
        public void TestReadPropertyMultipleEmptyIds()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }");
                List<Guid> ids = new List<Guid>() { };
                List<string> attributes = new List<string>() { mockAttributeName };
                IEnumerable<ReadPropertyResult> results = traditionalClient.ReadPropertyMultiple(ids, attributes);

                Assert.AreEqual(0, results.Count());
            }
        }

        [Test]
        public void TestReadPropertyMultipleEmptyAttribute()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }");
                List<Guid> ids = new List<Guid>() { mockid };
                List<string> attributes = new List<string>() { };
                IEnumerable<ReadPropertyResult> results = traditionalClient.ReadPropertyMultiple(ids, attributes);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, results.Count());
            }
        }

        [Test]
        public void TestReadPropertyMultipleOneIdOneAttribute()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }");
                List<Guid> ids = new List<Guid>() { mockid };
                List<string> attributes = new List<string>() { mockAttributeName };
                IEnumerable<ReadPropertyResult> results = traditionalClient.ReadPropertyMultiple(ids, attributes);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1, results.Count());
            }
        }

        [Test]
        public void TestReadPropertyMultipleTwoIdFiveAttribute()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest
                    .RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\", " +
                        "\"" + mockAttributeName2 + "\": 23, " +
                        "\"" + mockAttributeName3 + "\": 23.5, " +
                        "\"" + mockAttributeName4 + "\": true, " +
                        "\"" + mockAttributeName5 + "\": [ 1, 2, 3] } }")
                    .RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\", " +
                        "\"" + mockAttributeName2 + "\": 23, " +
                        "\"" + mockAttributeName3 + "\": 23.5, " +
                        "\"" + mockAttributeName4 + "\": true, " +
                        "\"" + mockAttributeName5 + "\": [ 1, 2, 3] } }");

                List<Guid> ids = new List<Guid>() { mockid, mockid2 };
                List<string> attributes = new List<string>() { mockAttributeName, mockAttributeName2, mockAttributeName3, mockAttributeName4, mockAttributeName5 };
                IEnumerable<ReadPropertyResult> results = traditionalClient.ReadPropertyMultiple(ids, attributes);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid2}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(results.Count(), 10);
                foreach (var result in results)
                {
                    Assert.AreNotEqual("Unsupported Data Type", result.StringValue);
                }
            }
        }

        [Test]
        public void TestReadPropertyMultipleOneIdOneAttributeDNE()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("{ \"item\": { \"attributeNoMatch\": \"stringvalue\" } }");
                List<Guid> ids = new List<Guid>() { mockid };
                List<string> attributes = new List<string>() { mockAttributeName };
                IEnumerable<ReadPropertyResult> results = traditionalClient.ReadPropertyMultiple(ids, attributes);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, results.Count());
            }
        }

        [Test]
        public void TestReadPropertyMultipleNullClient()
        {
            using (var httpTest = new HttpTest())
            {
                try
                {
                    List<Guid> ids = new List<Guid>() { mockid };
                    List<string> attributes = new List<string>() { mockAttributeName };
                    IEnumerable<ReadPropertyResult> results = traditionalClient.ReadPropertyMultiple(ids, attributes);

                    httpTest.ShouldNotHaveCalled($"https://hostname/api/V2/objects/{mockid}");
                    Assert.AreEqual(null, results);
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        #endregion

        #region WriteProperty Tests

        [Test]
        public void TestWritePropertyString()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Accepted", 202);

                traditionalClient.WriteProperty(mockid, mockAttributeName, "newValue");

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestJson($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyStringWithPriority()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Accepted", 202);

                traditionalClient.WriteProperty(mockid, mockAttributeName, "newValue", "writePriorityEnumSet.priorityDefault");

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestJson($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\",\"priority\":\"writePriorityEnumSet.priorityDefault\"}}}}")
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyInteger()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Accepted", 202);

                traditionalClient.WriteProperty(mockid, mockAttributeName, 32);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestJson($"{{\"item\":{{\"{mockAttributeName}\":32}}}}")
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyFloat()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Accepted", 202);

                traditionalClient.WriteProperty(mockid, mockAttributeName, 32.5);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestJson($"{{\"item\":{{\"{mockAttributeName}\":32.5}}}}")
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyBoolean()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Accepted", 202);

                traditionalClient.WriteProperty(mockid, mockAttributeName, true);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestJson($"{{\"item\":{{\"{mockAttributeName}\":true}}}}")
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyArrayString()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Accepted", 202);

                traditionalClient.WriteProperty(mockid, mockAttributeName, new[] { "1", "2", "3" });

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestJson($"{{\"item\":{{\"{mockAttributeName}\":[\"1\",\"2\",\"3\"]}}}}")
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyArrayInteger()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Accepted", 202);

                traditionalClient.WriteProperty(mockid, mockAttributeName, new[] { 1, 2, 3 });

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestJson($"{{\"item\":{{\"{mockAttributeName}\":[1,2,3]}}}}")
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyBadRequestDoesNothing()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Bad Request", 400);
                try
                {
                    traditionalClient.WriteProperty(mockid, mockAttributeName, "badType");
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                        .WithVerb(HttpMethod.Patch)
                        .WithRequestJson($"{{\"item\":{{\"{mockAttributeName}\":\"badType\"}}}}")
                        .Times(1);
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public void TestWritePropertyNullClient()
        {
            using (var httpTest = new HttpTest())
            {
                try
                {
                    traditionalClient.WriteProperty(mockid, mockAttributeName, "newValue");
                    httpTest.ShouldNotHaveCalled($"https://hostname/api/V2/objects/{mockid}");
                }
                catch
                {
                    Assert.Fail();
                }

            }
        }

        #endregion

        #region WritePropertyMultiple Tests

        [Test]
        public void TestWritePropertyMultipleOneIdOneString()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Accepted", 202);

                List<Guid> ids = new List<Guid>() { mockid };
                List<(string, object)> attributes = new List<(string, object)>() { (mockAttributeName, "newValue") };
                traditionalClient.WritePropertyMultiple(ids, attributes);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestJson($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyMultipleManyIdsOneString()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Accepted", 202);

                List<Guid> ids = new List<Guid>() { mockid, mockid2 };
                List<(string, object)> attributes = new List<(string, object)>() { (mockAttributeName, "newValue") };
                traditionalClient.WritePropertyMultiple(ids, attributes);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestJson($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")
                    .Times(1);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid2}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestJson($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyMultipleManyIdsManyAttributes()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Accepted", 202);

                List<Guid> ids = new List<Guid>() { mockid, mockid2 };
                List<(string, object)> attributes = new List<(string, object)>() {
                    (mockAttributeName, "stringvalue"),
                    (mockAttributeName2, 23),
                    (mockAttributeName3, 23.5),
                    (mockAttributeName4, true),
                    (mockAttributeName5, new [] { 1, 2, 3 })};
                traditionalClient.WritePropertyMultiple(ids, attributes);

                string requestBody = "{\"item\":{\"" + mockAttributeName + "\":\"stringvalue\"," +
                        "\"" + mockAttributeName2 + "\":23," +
                        "\"" + mockAttributeName3 + "\":23.5," +
                        "\"" + mockAttributeName4 + "\":true," +
                        "\"" + mockAttributeName5 + "\":[1,2,3]}}";

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestJson(requestBody)
                    .Times(1);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid2}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestJson(requestBody)
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyMultipleBadRequestDoesNothing()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Bad Request", 400);

                List<Guid> ids = new List<Guid>() { mockid };
                List<(string, object)> attributes = new List<(string, object)>() { ("badAttributeName", "newValue") };

                try
                {
                    traditionalClient.WritePropertyMultiple(ids, attributes);
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                        .WithVerb(HttpMethod.Patch)
                        .WithRequestJson("{\"item\":{\"badAttributeName\":\"newValue\"}}")
                        .Times(1);
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public void TestWritePropertyMultipleNullItemsDoesNothing()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Bad Request", 400);

                try
                {
                    traditionalClient.WritePropertyMultiple(null, null);
                    httpTest.ShouldNotHaveCalled($"https://hostname/api/V2/objects/{mockid}");
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public void TestWritePropertyMultipleNullClient()
        {
            using (var httpTest = new HttpTest())
            {
                try
                {
                    traditionalClient.WritePropertyMultiple(null, null);
                    httpTest.ShouldNotHaveCalled($"https://hostname/api/V2/objects/{mockid}");
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        #endregion

        #region SendCommand Tests

        [Test]
        public void TestSendCommandEmptyBody()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("OK", 200);

                traditionalClient.SendCommand(mockid, "EnableAlarms");
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/EnableAlarms")
                    .WithVerb(HttpMethod.Put)
                    .Times(1);
            }
        }

        [Test]
        public void TestSendCommandOneNumber()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("OK", 200);

                List<object> list = new List<object>() { 70 };
                traditionalClient.SendCommand(mockid, "Adjust", list);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/Adjust")
                    .WithVerb(HttpMethod.Put)
                    .Times(1);
            }
        }

        [Test]
        public void TestSendCommandManyNumber()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("OK", 200);

                List<object> list = new List<object>() { 70.5, 1, 0 };
                traditionalClient.SendCommand(mockid, "TemporaryOperatorOverride", list);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/TemporaryOperatorOverride")
                    .WithVerb(HttpMethod.Put)
                    .Times(1);
            }
        }

        [Test]
        public void TestSendCommandManyEnum()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("OK", 200);

                List<object> list = new List<object>() { "attributeEnumSet.presentValue", "writePriorityEnumSet.priorityNone" };
                traditionalClient.SendCommand(mockid, "Release", list);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/Release")
                    .WithVerb(HttpMethod.Put)
                    .Times(1);
            }
        }

        [Test]
        public void TestSendCommandBadRequestDoesNothing()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Bad Request", 400);

                try
                {
                    List<object> list = new List<object>() { "noMatch", "noMatch" };
                    traditionalClient.SendCommand(mockid, "Release", list);
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/Release")
                        .WithVerb(HttpMethod.Put)
                        .Times(1);
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public void TestSendCommandUnauthorizedDoesNothing()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("Unauthorized", 401);

                try
                {
                    List<object> list = new List<object>() { 40, "badDataTypes" };
                    traditionalClient.SendCommand(mockid, "Release", list);
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/Release")
                        .WithVerb(HttpMethod.Put)
                        .Times(1);
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public void TestSendCommandNullClient()
        {
            using (var httpTest = new HttpTest())
            {
                try
                {
                    List<object> list = new List<object>() { 40, "badDataTypes" };
                    traditionalClient.SendCommand(mockid, "Release", list);
                    httpTest.ShouldNotHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/Release");
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        #endregion

        #region GetCommands Tests

        [Test]
        public void TestGetCommandsNone()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith("[]");

                var commands = traditionalClient.GetCommands(mockid).ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, commands.Count);
            }
        }

        [Test]
        public void TestGetCommandsEmpty()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith(string.Concat("[{\"$schema\": \"http://json-schema.org/schema#\",",
                    "\"commandId\": \"EnableAlarms\",",
                    "\"title\": \"Enable Alarms\",",
                    "\"type\": \"array\",",
                    "\"items\": [],",
                    "\"minItems\": 0,",
                    "\"maxItems\": 0 },",
                    "{\"$schema\": \"http://json-schema.org/schema#\",",
                    "\"commandId\": \"DisableAlarms\",",
                    "\"title\": \"Disable Alarms\",",
                    "\"type\": \"array\",",
                    "\"items\": [],",
                    "\"minItems\": 0,",
                    "\"maxItems\": 0 }]"));

                var commands = traditionalClient.GetCommands(mockid).ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual("Enable Alarms", commands[0].Title);
                Assert.AreEqual("EnableAlarms", commands[0].CommandId);
                Assert.AreEqual(null, commands[0].Items);
                Assert.AreEqual("Disable Alarms", commands[1].Title);
                Assert.AreEqual("DisableAlarms", commands[1].CommandId);
                Assert.AreEqual(null, commands[1].Items);
            }
        }

        [Test]
        public void TestGetCommandsOneEnum()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith(string.Concat("[{\"$schema\": \"http://json-schema.org/schema#\",",
                    "\"commandId\": \"ReleaseAll\",",
                    "\"title\": \"Release All\",",
                    "\"type\": \"array\",",
                    "\"items\": [{",
                        "\"oneOf\": [{",
                            "\"const\": \"attributeEnumSet.presentValue\",",
                            "\"title\": \"Present Value\"}]",
                        "}],",
                    "\"minItems\": 1,",
                    "\"maxItems\": 1 }]"));

                var commands = traditionalClient.GetCommands(mockid).ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual("Release All", commands[0].Title);
                Assert.AreEqual("ReleaseAll", commands[0].CommandId);
                Assert.AreEqual(1, commands[0].Items.Count());

                var items = commands[0].Items.ToList();
                Assert.AreEqual("oneOf", items[0].Title);
                Assert.AreEqual("enum", items[0].Type);
                Assert.AreEqual(1, items[0].Maximum);
                Assert.AreEqual(1, items[0].Minimum);

                var enums = items[0].EnumerationValues.ToList();
                Assert.AreEqual("Present Value", enums[0].Title);
                Assert.AreEqual("attributeEnumSet.presentValue", enums[0].Value);
            }
        }

        [Test]
        public void TestGetCommandsOneNumber()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith(string.Concat("[{\"$schema\": \"http://json-schema.org/schema#\",",
                    "\"commandId\": \"Adjust\",",
                    "\"title\": \"Adjust\",",
                    "\"type\": \"array\",",
                    "\"items\": [{",
                        "\"type\": \"number\",",
                        "\"title\": \"Value\",",
                        "\"minimum\": -20.0,",
                        "\"maximum\": 120.0",
                        "}],",
                    "\"minItems\": 1,",
                    "\"maxItems\": 1 }]"));

                var commands = traditionalClient.GetCommands(mockid).ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual("Adjust", commands[0].Title);
                Assert.AreEqual("Adjust", commands[0].CommandId);
                Assert.AreEqual(1, commands[0].Items.Count());

                var items = commands[0].Items.ToList();
                Assert.AreEqual("Value", items[0].Title);
                Assert.AreEqual("number", items[0].Type);
                Assert.AreEqual(120, items[0].Maximum);
                Assert.AreEqual(-20, items[0].Minimum);
                Assert.AreEqual(null, items[0].EnumerationValues);
            }
        }

        [Test]
        public void TestGetCommandsTwoEnumOneNumber()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith(string.Concat("[{\"$schema\": \"http://json-schema.org/schema#\",",
                    "\"commandId\": \"Release\",",
                    "\"title\": \"Release\",",
                    "\"type\": \"array\",",
                    "\"items\": [{",
                        "\"oneOf\": [{",
                            "\"const\": \"attributeEnumSet.presentValue\",",
                            "\"title\": \"Present Value\"}]",
                        "},",
                        "{\"oneOf\": [{",
                            "\"const\": \"writePriorityEnumSet.priorityNone\",",
                            "\"title\": \"0 (No Priority)\"},",
                            "{\"const\": \"writePriorityEnumSet.priorityManualEmergency\",",
                            "\"title\": \"1 (Manual Life Safety)\"}],",
                        "},",
                        "{\"type\": \"number\",",
                        "\"title\": \"Value\",",
                        "\"minimum\": -20.0,",
                        "\"maximum\": 120.0",
                        "}],",
                    "\"minItems\": 3,",
                    "\"maxItems\": 3 }]"));

                var commands = traditionalClient.GetCommands(mockid).ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual("Release", commands[0].Title);
                Assert.AreEqual("Release", commands[0].CommandId);
                Assert.AreEqual(3, commands[0].Items.Count());

                var items = commands[0].Items.ToList();
                Assert.AreEqual("oneOf", items[0].Title);
                Assert.AreEqual("enum", items[0].Type);
                Assert.AreEqual(1, items[0].Maximum);
                Assert.AreEqual(1, items[0].Minimum);
                var enums1 = items[0].EnumerationValues.ToList();
                Assert.AreEqual("Present Value", enums1[0].Title);
                Assert.AreEqual("attributeEnumSet.presentValue", enums1[0].Value);

                Assert.AreEqual("oneOf", items[1].Title);
                Assert.AreEqual("enum", items[1].Type);
                Assert.AreEqual(1, items[1].Maximum);
                Assert.AreEqual(1, items[1].Minimum);
                var enums2 = items[1].EnumerationValues.ToList();
                Assert.AreEqual("0 (No Priority)", enums2[0].Title);
                Assert.AreEqual("writePriorityEnumSet.priorityNone", enums2[0].Value);
                Assert.AreEqual("1 (Manual Life Safety)", enums2[1].Title);
                Assert.AreEqual("writePriorityEnumSet.priorityManualEmergency", enums2[1].Value);

                Assert.AreEqual("Value", items[2].Title);
                Assert.AreEqual("number", items[2].Type);
                Assert.AreEqual(120, items[2].Maximum);
                Assert.AreEqual(-20, items[2].Minimum);
                Assert.AreEqual(null, items[2].EnumerationValues);
            }
        }

        [Test]
        public void TestGetCommandsNullClient()
        {
            using (var httpTest = new HttpTest())
            {
                try
                {
                    var commands = traditionalClient.GetCommands(mockid);
                    httpTest.ShouldNotHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands");
                    Assert.AreEqual(null, commands);
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        #endregion

        #region GetNetworkDevices Tests

        [Test]
        public void TestGetNetworkDevicesNone()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith(string.Concat("{",
                    "\"total\": 0,",
                    "\"next\": null,",
                    "\"previous\": null,",
                    "\"items\": [ ],",
                    "\"self\": \"https://hostname/api/V2/networkDevices?page=1&pageSize=200&sort=name\"}"));

                var devices = traditionalClient.GetNetworkDevices().ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/networkDevices")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, devices.Count);
            }
        }

        [Test]
        public void TestGetNetworkDevicesOnePage()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith(string.Concat("{",
                    "\"total\": 1,",
                    "\"next\": null,",
                    "\"previous\": null,",
                    "\"items\": [{",
                        "\"id\": \"", mockid, "\",",
                        "\"itemReference\": \"fully:qualified/reference\",",
                        "\"name\": \"name\",",
                        "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\",",
                        "\"description\": \"none\",",
                        "\"firmwareVersion\": \"4.0.0.1105\",",
                        "\"ipAddress\": \"\"",
                    "}],",
                    "\"self\": \"https://hostname/api/V2/networkDevices?page=1&pageSize=200&sort=name\"}"));

                var devices = traditionalClient.GetNetworkDevices().ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/networkDevices")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1, devices.Count);
                Assert.AreEqual(mockid, devices[0].Id);
                Assert.AreEqual("fully:qualified/reference", devices[0].ItemReference);
                Assert.AreEqual("name", devices[0].Name);
                Assert.AreEqual("https://hostname/api/v2/enumSets/508/members/197", devices[0].TypeUrl);
                Assert.AreEqual("none", devices[0].Description);
                Assert.AreEqual("4.0.0.1105", devices[0].FirmwareVersion);
                Assert.AreEqual("", devices[0].IpAddress);
            }
        }

        [Test]
        public void TestGetNetworkDevicesManyPages()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith(string.Concat("{",
                    "\"total\": 2,",
                    "\"next\": \"https://hostname/api/V2/networkDevices?page=2&pageSize=1&sort=name\",",
                    "\"previous\": null,",
                    "\"items\": [{",
                        "\"id\": \"", mockid, "\",",
                        "\"itemReference\": \"fully:qualified/reference\",",
                        "\"name\": \"name\",",
                        "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\",",
                        "\"description\": \"none\",",
                        "\"firmwareVersion\": \"4.0.0.1105\",",
                        "\"ipAddress\": \"\"",
                    "}],",
                    "\"self\": \"https://hostname/api/V2/networkDevices?page=1&pageSize=1&sort=name\"}"));

                httpTest.RespondWith(string.Concat("{",
                    "\"total\": 2,",
                    "\"next\": null,",
                    "\"previous\": null,",
                    "\"items\": [{",
                        "\"id\": \"", mockid, "\",",
                        "\"itemReference\": \"fully:qualified/reference\",",
                        "\"name\": \"name\",",
                        "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\",",
                        "\"description\": \"none\",",
                        "\"firmwareVersion\": \"4.0.0.1105\",",
                        "\"ipAddress\": \"\"},",

                        "{\"id\": \"", mockid2, "\",",
                        "\"itemReference\": \"fully:qualified/reference2\",",
                        "\"name\": \"name\",",
                        "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\",",
                        "\"description\": \"none\",",
                        "\"firmwareVersion\": \"4.0.0.1105\",",
                        "\"ipAddress\": \"\"",
                    "}],",
                    "\"self\": \"https://hostname/api/V2/networkDevices?page=1&pageSize=2&sort=name\"}"));

                var devices = traditionalClient.GetNetworkDevices().ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/networkDevices")
                    .WithVerb(HttpMethod.Get)
                    .Times(2);
                Assert.AreEqual(2, devices.Count);
            }
        }

        [Test]
        public void TestGetNetworkDevicesWithType()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith(string.Concat("{",
                    "\"total\": 1,",
                    "\"next\": null,",
                    "\"previous\": null,",
                    "\"items\": [{",
                        "\"id\": \"", mockid, "\",",
                        "\"itemReference\": \"fully:qualified/reference\",",
                        "\"name\": \"name\",",
                        "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\",",
                        "\"description\": \"none\",",
                        "\"firmwareVersion\": \"4.0.0.1105\",",
                        "\"ipAddress\": \"\"",
                    "}],",
                    "\"self\": \"https://hostname/api/V2/networkDevices?page=1&pageSize=200&sort=name\"}"));

                var devices = traditionalClient.GetNetworkDevices("197").ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/networkDevices")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1, devices.Count);
                Assert.AreEqual(mockid, devices[0].Id);
                Assert.AreEqual("fully:qualified/reference", devices[0].ItemReference);
                Assert.AreEqual("name", devices[0].Name);
                Assert.AreEqual("https://hostname/api/v2/enumSets/508/members/197", devices[0].TypeUrl);
                Assert.AreEqual("none", devices[0].Description);
                Assert.AreEqual("4.0.0.1105", devices[0].FirmwareVersion);
                Assert.AreEqual("", devices[0].IpAddress);
            }
        }

        [Test]
        public void TestGetNetworkDevicesMissingValues()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith(string.Concat("{",
                    "\"total\": 1,",
                    "\"next\": null,",
                    "\"previous\": null,",
                    "\"items\": [{}],",
                    "\"self\": \"https://hostname/api/V2/networkDevices?page=1&pageSize=200&sort=name\"}"));

                var devices = traditionalClient.GetNetworkDevices().ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/networkDevices")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1, devices.Count);
                Assert.AreEqual(Guid.Empty, devices[0].Id);
                Assert.AreEqual("N/A", devices[0].ItemReference);
                Assert.AreEqual("N/A", devices[0].Name);
                Assert.AreEqual("N/A", devices[0].TypeUrl);
                Assert.AreEqual("N/A", devices[0].Description);
                Assert.AreEqual("N/A", devices[0].FirmwareVersion);
                Assert.AreEqual("N/A", devices[0].IpAddress);
            }
        }

        [Test]
        public void TestGetNetworkDevicesNullClient()
        {
            using (var httpTest = new HttpTest())
            {
                try
                {
                    var devices = traditionalClient.GetNetworkDevices();
                    httpTest.ShouldNotHaveCalled($"https://hostname/api/V2/networkDevices");
                    Assert.AreEqual(null, devices);
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        #endregion

        #region GetNetworkDeviceTypes

        [Test]
        public void TestGetNetworkDeviceTypesNone()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith(string.Concat("{",
                    "\"total\": 0,",
                    "\"items\": [ ],",
                    "\"self\": \"https://hostname/api/V2/networkDevices/availableTypes\"}"));

                var types = traditionalClient.GetNetworkDeviceTypes().ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/networkDevices/availableTypes")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, types.Count);
            }
        }

        [Test]
        public void TestGetNetworkDeviceTypesOne()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith(string.Concat("{",
                    "\"total\": 1,",
                    "\"items\": [{",
                        "\"typeUrl\": \"https://hostname/api/V2/enumSets/508/members/185\"",
                    "}],",
                    "\"self\": \"https://hostname/api/V2/networkDevices/availableTypes\"}"));

                httpTest.RespondWith(string.Concat("{",
                    "\"id\": 185,",
                    "\"description\": \"NAE55-NIE59\",",
                    "\"self\": \"https://hostname/api/V2/enumSets/508/members/185\",",
                    "\"setUrl\": \"https://hostname/api/V2/enumSets/508\"}"));

                var types = traditionalClient.GetNetworkDeviceTypes().ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/networkDevices/availableTypes")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/enumSets/508/members/185")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1, types.Count);
                Assert.AreEqual(185, types[0].Item1);
                Assert.AreEqual("NAE55-NIE59", types[0].Item2);
            }
        }

        [Test]
        public void TestGetNetworkDeviceTypesMany()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith(string.Concat("{",
                    "\"total\": 2,",
                    "\"items\": [{",
                        "\"typeUrl\": \"https://hostname/api/V2/enumSets/508/members/185\"},",
                        "{\"typeUrl\": \"https://hostname/api/V2/enumSets/508/members/195\"",
                    "}],",
                    "\"self\": \"https://hostname/api/V2/networkDevices/availableTypes\"}"));

                httpTest.RespondWith(string.Concat("{",
                    "\"id\": 185,",
                    "\"description\": \"NAE55-NIE59\",",
                    "\"self\": \"https://hostname/api/V2/enumSets/508/members/185\",",
                    "\"setUrl\": \"https://hostname/api/V2/enumSets/508\"}"));

                httpTest.RespondWith(string.Concat("{",
                    "\"id\": 195,",
                    "\"description\": \"Field Bus MSTP\",",
                    "\"self\": \"https://hostname/api/V2/enumSets/508/members/195\",",
                    "\"setUrl\": \"https://hostname/api/V2/enumSets/508\"}"));

                var types = traditionalClient.GetNetworkDeviceTypes().ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/networkDevices/availableTypes")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/enumSets/508/members/185")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/enumSets/508/members/195")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                Assert.AreEqual(2, types.Count);
                Assert.AreEqual(185, types[0].Item1);
                Assert.AreEqual("NAE55-NIE59", types[0].Item2);
                Assert.AreEqual(195, types[1].Item1);
                Assert.AreEqual("Field Bus MSTP", types[1].Item2);
            }
        }

        [Test]
        public void TestGetNetworkDeviceTypesNotFoundDoesNothing()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken", expires = "2030-01-01T00:00:00Z" });
                traditionalClient.TryLogin("username", "password", "hostname");

                httpTest.RespondWith(string.Concat("{",
                    "\"total\": 1,",
                    "\"items\": [{",
                        "\"typeUrl\": \"https://hostname/api/V2/enumSets/508/members/3000\"",
                    "}],",
                    "\"self\": \"https://hostname/api/V2/networkDevices/availableTypes\"}"));
                httpTest.RespondWith("No HTTP resource was found that matches the request URI.", 404);

                var types = traditionalClient.GetNetworkDeviceTypes().ToList();
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/networkDevices/availableTypes")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/enumSets/508/members/3000")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, types.Count);
            }
        }

        [Test]
        public void TestGetNetworkDeviceTypesNullClient()
        {
            using (var httpTest = new HttpTest())
            {
                try
                {
                    var types = traditionalClient.GetNetworkDeviceTypes();
                    httpTest.ShouldNotHaveCalled($"https://hostname/api/V2/networkDevices/availableTypes");
                    Assert.AreEqual(null, types);
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        #endregion
    }
}
