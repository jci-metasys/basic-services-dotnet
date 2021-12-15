using System.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    internal class SubscriptionInfo
    {
        public string Id { get; }
        public string Url { get; }

        public SubscriptionInfo(string subscriptionUrl)
        {
            Url = subscriptionUrl;
            Id = subscriptionUrl.Split('/').Last();
        }
    }
}
