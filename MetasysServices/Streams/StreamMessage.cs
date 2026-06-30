using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace JohnsonControls.Metasys.BasicServices;
/// <summary>
/// Provides Stream message data
/// </summary>
public class StreamMessage
{
    private Guid _requestId = Guid.Empty;
    private string _subscriptionId;
    private string _data;

    /// <summary>
    /// Item or Activity Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Request Id
    /// </summary>
    public Guid RequestId
    {
        get { return _requestId; }
        set
        {
            if (_requestId != Guid.Empty) throw new InvalidOperationException("RequestId is already set!");
            _requestId = value;
        }
    }

    /// <summary>
    /// Subscription Identifier (String)
    /// </summary>
    public string SubscriptionId
    {
        get { return _subscriptionId; }
        set { _subscriptionId = value; }
    }

    /// <summary>
    /// Stream Identifier (String)
    /// </summary>
    public string StreamId { get; set; }

    /// <summary>
    /// Object Identifier (GUID)
    /// </summary>
    [JsonRequired]
    public Guid ObjectId { get; set; }

    /// <summary>
    /// Object Name
    /// </summary>
    public string ObjectName { get; set; }

    /// <summary>
    /// Attribute Name
    /// </summary>
    public string AttributeName { get; set; }

    /// <summary>
    /// Item Reference (FQR)
    /// </summary>
    public string ItemReference { get; set; }

    /// <summary>
    /// Present Value
    /// </summary>
    public string PresentValue { get; set; }

    /// <summary>
    /// Event Creation Time
    /// </summary>
    public string CreationTime { get; set; }

    /// <summary>
    /// Event that generated the stream message
    /// </summary>
    public string Event { get; }

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// JSON encoded string containing an object
    /// </summary>
    public string Data
    {
        get { return _data; }
        set
        {
            _data = value;
            ParseData(_data);
        }
    }

    /// <summary>
    /// Constructor of the class
    /// </summary>
    public StreamMessage(string eventType, string data)
    {
        Event = eventType;
        Data = data;
    }

    private void ParseData(string data)
    {
        if ((data.StartsWith("{") && data.EndsWith("}")) || //For object
                (data.StartsWith("[") && data.EndsWith("]"))) //For array
        {
            var dataObj = JsonNode.Parse(data) as JsonObject;
            switch (Event.ToLower())
            {
                case "object.values.update":
                    this.PresentValue = GetJObjectValue(dataObj, "item", "presentValue");
                    string objectId = GetJObjectValue(dataObj, "item", "id");
                    this.ObjectId = (objectId == string.Empty) ? Guid.Empty : new Guid(objectId);
                    this.Id = this.ObjectId;
                    this.ItemReference = GetJObjectValue(dataObj, "item", "itemReference");
                    this.ObjectName = GetJObjectValue(dataObj, "item", "objectName");
                    break;
                case "activity.audit.new":
                case "activity.alarm.new":
                case "activity.alarm.ack":
                    string id = GetJObjectValue(dataObj, "activity", "id");
                    this.Id = (id == string.Empty) ? Guid.Empty : new Guid(id);
                    objectId = GetJObjectValue(dataObj, "activity", "objectId");
                    this.ObjectId = (objectId == string.Empty) ? Guid.Empty : new Guid(objectId);
                    this.Id = this.ObjectId;
                    this.ItemReference = GetJObjectValue(dataObj, "activity", "itemReference");
                    this.CreationTime = GetJObjectValue(dataObj, "activity", "creationTime");

                    switch (Event.ToLower())
                    {
                        case "activity.audit.new":
                            if (dataObj != null && dataObj.ContainsKey("activity") && dataObj["activity"] != null)
                            {
                                JsonObject grp = dataObj["activity"] as JsonObject;
                                this.Description = GetJObjectValue(grp, "audit", "description");
                            }
                            break;
                        case "activity.alarm.new":
                        case "activity.alarm.ack":
                            if (dataObj != null && dataObj.ContainsKey("activity") && dataObj["activity"] != null)
                            {
                                JsonObject grp = dataObj["activity"] as JsonObject;
                                this.Description = GetJObjectValue(grp, "alarm", "description");
                            }
                            break;
                        default:
                            break;
                    }

                    break;
                case "message":
                    break;
                case "object.values.heartbeat":
                    break;
                default:
                    break;
            }
        }
    }

    private string GetJObjectValue(JsonObject jObj, string group, string field)
    {
        string res = string.Empty;
        try
        {
            if (jObj != null)
            {
                if (jObj.ContainsKey(group) && jObj[group] != null)
                {
                    JsonObject grp = jObj[group] as JsonObject;
                    if (grp != null && grp.ContainsKey(field) && grp[field] != null)
                    {
                        res = (string)grp[field];
                    }
                }
            }
        }
        catch (ArgumentNullException e)
        {
            throw new MetasysObjectException(e);
        }
        return res;
    }
}
