using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// this class provide helper methods to validate date range inputs and priority inputs
    /// </summary>
    public static class ValidationHelper
    {
        private const int MaxBatchSize = 10000;
        /// <summary>
        /// validate start time and end time inputs, verify it's a valid date range
        /// </summary>
        /// <param name="startTime">startTime string</param>
        /// <param name="endTime">endTime string</param>
        /// <param name="errorMessage">error message</param>
        /// <returns></returns>
        public static bool IsValidStartTimeEndTime(string startTime, string endTime, ref string errorMessage)
        {
            DateTime startDateTime = DateTime.UtcNow, endDatetime = DateTime.UtcNow;

            if (!string.IsNullOrWhiteSpace(startTime) && !DateTime.TryParse(startTime, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out startDateTime))
            {
                errorMessage = "The specified startTime is invalid";
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(endTime) && !DateTime.TryParse(endTime, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out endDatetime))
            {
                errorMessage = "The specified endTime is invalid";
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(startTime) && !string.IsNullOrWhiteSpace(endTime) && endDatetime.CompareTo(startDateTime) < 0)
            {
                errorMessage = "Invalid Date Range.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// validate the priority inputs, verify it's a valid priority range
        /// 255 is the lowest priority
        /// 0 is the highest priority
        /// </summary>
        /// <param name="priorityRange">a comma deliminated string that represents the priority range</param>
        /// <param name="errorMessage">error message</param>
        /// <param name="minimumPriority">parsed minimum priority</param>
        /// <param name="maximumPriority">parsed maximum priority</param>
        /// <returns></returns>
        public static bool IsValidPriority(string priorityRange, ref string errorMessage, out int? minimumPriority, out int? maximumPriority)
        {
            const int priorityBoundaryMin = 0;
            const int priorityBoundaryMax = 255;

            minimumPriority = null;
            maximumPriority = null;

            if (!string.IsNullOrWhiteSpace(priorityRange))
            {
                var priorityRangeArray = priorityRange.Split(',');

                if (priorityRangeArray.Length != 2)
                {
                    errorMessage = "Invalid priority range.";
                    return false;
                }

                if (int.TryParse(priorityRangeArray[0], out int firstPriority) &&
                    int.TryParse(priorityRangeArray[1], out int secondPriority) &&
                    firstPriority >= priorityBoundaryMin && firstPriority <= priorityBoundaryMax &&
                    secondPriority >= priorityBoundaryMin && secondPriority <= priorityBoundaryMax)
                {
                    // we allow input like "0,255" or "255,0"
                    if (firstPriority <= secondPriority)
                    {
                        minimumPriority = firstPriority;
                        maximumPriority = secondPriority;
                    }
                    else
                    {
                        minimumPriority = secondPriority;
                        maximumPriority = firstPriority;
                    }
                }
                else
                {
                    errorMessage = "Invalid priority range.";
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// validate page size
        /// </summary>
        /// <param name="pageSize">page size</param>
        /// <param name="errorMessage">error message</param>
        /// <returns></returns>
        public static bool IsValidPageSize(int? pageSize, ref string errorMessage)
        {
            if (pageSize.HasValue && (pageSize < 0 || pageSize > MaxBatchSize))
            {
                errorMessage = "Invalid Page Size.";
                return false;
            }

            return true;
        }
    }
}