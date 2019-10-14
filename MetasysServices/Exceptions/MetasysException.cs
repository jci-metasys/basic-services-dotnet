using System;
using Flurl;
using Flurl.Http;
using System.Web;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
	/// An exception that is thrown when a Flurl.Http exception occurs.
	/// </summary>
    [System.Serializable]
    public class MetasysHttpException : Exception
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
    public class MetasysTokenException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the MetasysTokenException.
        /// </summary>
        /// <param name="response">The Http response.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysTokenException(string response, Exception inner) : base($"Could not create AccessToken from response: {response}", inner) { }
    }

    /// <summary>
    /// An exception that is thrown when a Guid could not be created from a Http response.
    /// </summary>
    [System.Serializable]
    public class MetasysGuidException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the MetasysGuidException.
        /// </summary>
        /// <param name="message">The reason the exception was thrown.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysGuidException(string message, Exception inner) : base($"Could not create new Guid. Reason: {message}", inner) { }

        /// <summary>
        /// Initializes a new instance of the MetasysGuidException with the given argument for the Guid.
        /// </summary>
        /// <param name="message">The reason the exception was thrown.</param>
        /// <param name="argument">The argument passed to the Guid constructor.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysGuidException(string message, string argument, Exception inner) : base($"Could not create new Guid. Reason: {message}. Argument: {argument}", inner) { }
    }

    /// <summary>
    /// An exception that is thrown when a Variant could not be created from a Http response.
    /// </summary>
    [System.Serializable]
    public class MetasysPropertyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the MetasysPropertyException.
        /// </summary>
        /// <param name="response">The Http response.</param>
        /// <param name="inner">The inner exception.</param>
        public MetasysPropertyException(string response, Exception inner) : base($"Could not create Variant from response: {response}", inner) { }
    }
}