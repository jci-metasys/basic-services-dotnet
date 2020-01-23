using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices.Trends.Interfaces
{
    /// <summary>
    /// Provides attribute for Sample.
    /// </summary>
    public interface ISample
    {
        double Value { get; set; }
        string Unit { get; set; }
        DateTime Timestamp { get; set; }
        bool IsReliable { get; set; }
    
    }
}
