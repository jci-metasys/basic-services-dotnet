using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    internal class AttributeBatchModel
    {
        public string method { get; set; }
        public List<Request> requests { get; set; }
    }

    internal class Request
    {
        public string id { get; set; }
        public string relativeUrl { get; set; }
    }
}
