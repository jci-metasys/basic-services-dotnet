using JohnsonControls.Metasys.BasicServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    [ComVisible(true)]
    [Guid("0261C5FD-2473-4EC1-A78C-31A5C27C8163")]
    [ClassInterface(ClassInterfaceType.None)]
    public class LegacyMetasysClient : ILegacyMetasysClient
    {
        MetasysClient client;

        /// <summary>
        /// Creates a new LegacyClient.
        /// </summary>
        public LegacyMetasysClient()
        {          
        }

        /// <summary>
        /// Attempts to login to the given host.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void login(string hostname, string username, string password)
        {
            client = new MetasysClient(hostname);
            client.TryLogin(username, password);
        }

        /// <summary>
        /// Returns the object identifier (id) of the specified object.
        /// </summary>
        /// <param name="itemReference"></param>
        public Guid GetObjectIdentifier(string itemReference)
        {
            Guid response = client.GetObjectIdentifier(itemReference);
            return response;
        }

        /// <summary>
        /// Read one attribute value given the Guid of the object.
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="property"></param>
        /// <param name="stringValue"></param>
        /// <param name="rawValue"></param>
        /// <param name="reliability"></param>
        /// <param name="priority"></param>
        public string ReadProperty(string reference, string property, out double numericValue, out double rawValue, out string reliability, out string priority)
        {
            Guid fqr = GetObjectIdentifier(reference);
            var response = client.ReadProperty(fqr, property);
            reliability = response.Reliability;
            numericValue = response.NumericValue;
            priority = response.Priority;       
            rawValue = response.NumericValue;
            return response.StringValue;
        }
    }
}
