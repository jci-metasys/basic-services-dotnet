using System;
using System.Collections.Generic;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    public class TraditionalClient
    {
        private FlurlClient client;

        public TraditionalClient(string username, string password, string hostname, int apiVersion)
        {
            client = new FlurlClient($"https://{hostname}/api/v{apiVersion}");
            var response = client.Request("login")
                .PostJsonAsync(new {username, password})
                .ReceiveJson<JToken>();
            var accessToken = response.Result["accessToken"];
            client.Headers.Add("Authorization", $"Bearer {accessToken}");
        }

        ///<summary>Requests a new access token, must be called before current token expires.</summary>
        public void Refresh() {
            var response = client.Request("refreshToken")
                .GetJsonAsync<JToken>();
            var accessToken = response.Result["accessToken"];
            client.Headers.Remove("Authorization");
            client.Headers.Add("Authorization", $"Bearer {accessToken}");
            
        }

        ///<summary>Returns the object identifier (id) of the specified object.</summary>
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
        /// 
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
            // Call /objects/{id}/attributes/{attributeName}
            // You won't have schema information but we only support numbers, strings, booleans and enums which comes back as strings
            // Convert the response to appropriate result settings StringValue, NumericValue and ArrayValue 

            var response = client.Request($"objects/{id}/attributes/{attributeName}")
                .GetJsonAsync<JToken>();
            return new ReadPropertyResult(response.Result["item"][attributeName]);
        }


        public IEnumerable<ReadPropertyResult> ReadPropertyMultiple(IEnumerable<Guid> ids,
            IEnumerable<string> attributeNames)
        {
            // Most efficient implementation would read each object (async, and then join)
            // using /objects/{id}?includeSchema=true
            
            // As each object comes in, filter it down to the attributes requested
            // For each attribute calculate the stringvalue and numeric value
            
            
            throw new NotImplementedException();
        }
    }
}