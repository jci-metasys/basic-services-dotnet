using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Enumeration of possible OriginApplications for an Audit.
    /// </summary>
    /// <remarks>
    /// The actual values sent to the server are specified in the description.
    /// </remarks>
    [Flags]
    public enum OriginApplicationsEnum
    {
        [Description("0")]
        AlarmEvent = 1,

        [Description("1")]
        AuditTrails = 2,

        [Description("2")]
        DeviceServices = 4,

        [Description("3")]
        MCE = 8,

        [Description("4")]
        SiteServices = 16,

        [Description("5")]
        Trend = 32,

        [Description("6")]
        SystemSecurity = 64,

        [Description("7")]
        N2 = 128,

        [Description("8")]
        General = 256,

        [Description("9")]
        DeviceManager = 512,

        [Description("10")]
        WebServices = 1024,

        [Description("11")]
        EnergyManagement = 2048,

        [Description("12")]
        Interlock = 4096,

        [Description("13")]
        MCO = 8192,

        [Description("14")]
        Schedule = 16384
    }
}
