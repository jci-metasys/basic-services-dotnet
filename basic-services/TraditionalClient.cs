using System;
using System.Collections.Generic;
using System.Globalization;

namespace JohnsonControls.Metasys.BasicServices
{
    public class TraditionalClient
    {

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Takes an optional CultureInfo which is useful for formatting numbers. If not specified,
        /// the user's current culture is used.
        /// </remarks>
        /// <param name="cultureInfo"></param>
        /// <exception cref="NotImplementedException"></exception>
        public TraditionalClient(CultureInfo cultureInfo = null)
        {
            var culture = cultureInfo ?? CultureInfo.CurrentCulture;
            throw new NotImplementedException();
        }

        // Probably a boolean isn't good enough as it doesn't give a client any indication of what went wrong.
        // Could return an Result structure that contains error information or nothing.
        public bool TryLogin(string username, string password, string hostname, ApiVersion version = ApiVersion.V2)
        {
            throw new NotImplementedException();
        }
        
        
        public Guid GetObjectIdentifier(string itemReference)
        {
            // Consider caching results since clients may not. If we add caching, then we could  consider
            // taking itemReferences in ReadProperty and ReadPropertyMultiple. Until then we want to get clients
            // used to using identifiers.
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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