using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// DTO for Sample
    /// </summary>
    public class TrendService
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsReliable { get; set; }
    }
}
