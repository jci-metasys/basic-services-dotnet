using System.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Provides Subscription Info
    /// </summary>
    internal class SubscriptionInfo
    {
        /// <summary>
        /// Subscription Identifier (String)
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Subscription Url
        /// </summary>
        public string Url { get; }

        public SubscriptionInfo(string subscriptionUrl)
        {
            Url = subscriptionUrl;
            Id = subscriptionUrl.Split('/').Last();
        }
    }
}
