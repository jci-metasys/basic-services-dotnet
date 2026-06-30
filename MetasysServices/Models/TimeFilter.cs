using System;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Temporal filter for a timeline based request.
/// </summary>
public class TimeFilter : BasicFilter
{
    /// <summary>
    /// Earliest start time.
    /// </summary>
    public DateTimeOffset? StartTime { get; set; }

    /// <summary>
    /// Latest end time.
    /// </summary>
    public DateTimeOffset? EndTime { get; set; }
}
