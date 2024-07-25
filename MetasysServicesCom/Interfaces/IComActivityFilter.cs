using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Provides attribute to filter Activities.
    /// </summary>
    [ComVisible(true)]
    [Guid("915C206A-E3BD-4A1E-9CDF-E5044D97D218")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComActivityFilter
    {
        /// <summary>
        /// Earliest start time ISO8601 string
        /// </summary>
        string StartTime { get; set; }

        /// <summary>
        /// Latest end time ISO8601 string
        /// </summary>
        string EndTime { get; set; }

        /// <summary> Limit the activities returned to a specific type. </summary>
        /// <remarks> Possible values: 'alarm', 'audit'. </remarks>
        string ActivityType { get; set; }

        /// <summary> The flag to include discarded activity. </summary>
        bool IncludeDiscarded { get; set; }

        /// <summary> The criteria to use when sorting results. </summary>
        /// <remarks> Possible values: 'creationTime', '-creationTime', 'priority', '-priority'. Default: 'creationTime'</remarks>
        string Sort { get; set; }

        /// <summary>
        /// Filter by comma-separated list of equipment identifiers.
        /// Example: 'b7ed8b3e-cb95-410d-aaa7-37158852c398,40DBDE96-5B14-4D9E-AF4D-576370723531'.
        /// </summary>
        string Equipment { get; set; }

        /// <summary>
        /// Filter by comma-separated list of object identifiers.
        /// Example: 'b7ed8b3e-cb95-410d-aaa7-37158852c398,40DBDE96-5B14-4D9E-AF4D-576370723531'.
        /// </summary>
        string Object { get; set; }

        /// <summary>
        /// Filter by comma-separated list of space identifiers.
        /// Example: 'b7ed8b3e-cb95-410d-aaa7-37158852c398,40DBDE96-5B14-4D9E-AF4D-576370723531'.
        /// </summary>
        string Space { get; set; }

        /// <summary> The inclusive priority range, from 0 to 255, of the alarm. 
        /// Example: '0,255'
        /// </summary>
        string PriorityRange { get; set; }

        /// <summary> Filter by comma-separated list of specified types. </summary>
        /// <remarks> Possible values from 'alarmValueEnumSet' Metasys enum set. Example: 'alarmValueEnumSet.avHighLimit'. </remarks>
        string Type { get; set; }

        /// <summary> Determines whether acknowledged alarms will be included in the results. Default: (missing). </summary>
        bool IncludeAcknowledged { get; set; }

        /// <summary> Determines whether activities which can be acknowledged are included in the results. Default: true. </summary>
        bool IncludeAcknowledgementRequired { get; set; }

        /// <summary> Determines whether activities which can not be acknowledged are included in the results. Default: true. </summary>
        bool IncludeAcknowledgementNotRequired { get; set; }

        /// <summary> Filter by comma-separated list of authorization category of the requested activities. </summary>
        /// <remarks> Possible values from 'objectCategoryEnumSet' Metasys enum set. Example: 'objectCategoryEnumSet.hvacCategory'. </remarks>
        string Category { get; set; }


        /// <summary> Filter by comma-separated list of origin application that generated the audit message. </summary> 
        /// <remarks> Possible values from 'auditOriginAppEnumSet' Metasys enum set. Example: 'auditOriginAppEnumSet.deviceManagerAuditOriginApp'. </remarks>
        string OriginApplication { get; set; }

        /// <summary> Filter by comma-separated list of class level the audit belongs to. </summary>
        /// <remarks> Possible values from 'auditClassesEnumSet' Metasys enum set. Example: 'auditClassesEnumSet.userActionAuditClass'. </remarks>
        string ClassLevel { get; set; }

        /// <summary> Filter by comma-separated list of action type the user or system performed. </summary>
        /// <remarks> Possible values from 'auditActionTypeEnumSet' Metasys enum set. Example: 'auditActionTypeEnumSet.writeAuditActionType'. </remarks>
        string ActionType { get; set; }

        /// <summary> Filter by comma-separated list of users that initiated the action being audited. </summary>
        /// <remarks> Example of values: 'metasysuser'. </remarks> 
        string User { get; set; }
    }
}
