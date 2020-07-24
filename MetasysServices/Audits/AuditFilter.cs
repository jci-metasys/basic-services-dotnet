using System;
using System.Collections.Generic;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Filters to get audits
    /// </summary>
    public class AuditFilter : TimeFilter
    {
        /// <summary>
        /// Filter by comma-separated list of origin applications.
        /// See /enumSets/578/members for possible values.
        /// Example: 1,2.
        /// </summary>
       public OriginApplicationsEnum OriginApplications { get; set; }

        /// <summary>
        /// Filter by comma-separated list of class levels.
        /// See /enumSets/578/members for possible values.
        /// Example: 1,2.
        /// </summary>
      public ClassLevelsEnum ClassLevels { get; set; }

        /// <summary>
        /// Filter by comma-separated list of the action types.
        /// See /enumSets/578/members for possible values.
        /// Example: 1,2.
        /// </summary>
       public ActionTypeEnum ActionTypes { get; set; }

        /// <summary>
        /// Determines whether discarded audits will be excluded from results.
        /// Default is false (discarded audits will not be excluded).
        /// </summary>
       public bool? ExcludeDiscarded { get; set; }
    }
}