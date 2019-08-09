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
        public void TestBadVersionLogin()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 1);
                httpTest.ShouldHaveCalled($"https://hostname/api/v2/login")
                    .WithVerb(HttpMethod.Post)
                    .WithContentType("application/json")
                    .WithRequestBody("{\"username\":\"username\",\"password\":\"password\"")
                    .Times(1);
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

        [Test]
        public void TestReadPropertyMultipleEmptyIds()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }");
                List<Guid> ids = new List<Guid>() { };
                List<string> attributes = new List<string>() { mockAttributeName };
                IEnumerable<ReadPropertyResult> results = traditionalClient.ReadPropertyMultiple(ids, attributes);

                Assert.AreEqual(results.Count(), 0);
            }
        }

        [Test]
        public void TestReadPropertyMultipleEmptyAttribute()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }");
                List<Guid> ids = new List<Guid>() { mockid };
                List<string> attributes = new List<string>() { };
                IEnumerable<ReadPropertyResult> results = traditionalClient.ReadPropertyMultiple(ids, attributes);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(results.Count(), 0);
            }
        }

        [Test]
        public void TestReadPropertyMultipleOneIdOneAttribute()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{ \"item\": { \"" + mockAttributeName + "\": \"stringvalue\" } }");
                List<Guid> ids = new List<Guid>() { mockid };
                List<string> attributes = new List<string>() { mockAttributeName };
                IEnumerable<ReadPropertyResult> results = traditionalClient.ReadPropertyMultiple(ids, attributes);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(results.Count(), 1);
            }
        }

        [Test]
        public void TestReadPropertyMultipleTwoIdFiveAttribute()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                string mockAttributeName2 = "property2";
                string mockAttributeName3 = "property3";
                string mockAttributeName4 = "property4";
                string mockAttributeName5 = "property5";
                Guid mockid2 = new Guid("11111111-2222-3333-4444-555555555556");

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

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid2}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(results.Count(), 10);
                foreach (var result in results) {
                    Assert.AreNotEqual(result.StringValue, "Unsupported Data Type");
                }
            }
        }

        [Test]
        public void TestReadPropertyMultipleOneIdOneAttributeDNE()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("{ \"item\": { \"attributeNoMatch\": \"stringvalue\" } }");
                List<Guid> ids = new List<Guid>() { mockid };
                List<string> attributes = new List<string>() { mockAttributeName };
                IEnumerable<ReadPropertyResult> results = traditionalClient.ReadPropertyMultiple(ids, attributes);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
                Assert.AreEqual(results.Count(), 0);
            }
        }

        [Test]
        public void TestWritePropertyString()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("Accepted", 202);

                traditionalClient.WriteProperty(mockid, mockAttributeName, "newValue");

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyInteger()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("Accepted", 202);

                traditionalClient.WriteProperty(mockid, mockAttributeName, 32);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyFloat()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("Accepted", 202);

                traditionalClient.WriteProperty(mockid, mockAttributeName, 32.5);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyBoolean()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("Accepted", 202);

                traditionalClient.WriteProperty(mockid, mockAttributeName, true);

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyArrayString()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("Accepted", 202);

                traditionalClient.WriteProperty(mockid, mockAttributeName, new [] { "1", "2", "3" });

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyArrayInteger()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("Accepted", 202);

                traditionalClient.WriteProperty(mockid, mockAttributeName, new [] { 1, 2, 3 });

                httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                    .WithVerb(HttpMethod.Patch)
                    .Times(1);
            }
        }

        [Test]
        public void TestWritePropertyBadRequestThrowsException()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new {accessToken = "faketoken", expires = "2030-01-01T00:00:00Z"});
                var traditionalClient = new TraditionalClient("username", "password", "hostname", 2);

                httpTest.RespondWith("Bad Request", 400);
                try {
                    traditionalClient.WriteProperty(mockid, mockAttributeName, "badType");
                    Assert.Fail();
                } catch {
                    httpTest.ShouldHaveCalled($"https://hostname/api/v2/objects/{mockid}")
                        .WithVerb(HttpMethod.Patch)
                        .Times(1);
                }
            }
        }
    }
}
