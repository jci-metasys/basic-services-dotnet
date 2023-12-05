using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Filters to get activity items
    /// </summary>

    public class ActivityFilter : TimeFilter
    {
        /// <summary> Limit the activities returned to a specific type. </summary>
        /// <remarks> Possible values: 'alarm', 'audit'. </remarks>
        public string ActivityType { get; set; }

        /// <summary> The flag to include discarded activity. </summary>
        public bool? IncludeDiscarded { get; set; }

        /// <summary> The criteria to use when sorting results. </summary>
        /// <remarks> Possible values: 'creationTime', '-creationTime', 'priority', '-priority'. Default: 'creationTime'</remarks>
        public string Sort { get; set; }

        /// <summary> Filter by list of equipment identifiers. </summary>
        public string[] Equipment { get; set; }

        /// <summary> Filter by list of object identifiers. </summary>
        public string[] Object { get; set; }

        /// <summary> Filter by list of space identifiers. </summary>
        public string[] Space { get; set; }

        /// <summary> The inclusive priority range, from 0 to 255, of the alarm. </summary>
        public string PriorityRange { get; set; }

        /// <summary> Limits the alarms returned to specified types. </summary>
        /// <remarks> Possible values from 'alarmValueEnumSet' Metasys enum set. Example: 'alarmValueEnumSet.avHighLimit'. </remarks>
        public string[] Type { get; set; }

        /// <summary> Determines whether acknowledged alarms will be included in the results. Default: (missing). </summary>
        public bool? IncludeAcknowledged { get; set; }

        /// <summary> Determines whether activities which can be acknowledged are included in the results. Default: true. </summary>
        public bool? IncludeAcknowledgementRequired { get; set; }

        /// <summary> Determines whether activities which can not be acknowledged are included in the results. Default: true. </summary>
        public bool? IncludeAcknowledgementNotRequired { get; set; }

        /// <summary> The authorization category of the requested activities. </summary>
        /// <remarks> Possible values from 'objectCategoryEnumSet' Metasys enum set. Example: 'objectCategoryEnumSet.hvacCategory'. </remarks>
        public string[] Category { get; set; }


        /// <summary> The origin application property indicates which application in Metasys generated the audit message. </summary> 
        /// <remarks> Possible values from 'auditOriginAppEnumSet' Metasys enum set. Example: 'auditOriginAppEnumSet.deviceManagerAuditOriginApp'. </remarks>
        public string[] OriginApplication { get; set; }

        /// <summary> The class level of an audit indicates the class or family the audit belongs to. </summary>
        /// <remarks> Possible values from 'auditClassesEnumSet' Metasys enum set. Example: 'auditClassesEnumSet.userActionAuditClass'. </remarks>
        public string[] ClassLevel { get; set; }

        /// <summary> The action type property indicates the user or system action performed. </summary>
        /// <remarks> Possible values from 'auditActionTypeEnumSet' Metasys enum set. Example: 'auditActionTypeEnumSet.writeAuditActionType'. </remarks>
        public string[] ActionType { get; set; }

        /// <summary> The user property indicates which user initiated the action being audited. </summary>
        /// <remarks> Example of values: 'metasysuser'. </remarks> 
        public string[] User { get; set; }

    }
}
