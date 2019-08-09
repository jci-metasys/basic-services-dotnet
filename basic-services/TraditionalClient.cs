using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading;

namespace JohnsonControls.Metasys.BasicServices
{
    public class TraditionalClient
    {
        private FlurlClient client;

        public TraditionalClient(string username, string password, string hostname, int apiVersion)
        {
            if (apiVersion != 2) {
                Console.Error.WriteLine("Unsupported API Version, using Version 2.");
                apiVersion = 2;
            }
            client = new FlurlClient($"https://{hostname}/api/v{apiVersion}");
            var response = client.Request("login")
                .PostJsonAsync(new {username, password})
                .ReceiveJson<JToken>();
            var accessToken = response.Result["accessToken"];
            client.Headers.Add("Authorization", $"Bearer {accessToken}");
        }

        /// <summary>Requests a new access token, must be called before current token expires.</summary>
        public void Refresh() {
            var response = client.Request("refreshToken")
                .GetJsonAsync<JToken>();
            var accessToken = response.Result["accessToken"];
            client.Headers.Remove("Authorization");
            client.Headers.Add("Authorization", $"Bearer {accessToken}");
            
        }

        /// <summary>Returns the object identifier (id) of the specified object.</summary>
        public Guid GetObjectIdentifier(string itemReference)
        {
            // Consider caching results since clients may not. If we add caching, then we could  consider
            // taking itemReferences in ReadProperty and ReadPropertyMultiple. Until then we want to get clients
            // used to using identifiers.

            var response = client.Request($"objectIdentifiers")
                .SetQueryParam("fqr", itemReference)
                .GetStringAsync();

            return new Guid(response.Result.Trim('"'));
        }

        /// <summary>
        /// Read one attribute value given the Guid of the object
        /// </summary>
        /// <remarks>
        /// If the data type is not supported, then this should probably throw an exception. Or the ReadPropertyResult
        /// could include an error code. Exception is probably simplest. Consider Excel app integration however. In those
        /// cases adding error code field to ReadPropertyResult is better.
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>

        /// <exception cref=""></exception>
        /// which exceptions?
        /// If it's communication issues with client then perhaps CommunicationException
        /// If it's an HttpStatusCode that we are prepared for then make up some Exceptions:
        /// Other options?
        public ReadPropertyResult ReadProperty(Guid id, string attributeName)
        {
            var response = client.Request($"objects/{id}/attributes/{attributeName}")
                .GetJsonAsync<JToken>();
            return new ReadPropertyResult(id, response.Result["item"][attributeName], attributeName);
        }

        /// <summary>
        /// Read many attribute values given the Guids of the objects
        /// </summary>
        public IEnumerable<ReadPropertyResult> ReadPropertyMultiple(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames)
        {
            List<ReadPropertyResult> results = new List<ReadPropertyResult>() { };
            Parallel.ForEach(ids, (id) => {
                var response = client.Request($"objects/{id}")
                .GetJsonAsync<JToken>();
                foreach (string attributeName in attributeNames) 
                {
                    JToken value = response.Result["item"][attributeName];
                    if (value != null) 
                    {
                        lock (results) 
                        {
                            results.Add(new ReadPropertyResult(id, value, attributeName));
                        }
                    }
                }
            });
            return results;
        }

        /// <summary>
        /// Write a single attribute given the Guid of the object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attributeName"></param>
        /// <param name="newValue"></param>
        public void WriteProperty(Guid id, string attributeName, object newValue, string priority = null)
        {
            string body = "{ item: { ";
            if (priority != null) {
                body += $"priority: \"{priority}\", ";
            }
            var item = JsonConvert.SerializeObject(newValue);
            body += $"{attributeName}: {item} }} }}";
            
            try {
                var json = JsonConvert.DeserializeObject(body);
                var response = client.Request($"objects/{id}").PatchJsonAsync(json);
                Console.WriteLine(response.Result.StatusCode);
            } catch (Newtonsoft.Json.JsonReaderException e) {
                Console.Error.WriteLine("Could not format request.");
            }
        }

        /// <summary>
        /// Write to all attributes given the Guids of the objects
        /// </summary>
        /// <remarks>
        /// If a property needs the priority field the WriteProperty method should be used
        /// </remarks>
        /// <param name="ids"></param>
        /// <param name="attributeValues">The (attribute, newValue) pairs</param>
        public void WritePropertyMultiple(IEnumerable<Guid> ids, IEnumerable<(string, string)> attributeValues)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all available commands given the Guid of the object
        /// </summary>
        public IEnumerable<string> GetCommands(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send a command to an object
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="command"></param>
        /// <param name="titleValues">The (title, newValue) pairs</param>
        public void SendCommand(Guid id, string command, IEnumerable<(string, string)> titleValues = null)
        {
            throw new NotImplementedException();
        }
    }
}
