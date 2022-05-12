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
using System.Globalization;

namespace MetasysServices.Tests
{
    public class MetasysClientTests : MetasysClientTestsBase
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
        private static readonly Guid mockid2 = new Guid("11111111-2222-3333-4444-555555555556");
        private static readonly Guid mockid3 = new Guid("11111111-2222-3333-4444-555555555557");
        private const string mockAttributeName = "property";
        private const string mockAttributeName2 = "property2";
        private const string mockAttributeName3 = "property3";
        private const string mockAttributeName4 = "property4";
        private const string mockAttributeName5 = "property5";

        #region Login Tests

        [Test]
        public async Task TestLoginAsync()
        {
            CleanLogin();
            httpTest.RespondWithJson(new { accessToken = "faketokenLoginAsync", expires = date2 });

            await client.TryLoginAsync("username", "password").ConfigureAwait(false);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/login")
                .WithVerb(HttpMethod.Post)
                .WithContentType("application/json")
                .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                .Times(1);
            var token = client.GetAccessToken();
            var expected = new AccessToken("hostname", "username", "Bearer faketokenLoginAsync", dateTime2);
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

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/login")
                    .WithVerb(HttpMethod.Post)
                    .WithContentType("application/json")
                    .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                    .Times(1);
                var token = client.GetAccessToken();
                var expected = new AccessToken("hostname", "username", "Bearer faketokenLoginAsyncContext", dateTime2);
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/login")
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
            httpTest.RespondWith("Call failed. No such host is known POST https://badhost/api/v2/login", 404);
            MetasysClient clientBad = new MetasysClient("badhost");

            var e = Assert.Throws<MetasysHttpNotFoundException>(() =>
                clientBad.TryLogin("username", "password"));

            httpTest.ShouldHaveCalled($"https://badhost/api/v2/login")
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/login")
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/login")
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/refreshToken")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var token = client.GetAccessToken();
            var expected = new AccessToken("hostname", "cleanusername", "Bearer faketokenRefreshAsync", dateTime2);
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

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/refreshToken")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                var token = client.GetAccessToken();
                var expected = new AccessToken("hostname", "cleanusername", "Bearer faketokenRefreshAsyncContext", dateTime2);
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/refreshToken")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(original, client.GetAccessToken()); // The access token is not changed on error
            PrintMessage($"TestRefreshUnauthorizedThrowsException: {e.Message}", true);
        }

        //[Test]
        //public void TestRefreshTimerThreeSeconds()
        //{
        //    CleanLogin();
        //    DateTime now = DateTime.UtcNow;
        //    DateTime future = new DateTime(now.Ticks - (now.Ticks % TimeSpan.TicksPerSecond));
        //    future.AddSeconds(3);
        //    string time = future.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'");
        //    httpTest.RespondWithJson(new { accessToken = "faketokenTimer1", expires = time })
        //        .RespondWithJson(new { accessToken = "faketokenTimer2", expires = date2 });
        //    var expected1 = new AccessToken("hostname", "username", "Bearer faketokenTimer1", future);
        //    var expected2 = new AccessToken("hostname", "username", "Bearer faketokenTimer2", dateTime2);

        //    client.TryLogin("username", "password");

        //    var token1 = client.GetAccessToken();
        //    Assert.AreEqual(expected1, token1);

        //    System.Threading.Thread.Sleep(3000);
        //    httpTest.ShouldHaveCalled($"https://hostname/api/v2/refreshToken")
        //        .WithVerb(HttpMethod.Get)
        //        .Times(1);
        //    var token2 = client.GetAccessToken();
        //    Assert.AreEqual(expected2, token2);
        //}

        #endregion

        #region GetObjectIdentifier Tests

        [Test]
        public async Task TestGetObjectIdentifierAsync()
        {
            httpTest.RespondWith($"\"{mockid.ToString()}\"");

            var id = await client.GetObjectIdentifierAsync("fully:qualified/reference1").ConfigureAwait(false);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objectIdentifiers")
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
                var id = client.GetObjectIdentifier("fully:qualified/reference2");
                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objectIdentifiers")
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
                client.GetObjectIdentifier("fully:qualified/reference3"));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetObjectIdentifierBadRequestThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetObjectIdentifierBadResponseThrowsException()
        {
            httpTest.RespondWith($"\"{mockid.ToString()}1\"");

            var e = Assert.Throws<MetasysGuidException>(() =>
                client.GetObjectIdentifier("fully:qualified/reference4"));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new MetasysGuidException($"{mockid.ToString()}1", new NullReferenceException());
            Assert.AreEqual(expected.Message, e.Message);
            PrintMessage($"TestGetObjectIdentifierBadResponseThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetObjectIdentifierNullResponseThrowsException()
        {
            httpTest.RespondWith("null");

            var e = Assert.Throws<MetasysGuidException>(() =>
                client.GetObjectIdentifier("fully:qualified/reference5"));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new MetasysGuidException(null, new ArgumentNullException());
            Assert.AreEqual(expected.Message, e.Message);
            PrintMessage($"TestGetObjectIdentifierNullResponseThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetObjectIdentifierUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.GetObjectIdentifier("fully:qualified/reference6"));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetObjectIdentifierUnauthorizedThrowsException: {e.Message}", true);
        }

        #endregion

        #region ReadProperty Tests

        [Test]
        public async Task TestReadPropertyIntegerAsync()
        {
            string json = "{\"item\": { \"" + mockAttributeName + "\": 1 }}";
            var token = JToken.Parse(json);
            httpTest.RespondWith(json);

            Variant result = (await client.ReadPropertyAsync(mockid, mockAttributeName).ConfigureAwait(false));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyIntegerAsyncContext()
        {
            AsyncContext.Run(() =>
            {
                string json = "{\"item\": { \"" + mockAttributeName + "\": 1 }}";
                var token = JToken.Parse(json);
                httpTest.RespondWith(json);

                Variant result = client.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                var expected = new Variant(mockid, token, mockAttributeName, testCulture, ApiVersion.v2);
                Assert.AreEqual(expected, result);
            });
        }

        [Test]
        public void TestReadPropertyFloat()
        {
            string json = "{\"item\": { \"" + mockAttributeName + "\": 1.1 }}";
            var token = JToken.Parse(json);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyString()
        {
            string json = "{\"item\": { \"" + mockAttributeName + "\": \"stringvalue\" }}";
            var token = JToken.Parse(json);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyBooleanTrue()
        {
            string json = "{\"item\": { \"" + mockAttributeName + "\": true }}";
            var token = JToken.Parse(json);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyBooleanFalse()
        {
            string json = "{\"item\": { \"" + mockAttributeName + "\": false }}";
            var token = JToken.Parse(json);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyPresentValueInteger()
        {
            string json = string.Concat("{ \"item\": { \"presentValue\": {",
                "\"value\": 60 } } }");
            var token = JToken.Parse(json);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, "presentValue");

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/presentValue")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, "presentValue", testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyPresentValueString()
        {
            string json = string.Concat("{ \"item\": { \"presentValue\": {",
                "\"value\": \"stringvalue\" } } }");
            var token = JToken.Parse(json);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, "presentValue");

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/presentValue")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, "presentValue", testCulture, ApiVersion.v2);
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
            var token = JToken.Parse(json);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, "presentValue");

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/presentValue")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, "presentValue", testCulture, ApiVersion.v2);
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
            var token = JToken.Parse(json);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyArrayIntegers()
        {
            string json = "{ \"item\": { \"" + mockAttributeName + "\": [ 0, 1 ] } }";
            var token = JToken.Parse(json);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyArrayStrings()
        {
            string body = "[ \"stringvalue1\", \"stringvalue2\" ]";
            string json = string.Concat("{ \"item\": { \"", mockAttributeName, "\": ", body, " } }");
            var token = JToken.Parse(json);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyUnsupportedArrayObjects()
        {
            string body = string.Concat("[ ",
            "{ \"item1\": \"stringvalue1\", \"item2\": \"stringvalue2\" },",
            "{ \"item1\": \"stringvalue3\", \"item2\": \"stringvalue4\" } ]");
            string json = string.Concat("{ \"item\": { \"", mockAttributeName, "\": ", body, " } }");
            var token = JToken.Parse(json);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyUnsupportedEmptyObject()
        {
            string json = string.Concat("{ \"item\": { \"", mockAttributeName, "\": { } } }");
            var token = JToken.Parse(json);
            httpTest.RespondWith(json);

            Variant result = client.ReadProperty(mockid, mockAttributeName);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            var expected = new Variant(mockid, token, mockAttributeName, testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestReadPropertyDoesNotExistThrowsException()
        {
            httpTest.RespondWith("Not Found", 404);

            var e = Assert.Throws<MetasysHttpNotFoundException>(() =>
              client.ReadProperty(mockid, mockAttributeName));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestReadPropertyDoesNotExistThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestReadPropertyUnauthorizedThrowsException()
        {
            httpTest.RespondWith("unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.ReadProperty(mockid, mockAttributeName));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestReadPropertyUnauthorizedThrowsException: {e.Message}", true);
        }

        #endregion

        #region ReadPropertyMultiple Tests

        [Test]
        public void TestReadPropertyMultipleNullIds()
        {
            List<string> attributes = new List<string>() { mockAttributeName };

            var results = client.ReadPropertyMultiple(null, attributes);

            httpTest.ShouldNotHaveCalled($"https://hostname/api/v2/objects/");
            Assert.AreEqual(null, results);
        }

        [Test]
        public void TestReadPropertyMultipleNullAttributes()
        {
            List<Guid> ids = new List<Guid>() { mockid };

            var results = client.ReadPropertyMultiple(ids, null);

            httpTest.ShouldNotHaveCalled($"https://hostname/api/v2/objects/{mockid}");
            Assert.AreEqual(null, results);
        }

        [Test]
        public void TestReadPropertyMultipleEmptyIds()
        {
            List<Guid> ids = new List<Guid>() { };
            List<string> attributes = new List<string>() { mockAttributeName };

            var results = client.ReadPropertyMultiple(ids, attributes);

            httpTest.ShouldNotHaveCalled($"https://hostname/api/v2/objects/");
            Assert.AreEqual(0, results.Count());
        }

        [Test]
        public void TestReadPropertyMultipleEmptyAttributes()
        {
            List<Guid> ids = new List<Guid>() { mockid };
            List<string> attributes = new List<string>() { };

            var results = client.ReadPropertyMultiple(ids, attributes);

            httpTest.ShouldNotHaveCalled($"https://hostname/api/v2/objects/{mockid}");
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual(0, results.ElementAt(0).Values.Count());
        }

        [Test]
        public void TestReadPropertyMultipleOneIdOneAttribute()
        {
            var json = "{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }";
            httpTest.RespondWith(json);
            var token = JToken.Parse(json);
            List<Guid> ids = new List<Guid>() { mockid };
            List<string> attributes = new List<string>() { mockAttributeName };
            var results = client.ReadPropertyMultiple(ids, attributes);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Variant expected = new Variant(mockid, token, mockAttributeName, testCulture, ApiVersion.v2);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual(1, results.ElementAt(0).Values.Count());
            Assert.AreEqual(expected, results.ElementAt(0).Values.ElementAt(0));
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes")
                .WithVerb(HttpMethod.Get)
                .Times(5);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid2}/attributes")
                .WithVerb(HttpMethod.Get)
                .Times(5);
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(5, results.ElementAt(0).Values.Count());
            Assert.AreEqual(5, results.ElementAt(1).Values.Count());
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

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes")
                    .WithVerb(HttpMethod.Get)
                    .Times(5);
                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid2}/attributes")
                    .WithVerb(HttpMethod.Get)
                    .Times(5);
                Assert.AreEqual(results.Count(), 2);
                Assert.AreEqual(5, results.ElementAt(0).Values.Count());
                Assert.AreEqual(5, results.ElementAt(1).Values.Count());
            });
        }

        [Test]
        public void TestReadPropertyMultipleOneIdOneAttributeDNE()
        {
            httpTest.RespondWith("No HTTP resource was found that matches the request URI.", 404);
            List<Guid> ids = new List<Guid>() { mockid };
            List<string> attributes = new List<string>() { mockAttributeName };

            var results = client.ReadPropertyMultiple(ids, attributes);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, results.Count());
        }

        [Test]
        public void TestReadPropertyMultipleUnauthorizedThrowsException()
        {
            httpTest.RespondWith("unauthorized", 401);
            List<Guid> ids = new List<Guid>() { mockid };
            List<string> attributes = new List<string>() { mockAttributeName };

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.ReadPropertyMultiple(ids, attributes));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestReadPropertyMultipleUnauthorizedThrowsException: {e.Message}", true);
        }

        #endregion

        #region WriteProperty Tests

        [Test]
        public async Task TestWritePropertyStringAsync()
        {
            httpTest.RespondWith("Accepted", 202);

            await client.WritePropertyAsync(mockid, mockAttributeName, "newValue").ConfigureAwait(false);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
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

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")
                    .Times(1);
            });
        }

        [Test]
        public void TestWritePropertyInteger()
        {
            httpTest.RespondWith("Accepted", 202);

            client.WriteProperty(mockid, mockAttributeName, 32);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":32}}}}")
                .Times(1);
        }

        [Test]
        public void TestWritePropertyFloat()
        {
            httpTest.RespondWith("Accepted", 202);

            client.WriteProperty(mockid, mockAttributeName, 32.5);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":32.5}}}}")
                .Times(1);
        }

        [Test]
        public void TestWritePropertyBoolean()
        {
            httpTest.RespondWith("Accepted", 202);

            client.WriteProperty(mockid, mockAttributeName, true);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":true}}}}")
                .Times(1);
        }

        [Test]
        public void TestWritePropertyArrayString()
        {
            httpTest.RespondWith("Accepted", 202);

            client.WriteProperty(mockid, mockAttributeName, new[] { "1", "2", "3" });

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":[\"1\",\"2\",\"3\"]}}}}")
                .Times(1);
        }

        [Test]
        public void TestWritePropertyArrayInteger()
        {
            httpTest.RespondWith("Accepted", 202);

            client.WriteProperty(mockid, mockAttributeName, new[] { 1, 2, 3 });

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"badType\"}}}}")
                .Times(1);
            PrintMessage($"TestWritePropertyBadRequestThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestWritePropertyUnauthorizedThrowsException()
        {
            httpTest.RespondWith("unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.WriteProperty(mockid, mockAttributeName, "newValue"));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")
                .Times(1);
            PrintMessage($"TestWritePropertyUnauthorizedThrowsException: {e.Message}", true);
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")
                .Times(1);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid2}")
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
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody(requestBody)
                .Times(1);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid2}")
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
                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .WithRequestBody(requestBody)
                    .Times(1);
                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid2}")
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody("{\"item\":{\"badAttributeName\":\"newValue\"}}")
                .Times(1);
            PrintMessage($"TestWritePropertyMultipleBadRequestThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestWritePropertyMultipleUnauthorizedThrowsException()
        {
            httpTest.RespondWith("unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.WriteProperty(mockid, mockAttributeName, "newValue"));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                .WithVerb(HttpMethod.Patch)
                .WithRequestBody($"{{\"item\":{{\"{mockAttributeName}\":\"newValue\"}}}}")
                .Times(1);
            PrintMessage($"TestWritePropertyMultipleUnauthorizedThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestWritePropertyMultipleNullArguments()
        {
            Dictionary<string, object> attributeValues = null;
            Assert.Throws<ArgumentNullException>(() => client.WritePropertyMultiple(null, attributeValues));
            httpTest.ShouldNotHaveCalled($"https://hostname/api/v2/objects/{mockid}");
        }

        #endregion

        #region SendCommand Tests

        [Test]
        public void TestSendCommandEmptyBody()
        {
            httpTest.RespondWith("OK", 200);

            client.SendCommand(mockid, "EnableAlarms");

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands/EnableAlarms")
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands/Adjust")
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands/TemporaryOperatorOverride")
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

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands/TemporaryOperatorOverride")
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands/Release")
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands/Release")
                .WithVerb(HttpMethod.Put)
                .Times(1);
            PrintMessage($"TestSendCommandBadRequestThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestSendCommandUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);
            List<object> list = new List<object>() { 40, "data" };

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.SendCommand(mockid, "Release", list));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands/Release")
                .WithRequestBody("[40,\"data\"]")
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

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, commands.Count());
        }

        [Test]
        public void TestGetCommandsNoneAsyncContext()
        {
            AsyncContext.Run(() =>
            {
                httpTest.RespondWith("[]");

                var commands = client.GetCommands(mockid);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(0, commands.Count());
            });
        }

        [Test]
        public void TestGetCommandsEmptyItems()
        {
            string command1 = string.Concat("{\"$schema\": \"http://json-schema.org/schema#\",",
                "\"commandId\": \"EnableAlarms\",",
                "\"title\": \"Enable Alarms\",",
                "\"type\": \"array\",",
                "\"items\": [],",
                "\"minItems\": 0,",
                "\"maxItems\": 0 }");
            string command2 = string.Concat("{\"$schema\": \"http://json-schema.org/schema#\",",
                "\"commandId\": \"DisableAlarms\",",
                "\"title\": \"Disable Alarms\",",
                "\"type\": \"array\",",
                "\"items\": [],",
                "\"minItems\": 0,",
                "\"maxItems\": 0 }");
            httpTest.RespondWith(string.Concat("[", command1, ",", command2, "]"));

            var commands = client.GetCommands(mockid);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Command expected1 = new Command(JToken.Parse(command1), testCulture, ApiVersion.v2);
            Command expected2 = new Command(JToken.Parse(command2), testCulture, ApiVersion.v2);
            Assert.AreEqual(expected1, commands.ElementAt(0));
            Assert.AreEqual(expected2, commands.ElementAt(1));
        }

        [Test]
        public void TestGetCommandsOneEnum()
        {
            string command1 = string.Concat("{\"$schema\": \"http://json-schema.org/schema#\",",
                "\"commandId\": \"ReleaseAll\",",
                "\"title\": \"Release All\",",
                "\"type\": \"array\",",
                "\"items\": [{",
                    "\"oneOf\": [{",
                        "\"const\": \"attributeEnumSet.presentValue\",",
                        "\"title\": \"Present Value\"}]",
                    "}],",
                "\"minItems\": 1,",
                "\"maxItems\": 1 }");
            httpTest.RespondWith(string.Concat("[", command1, "]"));

            var commands = client.GetCommands(mockid);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Command expected = new Command(JToken.Parse(command1), testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, commands.ElementAt(0));
        }

        [Test]
        public void TestGetCommandsOneNumber()
        {
            string command1 = string.Concat("{\"$schema\": \"http://json-schema.org/schema#\",",
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
                "\"maxItems\": 1 }");
            httpTest.RespondWith(string.Concat("[", command1, "]"));

            var commands = client.GetCommands(mockid);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Command expected = new Command(JToken.Parse(command1), testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, commands.ElementAt(0));
        }

        [Test]
        public void TestGetCommandsOneNumberNullValues()
        {
            string command1 = string.Concat("{\"$schema\": \"http://json-schema.org/schema#\",",
                "\"commandId\": \"Adjust\",",
                "\"title\": \"Adjust\",",
                "\"type\": \"array\",",
                "\"items\": [{",
                    "\"type\": \"number\",",
                    "\"title\": \"Value\",",
                    "\"minimum\": null,",
                    "\"maximum\": null",
                    "}],",
                "\"minItems\": 1,",
                "\"maxItems\": 1 }");
            httpTest.RespondWith(string.Concat("[", command1, "]"));

            var commands = client.GetCommands(mockid);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Command expected = new Command(JToken.Parse(command1), testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, commands.ElementAt(0));
        }

        [Test]
        public void TestGetCommandsTwoEnumOneNumber()
        {
            string command1 = string.Concat("{\"$schema\": \"http://json-schema.org/schema#\",",
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
                "\"maxItems\": 3 }");
            httpTest.RespondWith(string.Concat("[", command1, "]"));

            var commands = client.GetCommands(mockid);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Command expected = new Command(JToken.Parse(command1), testCulture, ApiVersion.v2);
            Assert.AreEqual(expected, commands.ElementAt(0));
        }

        [Test]
        public void TestGetCommandsBadResponseThrowsException()
        {
            httpTest.RespondWith("[{}]");

            var e = Assert.Throws<MetasysCommandException>(() =>
                client.GetCommands(mockid));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetCommandsBadResponseThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetCommandsUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.GetCommands(mockid));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/commands")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetCommandsUnauthorizedThrowsException: {e.Message}", true);
        }

        #endregion

        #region GetNetworkDevices Tests

        [Test]
        public void TestGetNetworkDevicesNone()
        {
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 0,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [ ],",
                "\"self\": \"https://hostname/api/v2/networkDevices?page=1&pageSize=200&sort=name\"}"));

            var devices = client.GetNetworkDevices();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/networkDevices")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, devices.Count());
        }

        [Test]
        public void TestGetNetworkDevicesOnePage()
        {
            string device = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\",",
                "\"description\": \"none\",",
                "\"firmwareVersion\": \"4.0.0.1105\",",
                "\"ipAddress\": \"\"}");
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", device, "],",
                "\"self\": \"https://hostname/api/v2/networkDevices?page=1&pageSize=200&sort=name\"}"));

            var devices = client.GetNetworkDevices();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/networkDevices")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            MetasysObject expected = new MetasysObject(JToken.Parse(device), ApiVersion.v2, null, testCulture);
            Assert.AreEqual(expected, devices.ElementAt(0));
        }

        [Test]
        public void TestGetNetworkDevicesManyPages()
        {
            string device1 = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\",",
                "\"description\": \"none\",",
                "\"firmwareVersion\": \"4.0.0.1105\",",
                "\"ipAddress\": \"\"}");
            string device2 = string.Concat("{",
                "\"id\": \"", mockid2, "\",",
                "\"itemReference\": \"fully:qualified/reference2\",",
                "\"name\": \"name\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\",",
                "\"description\": \"none\",",
                "\"firmwareVersion\": \"4.0.0.1105\",",
                "\"ipAddress\": \"\"}");
            httpTest
                .RespondWith(string.Concat("{",
                    "\"total\": 2,",
                    "\"next\": \"https://hostname/api/v2/networkDevices?page=2&pageSize=1&sort=name\",",
                    "\"previous\": null,",
                    "\"items\": [", device1, "],",
                    "\"self\": \"https://hostname/api/v2/networkDevices?page=1&pageSize=1&sort=name\"}"))
                .RespondWith(string.Concat("{",
                    "\"total\": 2,",
                    "\"next\": null,",
                    "\"previous\": null,",
                    "\"items\": [", device2, "],",
                    "\"self\": \"https://hostname/api/v2/networkDevices?page=2&pageSize=1&sort=name\"}"));

            var devices = client.GetNetworkDevices();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/networkDevices")
                .WithVerb(HttpMethod.Get)
                .Times(2);
            MetasysObject expected1 = new MetasysObject(JToken.Parse(device1), ApiVersion.v2, null, testCulture);
            MetasysObject expected2 = new MetasysObject(JToken.Parse(device2), ApiVersion.v2, null, testCulture);
            Assert.AreEqual(expected1, devices.ElementAt(0));
            Assert.AreEqual(expected2, devices.ElementAt(1));
        }

        [Test]
        public void TestGetNetworkDevicesWithType()
        {
            string device = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\",",
                "\"description\": \"none\",",
                "\"firmwareVersion\": \"4.0.0.1105\",",
                "\"ipAddress\": \"\"}");
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", device, "],",
                "\"self\": \"https://hostname/api/v2/networkDevices?page=1&pageSize=200&sort=name\"}"));

            var devices = client.GetNetworkDevices("197");

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/networkDevices")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            MetasysObject expected = new MetasysObject(JToken.Parse(device), ApiVersion.v2, null, testCulture);
            Assert.AreEqual(expected, devices.ElementAt(0));
        }

        [Test]
        public void TestGetNetworkDevicesMissingItems()
        {
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 0,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [{}],",
                "\"self\": \"https://hostname/api/v2/networkDevices?page=1&pageSize=200&sort=name\"}"));

            var devices = client.GetNetworkDevices();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/networkDevices")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, devices.Count());
        }

        [Test]
        public void TestGetNetworkDevicesMissingValuesThrowsException()
        {
            string device = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\"}");
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", device, "],",
                $"\"self\": \"https://hostname/api/v2/networkDevices?page=1&pageSize=200&sort=name\"}}"));

            var e = Assert.Throws<MetasysObjectException>(() =>
                client.GetObjects(mockid));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/objects")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetNetworkDevicesMissingValuesThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetNetworkDevicesUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.GetNetworkDevices());

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/networkDevices")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetNetworkDevicesUnauthorizedThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetNetworkDevicesWithClassification()
        {
            string device = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"description\": \"none\",",
                "\"firmwareVersion\": \"4.0.0.1105\",",
                "\"ipAddress\": \"\"}");
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", device, "],",
                "\"self\": \"https://hostname/api/v2/networkDevices?page=1&pageSize=200&sort=name\"}"));

            var devices = client.GetNetworkDevicesByClassificationAsync("controller").GetAwaiter().GetResult(); ;

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/networkDevices")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            MetasysObject expected = new MetasysObject(JToken.Parse(device), ApiVersion.v2, null, testCulture);
            Assert.AreEqual(expected, devices.ElementAt(0));
        }

        #endregion

        #region GetNetworkDeviceTypes Tests

        [Test]
        public void TestGetNetworkDeviceTypesNone()
        {
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 0,",
                "\"items\": [ ],",
                "\"self\": \"https://hostname/api/v2/networkDevices/availableTypes\"}"));

            var types = client.GetNetworkDeviceTypes();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/networkDevices/availableTypes")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, types.Count());
        }

        [Test]
        public void TestGetNetworkDeviceTypesOne()
        {
            httpTest
                .RespondWith(string.Concat("{",
                    "\"total\": 1,",
                    "\"items\": [{",
                        "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/185\"",
                    "}],",
                    "\"self\": \"https://hostname/api/v2/networkDevices/availableTypes\"}"))
                .RespondWith(string.Concat("{",
                    "\"id\": 185,",
                    "\"description\": \"NAE55-NIE59\",",
                    "\"self\": \"https://hostname/api/v2/enumSets/508/members/185\",",
                    "\"setUrl\": \"https://hostname/api/v2/enumSets/508\"}"));

            var types = client.GetNetworkDeviceTypes();

            MetasysObjectType expected = new MetasysObjectType(185, "objectTypeEnumSet.n50Class",
                "NAE55-NIE59", testCulture);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/networkDevices/availableTypes")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/enumSets/508/members/185")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(expected, types.ElementAt(0));
        }

        [Test]
        public void TestGetNetworkDeviceTypesMany()
        {
            httpTest
                .RespondWith(string.Concat("{",
                    "\"total\": 2,",
                    "\"items\": [{",
                        "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/185\"},",
                        "{\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/195\"",
                    "}],",
                    "\"self\": \"https://hostname/api/v2/networkDevices/availableTypes\"}"))
                .RespondWith(string.Concat("{",
                    "\"id\": 185,",
                    "\"description\": \"NAE55-NIE59\",",
                    "\"self\": \"https://hostname/api/v2/enumSets/508/members/185\",",
                    "\"setUrl\": \"https://hostname/api/v2/enumSets/508\"}"))
                .RespondWith(string.Concat("{",
                    "\"id\": 195,",
                    "\"description\": \"Field Bus MSTP\",",
                    "\"self\": \"https://hostname/api/v2/enumSets/508/members/195\",",
                    "\"setUrl\": \"https://hostname/api/v2/enumSets/508\"}"));

            var types = client.GetNetworkDeviceTypes();

            MetasysObjectType expected1 = new MetasysObjectType(185, "objectTypeEnumSet.n50Class",
                "NAE55-NIE59", testCulture);
            MetasysObjectType expected2 = new MetasysObjectType(195, "objectTypeEnumSet.fieldBusClass",
                "Field Bus MSTP", testCulture);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/networkDevices/availableTypes")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/enumSets/508/members/185")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/enumSets/508/members/195")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(expected1, types.ElementAt(0));
            Assert.AreEqual(expected2, types.ElementAt(1));
        }

        [Test]
        public void TestGetNetworkDeviceTypesNotFoundThrowsException()
        {
            httpTest
                .RespondWith(string.Concat("{",
                    "\"total\": 1,",
                    "\"items\": [{",
                        "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/3000\"",
                    "}],",
                    "\"self\": \"https://hostname/api/v2/networkDevices/availableTypes\"}"))
                .RespondWith("No HTTP resource was found that matches the request URI.", 404);

            var e = Assert.Throws<MetasysHttpNotFoundException>(() =>
                client.GetNetworkDeviceTypes());

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/networkDevices/availableTypes")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/enumSets/508/members/3000")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetNetworkDeviceTypesNotFoundThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetNetworkDeviceTypesUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.GetNetworkDeviceTypes());

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/networkDevices/availableTypes")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            httpTest.ShouldNotHaveCalled($"https://hostname/api/v2/enumSets/*");
            PrintMessage($"TestGetNetworkDeviceTypesUnauthorizedThrowsException: {e.Message}", true);
        }

        #endregion

        #region GetObjects Tests

        [Test]
        public void TestGetObjectsNone()
        {
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 0,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [ ],",
                $"\"self\": \"https://hostname/api/v2/objects/{mockid}/objects?page=1&pageSize=200&sort=name\"}}"));

            var objects = client.GetObjects(mockid);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/objects")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, objects.Count());
        }

        [Test]
        public void TestGetObjectsOnePage()
        {
            string obj = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"description\": \"description\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\"}");
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", obj, "],",
                $"\"self\": \"https://hostname/api/v2/objects/{mockid}/objects?page=1&pageSize=200&sort=name\"}}"));

            var objects = client.GetObjects(mockid);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/objects")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            MetasysObject expected = new MetasysObject(JToken.Parse(obj), ApiVersion.v2, null, testCulture);
            Assert.AreEqual(expected, objects.ElementAt(0));
        }

        [Test]
        public void TestGetGraphicsObjects()
        {
            string obj = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"description\": \"description\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\"}");
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", obj, "],",
                $"\"self\": \"https://hostname/api/v2/objects/{mockid}/objects?page=1&pageSize=200&sort=name\"}}"));

            var objects = client.GetObjectsAsync(mockid, "objectTypeEnumSet.graphicClass").GetAwaiter().GetResult();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/objects")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            MetasysObject expected = new MetasysObject(JToken.Parse(obj), ApiVersion.v2, null, testCulture);
            Assert.AreEqual(expected, objects.ElementAt(0));
        }


        [Test]
        public void TestGetObjectsManyPages()
        {
            string obj1 = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"description\": \"description\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\"}");
            string obj2 = string.Concat("{",
                "\"id\": \"", mockid2, "\",",
                "\"itemReference\": \"fully:qualified/reference2\",",
                "\"name\": \"name\",",
                "\"description\": \"description\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\"}");
            httpTest
                .RespondWith(string.Concat("{",
                    "\"total\": 2,",
                    $"\"next\": \"https://hostname/api/v2/objects/{mockid}/objects?page=2&pageSize=1&sort=name\",",
                    "\"previous\": null,",
                    "\"items\": [", obj1, "],",
                    $"\"self\": \"https://hostname/api/v2/objects/{mockid}/objects?page=1&pageSize=1&sort=name\"}}"))
                .RespondWith(string.Concat("{",
                    "\"total\": 2,",
                    "\"next\": null,",
                    "\"previous\": null,",
                    "\"items\": [", obj2, "],",
                    $"\"self\": \"https://hostname/api/v2/objects/{mockid}/objects?page=2&pageSize=1&sort=name\"}}"));

            var objects = client.GetObjects(mockid);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/objects")
                .WithVerb(HttpMethod.Get)
                .Times(2);
            MetasysObject expected1 = new MetasysObject(JToken.Parse(obj1), ApiVersion.v2, null, testCulture);
            MetasysObject expected2 = new MetasysObject(JToken.Parse(obj2), ApiVersion.v2, null, testCulture);
            Assert.AreEqual(expected1, objects.ElementAt(0));
            Assert.AreEqual(expected2, objects.ElementAt(1));
        }

        [Test]
        public void TestGetObjectsManyLevels()
        {
            string obj1 = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"description\": \"description\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\"}");
            string obj2 = string.Concat("{",
                "\"id\": \"", mockid2, "\",",
                "\"itemReference\": \"fully:qualified/reference2\",",
                "\"name\": \"name\",",
                "\"description\": \"description\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\"}");
            httpTest
                .RespondWith(string.Concat("{",
                    "\"total\": 1,",
                    "\"next\": null,",
                    "\"previous\": null,",
                    "\"items\": [", obj1, "],",
                    $"\"self\": \"https://hostname/api/v2/objects/{mockid}/objects?page=1&pageSize=200&sort=name\"}}"))
                .RespondWith(string.Concat("{",
                    "\"total\": 1,",
                    "\"next\": null,",
                    "\"previous\": null,",
                    "\"items\": [", obj2, "],",
                    $"\"self\": \"https://hostname/api/v2/objects/{mockid2}/objects?page=1&pageSize=200&sort=name\"}}"))
                // Third level will be empty
                .RespondWith(string.Concat("{",
                    "\"total\": 0,",
                    "\"next\": null,",
                    "\"previous\": null,",
                    "\"items\": [],",
                    $"\"self\": \"https://hostname/api/v2/objects/{mockid2}/objects?page=1&pageSize=200&sort=name\"}}"));
            var objects = client.GetObjects(mockid3, 3).ToList();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid3}/objects")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/objects")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/objects")
              .WithVerb(HttpMethod.Get)
              .Times(1);
            MetasysObject expected2 = new MetasysObject(JToken.Parse(obj2), ApiVersion.v2, null, testCulture);
            List<MetasysObject> child = new List<MetasysObject>() { expected2 };
            MetasysObject expected1 = new MetasysObject(JToken.Parse(obj1), ApiVersion.v2, child.AsEnumerable(), testCulture);
            Assert.AreEqual(expected1, objects.ElementAt(0));
        }

        [Test]
        public void TestGetObjectsMissingItems()
        {
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 0,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [{}],",
                $"\"self\": \"https://hostname/api/v2/objects/{mockid}/objects?page=1&pageSize=200&sort=name\"}}"));

            Assert.Throws<MetasysObjectException>(() => client.GetObjects(mockid));
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/objects")
                .WithVerb(HttpMethod.Get)
                .Times(1);
        }

        [Test]
        public void TestGetObjectsLevelLessThanOne()
        {
            var objects = client.GetObjects(mockid, 0);

            httpTest.ShouldNotHaveCalled($"https://hostname/api/v2/objects/{mockid}/objects");
            Assert.IsNull(objects);
        }

        [Test]
        public void TestGetObjectsMissingValuesThrowsException()
        {
            string obj = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/508/members/197\"}");
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", obj, "],",
                $"\"self\": \"https://hostname/api/v2/objects/{mockid}/objects?page=1&pageSize=200&sort=name\"}}"));

            var e = Assert.Throws<MetasysObjectException>(() =>
                client.GetObjects(mockid));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/objects")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetObjectsMissingValuesThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetObjectsUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.GetObjects(mockid).ToList());

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/objects")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetObjectsUnauthorizedThrowsException: {e.Message}", true);
        }

        #endregion

        #region GetSpaces Tests

        [Test]
        public void TestGetSpacesNone()
        {
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 0,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [ ],",
                "\"self\": \"https://hostname/api/v2/spaces?page=1&pageSize=200&sort=name\"}"));

            var devices = client.GetSpaces();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/spaces")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, devices.Count());
        }

        [Test]
        public void TestGetSpacesOnePage()
        {
            string space = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\",",
                $"\"self\": \"https://hostname/api/v2/spaces/{mockid}\"}}");
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", space, "],",
                "\"self\": \"https://hostname/api/v2/spaces?page=1&pageSize=200&sort=name\"}"));

            var devices = client.GetSpaces();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/spaces")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            MetasysObject expected = new MetasysObject(JToken.Parse(space), ApiVersion.v2, null, testCulture);
            Assert.AreEqual(expected, devices.ElementAt(0));
        }

        [Test]
        public void TestGetSpacesManyPages()
        {
            string space1 = string.Concat("{",
                 "\"id\": \"", mockid, "\",",
                 "\"itemReference\": \"fully:qualified/reference1\",",
                 "\"name\": \"name\",",
                 "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\",",
                 $"\"self\": \"https://hostname/api/v2/spaces/{mockid}\"}}");
            string space2 = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference2\",",
                "\"name\": \"name\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\",",
                $"\"self\": \"https://hostname/api/v2/spaces/{mockid}\"}}");
            httpTest
                .RespondWith(string.Concat("{",
                    "\"total\": 2,",
                    "\"next\": \"https://hostname/api/v2/spaces?page=2&pageSize=1&sort=name\",",
                    "\"previous\": null,",
                    "\"items\": [", space1, "],",
                    "\"self\": \"https://hostname/api/v2/spaces?page=1&pageSize=1&sort=name\"}"))
                .RespondWith(string.Concat("{",
                    "\"total\": 2,",
                    "\"next\": null,",
                    "\"previous\": null,",
                    "\"items\": [", space2, "],",
                    "\"self\": \"https://hostname/api/v2/spaces?page=2&pageSize=1&sort=name\"}"));

            var spaces = client.GetSpaces();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/spaces")
                .WithVerb(HttpMethod.Get)
                .Times(2);
            MetasysObject expected1 = new MetasysObject(JToken.Parse(space1), ApiVersion.v2, null, testCulture);
            MetasysObject expected2 = new MetasysObject(JToken.Parse(space2), ApiVersion.v2, null, testCulture);
            Assert.AreEqual(expected1, spaces.ElementAt(0));
            Assert.AreEqual(expected2, spaces.ElementAt(1));
        }

        [Test]
        public void TestGetSpacesWithType()
        {
            string space = string.Concat("{",
               "\"id\": \"", mockid, "\",",
               "\"itemReference\": \"fully:qualified/reference\",",
               "\"name\": \"name\",",
               "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\",",
               $"\"self\": \"https://hostname/api/v2/spaces/{mockid}\"}}");
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", space, "],",
                "\"self\": \"https://hostname/api/v2/spaces?page=1&pageSize=200&sort=name\"}"));

            var devices = client.GetSpaces(SpaceTypeEnum.Room);

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/spaces")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            MetasysObject expected = new MetasysObject(JToken.Parse(space), ApiVersion.v2, null, testCulture);
            Assert.AreEqual(expected, devices.ElementAt(0));
        }

        [Test]
        public void TestGetSpacesMissingItems()
        {
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 0,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [{}],",
                "\"self\": \"https://hostname/api/v2/spaces?page=1&pageSize=200&sort=name\"}"));

            var devices = client.GetSpaces();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/spaces")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, devices.Count());
        }

        [Test]
        public void TestGetSpacesMissingValuesThrowsException()
        {
            string space = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\"}");
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", space, "],",
                $"\"self\": \"https://hostname/api/v2/spaces?page=1&pageSize=200&sort=name\"}}"));

            var e = Assert.Throws<MetasysObjectException>(() =>
                client.GetObjects(mockid));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/objects")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetSpacesMissingValuesThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetSpacesUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.GetSpaces());

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/spaces")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetSpacesUnauthorizedThrowsException: {e.Message}", true);
        }

        #endregion

        #region GetSpaceTypes Tests

        [Test]
        public void TestGetSpaceTypesNone()
        {
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 0,",
                "\"items\": [ ],",
                "\"self\": \"https://hostname/api/v2/enumSets/1766\"}"));

            var types = client.GetSpaceTypes();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/enumSets/1766")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, types.Count());
        }

        [Test]
        public void TestGetSpaceTypesOne()
        {
            var item = string.Concat("{",
                    "\"id\": 3,",
                    "\"description\": \"Room\",",
                    "\"self\": \"https://hostname/api/v2/enumSets/1766/members/3\",",
                    "\"setUrl\": \"https://hostname/api/v2/enumSets/1766\"}");
            httpTest
                .RespondWith(string.Concat("{",
                    "\"total\": 1,",
                    $"\"items\": [{item}],",
                    "\"self\": \"https://hostname/api/v2/enumSet/1766\"}"));

            var types = client.GetSpaceTypes();

            MetasysObjectType expected = new MetasysObjectType(3, "Room",
                "Room", testCulture);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/enumSets/1766")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(expected, types.ElementAt(0));
        }

        [Test]
        public void TestGetSpaceTypesMany()
        {
            var item1 = string.Concat("{",
                      "\"id\": 3,",
                      "\"description\": \"Room\",",
                      "\"self\": \"https://hostname/api/v2/enumSets/1766/members/3\",",
                      "\"setUrl\": \"https://hostname/api/v2/enumSets/1766\"}");
            var item2 = string.Concat("{",
                      "\"id\": 2,",
                      "\"description\": \"Floor\",",
                      "\"self\": \"https://hostname/api/v2/enumSets/1766/members/2\",",
                      "\"setUrl\": \"https://hostname/api/v2/enumSets/1766\"}");
            httpTest
                .RespondWith(string.Concat("{",
                    "\"total\": 2,",
                    $"\"items\": [{item1},{item2}],",
                    "\"self\": \"https://hostname/api/v2/enumSet/1766\"}"));

            var types = client.GetSpaceTypes();

            MetasysObjectType expected1 = new MetasysObjectType(3, "Room",
               "Room", testCulture);
            MetasysObjectType expected2 = new MetasysObjectType(2, "Floor",
                "Floor", testCulture);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/enumSets/1766")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(expected1, types.ElementAt(0));
            Assert.AreEqual(expected2, types.ElementAt(1));
        }

        [Test]
        public void TestGetSpaceTypesNotFoundThrowsException()
        {
            httpTest
                .RespondWith("No HTTP resource was found that matches the request URI.", 404);

            var e = Assert.Throws<MetasysHttpNotFoundException>(() =>
                client.GetSpaceTypes());

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/enumSets/1766")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetSpaceTypesNotFoundThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetSpaceTypesUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.GetSpaceTypes());

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/enumSets/1766")
                .WithVerb(HttpMethod.Get)
                .Times(1);

            PrintMessage($"TestGetSpaceTypesUnauthorizedThrowsException: {e.Message}", true);
        }

        #endregion

        #region GetEquipment Tests

        [Test]
        public void TestGetEquipmentNone()
        {
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 0,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [ ],",
                "\"self\": \"https://hostname/api/v2/equipment?page=1&pageSize=200&sort=name\"}"));

            var devices = client.GetEquipment();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/equipment")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, devices.Count());
        }

        [Test]
        public void TestGetEquipmentOnePage()
        {
            string space = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference\",",
                "\"name\": \"name\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\",",
                $"\"self\": \"https://hostname/api/v2/equipment/{mockid}\"}}");
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", space, "],",
                "\"self\": \"https://hostname/api/v2/equipment?page=1&pageSize=200&sort=name\"}"));

            var devices = client.GetEquipment();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/equipment")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            MetasysObject expected = new MetasysObject(JToken.Parse(space), ApiVersion.v2, null, testCulture);
            Assert.AreEqual(expected, devices.ElementAt(0));
        }

        [Test]
        public void TestGetEquipmentManyPages()
        {
            string space1 = string.Concat("{",
                 "\"id\": \"", mockid, "\",",
                 "\"itemReference\": \"fully:qualified/reference1\",",
                 "\"name\": \"name\",",
                 "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\",",
                 $"\"self\": \"https://hostname/api/v2/equipment/{mockid}\"}}");
            string space2 = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"itemReference\": \"fully:qualified/reference2\",",
                "\"name\": \"name\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\",",
                $"\"self\": \"https://hostname/api/v2/equipment/{mockid}\"}}");
            httpTest
                .RespondWith(string.Concat("{",
                    "\"total\": 2,",
                    "\"next\": \"https://hostname/api/v2/equipment?page=2&pageSize=1&sort=name\",",
                    "\"previous\": null,",
                    "\"items\": [", space1, "],",
                    "\"self\": \"https://hostname/api/v2/equipment?page=1&pageSize=1&sort=name\"}"))
                .RespondWith(string.Concat("{",
                    "\"total\": 2,",
                    "\"next\": null,",
                    "\"previous\": null,",
                    "\"items\": [", space2, "],",
                    "\"self\": \"https://hostname/api/v2/equipment?page=2&pageSize=1&sort=name\"}"));

            var Equipment = client.GetEquipment();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/equipment")
                .WithVerb(HttpMethod.Get)
                .Times(2);
            MetasysObject expected1 = new MetasysObject(JToken.Parse(space1), ApiVersion.v2, null, testCulture);
            MetasysObject expected2 = new MetasysObject(JToken.Parse(space2), ApiVersion.v2, null, testCulture);
            Assert.AreEqual(expected1, Equipment.ElementAt(0));
            Assert.AreEqual(expected2, Equipment.ElementAt(1));
        }


        [Test]
        public void TestGetEquipmentMissingItems()
        {
            httpTest.RespondWith(string.Concat("{",
                "\"total\": 0,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [{}],",
                "\"self\": \"https://hostname/api/v2/equipment?page=1&pageSize=200&sort=name\"}"));

            var devices = client.GetEquipment();

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/equipment")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            Assert.AreEqual(0, devices.Count());
        }

        [Test]
        public void TestGetEquipmentMissingValuesThrowsException()
        {
            string space = string.Concat("{",
                "\"id\": \"", mockid, "\",",
                "\"typeUrl\": \"https://hostname/api/v2/enumSets/1766/members/3\"}");

            httpTest.RespondWith(string.Concat("{",
                "\"total\": 1,",
                "\"next\": null,",
                "\"previous\": null,",
                "\"items\": [", space, "],",
                $"\"self\": \"https://hostname/api/v2/equipment?page=1&pageSize=200&sort=name\"}}"));

            var e = Assert.Throws<MetasysObjectException>(() =>
                client.GetObjects(mockid));

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/objects")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetEquipmentMissingValuesThrowsException: {e.Message}", true);
        }

        [Test]
        public void TestGetEquipmentUnauthorizedThrowsException()
        {
            httpTest.RespondWith("Unauthorized", 401);

            var e = Assert.Throws<MetasysHttpException>(() =>
                client.GetEquipment());

            httpTest.ShouldHaveCalled($"https://hostname/api/v2/equipment")
                .WithVerb(HttpMethod.Get)
                .Times(1);
            PrintMessage($"TestGetEquipmentUnauthorizedThrowsException: {e.Message}", true);
        }

        #endregion

        #region Caching

        [Test]
        public async Task TestGetObjectIdentifierCaching()
        {
            httpTest.RespondWith($"\"{mockid.ToString()}\"");
            var id = await client.GetObjectIdentifierAsync("fully:qualified/cache-reference").ConfigureAwait(false);
            Assert.AreEqual(mockid, id);
            // First call is expected to perform an Http Request, second an subsequent calls are expected to retrieve value from dictionary cache
            id = await client.GetObjectIdentifierAsync("fully:qualified/cache-reference").ConfigureAwait(false);
            Assert.AreEqual(mockid, id);
            httpTest.ShouldHaveCalled($"https://hostname/api/v2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
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