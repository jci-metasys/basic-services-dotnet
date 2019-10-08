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
            client = new MetasysClient("hostname");
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
                    MetasysClient clientBad = new MetasysClient("badhost");
                    clientBad.TryLogin("username", "password");

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
        public void TestGetObjectIdentifierBadRequestReturnsEmpty()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("Bad Request", 400);

                var id = client.GetObjectIdentifier("fully:qualified/reference");
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
                httpTest.RespondWith("Bad Request", 400);

                var id = client.GetObjectIdentifier("fully:qualified/reference");
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
                Assert.AreEqual(Guid.Empty, id);
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
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
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
                    Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
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
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
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
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
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
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
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
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
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
                Assert.AreEqual("writePriorityEnumSet.priorityNone", result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
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
                Assert.AreEqual("Unsupported Data Type", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
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
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
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
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
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
                Assert.AreEqual("Unsupported Data Type", result.ArrayValue[0].StringValue);
                Assert.AreEqual(1, result.ArrayValue[0].NumericValue);
                Assert.AreEqual(false, result.ArrayValue[0].BooleanValue);
                Assert.AreEqual("Unsupported Data Type", result.ArrayValue[1].StringValue);
                Assert.AreEqual(1, result.ArrayValue[1].NumericValue);
                Assert.AreEqual(false, result.ArrayValue[1].BooleanValue);
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
                httpTest.RespondWith("Not Found", 404);
                try
                {
                    Variant result = client.ReadProperty(mockid, mockAttributeName);
                    httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                        .WithVerb(HttpMethod.Get)
                        .Times(1);
                }
                catch
                {
                    Assert.Fail();
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
                Assert.AreEqual("Unsupported Data Type", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual("reliabilityEnumSet.reliable", result.Reliability);
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
                    Assert.AreEqual(1, results.Count());
                    Assert.AreEqual(1, results.ElementAt(0).Variants.Count());
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
                    Assert.AreEqual(1, results.Count());
                    Assert.AreEqual(1, results.ElementAt(0).Variants.Count());
                }
                catch
                {
                    Assert.Fail();
                }
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
