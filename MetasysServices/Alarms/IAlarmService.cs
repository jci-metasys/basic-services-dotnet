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
    public interface IAlarmsService
    {            
        /// <summary>
        /// Retrieves the specified alarm.
        /// </summary>
        /// <param name="alarmId">The identifier of the alarm.</param>
        /// <returns>The specified alarm details.</returns>
        Alarm GetSingleAlarm(Guid alarmId);


        /// <summary>
        /// Retrieves the specified alarm.
        /// </summary>
        /// <param name="alarmId">The identifier of the alarm.</param>
        /// <returns>The specified alarm details.</returns>
        /// <inheritdoc cref="IAlarmsService.GetSingleAlarm(Guid)"/>
		Task<Alarm> GetSingleAlarmAsync(Guid alarmId);
		
        /// <summary>
        /// Retrieves a collection of alarms.
        /// </summary>
        /// <param name="alarmFilter">The alarm model to filter alarms.</param>
        /// <returns>The list of alarms with details.</returns>
        PagedResult<Alarm> GetAlarms(AlarmFilter alarmFilter);

        /// <summary>
        /// Retrieve a collection of Alarm Annotations.
        /// </summary>
        /// <param name="alarmId"></param>
        /// <returns></returns>
        IEnumerable<AlarmAnnotation> GetAlarmAnnotations(Guid alarmId);

        /// <summary>
        /// Retrieve a collection of Alarm Annotations asynchronously.
        /// </summary>
        /// <param name="alarmId"></param>
        /// <returns></returns>
        Task<IEnumerable<AlarmAnnotation>> GetAlarmAnnotationsAsync(Guid alarmId);

        /// <summary>
        /// Retrieves a collection of alarms.
        /// </summary>
        /// <param name="alarmFilter">The alarm model to filter alarms.</param>
        /// <returns>The list of alarms with details.</returns>
        /// <inheritdoc cref="AlarmServiceProvider.GetAlarms(AlarmFilter)"/>
		Task<PagedResult<Alarm>> GetAlarmsAsync(AlarmFilter alarmFilter);

        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <param name="alarmFilter">The filter to be applied to alarms list.</param>
        /// <returns>The list of alarms with details.</returns>
        PagedResult<Alarm> GetAlarmsForAnObject(Guid objectId, AlarmFilter alarmFilter);

        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <param name="alarmFilter">The filter to be applied to alarms list.</param>
        /// <returns>The list of alarms with details.</returns>
        /// <inheritdoc cref="AlarmServiceProvider.GetAlarmsForAnObject(Guid, AlarmFilter)"/> 
        Task<PagedResult<Alarm>> GetAlarmsForAnObjectAsync(Guid objectId, AlarmFilter alarmFilter);

        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the network device.</param>
        /// <param name="alarmFilter">The filter to be applied to alarms list.</param>
        /// <returns>The list of alarms with details.</returns>
        PagedResult<Alarm> GetAlarmsForNetworkDevice(Guid networkDeviceId, AlarmFilter alarmFilter);

        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the network device.</param>
        /// <param name="alarmFilter">The filter to be applied to alarms list.</param>
        /// <returns>The list of alarms with details.</returns>
        /// <inheritdoc cref="AlarmServiceProvider.GetAlarmsForNetworkDevice(Guid, AlarmFilter)"/>
		Task<PagedResult<Alarm>> GetAlarmsForNetworkDeviceAsync(Guid networkDeviceId, AlarmFilter alarmFilter);
    }
}