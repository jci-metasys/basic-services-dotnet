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
using System.Globalization;

namespace Tests
{
    public class MetasysClientTests
    {
        // Update these en-US resources as needed
        private const string ArrayEnum = "dataTypeEnumSet.arrayDataType";
        private const string Array = "Array";
        private const string UnsupportedEnum = "statusEnumSet.unsupportedObjectType";
        private const string Unsupported = "Unsupported object type";
        private const string PriorityNoneEnum = "writePriorityEnumSet.priorityNone";
        private const string PriorityNone = "0 (No Priority)";
        private const string ReliableEnum = "reliabilityEnumSet.reliable";
        private const string Reliable = "Reliable";
        private const string ReliableHighEnum = "reliabilityEnumSet.unreliableHigh";
        private const string ReliableHigh = "Out of range high";
        private static readonly Guid mockid = new Guid("11111111-2222-3333-4444-555555555555");
        private static readonly Guid mockid2 = new Guid("11111111-2222-3333-4444-555555555556");
        private static readonly Guid mockid3 = new Guid("11111111-2222-3333-4444-555555555557");
        private const string mockAttributeName = "property";
        private const string mockAttributeName2 = "property2";
        private const string mockAttributeName3 = "property3";
        private const string mockAttributeName4 = "property4";
        private const string mockAttributeName5 = "property5";
        private const string date1 = "2030-01-01T00:00:00Z";
        private static readonly DateTime dateTime1 = DateTime.Parse(date1).ToUniversalTime();
        private const string date2 = "2030-01-01T00:01:00Z";
        private static readonly DateTime dateTime2 = DateTime.Parse(date2).ToUniversalTime();
        private static readonly CultureInfo testCulture = new CultureInfo("en-US");
        private MetasysClient client;
        private HttpTest httpTest;

        [OneTimeSetUp]
        public void Init()
        {
            client = new MetasysClient("hostname", false, ApiVersion.V2, testCulture);
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

        /// <summary>
        /// Use this method to control the "dotnet test" console message printing.
        /// </summary>
        private void PrintMessage(string message, bool isException)
        {
            Console.Error.WriteLine(message);
        }

        /// <summary>
        /// Use to setup client when the AccessToken is being tested.
        /// </summary>
        private void CleanLogin()
        {
            httpTest.RespondWithJson(new { accessToken = "cleanfaketoken", expires = date1 });
            client.TryLogin("cleanusername", "cleanpassword");
        }

        #region Login Tests

        [Test]
        public async Task TestLoginAsync()
        {
            CleanLogin();
            httpTest.RespondWithJson(new { accessToken = "faketokenLoginAsync", expires = date2 });

            await client.TryLoginAsync("username", "password").ConfigureAwait(false);

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
                .WithVerb(HttpMethod.Post)
                .WithContentType("application/json")
                .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                .Times(1);
            var token = client.GetAccessToken();
            var expected = new AccessToken("Bearer faketokenLoginAsync", dateTime2);
            Assert.AreEqual(expected, token);
        }

        [Test]
        public void TestLoginAsyncContext()
        {
            AsyncContext.Run(() =>
            {
                CleanLogin();
                httpTest.RespondWithJson(new { accessToken = "faketokenLoginAsyncContext", expires = date2 });

                client.TryLogin("username", "password");

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
                    .WithVerb(HttpMethod.Post)
                    .WithContentType("application/json")
                    .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                    .Times(1);
                var token = client.GetAccessToken();
                var expected = new AccessToken("Bearer faketokenLoginAsyncContext", dateTime2);
                Assert.AreEqual(expected, token);
            });
        }

        [Test]
        public void TestLoginUnauthorizedThrowsException()
        {
            CleanLogin();
            var original = client.GetAccessToken();
            httpTest.RespondWith("unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.TryLogin("username", "badpassword"));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
                .WithVerb(HttpMethod.Post)
                .WithContentType("application/json")
                .WithRequestBody("{\"username\":\"username\",\"password\":\"badpassword\"")
                .Times(1);
            Assert.AreEqual(original, client.GetAccessToken()); // The access token is not changed on error
            PrintMessage($"TestLoginUnauthorizedThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestLoginBadHostThrowsException()
        {
            CleanLogin();
            var original = client.GetAccessToken();
            httpTest.RespondWith("Call failed. No such host is known POST https://badhost/api/V2/login", 404);
            MetasysClient clientBad = new MetasysClient("badhost");

            var e = Assert.Throws<MetasysHttpException>(() =>
                clientBad.TryLogin("username", "password"));

            httpTest.ShouldHaveCalled($"https://badhost/api/V2/login")
                .WithVerb(HttpMethod.Post)
                .WithContentType("application/json")
                .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                .Times(1);
            Assert.AreEqual(original, client.GetAccessToken()); // The access token is not changed on error
            PrintMessage($"TestLoginBadHostThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestLoginBadResponseMissingTokenThrowsException()
        {
            CleanLogin();
            var original = client.GetAccessToken();
            httpTest.RespondWithJson(new { expires = date2 });

            var e = Assert.Throws<MetasysTokenException>(() =>
                client.TryLogin("username", "password"));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
                .WithVerb(HttpMethod.Post)
                .WithContentType("application/json")
                .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                .Times(1);
            Assert.AreEqual(original, client.GetAccessToken()); // The access token is not changed on error
            PrintMessage($"TestLoginBadResponseMissingTokenThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestLoginBadResponseMissingExpiresThrowsException()
        {
            CleanLogin();
            var original = client.GetAccessToken();

            httpTest.RespondWithJson(new { accessToken = "faketokenNoExpire" });
            var e = Assert.Throws<MetasysTokenException>(() =>
                client.TryLogin("username", "badpassword"));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/login")
                .WithVerb(HttpMethod.Post)
                .WithContentType("application/json")
                .WithRequestBody("{\"username\":\"username\",\"password\":\"badpassword\"")
                .Times(1);
            Assert.AreEqual(original, client.GetAccessToken()); // The access token is not changed on error
            PrintMessage($"TestLoginBadResponseMissingExpiresThrowsException: {e.Message}", true);
        }

        #endregion

        #region Refresh Tests

        [Test]
        public async Task TestRefreshAsync()
        {
            CleanLogin();
            httpTest.RespondWithJson(new { accessToken = "faketokenRefreshAsync", expires = date2 });

            await client.RefreshAsync().ConfigureAwait(false);

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/refreshToken")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var token = client.GetAccessToken();
            var expected = new AccessToken("Bearer faketokenRefreshAsync", dateTime2);
            Assert.AreEqual(expected, token);
        }

        [Test]
        public void TestRefreshAsyncContext()
        {
            AsyncContext.Run(() =>
            {
                CleanLogin();
                httpTest.RespondWithJson(new { accessToken = "faketokenRefreshAsyncContext", expires = date2 });

                client.Refresh();

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/refreshToken")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                var token = client.GetAccessToken();
                var expected = new AccessToken("Bearer faketokenRefreshAsyncContext", dateTime2);
                Assert.AreEqual(expected, token);
            });
        }

        [Test]
        public void TestRefreshUnauthorizedThrowsException()
        {
            CleanLogin();
            var original = client.GetAccessToken();
            httpTest.RespondWith("unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                    client.Refresh());

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/refreshToken")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(original, client.GetAccessToken()); // The access token is not changed on error
            PrintMessage($"TestRefreshUnauthorizedThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestRefreshTimerTwoSeconds()
        {
            DateTime now = DateTime.UtcNow;
            DateTime future = new DateTime(now.Ticks - (now.Ticks % TimeSpan.TicksPerSecond));
            future.AddSeconds(2);
            string time = future.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'");
            httpTest.RespondWithJson(new { accessToken = "faketokenTimer1", expires = time })
                .RespondWithJson(new { accessToken = "faketokenTimer2", expires = date2 });
            var expected1 = new AccessToken("Bearer faketokenTimer1", future);
            var expected2 = new AccessToken("Bearer faketokenTimer2", dateTime2);

            client.TryLogin("username", "password");

            var token1 = client.GetAccessToken();
            Assert.AreEqual(expected1, token1);

            System.Threading.Thread.Sleep(2000);
            httpTest.ShouldHaveCalled($"https://hostname/api/V2/refreshToken")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var token2 = client.GetAccessToken();
            Assert.AreEqual(expected2, token2);
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
            Assert.AreEqual(mockid, id);
        }

        [Test]
        public void TestGetObjectIdentifierAsyncContext()
        {
            AsyncContext.Run(() =>
            {
                httpTest.RespondWith($"\"{mockid.ToString()}\"");
                var id = client.GetObjectIdentifier("fully:qualified/reference");
                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objectIdentifiers")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(mockid, id);
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
            PrintMessage($"TestGetObjectIdentifierBadRequestThrowsException: {e.Message}", true);
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
            PrintMessage($"TestGetObjectIdentifierBadResponseThrowsException: {e.Message}", true);
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
            PrintMessage($"TestGetObjectIdentifierNullResponseThrowsException: {e.Message}", true);
        }

        #endregion

        #region ReadProperty Tests

        [Test]
        public async Task TestReadPropertyIntegerAsync()
        {
            string json = "{\"item\": { \"" + mockAttributeName + "\": 1 }}";
            var token = JToken.FromObject(1);
            httpTest.RespondWith(json);

            Variant result = (await client.ReadPropertyAsync(mockid, mockAttributeName).ConfigureAwait(false)).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyIntegerAsyncContext()
        {
            AsyncContext.Run(() =>
            {
                string json = "{\"item\": { \"" + mockAttributeName + "\": 1 }}";
                var token = JToken.FromObject(1);
                httpTest.RespondWith(json);

                Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

                httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                var expected = new Variant(mockid, token, mockAttributeName, testCulture);
                Assert.AreEqual(expected, result);
            });
        }

        [Test]
        public void TestReadPropertyFloat()
        {
            string json = "{\"item\": { \"" + mockAttributeName + "\": 1.1 }}";
            var token = JToken.FromObject(1.1);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyString()
        {
            string json = "{\"item\": { \"" + mockAttributeName + "\": \"stringvalue\" }}";
            var token = JToken.FromObject("stringvalue");
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyBooleanTrue()
        {
            string json = "{\"item\": { \"" + mockAttributeName + "\": true }}";
            var token = JToken.FromObject(true);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyBooleanFalse()
        {
            string json = "{\"item\": { \"" + mockAttributeName + "\": false }}";
            var token = JToken.FromObject(false);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyPresentValueInteger()
        {
            string json = string.Concat("{ \"item\": { \"presentValue\": {", 
                "\"value\": 60 } } }");
            var token = JToken.Parse("{ \"value\": 60 }");
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, "presentValue").Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/presentValue")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, "presentValue", testCulture);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyPresentValueString()
        {
            string json = string.Concat("{ \"item\": { \"presentValue\": {",
                "\"value\": \"stringvalue\" } } }");
            var token = JToken.Parse("{ \"value\": \"stringvalue\" }");
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, "presentValue").Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/presentValue")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, "presentValue", testCulture);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyPresentValueNoValue()
        {
            string body = string.Concat("{",
                "\"property\": \"stringvalue\",",
                "\"reliability\": \"", ReliableHighEnum, "\",",
                "\"priority\": \"", PriorityNoneEnum, "\"}");
            string json = string.Concat("{ \"item\": { \"presentValue\": ", body, " } }");
            var token = JToken.Parse(body);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, "presentValue").Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/presentValue")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, "presentValue", testCulture);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyObjectNotPresentValue()
        {
            string body = string.Concat("{ ",
                "\"property\": \"stringvalue\",",
                "\"reliability\": \"", ReliableHighEnum, "\",",
                "\"priority\": \"", PriorityNoneEnum, "\"}");
            string json = string.Concat("{ \"item\": { \"", mockAttributeName, "\": ", body, " } }");
            var token = JToken.Parse(body);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyArrayIntegers()
        {
            string json = "{ \"item\": { \"" + mockAttributeName + "\": [ 0, 1 ] } }";
            var token = JArray.Parse("[ 0, 1 ]");
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture);

            // There is a problem with the comparisions for array types??
            Assert.Multiple(() => {
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Attribute, result.Attribute);
                Assert.AreEqual(expected.BooleanValue, result.BooleanValue);
                Assert.AreEqual(expected.IsReliable, result.IsReliable);
                Assert.AreEqual(expected.NumericValue, result.NumericValue);
                Assert.AreEqual(expected.Reliability, result.Reliability);
                Assert.AreEqual(expected.StringValue, result.StringValue);
                Assert.AreEqual(expected.ArrayValue, result.ArrayValue);
            });
        }

        [Test]
        public void TestReadPropertyArrayStrings()
        {
            string body = "[ \"stringvalue1\", \"stringvalue2\" ]";
            string json = string.Concat("{ \"item\": { \"", mockAttributeName, "\": ", body, " } }");
            var token = JArray.Parse(body);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture);
            
            // There is a problem with the comparisions for array types??
            Assert.Multiple(() => {
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Attribute, result.Attribute);
                Assert.AreEqual(expected.BooleanValue, result.BooleanValue);
                Assert.AreEqual(expected.IsReliable, result.IsReliable);
                Assert.AreEqual(expected.NumericValue, result.NumericValue);
                Assert.AreEqual(expected.Reliability, result.Reliability);
                Assert.AreEqual(expected.StringValue, result.StringValue);
                Assert.AreEqual(expected.ArrayValue, result.ArrayValue);
            });
        }

        [Test]
        public void TestReadPropertyArrayObjectsUnsupported()
        {
            string body = string.Concat("[ ",
            "{ \"item1\": \"stringvalue1\", \"item2\": \"stringvalue2\" },",
            "{ \"item1\": \"stringvalue3\", \"item2\": \"stringvalue4\" } ]");
            string json = string.Concat("{ \"item\": { \"", mockAttributeName, "\": ", body, " } }");
            var token = JArray.Parse(body);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture);

            // There is a problem with the comparisions for array types??
            Assert.Multiple(() => {
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Attribute, result.Attribute);
                Assert.AreEqual(expected.BooleanValue, result.BooleanValue);
                Assert.AreEqual(expected.IsReliable, result.IsReliable);
                Assert.AreEqual(expected.NumericValue, result.NumericValue);
                Assert.AreEqual(expected.Reliability, result.Reliability);
                Assert.AreEqual(expected.StringValue, result.StringValue);
                Assert.AreEqual(expected.ArrayValue, result.ArrayValue);
            });
        }

        [Test]
        public void TestReadPropertyUnsupportedEmptyObject()
        {
            string json = string.Concat("{ \"item\": { \"", mockAttributeName, "\": { } } }");
            var token = JToken.Parse("{ }");
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName).Value;

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyDoesNotExistDoesNotThrowException()
        {
            httpTest.RespondWith("Not Found", 404);

            var result = client.ReadProperty(mockid, mockAttributeName);

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TestReadPropertyUnauthorizedThrowsException()
        {
            httpTest.RespondWith("unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.ReadProperty(mockid, mockAttributeName));

            httpTest.ShouldHaveCalled($"https://hostname/api/V2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestReadPropertyUnauthorizedThrowsException: {e.Message}", true);
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
        }

        [Test]
        public void TestReadPropertyMultipleTwoIdFiveAttributeAsyncContext()
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
        public void TestWritePropertyStringAsyncContext()
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

            PrintMessage($"TestBadResponseExpiresThrowsException: {e.Message}", true);
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
        public void TestWritePropertyMultipleManyIdsManyAttributesAsyncContext()
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
            PrintMessage($"TestWritePropertyMultipleBadRequestThrowsException: {e.Message}", true);
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
        public void TestSendCommandManyNumberAsyncContext()
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

            PrintMessage($"TestSendCommandBadRequestThrowsException: {e.Message}", true);
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

            PrintMessage($"TestSendCommandUnauthorizedThrowsException: {e.Message}", true);
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
        public void TestGetCommandsNoneAsyncContext()
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
        public void TestGetCommandsEmptyItems()
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
        public void TestMiscNullTokenValue()
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
