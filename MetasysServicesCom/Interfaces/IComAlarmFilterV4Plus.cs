using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Provides attribute to filter alarm.
    /// </summary>
    [ComVisible(true)]
    [Guid("1E8ABDFF-F907-414E-9985-E112189FE736")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComAlarmFilterV4Plus
    {
        /// <summary>
        /// Earliest start time ISO8601 string
        /// </summary>
        string StartTime { get; set; }

        /// <summary>
        /// Latest end time ISO8601 string
        /// </summary>
        string EndTime { get; set; }

        /// <summary> 
        /// The inclusive priority range, from 0 to 255, of the alarm. 
        /// </summary>
        string PriorityRange { get; set; }

        /// <summary> 
        /// Limits the alarms returned to specified types. 
        /// </summary>
        /// <remarks> 
        /// Possible values from 'alarmValueEnumSet' Metasys enum set. Example: 'alarmValueEnumSet.avHighLimit'. 
        /// </remarks>
         string[] Type { get; set; }

        /// <summary> 
        /// Determines whether acknowledged alarms will be included in the results. Default: (missing). 
        /// </summary>
        bool? IncludeAcknowledged { get; set; }

        /// <summary> 
        /// The flag to include discarded alarms. Default: (missing). 
        /// </summary>
        bool? IncludeDiscarded { get; set; }

        /// <summary> 
        /// Determines whether activities which can be acknowledged are included in the results. Default: true. 
        /// </summary>
        bool? IncludeAcknowledgementRequired { get; set; }

        /// <summary> 
        /// Determines whether activities which can not be acknowledged are included in the results. Default: true. 
        /// </summary>
        bool? IncludeAcknowledgementNotRequired { get; set; }

        /// <summary> 
        /// Filter by list of equipment identifiers. 
        /// </summary>
        string[] Equipment { get; set; }

        /// <summary> 
        /// Filter by list of object identifiers. 
        /// </summary>
        string[] Object { get; set; }

        /// <summary> 
        /// Filter by list of space identifiers. 
        /// </summary>
        string[] Space { get; set; }

        /// <summary> 
        /// The authorization category of the requested alarms. 
        /// </summary>
        /// <remarks> 
        /// Possible values from 'objectCategoryEnumSet' Metasys enum set. Example: 'objectCategoryEnumSet.hvacCategory'. 
        /// </remarks>
        string[] Category { get; set; }

    }
}
