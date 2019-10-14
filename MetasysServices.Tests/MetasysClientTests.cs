using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using Flurl.Http.Testing;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using JohnsonControls.Metasys.BasicServices;
using Nito.AsyncEx;
using System.Threading.Tasks;
using JohnsonControls.Metasys.BasicServices.Models;

namespace Tests
{
    public class MetasysClientTests
    {
        // Update these en-US resources as needed
        static string Unsupported = "Unsupported object type";
        static string PriorityNone = "0 (No Priority)";
        static string Reliable = "Reliable";
        Guid mockid;
        Guid mockid2;
        Guid mockid3;
        string mockAttributeName;
        string mockAttributeName2;
        string mockAttributeName3;
        string mockAttributeName4;
        string mockAttributeName5;
        string date1;
        DateTime dateTime1;
        string date2;
        DateTime dateTime2;
        MetasysClient client;

        [SetUp]
        public void Init()
        {
            client = new MetasysClient("hostname", false, ApiVersion.V2, new System.Globalization.CultureInfo("en-US"));
            mockAttributeName = "property";
            mockAttributeName2 = "property2";
            mockAttributeName3 = "property3";
            mockAttributeName4 = "property4";
            mockAttributeName5 = "property5";
            mockid = new Guid("11111111-2222-3333-4444-555555555555");
            mockid2 = new Guid("11111111-2222-3333-4444-555555555556");
            mockid3 = new Guid("11111111-2222-3333-4444-555555555557");
            date1 = "2030-01-01T00:00:00Z";
            dateTime1 = DateTime.Parse(date1).ToUniversalTime();
            date2 = "2030-01-01T00:01:00Z";
            dateTime2 = DateTime.Parse(date2).ToUniversalTime();
        }

        #region Login Tests

        [Test]
        public async Task TestLoginAsync()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken1", expires = date1 });
                await client.TryLoginAsync("username", "password").ConfigureAwait(false);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
                    .WithVerb(HttpMethod.Post)
                    .WithContentType("application/json")
                    .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                    .Times(1);
                var token = client.GetAccessToken();
                Assert.AreEqual("Bearer faketoken1", token.Token);
                Assert.AreEqual(dateTime1, token.Expires);
            }
        }

        [Test]
        public void TestLogin()
        {
            using (var httpTest = new HttpTest())
            {
                AsyncContext.Run(() =>
                {
                    httpTest.RespondWithJson(new { accessToken = "faketoken2", expires = date2 });
                    client.TryLogin("username", "password");
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
                        .WithVerb(HttpMethod.Post)
                        .WithContentType("application/json")
                        .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                        .Times(1);
                    var token = client.GetAccessToken();
                    Assert.AreEqual("Bearer faketoken2", token.Token);
                    Assert.AreEqual(dateTime2, token.Expires);
                });
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
                    client.TryLogin("username", "badpassword");
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
                        .WithVerb(HttpMethod.Post)
                        .WithContentType("application/json")
                        .WithRequestBody("{\"username\":\"username\",\"password\":\"badpassword\"")
                        .Times(1);
                    TestContext.Out.WriteLine(e.Message);
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
                    MetasysClient clientBad = new MetasysClient("badhost");
                    clientBad.TryLogin("username", "password");
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    httpTest.ShouldHaveCalled($"https://badhost/api/V2/login")
                        .WithVerb(HttpMethod.Post)
                        .WithContentType("application/json")
                        .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                        .Times(1);
                    
                    TestContext.Out.WriteLine(e.Message);
                }
            }
        }

        #endregion

        #region Refresh Tests

        [Test]
        public async Task TestRefreshAsync()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new { accessToken = "faketoken3", expires = date1 });
                await client.RefreshAsync().ConfigureAwait(false);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/refreshToken")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                var token = client.GetAccessToken();
                Assert.AreEqual("Bearer faketoken3", token.Token);
                Assert.AreEqual(dateTime1, token.Expires);
            }
        }

        [Test]
        public void TestRefresh()
        {
            using (var httpTest = new HttpTest())
            {
                AsyncContext.Run(() =>
                {
                    httpTest.RespondWithJson(new { accessToken = "faketoken4", expires = date2 });
                    client.Refresh();
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/refreshToken")
                        .WithVerb(HttpMethod.Get)
                        .Times(1);
                    var token = client.GetAccessToken();
                    Assert.AreEqual("Bearer faketoken4", token.Token);
                    Assert.AreEqual(dateTime2, token.Expires);
                });
            }
        }

        [Test]
        public void TestRefreshHandlesException()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("unauthorized", 401);

                try
                {
                    client.Refresh();
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/refreshToken")
                        .WithVerb(HttpMethod.Get)
                        .Times(1);
                    TestContext.Out.WriteLine(e.Message);
                }
            }
        }

        [Test]
        public void TestRefreshTimer()
        {
            using (var httpTest = new HttpTest())
            {
                DateTime now = DateTime.UtcNow;
                DateTime future = new DateTime(now.Ticks - (now.Ticks % TimeSpan.TicksPerSecond));
                future.AddSeconds(2);
                string time = future.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'");

                httpTest.RespondWithJson(new { accessToken = "faketoken5", expires = time })
                    .RespondWithJson(new { accessToken = "faketoken6", expires = date1 });

                client.TryLogin("username", "password");
                var token = client.GetAccessToken();
                Assert.AreEqual("Bearer faketoken5", token.Token);
                Assert.AreEqual(future, token.Expires);

                System.Threading.Thread.Sleep(2000);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/refreshToken")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                var token2 = client.GetAccessToken();
                Assert.AreEqual("Bearer faketoken6", token2.Token);
                Assert.AreEqual(dateTime1, token2.Expires);
            }
        }

        #endregion

        #region GetObjectIdentifier Tests

        [Test]
        public async Task TestGetObjectIdentifierAsync()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith($"\"{mockid.ToString()}\"");
                var id = await client.GetObjectIdentifierAsync("fully:qualified/reference").ConfigureAwait(false);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
                Assert.AreEqual(typeof(Guid), id.GetType());
            }
        }

        [Test]
        public void TestGetObjectIdentifier()
        {
            using (var httpTest = new HttpTest())
            {
                AsyncContext.Run(() =>
                {
                    httpTest.RespondWith($"\"{mockid.ToString()}\"");
                    var id = client.GetObjectIdentifier("fully:qualified/reference");
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objectIdentifiers")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                    Assert.AreEqual(typeof(Guid), id.GetType());
                });
            }
        }

        [Test]
        public void TestGetObjectIdentifierBadRequestThrowsException()
        {
            using (var httpTest = new HttpTest())
            {
                try
                {
                    httpTest.RespondWith("Bad Request", 400);
                    var id = client.GetObjectIdentifier("fully:qualified/reference");
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objectIdentifiers")
                        .WithVerb(HttpMethod.Get)
                        .Times(1);
                    TestContext.Out.WriteLine(e.Message);
                }
            }
        }

        #endregion

        #region ReadProperty Tests

        [Test]
        public async Task TestReadPropertyIntegerAsync()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": 1 }}");
                Variant result = await client.ReadPropertyAsync(mockid, mockAttributeName).ConfigureAwait(false);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1, result.NumericValue);
                Assert.AreEqual("1", result.StringValue);
                Assert.AreEqual(true, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyInteger()
        {
            using (var httpTest = new HttpTest())
            {
                AsyncContext.Run(() =>
                {
                    httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": 1 }}");
                    Variant result = client.ReadProperty(mockid, mockAttributeName);

                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                        .WithVerb(HttpMethod.Get)
                        .Times(1);
                    Assert.AreEqual(1, result.NumericValue);
                    Assert.AreEqual("1", result.StringValue);
                    Assert.AreEqual(true, result.BooleanValue);
                    Assert.AreEqual(null, result.ArrayValue);
                    Assert.AreEqual(null, result.Priority);
                    Assert.AreEqual(Reliable, result.Reliability);
                    Assert.AreEqual(true, result.IsReliable);
                });
            }
        }

        [Test]
        public void TestReadPropertyFloat()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": 1.1 }}");
                Variant result = client.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1.1, result.NumericValue);
                Assert.AreEqual("1.1", result.StringValue);
                Assert.AreEqual(true, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyString()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": \"stringvalue\" }}");
                Variant result = client.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("stringvalue", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyBooleanTrue()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": true }}");
                Variant result = client.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1, result.NumericValue);
                Assert.AreEqual("True", result.StringValue);
                Assert.AreEqual(true, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyBooleanFalse()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": false }}");
                Variant result = client.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("False", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyObjectPresentValueInteger()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith(string.Concat("{ \"item\": { \"presentValue\": {",
                    "\"value\": 60,",
                    "\"reliability\": \"reliabilityEnumSet.reliable\",",
                    "\"priority\": \"writePriorityEnumSet.priorityNone\"} } }"));
                Variant result = client.ReadProperty(mockid, "presentValue");

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/presentValue")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(60, result.NumericValue);
                Assert.AreEqual("60", result.StringValue);
                Assert.AreEqual(true, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(PriorityNone, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyObjectPresentValueString()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith(string.Concat("{ \"item\": { \"presentValue\": {",
                    "\"value\": \"stringvalue\",",
                    "\"reliability\": \"reliabilityEnumSet.reliable\",",
                    "\"priority\": \"writePriorityEnumSet.priorityNone\"} } }"));
                Variant result = client.ReadProperty(mockid, "presentValue");

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/presentValue")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("stringvalue", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(PriorityNone, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyObjectWithReliabilityPriorityStringNoValueField()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith(string.Concat("{ \"item\": { \"", mockAttributeName, "\": { ",
                "\"property\": \"stringvalue\",",
                "\"property2\": \"stringvalue2\", ",
                "\"reliability\": \"reliabilityEnumSet.noInput\",",
                "\"priority\": \"writePriorityEnumSet.priorityDefault\"} } }"));
                Variant result = client.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1, result.NumericValue);
                Assert.AreEqual(Unsupported, result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyArrayIntegers()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": [ 0, 1 ] } }");
                Variant result = client.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("Array", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual("0", result.ArrayValue[0].StringValue);
                Assert.AreEqual(0, result.ArrayValue[0].NumericValue);
                Assert.AreEqual(false, result.ArrayValue[0].BooleanValue);
                Assert.AreEqual("1", result.ArrayValue[1].StringValue);
                Assert.AreEqual(1, result.ArrayValue[1].NumericValue);
                Assert.AreEqual(true, result.ArrayValue[1].BooleanValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyArrayStrings()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith(string.Concat("{ \"item\": { \"", mockAttributeName, "\": [ ",
                "\"stringvalue1\", \"stringvalue2\" ] } }"));
                Variant result = client.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("Array", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual("stringvalue1", result.ArrayValue[0].StringValue);
                Assert.AreEqual(0, result.ArrayValue[0].NumericValue);
                Assert.AreEqual(false, result.ArrayValue[0].BooleanValue);
                Assert.AreEqual("stringvalue2", result.ArrayValue[1].StringValue);
                Assert.AreEqual(0, result.ArrayValue[1].NumericValue);
                Assert.AreEqual(false, result.ArrayValue[1].BooleanValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyArrayObjectUnsupported()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith(string.Concat("{ \"item\": { \"", mockAttributeName, "\": [ ",
                "{ \"item1\": \"stringvalue1\", \"item2\": \"stringvalue2\" },",
                "{ \"item1\": \"stringvalue3\", \"item2\": \"stringvalue4\" } ] } }"));
                Variant result = client.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("Array", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(Unsupported, result.ArrayValue[0].StringValue);
                Assert.AreEqual(1, result.ArrayValue[0].NumericValue);
                Assert.AreEqual(false, result.ArrayValue[0].BooleanValue);
                Assert.AreEqual(Unsupported, result.ArrayValue[1].StringValue);
                Assert.AreEqual(1, result.ArrayValue[1].NumericValue);
                Assert.AreEqual(false, result.ArrayValue[1].BooleanValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        [Test]
        public void TestReadPropertyDoesNotExistThrowsException()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("Not Found", 404);
                try
                {
                    Variant result = client.ReadProperty(mockid, mockAttributeName);
                    Assert.Fail();
                }
                catch (Exception e)
                {
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                        .WithVerb(HttpMethod.Get)
                        .Times(1);
                    TestContext.Out.WriteLine(e.Message);
                }
            }
        }

        [Test]
        public void TestReadPropertyUnsupportedEmptyObject()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": {}");
                Variant result = client.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1, result.NumericValue);
                Assert.AreEqual(Unsupported, result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            }
        }

        #endregion

        #region ReadPropertyMultiple Tests

        [Test]
        public void TestReadPropertyMultipleEmptyIds()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }");
                List<Guid> ids = new List<Guid>() { };
                List<string> attributes = new List<string>() { mockAttributeName };
                var results = client.ReadPropertyMultiple(ids, attributes);

                Assert.AreEqual(0, results.Count());
            }
        }

        [Test]
        public void TestReadPropertyMultipleEmptyAttribute()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }");
                List<Guid> ids = new List<Guid>() { mockid };
                List<string> attributes = new List<string>() { };
                var results = client.ReadPropertyMultiple(ids, attributes);

                httpTest.ShouldNotHaveCalled($"https://hostname/api/V2/objects/{mockid}");
                Assert.AreEqual(1, results.Count());
                Assert.AreEqual(0, results.ElementAt(0).Variants.Count());
            }
        }

        [Test]
        public void TestReadPropertyMultipleOneIdOneAttribute()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }");
                List<Guid> ids = new List<Guid>() { mockid };
                List<string> attributes = new List<string>() { mockAttributeName };
                var results = client.ReadPropertyMultiple(ids, attributes);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(1, results.Count());
                Assert.AreEqual(1, results.ElementAt(0).Variants.Count());
            }
        }

        [Test]
        public async Task TestReadPropertyMultipleTwoIdFiveAttributeAsync()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest
                    .RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }")
                    .RespondWith("{ \"item\": { \"" + mockAttributeName2 + "\": 23 } }")
                    .RespondWith("{ \"item\": { \"" + mockAttributeName3 + "\": 23.5 } }")
                    .RespondWith("{ \"item\": { \"" + mockAttributeName4 + "\": false } }")
                    .RespondWith("{ \"item\": { \"" + mockAttributeName5 + "\": [ 1, 2, 3] } }")
                    .RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }")
                    .RespondWith("{ \"item\": { \"" + mockAttributeName2 + "\": 23 } }")
                    .RespondWith("{ \"item\": { \"" + mockAttributeName3 + "\": 23.5 } }")
                    .RespondWith("{ \"item\": { \"" + mockAttributeName4 + "\": false } }")
                    .RespondWith("{ \"item\": { \"" + mockAttributeName5 + "\": [ 1, 2, 3] } }");

                List<Guid> ids = new List<Guid>() { mockid, mockid2 };
                List<string> attributes = new List<string>() { mockAttributeName, mockAttributeName2, mockAttributeName3, mockAttributeName4, mockAttributeName5 };
                var results = await client.ReadPropertyMultipleAsync(ids, attributes).ConfigureAwait(false);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes")
                    .WithVerb(HttpMethod.Get)
                    .Times(5);
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid2}/attributes")
                    .WithVerb(HttpMethod.Get)
                    .Times(5);
                Assert.AreEqual(results.Count(), 2);
                Assert.AreEqual(5, results.ElementAt(0).Variants.Count());
                Assert.AreEqual(5, results.ElementAt(1).Variants.Count());
                foreach (var result in results.ToList())
                {
                    foreach (var attribute in result.Variants.ToList())
                    {
                        Assert.AreNotEqual(1, attribute.NumericValue);
                    }
                }
            }
        }

        [Test]
        public void TestReadPropertyMultipleTwoIdFiveAttribute()
        {
            using (var httpTest = new HttpTest())
            {
                AsyncContext.Run(() =>
                {
                    httpTest
                        .RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }")
                        .RespondWith("{ \"item\": { \"" + mockAttributeName2 + "\": 23 } }")
                        .RespondWith("{ \"item\": { \"" + mockAttributeName3 + "\": 23.5 } }")
                        .RespondWith("{ \"item\": { \"" + mockAttributeName4 + "\": false } }")
                        .RespondWith("{ \"item\": { \"" + mockAttributeName5 + "\": [ 4, 2, 3] } }")
                        .RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }")
                        .RespondWith("{ \"item\": { \"" + mockAttributeName2 + "\": 23 } }")
                        .RespondWith("{ \"item\": { \"" + mockAttributeName3 + "\": 23.5 } }")
                        .RespondWith("{ \"item\": { \"" + mockAttributeName4 + "\": false } }")
                        .RespondWith("{ \"item\": { \"" + mockAttributeName5 + "\": [ 4, 2, 3] } }");

                    List<Guid> ids = new List<Guid>() { mockid, mockid2 };
                    List<string> attributes = new List<string>() { mockAttributeName, mockAttributeName2, mockAttributeName3, mockAttributeName4, mockAttributeName5 };
                    var results = client.ReadPropertyMultiple(ids, attributes);

                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes")
                        .WithVerb(HttpMethod.Get)
                        .Times(5);
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid2}/attributes")
                        .WithVerb(HttpMethod.Get)
                        .Times(5);
                    Assert.AreEqual(results.Count(), 2);
                    Assert.AreEqual(5, results.ElementAt(0).Variants.Count());
                    Assert.AreEqual(5, results.ElementAt(1).Variants.Count());
                    foreach (var result in results.ToList())
                    {
                        foreach (var attribute in result.Variants.ToList())
                        {
                            Assert.AreNotEqual(1, attribute.NumericValue);
                        }
                    }
                });
            }
        }

        [Test]
        public void TestReadPropertyMultipleOneIdOneAttributeDNE()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("No HTTP resource was found that matches the request URI.", 404);
                List<Guid> ids = new List<Guid>() { mockid };
                List<string> attributes = new List<string>() { mockAttributeName };

                try
                {
                    var results = client.ReadPropertyMultiple(ids, attributes);

                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                        .WithVerb(HttpMethod.Get)
                        .Times(1);
                    Assert.AreEqual(0, results.Count());
                }
                catch
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public void TestReadPropertyMultipleOneIdDNE()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("No HTTP resource was found that matches the request URI.", 404);
                List<Guid> ids = new List<Guid>() { mockid };
                List<string> attributes = new List<string>() { mockAttributeName };

                try
                {
                    var results = client.ReadPropertyMultiple(ids, attributes);

                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                        .WithVerb(HttpMethod.Get)
                        .Times(1);
                    Assert.AreEqual(0, results.Count());
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

        public async Task TestWritePropertyStringAsync()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("Accepted", 202);



                await client.WritePropertyAsync(mockid, mockAttributeName, "newValue").ConfigureAwait(false);



                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                    .WithVerb(HttpMethod.Patch)

                    .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")

                    .Times(1);

            }

        }



        [Test]

        public void TestWritePropertyString()

        {

            using (var httpTest = new HttpTest())

            {

                AsyncContext.Run(() =>

                {

                    httpTest.RespondWith("Accepted", 202);



                    client.WriteProperty(mockid, mockAttributeName, "newValue");



                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                        .WithVerb(HttpMethod.Patch)

                        .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")

                        .Times(1);

                });

            }

        }



        [Test]

        public void TestWritePropertyStringWithPriority()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("Accepted", 202);



                client.WriteProperty(mockid, mockAttributeName, "newValue", "writePriorityEnumSet.priorityDefault");



                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                    .WithVerb(HttpMethod.Patch)

                    .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\",\"priority\":\"writePriorityEnumSet.priorityDefault\"}}}}")

                    .Times(1);

            }

        }



        [Test]

        public void TestWritePropertyInteger()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("Accepted", 202);



                client.WriteProperty(mockid, mockAttributeName, 32);



                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                    .WithVerb(HttpMethod.Patch)

                    .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":32}}}}")

                    .Times(1);

            }

        }



        [Test]

        public void TestWritePropertyFloat()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("Accepted", 202);



                client.WriteProperty(mockid, mockAttributeName, 32.5);



                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                    .WithVerb(HttpMethod.Patch)

                    .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":32.5}}}}")

                    .Times(1);

            }

        }



        [Test]

        public void TestWritePropertyBoolean()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("Accepted", 202);



                client.WriteProperty(mockid, mockAttributeName, true);



                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                    .WithVerb(HttpMethod.Patch)

                    .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":true}}}}")

                    .Times(1);

            }

        }



        [Test]

        public void TestWritePropertyArrayString()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("Accepted", 202);



                client.WriteProperty(mockid, mockAttributeName, new[] { "1", "2", "3" });



                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                    .WithVerb(HttpMethod.Patch)

                    .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":[\"1\",\"2\",\"3\"]}}}}")

                    .Times(1);

            }

        }



        [Test]

        public void TestWritePropertyArrayInteger()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("Accepted", 202);



                client.WriteProperty(mockid, mockAttributeName, new[] { 1, 2, 3 });



                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                    .WithVerb(HttpMethod.Patch)

                    .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":[1,2,3]}}}}")

                    .Times(1);

            }

        }



        [Test]

        public void TestWritePropertyBadRequestDoesNothing()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("Bad Request", 400);

                try

                {

                    client.WriteProperty(mockid, mockAttributeName, "badType");

                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                        .WithVerb(HttpMethod.Patch)

                        .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"badType\"}}}}")

                        .Times(1);

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

                httpTest.RespondWith("Accepted", 202);



                List<Guid> ids = new List<Guid>() { mockid };

                List<(string, object)> attributes = new List<(string, object)>() { (mockAttributeName, "newValue") };

                client.WritePropertyMultiple(ids, attributes);



                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                    .WithVerb(HttpMethod.Patch)

                    .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")

                    .Times(1);

            }

        }



        [Test]

        public void TestWritePropertyMultipleManyIdsOneString()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("Accepted", 202);



                List<Guid> ids = new List<Guid>() { mockid, mockid2 };

                List<(string, object)> attributes = new List<(string, object)>() { (mockAttributeName, "newValue") };

                client.WritePropertyMultiple(ids, attributes);



                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                    .WithVerb(HttpMethod.Patch)

                    .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")

                    .Times(1);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid2}")

                    .WithVerb(HttpMethod.Patch)

                    .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")

                    .Times(1);

            }

        }



        [Test]

        public async Task TestWritePropertyMultipleManyIdsManyAttributesAsync()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("Accepted", 202);



                List<Guid> ids = new List<Guid>() { mockid, mockid2 };

                List<(string, object)> attributes = new List<(string, object)>() {

                    (mockAttributeName, "stringvalue"),

                    (mockAttributeName2, 23),

                    (mockAttributeName3, 23.5),

                    (mockAttributeName4, true),

                    (mockAttributeName5, new [] { 1, 2, 3 })};

                await client.WritePropertyMultipleAsync(ids, attributes).ConfigureAwait(false);



                string requestBody = string.Concat("{\"item\":{\"" + mockAttributeName + "\":\"stringvalue\",",

                        "\"" + mockAttributeName2 + "\":23,",

                        "\"" + mockAttributeName3 + "\":23.5,",

                        "\"" + mockAttributeName4 + "\":true,",

                        "\"" + mockAttributeName5 + "\":[1,2,3]}}");



                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                    .WithVerb(HttpMethod.Patch)

                    .WithRequestBody(requestBody)

                    .Times(1);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid2}")

                    .WithVerb(HttpMethod.Patch)

                    .WithRequestBody(requestBody)

                    .Times(1);

            }

        }



        [Test]

        public void TestWritePropertyMultipleManyIdsManyAttributes()

        {

            using (var httpTest = new HttpTest())

            {

                AsyncContext.Run(() =>

                {

                    httpTest.RespondWith("Accepted", 202);



                    List<Guid> ids = new List<Guid>() { mockid, mockid2 };

                    List<(string, object)> attributes = new List<(string, object)>() {

                        (mockAttributeName, "stringvalue"),

                        (mockAttributeName2, 23),

                        (mockAttributeName3, 23.5),

                        (mockAttributeName4, true),

                        (mockAttributeName5, new [] { 1, 2, 3 })};

                    client.WritePropertyMultiple(ids, attributes);



                    string requestBody = string.Concat("{\"item\":{\"" + mockAttributeName + "\":\"stringvalue\",",

                        "\"" + mockAttributeName2 + "\":23,",

                        "\"" + mockAttributeName3 + "\":23.5,",

                        "\"" + mockAttributeName4 + "\":true,",

                        "\"" + mockAttributeName5 + "\":[1,2,3]}}");



                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                        .WithVerb(HttpMethod.Patch)

                        .WithRequestBody(requestBody)

                        .Times(1);

                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid2}")

                        .WithVerb(HttpMethod.Patch)

                        .WithRequestBody(requestBody)

                        .Times(1);

                });

            }

        }



        [Test]

        public void TestWritePropertyMultipleBadRequestDoesNothing()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("Bad Request", 400);



                List<Guid> ids = new List<Guid>() { mockid };

                List<(string, object)> attributes = new List<(string, object)>() { ("badAttributeName", "newValue") };



                try

                {

                    client.WritePropertyMultiple(ids, attributes);

                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")

                        .WithVerb(HttpMethod.Patch)

                        .WithRequestBody("{\"item\":{\"badAttributeName\":\"newValue\"}}")

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

                httpTest.RespondWith("Bad Request", 400);



                try

                {

                    client.WritePropertyMultiple(null, null);

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

                httpTest.RespondWith("OK", 200);



                client.SendCommand(mockid, "EnableAlarms");

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/EnableAlarms")

                    .WithRequestBody("[]")

                    .WithVerb(HttpMethod.Put)

                    .Times(1);

            }

        }



        [Test]

        public void TestSendCommandOneNumber()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("OK", 200);



                List<object> list = new List<object>() { 70 };

                client.SendCommand(mockid, "Adjust", list);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/Adjust")

                    .WithRequestBody("[70]")

                    .WithVerb(HttpMethod.Put)

                    .Times(1);

            }

        }



        [Test]

        public async Task TestSendCommandManyNumberAsync()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("OK", 200);



                List<object> list = new List<object>() { 70.5, 1, 0 };

                await client.SendCommandAsync(mockid, "TemporaryOperatorOverride", list).ConfigureAwait(false);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/TemporaryOperatorOverride")

                    .WithRequestBody("[70.5,1,0]")

                    .WithVerb(HttpMethod.Put)

                    .Times(1);

            }

        }



        [Test]

        public void TestSendCommandManyNumber()

        {

            using (var httpTest = new HttpTest())

            {

                AsyncContext.Run(() =>

                {

                    httpTest.RespondWith("OK", 200);



                    List<object> list = new List<object>() { 70.5, 1, 0 };

                    client.SendCommand(mockid, "TemporaryOperatorOverride", list);

                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/TemporaryOperatorOverride")

                        .WithRequestBody("[70.5,1,0]")

                        .WithVerb(HttpMethod.Put)

                        .Times(1);

                });

            }

        }



        [Test]

        public void TestSendCommandManyEnum()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("OK", 200);



                List<object> list = new List<object>() { "attributeEnumSet.presentValue", "writePriorityEnumSet.priorityNone" };

                client.SendCommand(mockid, "Release", list);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/Release")

                    .WithRequestBody("[\"attributeEnumSet.presentValue\",\"writePriorityEnumSet.priorityNone\"]")

                    .WithVerb(HttpMethod.Put)

                    .Times(1);

            }

        }



        [Test]

        public void TestSendCommandBadRequestDoesNothing()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("Bad Request", 400);



                try

                {

                    List<object> list = new List<object>() { "noMatch", "noMatch" };

                    client.SendCommand(mockid, "Release", list);

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

                httpTest.RespondWith("Unauthorized", 401);



                try

                {

                    List<object> list = new List<object>() { 40, "badDataTypes" };

                    client.SendCommand(mockid, "Release", list);

                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/Release")

                        .WithRequestBody("[40,\"badDataTypes\"]")

                        .WithVerb(HttpMethod.Put)

                        .Times(1);

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

        public async Task TestGetCommandsNoneAsync()

        {

            using (var httpTest = new HttpTest())

            {

                httpTest.RespondWith("[]");



                var commands = await client.GetCommandsAsync(mockid).ConfigureAwait(false);

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands")

                    .WithVerb(HttpMethod.Get)

                    .Times(1);

                Assert.AreEqual(0, commands.ToList().Count);

            }

        }



        [Test]

        public void TestGetCommandsNone()

        {

            using (var httpTest = new HttpTest())

            {

                AsyncContext.Run(() =>

                {

                    httpTest.RespondWith("[]");



                    var commands = client.GetCommands(mockid).ToList();

                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands")

                        .WithVerb(HttpMethod.Get)

                        .Times(1);

                    Assert.AreEqual(0, commands.Count);

                });

            }

        }



        [Test]

        public void TestGetCommandsEmpty()

        {

            using (var httpTest = new HttpTest())

            {

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



                var commands = client.GetCommands(mockid).ToList();

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



                var commands = client.GetCommands(mockid).ToList();

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



                var commands = client.GetCommands(mockid).ToList();

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



                var commands = client.GetCommands(mockid).ToList();

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

        #endregion       


      


        #region miscellaneous

        [Test]
        public void TestNullTokenValue()
        {
            string json = "{\"test\":null}";
            JToken o = JToken.Parse(json);
            string oString = o.ToString().Replace(" ", "").Replace("\r", "").Replace("\n", "");

            Assert.AreEqual(json, oString);
            Assert.AreEqual(JTokenType.Null, o["test"].Type);
        }

        #endregion
    }
}
