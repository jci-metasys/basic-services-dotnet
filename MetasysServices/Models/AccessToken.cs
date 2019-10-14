using System;

namespace JohnsonControls.Metasys.BasicServices.Models
{
    /// <summary>
    /// The session access token and expiration in UTC time.
    /// </summary>
    public struct AccessToken
    {
        /// <summary>The session access token for bearer authentication.</summary>
        /// <value>String in the format "Bearer ..."</value>
        public string Token { private set; get; }

        /// <summary>Expiration date in UTC time.</summary>
        public DateTime Expires { private set; get; }

        internal AccessToken(string token, DateTime expires)
        {
            Token = token;
            Expires = expires;
        }
    }
}
