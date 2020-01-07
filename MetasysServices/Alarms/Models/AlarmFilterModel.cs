using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Filters to get alarms
    /// </summary>
    public class AlarmFilterModel
    {
        /// <summary>
        /// Lowest priority value
        /// </summary>
        public const int MinPriority = 0;

        /// <summary>
        ///  Highest priority value
        /// </summary>
        public const int MaxPriority = 255;

        /// <summary>
        /// Earliest start time ISO8601 string
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// Latest end time ISO8601 string
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// Unique identifier of latest alarm in recent result set
        /// </summary>
        public string LastProcessedId { get; set; }

        /// <summary>
        /// Max size of page
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// input for the priority range, comma deliminated 
        /// </summary>
        public string PriorityRange { get; set; }

        /// <summary>
        /// Priority minimum value of an alarm 
        /// </summary>
        public int? PriorityMinimum { get; private set; }

        /// <summary>
        /// Priority maximum value of an alarm 
        /// </summary>
        public int? PriorityMaximum { get; private set; }

        /// <summary>
        /// Type of alarm
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// Authorization Category of Item
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// Result set PageNumber
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Sort Column and Order
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Previous Page
        /// </summary>
        public bool? PreviousPage { get; set; }

        /// <summary>
        /// Filter to get pending alarms
        /// </summary>
        public bool? ExcludePending { get; set; }

        /// <summary>
        /// Filter to get acknowledged alarms
        /// </summary>
        public bool? ExcludeAcknowledged { get; set; }

        /// <summary>
        /// Filter to get discarded alarms
        /// </summary>
        public bool? ExcludeDiscarded { get; set; }

        /// <summary>
        /// validate if the object properties are valid
        /// </summary>
        /// <param name="errorMessage">error message</param>
        /// <returns></returns>
        public bool IsValid(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (Page < 1)
            {
                errorMessage = "The specified page must be greater than 0";
                return false;
            }

            if (PageSize < 1 || PageSize > 10000)
            {
                errorMessage = "The specified pageSize is outside the valid range (1 - 10000)";
                return false;
            }

            if (!ValidationHelper.IsValidStartTimeEndTime(StartTime, EndTime, ref errorMessage))
            {
                return false;
            }

            int? priorityMinimum = null;
            int? priorityMaximum = null;

            if (!ValidationHelper.IsValidPriority(PriorityRange, ref errorMessage, out priorityMinimum, out priorityMaximum))
            {
                return false;
            }
            else
            {
                PriorityMinimum = priorityMinimum;
                PriorityMaximum = priorityMaximum;
            }

            if (!ValidationHelper.IsValidPageSize(PageSize, ref errorMessage))
            {
                errorMessage = "Invalid Page Size.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AlarmFilterModel()
        { }

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="startTime">start Time</param>
        /// <param name="endTime">end Time</param>
        /// <param name="lastProcessedId">last processed alarm unique Id</param>
        /// <param name="batchSize">batch Size</param>
        /// <param name="priorityMin">priority Min</param>
        /// <param name="priorityMax">priority Max</param>
        /// <param name="type">type</param>
        /// <param name="category">category</param>
        /// <param name="pageNumber">pageNumber</param>
        /// <param name="sortColumn">sort Column</param>
        /// <param name="sortOrder">sort Order</param>
        /// <param name="previousPage">previous Page</param>
        /// <param name="userItemCategories">user's viewable item categories</param>
        /// <param name="pending">Pending state filter</param>
        /// <param name="acknowledged">Acknowledged state filter</param>
        /// <param name="discarded">Discarded state filter</param>
        public AlarmFilterModel(string startTime, string endTime, string lastProcessedId, int? pageSize, string priorityRange, int? priorityMinimum, int? priorityMaximum,
            int? type, int? category, int? page, string sort, bool? previousPage, bool? excludePending, bool? excludeAcknowledged, bool? excludeDiscarded)
        {
            StartTime = startTime;
            EndTime = endTime;
            LastProcessedId = lastProcessedId;
            PageSize = pageSize;
            PriorityRange = priorityRange;
            PriorityMinimum = priorityMinimum;
            PriorityMaximum = priorityMaximum;
            Type = type;
            Category = category;
            Page = page;
            Sort = sort;
            PreviousPage = previousPage;
            ExcludePending = excludePending;
            ExcludeAcknowledged = excludeAcknowledged;
            ExcludeDiscarded = excludeDiscarded;
        }
    }
}