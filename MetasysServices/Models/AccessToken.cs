using System;
using System.Globalization;


namespace JohnsonControls.Metasys.BasicServices.Models
{
    public struct AccessToken
    {
        public string Token { private set; get; }

        // Expiration date in UTC time
        public DateTime Expires  { private set; get; }

        internal AccessToken(string token, DateTime expires)
        {
            Token = token;
            Expires = expires;
        }
    }
}
