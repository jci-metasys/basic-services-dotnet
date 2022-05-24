using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace JohnsonControls.Metasys.BasicServices.Utils
{
    /// <summary>
    /// Utility that provides useful methods to handle Json values.
    /// </summary>

    public class ObjectUtil
    {
        /// <summary>
        /// Get the string value of a JToken field.
        /// </summary>
        /// <param name="jToken"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string GetJTokenValue(JToken jToken, string field)
        {
            string res = string.Empty;
            try
            {
                if (jToken != null)
                {
                    if ((jToken.Contains(field)) && (jToken[field] != null))
                    {
                        res = jToken[field].Value<string>();
                    };
                };
            }
            catch (ArgumentNullException e)
            {
                // Something went wrong on object parsing
                throw new MetasysObjectException(e);
            }
            return res;
        }
        /// <summary>
        /// Get the date value of a JToken field.
        /// </summary>
        /// <param name="jToken"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static DateTime GetJTokenDate(JToken jToken, string field)
        {
            DateTime res = DateTime.UtcNow;
            try
            {
                if (jToken != null)
                {
                    if (jToken.Contains(field) && (jToken[field] != null))
                    {
                        res = jToken[field].Value<DateTime>();
                    };
                };
            }
            catch (ArgumentNullException e)
            {
                // Something went wrong on object parsing
                throw new MetasysObjectException(e);
            }
            return res;
        }

    }
}
