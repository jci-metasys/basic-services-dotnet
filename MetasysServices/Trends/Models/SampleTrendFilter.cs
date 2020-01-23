using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    public class SampleTrendFilter : TimeFilter, ISampleTrendFilter
    {
        /// <summary>
        /// The inclusive priority range, from 0 to 255, of the trendable object.
        /// </summary>
        public string PriorityRange { get; set; }

        /// <summary>
        /// The type of the requested object.
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// The flag to exclude pending objects. Default: false.
        /// </summary>
        public bool? ExcludePending { get; set; }

        /// <summary>
        /// The flag to exclude acknowledged objects. Default: false.
        /// </summary>
        public bool? ExcludeAcknowledged { get; set; }

        /// <summary>
        /// The flag to exclude discarded object. Default: false.
        /// </summary>
        public bool? ExcludeDiscarded { get; set; }

        /// <summary>
        /// The attribute of the requested trendable object.
        /// </summary>
        public int? Attribute { get; set; }

        /// <summary>
        /// The system category of the requested trendable object.
        /// </summary>
        public int? Category { get; set; }
    }
}
