using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
        /// <summary>
        /// Origin Application: AlarmEvent (Enum id 0)
        /// </summary>
        [Description("0")]
        AlarmEvent = 1,

        /// <summary>
        /// Origin Application: AuditTrails (Enum id 1)
        /// </summary>
        [Description("1")]
        AuditTrails = 2,

        /// <summary>
        /// Origin Application: DeviceServices (Enum id 2)
        /// </summary>
        [Description("2")]
        DeviceServices = 4,

        /// <summary>
        /// Origin Application: MCE (Enum id 3)
        /// </summary>
        [Description("3")]
        MCE = 8,

        /// <summary>
        /// Origin Application: SiteServices (Enum id 0)
        /// </summary>
        [Description("4")]
        SiteServices = 16,

        /// <summary>
        /// Origin Application: Trend (Enum id 5)
        /// </summary>
        [Description("5")]
        Trend = 32,

        /// <summary>
        /// Origin Application: SystemSecurity (Enum id 6)
        /// </summary>
        [Description("6")]
        SystemSecurity = 64,

        /// <summary>
        /// Origin Application: N2 (Enum id 7)
        /// </summary>
        [Description("7")]
        N2 = 128,

        /// <summary>
        /// Origin Application: General (Enum id 8)
        /// </summary>
        [Description("8")]
        General = 256,

        /// <summary>
        /// Origin Application: DeviceManager (Enum id 9)
        /// </summary>
        [Description("9")]
        DeviceManager = 512,

        /// <summary>
        /// Origin Application: WebServices (Enum id 10)
        /// </summary>
        [Description("10")]
        WebServices = 1024,

        /// <summary>
        /// Origin Application: EnergyManagement (Enum id 11)
        /// </summary>
        [Description("11")]
        EnergyManagement = 2048,

        /// <summary>
        /// Origin Application: Interlock (Enum id 12)
        /// </summary>
        [Description("12")]
        Interlock = 4096,

        /// <summary>
        /// Origin Application: MCO (Enum id 13)
        /// </summary>
        [Description("13")]
        MCO = 8192,

        /// <summary>
        /// Origin Application: Schedule (Enum id 14)
        /// </summary>
        [Description("14")]
        Schedule = 16384
    }
}
