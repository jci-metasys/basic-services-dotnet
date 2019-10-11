using System;

namespace JohnsonControls.Metasys.BasicServices.Models
{
    /// <summary>
    /// The session access token and expiration in UTC time.
    /// </summary>
    public struct AccessToken
    {
        /// <value>The session access token.</value>
        public string Token { private set; get; }

        /// <value>Expiration date in UTC time.</value>
        public DateTime Expires { private set; get; }

        internal AccessToken(string token, DateTime expires)
        {
            Token = token;
            Expires = expires;
        }
    }
}
