using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary> Provides Activity Item </summary>
/// <remarks> This is available since Metasys API v5. </remarks>
public class Activity
{
    /// <summary> Activity Unique Identifier </summary>
    [JsonRequired]
    public ActivityId Id { get; set; }

    /// <summary> Item fully qualified reference </summary>
    [JsonRequired]
    public string ItemReference { get; set; }

    /// <summary> Object Name </summary>
    [JsonRequired]
    public string ObjectName { get; set; }

    /// <summary> Activity Management Status </summary>
    [JsonRequired]
    public string ActivityManagementStatus { get; set; }

    /// <summary> Discarded Time </summary>
    public string DiscardedTime { get; set; }

    /// <summary> Activity creation time </summary>
    public string CreationTime { get; set; }

    /// <summary> Spaces </summary>
    public string[] Spaces { get; set; }

    /// <summary> Equipment </summary>
    public string[] Equipment { get; set; }

    /// <summary> Object Unique Identifier (GUID) </summary>
    public Guid ObjectId { get; set; }

    /// <summary>
    /// Alarm object (in case the activityType = alarm)
    /// </summary>
    public ActivityAlarm Alarm { get; set; }

    /// <summary>
    /// Audit object (in case the activityType = audit)
    /// </summary>
    public ActivityAudit Audit { get; set; }


    /// <summary>
    /// Returns a value indicating whether this instance has values equal to a specified object.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (obj != null && obj is Activity activity)
        {
            var o = activity;
            // Compare each properties one by one for better performance
            return this.Id == o.Id && this.ItemReference == o.ItemReference && this.ObjectName == o.ObjectName
                && this.ActivityManagementStatus == o.ActivityManagementStatus && this.ItemReference == o.ItemReference
                && this.Spaces == o.Spaces && this.Equipment == o.Equipment && this.ObjectId == o.ObjectId
                && this.Alarm == o.Alarm && this.Audit == o.Audit;
        }
        return false;
    }

    /// <summary></summary>
    public override int GetHashCode()
    {
        var code = 13;
        // Calculate hash on each properties one by one
        code = (code * 7) + Id.GetHashCode();
        if (ItemReference != null)
            code = (code * 7) + ItemReference.GetHashCode();
        if (this.ObjectName != null)
            code = (code * 7) + ObjectName.GetHashCode();
        if (this.ActivityManagementStatus != null)
            code = (code * 7) + ActivityManagementStatus.GetHashCode();
        if (this.DiscardedTime != null)
            code = (code * 7) + DiscardedTime.GetHashCode();
        if (this.CreationTime != null)
            code = (code * 7) + CreationTime.GetHashCode();
        code = (code * 7) + Spaces.GetHashCode();
        code = (code * 7) + Equipment.GetHashCode();
        code = (code * 7) + ObjectId.GetHashCode();
        if (this.Alarm != null)
            code = (code * 7) + Alarm.GetHashCode();
        if (this.Audit != null)
            code = (code * 7) + Audit.GetHashCode();
        return code;
    }

    /// <summary>
    /// Return a pretty JSON string of the current object.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}

