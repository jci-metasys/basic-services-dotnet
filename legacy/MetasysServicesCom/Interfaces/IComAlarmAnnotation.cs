using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// Provides attribute to Alarm Annotation.
    /// </summary>
    [ComVisible(true)]
    [Guid("DB81B410-BA46-44E1-A5AD-F82F7EBC4072")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]

    public interface IComAlarmAnnotation
    {
        /// <summary>
        /// Text of the annotation.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// User who made the annotation.
        /// </summary>
        string User { get; set; }

        /// <summary>
        /// Creation time of the annotation.
        /// </summary>
        DateTime CreationTime { get; set; }

        /// <summary>
        /// Action of the annotation.
        /// </summary>
        string Action { get; set; }

        /// <summary>
        /// URL of the alarm related to the annotation.
        /// </summary>
        string AlarmUrl { get; set; }

    }
}
