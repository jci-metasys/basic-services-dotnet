using System;
using Flurl;
using Flurl.Http;
using System.Web;

namespace JohnsonControls.Metasys.BasicServices
{
    [System.Serializable]
    public class MetasysHttpException : FlurlHttpException {
        public MetasysHttpException(HttpCall call, string message, Exception inner) : this(call, message, null, inner) { }
        public MetasysHttpException(HttpCall call, string message, string capturedResponseBody, Exception inner) : base(call, message, capturedResponseBody, inner) { }
    }

    [System.Serializable]
    public class MetasysHttpTimeoutException : FlurlHttpTimeoutException {
        public MetasysHttpTimeoutException(HttpCall call, Exception inner) : base(call, inner) { }
    }

    [System.Serializable]
    public class MetasysHttpParsingException : FlurlParsingException {
        public MetasysHttpParsingException(HttpCall call, string expectedFormat, string responseBody, Exception inner) : base(call, expectedFormat, responseBody, inner) { }
    }

    [System.Serializable]
    public class MetasysTokenException : Exception {
        public MetasysTokenException(string response) : base($"Could not create AccessToken from response: {response}") { }
    }

    [System.Serializable]
    public class MetasysGuidException : Exception {
        public MetasysGuidException(string message) : base($"Could not create new Guid. Reason: {message}") { }
        public MetasysGuidException(string message, string argument) : base($"Could not create new Guid. Reason: {message}. Argument: {argument}") { }
    }

    [System.Serializable]
    public class MetasysPropertyException: Exception {
        public MetasysPropertyException(string response) : base($"Could not create Variant from response: {response}") { }
    }
}