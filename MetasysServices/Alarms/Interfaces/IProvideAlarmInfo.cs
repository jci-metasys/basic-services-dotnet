using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Flurl.Http;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Defines method to provide alarm infos for endpoints of the Metasys Alarm API.
    /// </summary>
    public interface IProvideAlarmInfo
    {
        /// <summary>
        /// Retrieves the specified alarm.
        /// </summary>
        /// <param name="alarmId">The identifier of the alarm.</param>
        /// <returns>The specified alarm details.</returns>
        AlarmItemProvider GetSingleAlarm(Guid alarmId);

        /// <summary>
        /// Retrieves the specified alarm asynchronously.
        /// </summary>
        /// <param name="alarmId">The identifier of the alarm.</param>
        /// <returns>The specified alarm details.</returns>
        Task<AlarmItemProvider> GetSingleAlarmAsync(Guid alarmId);

        /// <summary>
        /// Retrieves a collection of alarms.
        /// </summary>
        /// <param name="alarmFilter">The alarm model to filter alarms.</param>
        /// <returns>The list of alarms with details.</returns>
        PagedResult<List<AlarmItemProvider>> GetAlarms(AlarmFilter alarmFilter);

        /// <summary>
        /// Retrieves a collection of alarms.
        /// </summary>
        /// <param name="alarmFilter">The alarm model to filter alarms.</param>
        /// <returns>The list of alarms with details.</returns>
        Task<PagedResult<List<AlarmItemProvider>>> GetAlarmsAsync(AlarmFilter alarmFilter);

        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <returns>The list of alarms with details.</returns>
        PagedResult<List<AlarmItemProvider>> GetAlarmsForAnObject(Guid objectId, AlarmFilter alarmFilter);

        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <returns>The list of alarms with details.</returns>
        Task<PagedResult<List<AlarmItemProvider>>> GetAlarmsForAnObjectAsync(Guid objectId, AlarmFilter alarmFilter);

        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the network device.</param>
        /// <returns>The list of alarms with details.</returns>
        PagedResult<List<AlarmItemProvider>> GetAlarmsForNetworkDevice(Guid networkDeviceId, AlarmFilter alarmFilter);

        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the network device.</param>
        /// <returns>The list of alarms with details.</returns>
        Task<PagedResult<List<AlarmItemProvider>>> GetAlarmsForNetworkDeviceAsync(Guid networkDeviceId, AlarmFilter alarmFilter);
    }
}