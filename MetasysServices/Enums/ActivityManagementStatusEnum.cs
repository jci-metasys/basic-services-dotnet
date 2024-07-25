﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Enumeration of possible values for editing an Alarm.
    /// </summary>

    public enum ActivityManagementStatusEnum
    {
        /// <summary>
        /// Acknowledged Alarm
        /// </summary>
        [Description("Acknowledged")]
        acknowledged = 0,
        /// <summary>
        /// Discared Alarm
        /// </summary>
        [Description("Discarded")]
        discarded = 1
    }
}
