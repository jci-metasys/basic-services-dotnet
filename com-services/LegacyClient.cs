using JohnsonControls.Metasys.BasicServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace com_services
{
    [ComVisible(true)]
    [Guid("0261C5FD-2473-4EC1-A78C-31A5C27C8163")]
    [ClassInterface(ClassInterfaceType.None)]
    public class LegacyClient : ILegacyClient
    {
        TraditionalClient traditionalClient;

        /// <summary>
        /// Creates a new LegacyClient.
        /// </summary>
        public LegacyClient(string hostname)
        {
           traditionalClient = new TraditionalClient(hostname);
        }

        /// <summary>
        /// Attempts to login to the given host.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void login(string username, string password)
        {
            traditionalClient.TryLogin(username, password);
        }

        /// <summary>
        /// Returns the object identifier (id) of the specified object.
        /// </summary>
        /// <param name="itemReference"></param>
        public Guid GetObjectIdentifier(string itemReference)
        {
            Guid response = traditionalClient.GetObjectIdentifier(itemReference);
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
        public int ReadProperty(string reference, string property, out string stringValue, out double rawValue, out string reliability, out string priority)
        {
            Guid fqr = GetObjectIdentifier(reference);
            var response = traditionalClient.ReadProperty(fqr, property);
            reliability = response.Reliability;
            stringValue = response.StringValue;
            priority = response.Priority;
            rawValue = response.NumericValue;

            return (int)response.NumericValue;
        }
    }
}
