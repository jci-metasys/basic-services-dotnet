using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    public class SubscriptionModel
    {
        public List<Subscription> Subscriptions { get; set; }
    }

    public class Subscription
    {
        public string RelativeUrl { get; set; }
        public string Method { get; set; }
        public Dictionary<string, string> Params { get; set; }
        public dynamic Body { get; set; }
    }
}
