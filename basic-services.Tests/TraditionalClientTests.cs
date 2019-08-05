using System;
using System.Net.Http;
using Flurl.Http.Testing;
using NUnit.Framework;
using JohnsonControls.Metasys.BasicServices;

namespace Tests
{
    public class TraditionalClientTests
    {

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
    }
}