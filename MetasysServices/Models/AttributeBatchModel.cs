using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    internal class AttributeBatchModel
    {
        public string Method { get; set; }
        public List<Request> Requests { get; set; }
    }

    internal class Request
    {
        public string Id { get; set; }
        public string RelativeUrl { get; set; }
    }
}
