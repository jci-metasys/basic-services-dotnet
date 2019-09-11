using JohnsonControls.Metasys.BasicServices;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace com_services
{
    [ComVisible(true)]
    [Guid("0261C5FD-2473-4EC1-A78C-31A5C27C8163")]
    [ClassInterface(ClassInterfaceType.None)]
    public class LegacyClient : ILegacyClient
    {

        private TraditionalClient traditionalClient;
        public LegacyClient()
        {
        }

        /// <summary>
        /// Attempts to login to the given host.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="hostname"></param>
        public int login(string username, string password, string hostname)
        {
            traditionalClient = new TraditionalClient();
            traditionalClient.TryLogin(username, password, hostname);
            return 0;
        }

        /// <summary>
        /// Read one attribute value given the Guid of the object
        /// </summary>
        /// <param name="reference"></param>>
        /// <param name="property"></param>
        /// <param name="stringValue"></param>
        /// <param name="rawValue"></param
        /// <param name="reliability"></param>
        /// <param name="priority"></param>
        public int ReadProperty(string reference, string property, out string stringValue, out double rawValue, out string reliability, out string priority)
        {
            Guid fqr = traditionalClient.GetObjectIdentifier(reference);
            ReadPropertyResult response = traditionalClient.ReadProperty(fqr, property);
            reliability = response.Reliability;
            stringValue = response.StringValue;
            priority = response.Priority;
            rawValue = response.NumericValue;
            if (stringValue == "Unsupported Data Type")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Read multiple attribute value given the Guid of the object
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="objectList"></param>
        /// <param name="propertyList"></param>
        /// <param name="valueList"></param>
        public int ReadPropertyMultiple(string reference, ref string[] objectList,
            ref string[] propertyList, out string[] valueList)
        {
            int readPropertyMutlipleResponse = 0;

            List<Guid> ObjectFqrList = new List<Guid>();
            foreach (string objects in objectList)
            {
                var fqr = traditionalClient.GetObjectIdentifier(objects);
                ObjectFqrList.Add(fqr);
            }
            IEnumerable<ReadPropertyResult> response = traditionalClient.ReadPropertyMultiple(ObjectFqrList, propertyList);

            //TO DO Implementation
            List<string> ValueList = new List<string>();
            ValueList.Add("1");
            ValueList.Add("2");
            valueList = ValueList.ToArray();
            return readPropertyMutlipleResponse;
        }
    }
}
