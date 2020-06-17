using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Enumeration of possible OriginApplications for an Audit.
    /// </summary>
    [Flags]
    public enum OriginApplicationsEnum
    {
        AlarmEvent = 0,
        AuditTrails = 1,
        DeviceServices = 2,
        MCE = 3,
        SiteServices = 4,
        Trend = 5,
        SystemSecurity = 6,
        N2 = 7,
        General = 8,
        DeviceManager = 9,
        WebServices = 10,
        EnergyManagement = 11,
        Interlock = 12,
        MCO = 13,
        Schedule = 14
    }
}
