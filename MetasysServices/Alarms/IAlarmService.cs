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
    public interface IAlarmsService:IBasicService
    {
        /// <summary>
        /// Set an Alarm as 'acknowledged' or 'discared'.
        /// </summary>
        /// <param name="alarmId">The identifier of the alarm.</param>
        /// <param name="action">Action: Acknowledged or Discarded.</param>
        /// <param name="annotationText">Annotation Text (optional).</param>
        void EditAlarm(Guid alarmId, ActivityManagementStatusEnum action, string annotationText = null);

        /// <inheritdoc cref="IAlarmsService.EditAlarm(Guid, ActivityManagementStatusEnum, String)"/>
        Task EditAlarmAsync(Guid alarmId, ActivityManagementStatusEnum action, string annotationText = null);

        // --------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the specified alarm.
        /// </summary>
        /// <param name="alarmId">The identifier of the alarm.</param>
        /// <returns>The specified alarm details.</returns>
        Alarm FindById(Guid alarmId);

        /// <inheritdoc cref="IAlarmsService.FindById(Guid)"/>
        Task<Alarm> FindByIdAsync(Guid alarmId);

        // --------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves a collection of alarms.
        /// </summary>
        /// <param name="alarmFilter">The alarm model to filter alarms.</param>
        /// <returns>The list of alarms with details.</returns>
        PagedResult<Alarm> Get(AlarmFilter alarmFilter);

        /// <inheritdoc cref="IAlarmsService.Get(AlarmFilter)"/>
        Task<PagedResult<Alarm>> GetAsync(AlarmFilter alarmFilter);

        // --------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieve a collection of Alarm Annotations.
        /// </summary>
        /// <param name="alarmId"></param>
        /// <returns></returns>
        IEnumerable<AlarmAnnotation> GetAnnotations(Guid alarmId);

        /// <inheritdoc cref="IAlarmsService.GetAnnotations(Guid)"/>
        Task<IEnumerable<AlarmAnnotation>> GetAnnotationsAsync(Guid alarmId);

        // --------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="networkDeviceId">The identifier of the network device.</param>
        /// <param name="alarmFilter">The filter to be applied to alarms list.</param>
        /// <returns>The list of alarms with details.</returns>
        PagedResult<Alarm> GetForNetworkDevice(Guid networkDeviceId, AlarmFilter alarmFilter);

        /// <inheritdoc cref="IAlarmsService.GetForNetworkDevice(Guid, AlarmFilter)"/>
        Task<PagedResult<Alarm>> GetForNetworkDeviceAsync(Guid networkDeviceId, AlarmFilter alarmFilter);

        // --------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves a collection of alarms for the specified object.
        /// </summary>
        /// <param name="objectId">The identifier of the object.</param>
        /// <param name="alarmFilter">The filter to be applied to alarms list.</param>
        /// <returns>The list of alarms with details.</returns>
        PagedResult<Alarm> GetForObject(Guid objectId, AlarmFilter alarmFilter);

        /// <inheritdoc cref="AlarmServiceProvider.GetForObject(Guid, AlarmFilter)"/> 
        Task<PagedResult<Alarm>> GetForObjectAsync(Guid objectId, AlarmFilter alarmFilter);

    }
}