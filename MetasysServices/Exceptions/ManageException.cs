using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Flurl.Http;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Manage Http exceptions.
    /// </summary>
    public sealed class ManageException
    {
        /// <summary>
        /// Throws a Metasys Exception from a Flurl.Http exception.
        /// </summary>
        /// <param name="exception">The exception to catch.</param>
        public static void ThrowHttpException(FlurlHttpException exception)
        {
            if (exception.Call.Response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new MetasysHttpNotFoundException(exception);
            }
            if (exception.GetType() == typeof(FlurlParsingException))
            {
                throw new MetasysHttpParsingException((FlurlParsingException) exception);
            }
            else if (exception.GetType() == typeof(FlurlHttpTimeoutException))
            {
                throw new MetasysHttpTimeoutException((FlurlHttpTimeoutException) exception);
            }
            else
            {
                throw new MetasysHttpException(exception);
            }
        }
    }
}