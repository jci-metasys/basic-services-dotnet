using System;
using System.Net.Http;
using Flurl.Http.Testing;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using JohnsonControls.Metasys.BasicServices;


namespace Tests
{
    public class TraditionalClientTests
    {
        Guid mockid;
        string mockAttributeName;

        [SetUp]
        public void Init()
        {
            mockAttributeName = "property";
            mockid = new Guid("11111111-2222-3333-4444-555555555555");
        }

        [Test]
        public void TestLogin()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);
                httpTest.ShouldHaveCalled($"https://hostname/api/v2/login")
                    .WithVerb(HttpMethod.Post)
                    .WithContentType("application/json")
                    .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                    .Times(1);
            }
        }

        [Test]
        public void TestUnauthorizedLoginThrowsException()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("unauthorized", 401);
                try {
                    var traditionalClient = new TraditionalClient("username", "badpassword", "hostname", 2);
                    Assert.Fail();
                } catch {
                    httpTest.ShouldHaveCalled($"https://hostname/api/v2/login")
                    .WithVerb(HttpMethod.Post)
                    .WithContentType("application/json")
                    .WithRequestBody("{\"username\":\"username\",\"password\":\"badpassword\"")
                    .Times(1);
                }
            }
        }

        [Test]
        public void TestBadHostLoginThrowsException()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("Call failed. No such host is known POST https://badhost/api/v2/login");
                try {
                    var traditionalClient = new TraditionalClient("username", "password", "badhost", 2);
                    Assert.Fail();
                } catch {
                    httpTest.ShouldHaveCalled($"https://badhost/api/v2/login")
                    .WithVerb(HttpMethod.Post)
                    .WithContentType("application/json")
                    .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                    .Times(1);
                }
            }
        }

        [Test]
        public void TestRefresh()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                traditionalClient.Refresh();
                httpTest.ShouldHaveCalled($"https://hostname/api/v2/refreshToken")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
            }
        }

        [Test]
        public void TestRefreshThrowsException()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("unauthorized", 401);
                try {
                    traditionalClient.Refresh();
                    Assert.Fail();
                } catch {
                    httpTest.ShouldHaveCalled($"https://hostname/api/v2/refreshToken")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                }
            }
        }

        [Test]
        public void TestGetObjectIdentifier()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith(mockid.ToString());
                var id = traditionalClient.GetObjectIdentifier("fully:qualified/reference");
                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objectIdentifiers")
                .WithVerb(HttpMethod.Get)
                .Times(1);
                Assert.AreEqual(id.GetType(), typeof(Guid));
            }
        }

        [Test]
        public void TestGetBadObjectIdentifierThrowsException()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("Bad Request", 400);
                try {
                    var id = traditionalClient.GetObjectIdentifier("fully:qualified/reference");
                    Assert.Fail();
                } catch {
                    httpTest.ShouldHaveCalled($"https://hostname/api/v2/objectIdentifiers")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                }
            }
        }

        [Test]
        public void TestReadPropertyInteger()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": 1 }}");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(result.NumericValue, 1);
                Assert.AreEqual(result.StringValue, "1");
                Assert.AreEqual(result.ArrayValue, null);
            }
        }

        [Test]
        public void TestReadPropertyFloat()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": 1.1 }}");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(result.NumericValue, 1.1);
                Assert.AreEqual(result.StringValue, "1.1");
                Assert.AreEqual(result.ArrayValue, null);
            }
        }

        [Test]
        public void TestReadPropertyString()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": \"stringvalue\" }}");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(result.NumericValue, 0);
                Assert.AreEqual(result.StringValue, "stringvalue");
                Assert.AreEqual(result.ArrayValue, null);
            }
        }
    }
}
