using Newtonsoft.Json;
using System;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// The session access token and expiration in UTC time along with related host information.
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// The Metasys Authorization provider hostname that issued the Access Token.
        /// </summary>
        public string Issuer { get; private set; }

        /// <summary>
        /// The Metasys Username that requested the Access Token.
        /// </summary>
        public string IssuedTo { get; private set; }
        
        /// <summary>The session access token for bearer authentication.</summary>
        /// <value>String in the format "Bearer ..."</value>
        public string Token { private set; get; }

        /// <summary>Expiration date in UTC time.</summary>
        public DateTime Expires { private set; get; }
       
        /// <summary>
        /// Initialize an AccessToken Object with all required information.
        /// </summary>
        /// <param name="issuer"></param>
        /// <param name="issuedTo"></param>
        /// <param name="token"></param>
        /// <param name="expires"></param>
        public AccessToken(string issuer, string issuedTo, string token, DateTime expires)
        {
            Issuer = issuer;
            IssuedTo = issuedTo;
            Token = token;
            Expires = expires;           
        }
        
        /// <summary>
        /// Returns a value indicating whither this instance has values equal to a specified object.
        /// </summary>
        /// <param name="obj"></param>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is AccessToken token)
            {
                var other = token;
                return (this.Token == null && other.Token == null || (this.Token != null && other.Token != null &&
                    other.Token.Equals(this.Token) &&
                    other.Expires.Equals(this.Expires) &&
                    other.IssuedTo.Equals(this.IssuedTo) && 
                    other.Issuer.Equals(this.Issuer)));
            }
            return false;
        }

        /// <summary></summary>
        public override int GetHashCode()
        {
            var code = 13;
            if (Token != null)
                code = (code * 7) + Token.GetHashCode();
            if (Expires != null)
                code = (code * 7) + Expires.GetHashCode();
            if (Issuer != null)
                code = (code * 7) + Issuer.GetHashCode();
            if (IssuedTo != null)
                code = (code * 7) + IssuedTo.GetHashCode();
            return code;
        }


        /// <summary>
        /// Return a pretty JSON string of the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
