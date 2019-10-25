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
        public MetasysHttpException(FlurlHttpException e) : base(e.Message, e) { 
            this.Call = e.Call;
            this.ResponseBody = e.GetResponseStringAsync().GetAwaiter().GetResult();
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
    }

    /// <summary>
    /// An exception that is thrown when an AccessToken could not be created from a Http response.
    /// </summary>
    [System.Serializable]
    public class MetasysTokenException : MetasysException
    {
        /// <summary>
        /// The server response that could not be formatted into an AccessToken.
        /// </summary>
        /// <remarks>
        /// Since access tokens are sensitive information it is important to protect them from
        /// being automatically logged. For this reason the response should not be passed into
        /// the base Exception in the message, but rather accessed through this property.
        /// </remarks>
        public string Response { get; }

        /// <summary>
        /// Initializes a new instance of the MetasysTokenException.
        /// </summary>
        /// <param name="response">The Http response.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysTokenException(string response, Exception inner) :
            base($"Could not create AccessToken from response.", inner) 
        { 
            Response = response;
        }
    }

    /// <summary>
    /// An exception that is thrown when a Guid could not be created from a Http response.
    /// </summary>
    [System.Serializable]
    public class MetasysGuidException : MetasysException
    {
        /// <summary>
        /// Initializes a new instance of the MetasysGuidException.
        /// </summary>
        /// <param name="message">The reason the exception was thrown.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysGuidException(string message, Exception inner) :
            base($"Could not create new Guid. Reason: {message}", inner) { }

        /// <summary>
        /// Initializes a new instance of the MetasysGuidException with the given argument for the Guid.
        /// </summary>
        /// <param name="message">The reason the exception was thrown.</param>
        /// <param name="argument">The argument passed to the Guid constructor.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysGuidException(string message, string argument, Exception inner) :
            base($"Could not create new Guid. Reason: {message}. Argument: {argument}", inner) { }
    }

    /// <summary>
    /// An exception that is thrown when a Variant could not be created from a Http response.
    /// </summary>
    [System.Serializable]
    public class MetasysPropertyException : MetasysException
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
            base($"Could not create Variant from response: {response}", inner) { }
    }
}
