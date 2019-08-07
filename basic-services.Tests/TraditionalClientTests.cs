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
                Assert.AreEqual(result.Priority, null);
                Assert.AreEqual(result.Reliability, null);
                Assert.AreEqual(result.IsReliable, false);
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
                Assert.AreEqual(result.Priority, null);
                Assert.AreEqual(result.Reliability, null);
                Assert.AreEqual(result.IsReliable, false);
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
                Assert.AreEqual(result.Priority, null);
                Assert.AreEqual(result.Reliability, null);
                Assert.AreEqual(result.IsReliable, false);
            }
        }

        [Test]
        public void TestReadPropertyBooleanTrue()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": true }}");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(result.NumericValue, 1);
                Assert.AreEqual(result.StringValue, "True");
                Assert.AreEqual(result.ArrayValue, null);
                Assert.AreEqual(result.Priority, null);
                Assert.AreEqual(result.Reliability, null);
                Assert.AreEqual(result.IsReliable, false);
            }
        }

        [Test]
        public void TestReadPropertyBooleanFalse()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{\"item\": { \"" + mockAttributeName + "\": false }}");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(result.NumericValue, 0);
                Assert.AreEqual(result.StringValue, "False");
                Assert.AreEqual(result.ArrayValue, null);
                Assert.AreEqual(result.Priority, null);
                Assert.AreEqual(result.Reliability, null);
                Assert.AreEqual(result.IsReliable, false);
            }
        }

        [Test]
        public void TestReadPropertyObjectWithReliabilityPriorityInteger()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": {" +
                "\"value\": 60, \"reliability\": \"reliabilityEnumSet.reliable\", \"priority\": \"writePriorityEnumSet.priorityNone\"} } }");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(result.NumericValue, 60);
                Assert.AreEqual(result.StringValue, "60");
                Assert.AreEqual(result.ArrayValue, null);
                Assert.AreEqual(result.Priority, "writePriorityEnumSet.priorityNone");
                Assert.AreEqual(result.Reliability, "reliabilityEnumSet.reliable");
                Assert.AreEqual(result.IsReliable, true);
            }
        }

        [Test]
        public void TestReadPropertyObjectWithReliabilityPriorityString()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": {" +
                "\"value\": \"stringvalue\", \"reliability\": \"reliabilityEnumSet.reliable\", \"priority\": \"writePriorityEnumSet.priorityNone\"} } }");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(result.NumericValue, 0);
                Assert.AreEqual(result.StringValue, "stringvalue");
                Assert.AreEqual(result.ArrayValue, null);
                Assert.AreEqual(result.Priority, "writePriorityEnumSet.priorityNone");
                Assert.AreEqual(result.Reliability, "reliabilityEnumSet.reliable");
                Assert.AreEqual(result.IsReliable, true);
            }
        }

        [Test]
        public void TestReadPropertyObjectWithReliabilityPriorityStringNoValueField()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": { " +
                "\"property\": \"stringvalue\", \"property2\": \"stringvalue2\", "+
                "\"reliability\": \"reliabilityEnumSet.reliable\", \"priority\": \"writePriorityEnumSet.priorityNone\"} } }");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(result.NumericValue, 0);
                Assert.AreEqual(result.StringValue, "stringvalue");
                Assert.AreEqual(result.ArrayValue, null);
                Assert.AreEqual(result.Priority, "writePriorityEnumSet.priorityNone");
                Assert.AreEqual(result.Reliability, "reliabilityEnumSet.reliable");
                Assert.AreEqual(result.IsReliable, true);
            }
        }

        [Test]
        public void TestReadPropertyArrayIntegers()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": [ " +
                "1, 2 ] } }");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(result.NumericValue, 0);
                Assert.AreEqual(result.StringValue, "Array");
                Assert.AreEqual(result.ArrayValue[0], ("1", 1));
                Assert.AreEqual(result.ArrayValue[1], ("2", 2));
                Assert.AreEqual(result.Priority, null);
                Assert.AreEqual(result.Reliability, null);
                Assert.AreEqual(result.IsReliable, false);
            }
        }

        [Test]
        public void TestReadPropertyArrayStrings()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": [ " +
                "\"stringvalue1\", \"stringvalue2\" ] } }");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(result.NumericValue, 0);
                Assert.AreEqual(result.StringValue, "Array");
                Assert.AreEqual(result.ArrayValue[0], ("stringvalue1", 0));
                Assert.AreEqual(result.ArrayValue[1], ("stringvalue2", 0));
                Assert.AreEqual(result.Priority, null);
                Assert.AreEqual(result.Reliability, null);
                Assert.AreEqual(result.IsReliable, false);
            }
        }

        [Test]
        public void TestReadPropertyArrayObjectUnsupported()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": [ " +
                "{ \"item1\": \"stringvalue1\", \"item2\": \"stringvalue2\" }," +
                "{ \"item1\": \"stringvalue3\", \"item2\": \"stringvalue4\" } ] } }");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(result.NumericValue, 0);
                Assert.AreEqual(result.StringValue, "Array");
                Assert.AreEqual(result.ArrayValue[0], ("Unsupported Data Type", 1));
                Assert.AreEqual(result.ArrayValue[1], ("Unsupported Data Type", 1));
                Assert.AreEqual(result.Priority, null);
                Assert.AreEqual(result.Reliability, null);
                Assert.AreEqual(result.IsReliable, false);
            }
        }

        [Test]
        public void TestReadPropertyDoesNotExist()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("Not Found", 404);
                try {
                    ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);
                    Assert.Fail();
                } catch {
                    httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
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
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": {}");
                ReadPropertyResult result = traditionalClient.ReadProperty(mockid, mockAttributeName);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}/attributes/{mockAttributeName}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(result.NumericValue, 1);
                Assert.AreEqual(result.StringValue, "Unsupported Data Type");
                Assert.AreEqual(result.ArrayValue, null);
                Assert.AreEqual(result.Priority, null);
                Assert.AreEqual(result.Reliability, null);
                Assert.AreEqual(result.IsReliable, false);
            }
        }
    }
}
