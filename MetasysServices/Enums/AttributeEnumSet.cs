namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Enumeration of possible Attributes (typically for Trended Samples).
    /// </summary>
    public enum AttributeEnumSet
    {
        /// <summary>
        /// Acked Transitions
        /// </summary>
        ackedTransitions = 0,
        /// <summary>
        /// Ack Required
        /// </summary>
        ackRequired = 1,

        /// <summary>
        /// Alarm Value
        /// </summary>
        alarmValue = 6,

        /// <summary>
        /// COS Count
        /// </summary>
        cosCount = 15,

        /// <summary>
        /// Notification Class
        /// </summary>
        notificationClass = 17,

        /// <summary>
        /// COV Increment
        /// </summary>
        covIncrement = 22,

        /// <summary>
        /// BACnet Deadband
        /// </summary>
        bacnetDeadband = 25,

        /// <summary>
        /// Elapsed Active Time
        /// </summary>
        elapsedActiveTime = 33,

        /// <summary>
        /// Event State
        /// </summary>
        eventState = 36,

        /// <summary>
        /// High Limit
        /// </summary>
        highLimit = 45,

        /// <summary>
        /// Low Limit
        /// </summary>
        lowLimit = 59,

        /// <summary>
        /// Max Value
        /// </summary>
        maxPresValue = 65,
        /// <summary>
        /// Min Off Time
        /// </summary>
        minOffTime = 66,
        /// <summary>
        /// Min On Time
        /// </summary>
        minOnTime = 67,

        /// <summary>
        /// Min Value
        /// </summary>
        minPresValue = 69,

        /// <summary>
        /// Notify Type
        /// </summary>
        notifyType = 72,

        /// <summary>
        /// Number Of States
        /// </summary>
        numberOfStates = 74,

        /// <summary>
        /// Object Type
        /// </summary>
        bacnetObjectType = 79,

        /// <summary>
        /// Out Of Service
        /// </summary>
        outOfService = 81,

        /// <summary>
        /// Present Value
        /// </summary>
        presentValue = 85,

        /// <summary>
        /// Reliability
        /// </summary>
        reliability = 103,
        /// <summary>
        /// Relinquish Default
        /// </summary>
        relinquishDefault = 104,

        /// <summary>
        /// State Text
        /// </summary>
        stateText = 110,

        /// <summary>
        /// Time Delay
        /// </summary>
        timeDelay = 113,

        /// <summary>
        /// Units
        /// </summary>
        units = 117,

        /// <summary>
        /// Event Detection Enable
        /// </summary>
        eventDetectionEnable = 353,

        /// <summary>
        /// Current Command Priority
        /// </summary>
        currentCommandPriority = 431,

        /// <summary>
        /// Status
        /// </summary>
        status = 512,

        /// <summary>
        /// Display Precision
        /// </summary>
        displayPrecision = 661,

        /// <summary>
        /// Enabled
        /// </summary>
        enabled = 673,

        /// <summary>
        /// Direction
        /// </summary>
        direction = 746,

        /// <summary>
        /// Authorization Category
        /// </summary>
        dobjectCategory = 908,

        /// <summary>
        /// Alarm State
        /// </summary>
        alarmState = 1006,

        /// <summary>
        /// Connected Status
        /// </summary>
        connectedStatus = 1243,

        /// <summary>
        /// Execution Priority
        /// </summary>
        executionPriority = 2197,

        /// <summary>
        /// Estimated Flash Available
        /// </summary>
        estimatedFlashAvailable = 2395,

        /// <summary>
        /// Failsoft
        /// </summary>
        failsoft = 2567,

        /// <summary>
        /// Memory Usage
        /// </summary>
        memoryUsage = 2581,
        /// <summary>
        /// CPU Usage
        /// </summary>
        cpuUsage = 2583,

        /// <summary>
        /// Default Value
        /// </summary>
        defaultValue = 3113,

        /// <summary>
        /// BACnet Exposed
        /// </summary>
        bacnetExposed = 3807,

        /// <summary>
        /// Use COV Min Send Time
        /// </summary>
        useCovMinSendTime = 3930,

        /// <summary>
        /// Intrinsic Alarming Disabled
        /// </summary>
        intrinsicAlarmDisabled = 4305,

        /// <summary>
        /// Present Value Writable
        /// </summary>
        presentValueWritable = 6080,
        /// <summary>
        /// Connected to Internal Application
        /// </summary>
        connectedToInternalApplication = 6081,

        /// <summary>
        /// Priority Supported
        /// </summary>
        prioritySupported = 6083,
        /// <summary>
        /// Referenced Value
        /// </summary>
        referencedValue = 6084,
        /// <summary>
        /// Referenced Reliability
        /// </summary>
        referencedReliability = 6085,
        /// <summary>
        /// Referenced Value COS Count
        /// </summary>
        referencedValueCosCount = 6086,

        /// <summary>
        /// Failsoft Currently Active
        /// </summary>
        failsoftCurrentlyActive = 6088,

        /// <summary>
        /// Priority For Writing to Connected Object
        /// </summary>
        priorityForWritingToConnected = 6093,

        /// <summary>
        /// Last Idle Sample
        /// </summary>
        lastIdleSample = 30082

    }
}
