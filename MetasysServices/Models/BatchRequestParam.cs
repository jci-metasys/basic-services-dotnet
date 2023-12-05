using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Body class to pass list of parameters for Metasys server batch request.
    /// </summary>

    public class BatchRequestParam
    {
        /// <summary> Id to identify the object
        public Guid ObjectId { get; set; }

        /// <summary> String that could represent a text resource as, for instance, a text annotation
        public string Resource { get; set; }

        /// <summary> Activity Type. The possible values are: 'alarm', 'audit'
        public string ActivityType { get; set; } = "";

        /// <summary> Activity Management Status. The possible values are: 'discarded' (for Alarms and Audits), 'acknowledged' (for Audits)
        public string ActivityManagementStatus { get; set; } = "";

    }
}
