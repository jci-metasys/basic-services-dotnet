using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Base Interface for implementing a new service for Metasys Client.
    /// </summary>
    public interface IBasicService
    {
        ApiVersion Version { get; set; }

        CultureInfo Culture { get; set; }
    }
}
