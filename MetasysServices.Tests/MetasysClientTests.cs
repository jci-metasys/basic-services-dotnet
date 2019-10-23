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
        private static string ArrayEnum = "dataTypeEnumSet.arrayDataType";
        private static string Array = "Array";
        private static string UnsupportedEnum = "statusEnumSet.unsupportedObjectType";
        private static string Unsupported = "Unsupported object type";
        private static string PriorityNoneEnum = "writePriorityEnumSet.priorityNone";
        private static string PriorityNone = "0 (No Priority)";
        private static string ReliableEnum = "reliabilityEnumSet.reliable";
        private static string Reliable = "Reliable";
        private static string ReliableHighEnum = "reliabilityEnumSet.unreliableHigh";
        private static string ReliableHigh = "Out of range high";
        private static Guid mockid = new Guid("11111111-2222-3333-4444-555555555555");
        private static Guid mockid2 = new Guid("11111111-2222-3333-4444-555555555556");
        private static Guid mockid3 = new Guid("11111111-2222-3333-4444-555555555557");
        private static string mockAttributeName = "property";
        private static string mockAttributeName2 = "property2";
        private static string mockAttributeName3 = "property3";
        private static string mockAttributeName4 = "property4";
        private static string mockAttributeName5 = "property5";
        private static string date1 = "2030-01-01T00:00:00Z";
        private static DateTime dateTime1 = DateTime.Parse(date1).ToUniversalTime();
        private static string date2 = "2030-01-01T00:01:00Z";
        private static DateTime dateTime2 = DateTime.Parse(date2).ToUniversalTime();
        private MetasysClient client;
        private HttpTest httpTest;

        [OneTimeSetUp]
        public void Init()
        {
            client = new MetasysClient("hostname", false, ApiVersion.V2, new System.Globalization.CultureInfo("en-US"));
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

        #region Login Tests

        [Test]
        public async Task TestLoginAsync()
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

        [Test]
        public void TestLogin()
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

        [Test]
        public void TestUnauthorizedLoginThrowsException()
        {
            httpTest.RespondWith("unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.TryLogin("username", "badpassword"));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
                .WithVerb(HttpMethod.Post)
                .WithContentType("application/json")
                .WithRequestBody("{\"username\":\"username\",\"password\":\"badpassword\"")
                .Times(1);

            Console.Error.WriteLine($"TestUnauthorizedLoginThrowsException: {e.Message}");
        }

        [Test]
        public void TestBadHostLoginThrowsException()
        {
            httpTest.RespondWith("Call failed. No such host is known POST https://badhost/api/V2/login", 404);
            MetasysClient clientBad = new MetasysClient("badhost");
            var e = Assert.Throws<MetasysHttpException>(() =>
                    clientBad.TryLogin("username", "password"));

            httpTest.ShouldHaveCalled($"https://badhost/api/V2/login")
                .WithVerb(HttpMethod.Post)
                .WithContentType("application/json")
                .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                .Times(1);

            Console.Error.WriteLine($"TestBadHostLoginThrowsException: {e.Message}");
        }

        [Test]
        public void TestBadResponseTokenThrowsException()
        {
            httpTest.RespondWithJson(new { expires = date1 });
            var accessToken = client.GetAccessToken();

            var e = Assert.Throws<MetasysTokenException>(() =>
                client.TryLogin("username", "password"));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
                .WithVerb(HttpMethod.Post)
                .WithContentType("application/json")
                .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                .Times(1);
            Assert.AreEqual(accessToken, client.GetAccessToken());
            Console.Error.WriteLine($"TestBadResponseTokenThrowsException: {e.Message}");
        }

        [Test]
        public void TestBadResponseExpiresThrowsException()
        {
            httpTest.RespondWithJson(new { accessToken = "faketoken1" });
            var accessToken = client.GetAccessToken();

            var e = Assert.Throws<MetasysTokenException>(() =>
                client.TryLogin("username", "badpassword"));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
                .WithVerb(HttpMethod.Post)
                .WithContentType("application/json")
                .WithRequestBody("{\"username\":\"username\",\"password\":\"badpassword\"")
                .Times(1);
            Assert.AreEqual(accessToken, client.GetAccessToken());
            Console.Error.WriteLine($"TestBadResponseExpiresThrowsException: {e.Message}");
        }

        #endregion

        #region Refresh Tests

        [Test]
        public async Task TestRefreshAsync()
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

        [Test]
        public void TestRefresh()
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

        [Test]
        public void TestUnauthorizedRefreshThrowsException()
        {
            httpTest.RespondWith("unauthorized", 401);
            var e = Assert.Throws<MetasysHttpException>(() =>
                    client.Refresh());

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/refreshToken")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Console.Error.WriteLine($"TestUnauthorizedRefreshThrowsException: {e.Message}");
        }

        [Test]
        public void TestRefreshTimer()
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

        #endregion

        #region GetObjectIdentifier Tests

        [Test]
        public async Task TestGetObjectIdentifierAsync()
        {
            httpTest.RespondWith($"\"{mockid.ToString()}\"");
            var id = await client.GetObjectIdentifierAsync("fully:qualified/reference").ConfigureAwait(false);
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(typeof(Guid), id.GetType());
        }

        [Test]
        public void TestGetObjectIdentifier()
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

        [Test]
        public void TestGetObjectIdentifierBadRequestThrowsException()
        {
            httpTest.RespondWith("Bad Request", 400);
            var e = Assert.Throws<MetasysHttpException>(() =>
                client.GetObjectIdentifier("fully:qualified/reference"));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Console.Error.WriteLine($"TestGetObjectIdentifierBadRequestThrowsException: {e.Message}");
        }

        [Test]
        public void TestGetObjectIdentifierBadResponseThrowsException()
        {
            httpTest.RespondWith($"\"{mockid.ToString()}1\"");
            var e = Assert.Throws<MetasysGuidException>(() =>
                client.GetObjectIdentifier("fully:qualified/reference"));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new MetasysGuidException("Bad Argument", $"{mockid.ToString()}1", null);
            Assert.AreEqual(expected.Message, e.Message);
            Console.Error.WriteLine($"TestGetObjectIdentifierBadResponseThrowsException: {e.Message}");
        }

        [Test]
        public void TestGetObjectIdentifierNullResponseThrowsException()
        {
            httpTest.RespondWith("null");
            var e = Assert.Throws<MetasysGuidException>(() =>
                client.GetObjectIdentifier("fully:qualified/reference"));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new MetasysGuidException("Argument Null", null);
            Assert.AreEqual(expected.Message, e.Message);
            Console.Error.WriteLine($"TestGetObjectIdentifierBadResponseThrowsException: {e.Message}");
        }

        #endregion

        #region ReadProperty Tests

        [Test]
        public async Task TestReadPropertyIntegerAsync()
        {
            httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": 1 }}");
            Variant result = (await client.ReadPropertyAsync(mockid, mockAttributeName).ConfigureAwait(false)).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, result.NumericValue);
                Assert.AreEqual("1", result.StringValue);
                Assert.AreEqual(true, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            });
        }

        [Test]
        public void TestReadPropertyInteger()
        {
            AsyncContext.Run(() =>
            {
                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": 1 }}");
                Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(1, result.NumericValue);
                    Assert.AreEqual("1", result.StringValue);
                    Assert.AreEqual(true, result.BooleanValue);
                    Assert.AreEqual(null, result.ArrayValue);
                    Assert.AreEqual(null, result.Priority);
                    Assert.AreEqual(Reliable, result.Reliability);
                    Assert.AreEqual(true, result.IsReliable);
                });
            });
        }

        [Test]
        public void TestReadPropertyFloat()
        {
            httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": 1.1 }}");
            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1.1, result.NumericValue);
                Assert.AreEqual("1.1", result.StringValue);
                Assert.AreEqual(true, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            });

        }

        [Test]
        public void TestReadPropertyString()
        {
            httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": \"stringvalue\" }}");
            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("stringvalue", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            });
        }

        [Test]
        public void TestReadPropertyBooleanTrue()
        {
            httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": true }}");
            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, result.NumericValue);
                Assert.AreEqual("True", result.StringValue);
                Assert.AreEqual(true, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            });
        }

        [Test]
        public void TestReadPropertyBooleanFalse()
        {
            httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": false }}");
            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("False", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            });
        }

        [Test]
        public void TestReadPropertyPresentValueInteger()
        {
            httpTest.RespondWith(string.Concat("{ \"item\": { \"presentValue\": {",
                "\"value\": 60 } } }"));
            Variant result = client.ReadProperty(mockid, "presentValue").Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/presentValue")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(60, result.NumericValue);
                Assert.AreEqual("60", result.StringValue);
                Assert.AreEqual(true, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            });
        }

        [Test]
        public void TestReadPropertyPresentValueString()
        {
            httpTest.RespondWith(string.Concat("{ \"item\": { \"presentValue\": {",
                "\"value\": \"stringvalue\" } } }"));
            Variant result = client.ReadProperty(mockid, "presentValue").Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/presentValue")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual("stringvalue", result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            });
        }

        [Test]
        public void TestReadPropertyPresentValueNoValue()
        {
            httpTest.RespondWith(string.Concat("{ \"item\": { \"presentValue\": { ",
            "\"property\": \"stringvalue\",",
            "\"reliability\": \"", ReliableHighEnum, "\",",
            "\"priority\": \"", PriorityNoneEnum, "\"} } }"));
            Variant result = client.ReadProperty(mockid, "presentValue").Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/presentValue")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, result.NumericValue);
                Assert.AreEqual(Unsupported, result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(PriorityNone, result.Priority);
                Assert.AreEqual(ReliableHigh, result.Reliability);
                Assert.AreEqual(false, result.IsReliable);
            });
        }

        [Test]
        public void TestReadPropertyObjectNotPresentValue()
        {
            httpTest.RespondWith(string.Concat("{ \"item\": { \"", mockAttributeName, "\": { ",
            "\"property\": \"stringvalue\",",
            "\"reliability\": \"", ReliableHighEnum, "\",",
            "\"priority\": \"", PriorityNoneEnum, "\"} } }"));
            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, result.NumericValue);
                Assert.AreEqual(Unsupported, result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            });
        }

        [Test]
        public void TestReadPropertyArrayIntegers()
        {
            httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": [ 0, 1 ] } }");
            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual(Array, result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            });
            Assert.Multiple(() =>
            {
                Assert.AreEqual("0", result.ArrayValue[0].StringValue);
                Assert.AreEqual(0, result.ArrayValue[0].NumericValue);
                Assert.AreEqual(false, result.ArrayValue[0].BooleanValue);

                Assert.AreEqual("1", result.ArrayValue[1].StringValue);
                Assert.AreEqual(1, result.ArrayValue[1].NumericValue);
                Assert.AreEqual(true, result.ArrayValue[1].BooleanValue);
            });
        }

        [Test]
        public void TestReadPropertyArrayStrings()
        {
            httpTest.RespondWith(string.Concat("{ \"item\": { \"", mockAttributeName, "\": [ ",
            "\"stringvalue1\", \"stringvalue2\" ] } }"));
            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual(Array, result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            });
            Assert.Multiple(() =>
            {
                Assert.AreEqual("stringvalue1", result.ArrayValue[0].StringValue);
                Assert.AreEqual(0, result.ArrayValue[0].NumericValue);
                Assert.AreEqual(false, result.ArrayValue[0].BooleanValue);
                Assert.AreEqual("stringvalue2", result.ArrayValue[1].StringValue);
                Assert.AreEqual(0, result.ArrayValue[1].NumericValue);
                Assert.AreEqual(false, result.ArrayValue[1].BooleanValue);
            });
        }

        [Test]
        public void TestReadPropertyArrayObjectUnsupported()
        {
            httpTest.RespondWith(string.Concat("{ \"item\": { \"", mockAttributeName, "\": [ ",
            "{ \"item1\": \"stringvalue1\", \"item2\": \"stringvalue2\" },",
            "{ \"item1\": \"stringvalue3\", \"item2\": \"stringvalue4\" } ] } }"));
            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(0, result.NumericValue);
                Assert.AreEqual(Array, result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);

                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            });
            Assert.Multiple(() =>
            {
                Assert.AreEqual(Unsupported, result.ArrayValue[0].StringValue);
                Assert.AreEqual(1, result.ArrayValue[0].NumericValue);
                Assert.AreEqual(false, result.ArrayValue[0].BooleanValue);
                Assert.AreEqual(Unsupported, result.ArrayValue[1].StringValue);
                Assert.AreEqual(1, result.ArrayValue[1].NumericValue);
                Assert.AreEqual(false, result.ArrayValue[1].BooleanValue);
            });
        }

        [Test]
        public void TestReadPropertyUnsupportedEmptyObject()
        {
            httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": {}");
            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, result.NumericValue);
                Assert.AreEqual(Unsupported, result.StringValue);
                Assert.AreEqual(false, result.BooleanValue);
                Assert.AreEqual(null, result.ArrayValue);
                Assert.AreEqual(null, result.Priority);
                Assert.AreEqual(Reliable, result.Reliability);
                Assert.AreEqual(true, result.IsReliable);
            });
        }

        [Test]
        public void TestReadPropertyDoesNotExistDoesNotThrowException()
        {
            httpTest.RespondWith("Not Found", 404);
            Variant? result = client.ReadProperty(mockid, mockAttributeName);
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(null, result);
        }

        #endregion

        #region ReadPropertyMultiple Tests

        [Test]
        public void TestReadPropertyMultipleEmptyIds()
        {
            httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }");
            List<Guid> ids = new List<Guid>() { };
            List<string> attributes = new List<string>() { mockAttributeName };
            var results = client.ReadPropertyMultiple(ids, attributes);

            Assert.AreEqual(0, results.Count());
        }

        [Test]
        public void TestReadPropertyMultipleEmptyAttributes()
        {
            httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }");
            List<Guid> ids = new List<Guid>() { mockid };
            List<string> attributes = new List<string>() { };
            var results = client.ReadPropertyMultiple(ids, attributes);

            httpTest.ShouldNotHaveCalled($"https://hostname/api/V2/objects/{mockid}");
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual(0, results.ElementAt(0).Variants.Count());
        }

        [Test]
        public void TestReadPropertyMultipleOneIdOneAttribute()
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

        [Test]
        public async Task TestReadPropertyMultipleTwoIdFiveAttributeAsync()
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
            List<string> attributes = new List<string>() {
                mockAttributeName, mockAttributeName2, mockAttributeName3, mockAttributeName4, mockAttributeName5 };
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

        [Test]
        public void TestReadPropertyMultipleTwoIdFiveAttribute()
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

        [Test]
        public void TestReadPropertyMultipleOneIdOneAttributeDNE()
        {
            httpTest.RespondWith("No HTTP resource was found that matches the request URI.", 404);
            List<Guid> ids = new List<Guid>() { mockid };
            List<string> attributes = new List<string>() { mockAttributeName };

            var results = client.ReadPropertyMultiple(ids, attributes);

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, results.Count());
        }

        [Test]
        public void TestReadPropertyMultipleOneIdDNE()
        {
            httpTest.RespondWith("No HTTP resource was found that matches the request URI.", 404);
            List<Guid> ids = new List<Guid>() { mockid };
            List<string> attributes = new List<string>() { mockAttributeName };

            var results = client.ReadPropertyMultiple(ids, attributes);

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, results.Count());
        }

        #endregion

        #region WriteProperty Tests

        [Test]
        public async Task TestWritePropertyStringAsync()
        {
            httpTest.RespondWith("Accepted", 202);
            await client.WritePropertyAsync(mockid, mockAttributeName, "newValue").ConfigureAwait(false);
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")
                .Times(1);
        }

        [Test]
        public void TestWritePropertyString()
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

        [Test]
        public void TestWritePropertyStringWithPriority()
        {
            httpTest.RespondWith("Accepted", 202);
            client.WriteProperty(mockid, mockAttributeName, "newValue", "writePriorityEnumSet.priorityDefault");
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\",\"priority\":\"writePriorityEnumSet.priorityDefault\"}}}}")
                .Times(1);
        }

        [Test]
        public void TestWritePropertyInteger()
        {
            httpTest.RespondWith("Accepted", 202);
            client.WriteProperty(mockid, mockAttributeName, 32);
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":32}}}}")
                .Times(1);
        }

        [Test]
        public void TestWritePropertyFloat()
        {
            httpTest.RespondWith("Accepted", 202);
            client.WriteProperty(mockid, mockAttributeName, 32.5);
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":32.5}}}}")
                .Times(1);
        }

        [Test]
        public void TestWritePropertyBoolean()
        {
            httpTest.RespondWith("Accepted", 202);
            client.WriteProperty(mockid, mockAttributeName, true);
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":true}}}}")
                .Times(1);
        }

        [Test]
        public void TestWritePropertyArrayString()
        {
            httpTest.RespondWith("Accepted", 202);
            client.WriteProperty(mockid, mockAttributeName, new[] { "1", "2", "3" });
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":[\"1\",\"2\",\"3\"]}}}}")
                .Times(1);
        }

        [Test]
        public void TestWritePropertyArrayInteger()
        {
            httpTest.RespondWith("Accepted", 202);
            client.WriteProperty(mockid, mockAttributeName, new[] { 1, 2, 3 });
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":[1,2,3]}}}}")
                .Times(1);
        }

        [Test]
        public void TestWritePropertyBadRequestThrowsException()
        {
            httpTest.RespondWith("Bad Request", 400);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.WriteProperty(mockid, mockAttributeName, "badType"));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"badType\"}}}}")
                .Times(1);
            
            Console.Error.WriteLine($"TestBadResponseExpiresThrowsException: {e.Message}");
        }

        #endregion

        #region WritePropertyMultiple Tests

        [Test]
        public void TestWritePropertyMultipleOneIdOneString()
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

        [Test]
        public void TestWritePropertyMultipleManyIdsOneString()
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

        [Test]
        public async Task TestWritePropertyMultipleManyIdsManyAttributesAsync()
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

        [Test]
        public void TestWritePropertyMultipleManyIdsManyAttributes()
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

        [Test]
        public void TestWritePropertyMultipleBadRequestThrowsException()
        {
            httpTest.RespondWith("Bad Request", 400);
            List<Guid> ids = new List<Guid>() { mockid };
            List<(string, object)> attributes = new List<(string, object)>() { ("badAttributeName", "newValue") };
            
            var e = Assert.Throws<MetasysHttpException>(() =>
                client.WritePropertyMultiple(ids, attributes));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody("{\"item\":{\"badAttributeName\":\"newValue\"}}")
                .Times(1);
            Console.Error.WriteLine($"TestWritePropertyMultipleBadRequestThrowsException: {e.Message}");
        }

        [Test]
        public void TestWritePropertyMultipleNullArguments()
        {
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

        #endregion

        #region SendCommand Tests

        [Test]
        public void TestSendCommandEmptyBody()
        {
            httpTest.RespondWith("OK", 200);
            client.SendCommand(mockid, "EnableAlarms");
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/EnableAlarms")
                .WithRequestBody("[]")
                .WithVerb(HttpMethod.Put)
                .Times(1);
        }

        [Test]
        public void TestSendCommandOneNumber()
        {
            httpTest.RespondWith("OK", 200);
            List<object> list = new List<object>() { 70 };
            client.SendCommand(mockid, "Adjust", list);
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/Adjust")
                .WithRequestBody("[70]")
                .WithVerb(HttpMethod.Put)
                .Times(1);
        }

        [Test]
        public async Task TestSendCommandManyNumberAsync()
        {
            httpTest.RespondWith("OK", 200);
            List<object> list = new List<object>() { 70.5, 1, 0 };
            await client.SendCommandAsync(mockid, "TemporaryOperatorOverride", list).ConfigureAwait(false);
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/TemporaryOperatorOverride")
                .WithRequestBody("[70.5,1,0]")
                .WithVerb(HttpMethod.Put)
                .Times(1);
        }

        [Test]
        public void TestSendCommandManyNumber()
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

        [Test]
        public void TestSendCommandManyEnum()
        {
            httpTest.RespondWith("OK", 200);
            List<object> list = new List<object>() { "attributeEnumSet.presentValue", "writePriorityEnumSet.priorityNone" };
            client.SendCommand(mockid, "Release", list);
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/Release")
                .WithRequestBody("[\"attributeEnumSet.presentValue\",\"writePriorityEnumSet.priorityNone\"]")
                .WithVerb(HttpMethod.Put)
                .Times(1);
        }

        [Test]
        public void TestSendCommandBadRequestThrowsException()
        {
            httpTest.RespondWith("Bad Request", 400);
            List<object> list = new List<object>() { "noMatch", "noMatch" };

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.SendCommand(mockid, "Release", list));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/Release")
                .WithVerb(HttpMethod.Put)
                .Times(1);

            Console.Error.WriteLine($"TestSendCommandBadRequestThrowsException: {e.Message}");
        }

        [Test]
        public void TestSendCommandUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);
            List<object> list = new List<object>() { 40, "badDataTypes" };
                
            var e = Assert.Throws<MetasysHttpException>(() =>
                client.SendCommand(mockid, "Release", list));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands/Release")
                .WithRequestBody("[40,\"badDataTypes\"]")
                .WithVerb(HttpMethod.Put)
                .Times(1);

            Console.Error.WriteLine($"TestSendCommandUnauthorizedThrowsException: {e.Message}");
        }

        #endregion

        #region GetCommands Tests

        [Test]
        public async Task TestGetCommandsNoneAsync()
        {
            httpTest.RespondWith("[]");
            var commands = await client.GetCommandsAsync(mockid).ConfigureAwait(false);
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/commands")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, commands.ToList().Count);
        }

        [Test]
        public void TestGetCommandsNone()
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

        [Test]
        public void TestGetCommandsEmpty()
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

        [Test]
        public void TestGetCommandsOneEnum()
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

        [Test]
        public void TestGetCommandsOneNumber()
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

        [Test]
        public void TestGetCommandsTwoEnumOneNumber()
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
