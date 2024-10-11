namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Filters to get activity items from API v4 on.
    /// </summary>
    public class AlarmFilterV4Plus : TimeFilter
    {
        /// <summary> 
        /// The inclusive priority range, from 0 to 255, of the alarm. 
        /// </summary>
        public string PriorityRange { get; set; }

        /// <summary> 
        /// Limits the alarms returned to specified types. 
        /// </summary>
        /// <remarks> 
        /// Possible values from 'alarmValueEnumSet' Metasys enum set. Example: 'alarmValueEnumSet.avHighLimit'. 
        /// </remarks>
        public string[] Type { get; set; }

        /// <summary> 
        /// Determines whether acknowledged alarms will be included in the results. Default: (missing). 
        /// </summary>
        public bool? IncludeAcknowledged { get; set; }

        /// <summary> 
        /// The flag to include discarded alarms. Default: (missing). 
        /// </summary>
        public bool? IncludeDiscarded { get; set; }

        /// <summary> 
        /// Determines whether activities which can be acknowledged are included in the results. Default: true. 
        /// </summary>
        public bool? IncludeAcknowledgementRequired { get; set; }

        /// <summary> 
        /// Determines whether activities which can not be acknowledged are included in the results. Default: true. 
        /// </summary>
        public bool? IncludeAcknowledgementNotRequired { get; set; }

        /// <summary> 
        /// Filter by list of equipment identifiers. 
        /// </summary>
        public string[] Equipment { get; set; }

        /// <summary> 
        /// Filter by list of object identifiers. 
        /// </summary>
        public string[] Object { get; set; }

        /// <summary> 
        /// Filter by list of space identifiers. 
        /// </summary>
        public string[] Space { get; set; }

        /// <summary> 
        /// The authorization category of the requested alarms. 
        /// </summary>
        /// <remarks> 
        /// Possible values from 'objectCategoryEnumSet' Metasys enum set. Example: 'objectCategoryEnumSet.hvacCategory'. 
        /// </remarks>
        public string[] Category { get; set; }

    }
}
