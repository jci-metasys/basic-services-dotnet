using System.Collections.Generic;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Defines method to provide activity infos for endpoints of the Metasys Activity API.
    /// </summary>

    public interface IActivityService : IBasicService
    {
        // --------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves a collection of activity items.
        /// </summary>
        /// <param name="activityFilter">The activity model to filter activity items.</param>
        /// <returns>The list of activity items.</returns>
        PagedResult<Activity> Get(ActivityFilter activityFilter);

        /// <inheritdoc cref="IActivityService.Get(ActivityFilter)"/>
        Task<PagedResult<Activity>> GetAsync(ActivityFilter activityFilter);

        /// <summary>
        /// Perform batch actions as discard/acknowledge an alarm/audit given a list of requests containing the info necessary to perform the actions.
        /// </summary>
        /// <param name="requests">List of BatchRequestParam to specify the info necessary to perform the actions.</param>
        /// <returns>
        /// A list of BatchRequestParam with all the specified attributes.
        /// </returns>
        IEnumerable<Result> ActionMultiple(IEnumerable<BatchRequestParam> requests);

        /// <summary>
        /// Perform batch actions as discard/acknowledge an alarm/audit given a list of requests containing the info necessary to perform the actions.
        /// </summary>
        /// <param name="requests">List of BatchRequestParam to specify the info necessary to perform the actions.</param>
        /// <returns>
        /// A list of BatchRequestParam with all the specified attributes.
        /// </returns>
        Task<IEnumerable<Result>> ActionMultipleAsync(IEnumerable<BatchRequestParam> requests);


    }
}
