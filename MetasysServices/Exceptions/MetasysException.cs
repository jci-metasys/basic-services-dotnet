using System;
using Flurl;
using Flurl.Http;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
	/// A general exception that is thrown when any type of Metasys Exception occurs.
	/// </summary>
    [System.Serializable]
    public class MetasysException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the MetasysException class from another expection.
        /// </summary>
        /// <param name="e">The Exception.</param>
        public MetasysException(Exception e) : base(e.Message, e) { }

        /// <summary>
        /// Initializes a new instance of the MetasysException class with a specified message.
        /// </summary>
        /// <param name="message">The reason the exception was thrown.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the MetasysException class with a specified message.
        /// </summary>
        /// <param name="message">The reason the exception was thrown.</param>
        public MetasysException(string message) : base(message) { }
    }

    /// <summary>
    /// An exception that is thrown when the given API version is invalid or not supported
    /// </summary>
    [System.Serializable]
    public class MetasysUnsupportedApiVersion : MetasysException
    {
        /// <summary>
        /// Initializes a new instance of the MetasysUnsupportedApiVersion with a predefined message given the API Version
        /// </summary>
        /// <param name="version"></param>
        public MetasysUnsupportedApiVersion(string version):base($"Invalid or not supported Api version ({version})")
        {
        }
    }

    /// <summary>
	/// An exception that is thrown when a Flurl.Http exception occurs.
	/// </summary>
    [System.Serializable]
    public class MetasysHttpException : MetasysException
    {
        /// <summary>
        /// An object containing details about the failed Http call.
        /// </summary>
        public HttpCall Call { get; }

        /// <summary>
        /// The string representation of the Http response body from the failed call if any.
        /// </summary>
        public string ResponseBody { get; }

        /// <summary>
        /// Initializes a new instance of the MetasysHttpException class using the Flurl.Http.FlurlHttpException class.
        /// </summary>
        /// <param name="e">The Flurl.Http exception.</param>
        public MetasysHttpException(FlurlHttpException e) : base(e.Message, e.InnerException) { 
            this.Call = e.Call;
            this.ResponseBody = e.GetResponseStringAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Initializes a new instance of the MetasysHttpException class without an HttpCall.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="response"></param>
        /// <param name="inner">The inner exception.</param>
        public MetasysHttpException(string message, string response, Exception inner) : base(message, inner) { 
            this.Call = null;
            this.ResponseBody = response;
        }

        /// <summary>
        /// Initializes a new instance of the MetasysHttpException class without an HttpCall.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public MetasysHttpException(string message, string response) : base(message) { 
            this.Call = null;
            this.ResponseBody = response;
        }
    }

    /// <summary>
	/// An exception that is thrown when a Flurl.Http.FlurlHttpTimeoutException exception occurs.
	/// </summary>
    [System.Serializable]
    public class MetasysHttpTimeoutException : MetasysHttpException
    {
        /// <summary>
        /// Initializes a new instance of the MetasysHttpTimeoutException class using the Flurl.Http.FlurlHttpTimeoutException class.
        /// </summary>
        /// <param name="e">The Flurl.Http exception.</param>
        public MetasysHttpTimeoutException(FlurlHttpTimeoutException e) : base(e) { }
    }

    /// <summary>
	/// An exception that is thrown when a Flurl.Http.FlurlHttpParsingException exception occurs.
	/// </summary>
    [System.Serializable]
    public class MetasysHttpParsingException : MetasysHttpException
    {
        /// <summary>
        /// Initializes a new instance of the MetasysHttpParsingException class using the Flurl.Http.FlurlParsingException class.
        /// </summary>
        /// <param name="e">The Flurl.Http exception.</param>
        public MetasysHttpParsingException(FlurlParsingException e) : base(e) { }

        /// <summary>
        /// Initializes a new instance of the MetasysHttpParsingException class with a message and inner exception.
        /// </summary>
        /// <param name="message">The original exception message.</param>
        /// <param name="response">The Http response.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysHttpParsingException(string message, string response, Exception inner) : 
            base(message, response, inner) { }

        /// <summary>
        /// Initializes a new instance of the MetasysHttpParsingException class with an inner exception.
        /// </summary>
        /// <param name="response">The Http response.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysHttpParsingException(string response, Exception inner) : 
            base("Error occurred when parsing the Http response.", response, inner) { }

        /// <summary>
        /// Initializes a new generic instance of the MetasysHttpParsingException class.
        /// </summary>
        /// <param name="response">The Http response.</param>
        public MetasysHttpParsingException(string response) : base(
            "Error occurred when parsing the Http response.", response) { }
    }

    /// <summary>
    /// An exception that is thrown when a resource is not found
    /// </summary>
    [System.Serializable]
    public class MetasysHttpNotFoundException : MetasysHttpException
    {
        /// <summary>
        /// Initializes a new instance of the MetasysNotFoundException
        /// </summary>         
        /// <param name="inner"></param>
        public MetasysHttpNotFoundException(Flurl.Http.FlurlHttpException inner) :
            base(inner)
        { }
    }

    /// <summary>
    /// An exception that is thrown when an AccessToken could not be created from a Http response.
    /// </summary>
    [System.Serializable]
    public class MetasysTokenException : MetasysHttpParsingException
    {
        /// <summary>
        /// Initializes a new instance of the MetasysTokenException.
        /// </summary>
        /// <remarks>
        /// Since access tokens are sensitive information it is important to protect them from
        /// being automatically logged. For this reason the response should not be passed into
        /// the base Exception in the message, but rather accessed through the MetasysHttpException
        /// ResponseBody property.
        /// </remarks>
        /// <param name="response">The Http response.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysTokenException(string response, Exception inner) :
            base($"Could not create AccessToken from response.", response, inner) { }
    }

    /// <summary>
    /// An exception that is thrown when a Guid could not be created from a Http response.
    /// </summary>
    [System.Serializable]
    public class MetasysGuidException : MetasysHttpParsingException
    {
        /// <summary>
        /// Initializes a new instance of the MetasysGuidException with the given argument for the Guid.
        /// </summary>
        /// <param name="response">The argument passed to the Guid constructor.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysGuidException(string response, Exception inner) :
            base($"Could not create Guid from response.", response, inner) { }
    }

    /// <summary>
    /// An exception that is thrown when a Variant could not be created from a Http response.
    /// </summary>
    [System.Serializable]
    public class MetasysPropertyException : MetasysHttpParsingException
    {
        /// <summary>
        /// Initializes a new instance of the MetasysPropertyException.
        /// </summary>
        /// <remarks>
        /// By passing the response in the message the value/values can still be seen.
        /// This information can be useful despite the Variant construction failing.
        /// </remarks>
        /// <param name="response">The Http response.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysPropertyException(string response, Exception inner) :
            base($"Could not create Variant from response.", response, inner) { }
    }

    /// <summary>
    /// An exception that is thrown when a MetasysObject could not be created from a Http response.
    /// </summary>
    [System.Serializable]
    public class MetasysCommandException : MetasysHttpParsingException
    {
        /// <summary>
        /// Initializes a new instance of the MetasysObjectException.
        /// </summary>
        /// <param name="response">The Http response.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysCommandException(string response, Exception inner) :
            base($"Could not create Command from response.", response, inner) { }
    }

    /// <summary>
    /// An exception that is thrown when a MetasysObject could not be created from a Http response.
    /// </summary>
    [System.Serializable]
    public class MetasysObjectException : MetasysHttpParsingException
    {
        /// <summary>
        /// Initializes a new instance of the MetasysObjectException.
        /// </summary>
        /// <param name="response">The Http response.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysObjectException(string response, Exception inner) :
            base($"Could not create MetasysObject from response.", response, inner) { }

        /// <summary>
        /// Initializes a new instance of the MetasysObjectException.
        /// </summary>
        /// <param name="inner">The inner exception.</param>
        public MetasysObjectException(Exception inner) :
            base($"An error occurred while creating the MetasysObject.", inner) { }
    }

    /// <summary>
    /// An exception that is thrown when a MetasysObjectType could not be created from a Http response.
    /// </summary>
    [System.Serializable]
    public class MetasysObjectTypeException : MetasysHttpParsingException
    {
        /// <summary>
        /// Initializes a new instance of the MetasysObjectTypeException.
        /// </summary>
        /// <param name="response">The Http response.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysObjectTypeException(string response, Exception inner) :
            base($"Could not create MetasysObjectType from response.", response, inner) { }
    }
}
