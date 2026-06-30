using System;
using System.Text.Json.Nodes;

namespace JohnsonControls.Metasys.BasicServices.Utils;
/// <summary>
/// Utility that provides useful methods to handle Json values.
/// </summary>

public class ObjectUtil
{
    /// <summary>
    /// Get the string value of a JToken field.
    /// </summary>
    /// <param name="jToken"></param>
    /// <param name="field"></param>
    /// <returns></returns>
    public static string GetJTokenValue(JsonNode jToken, string field)
    {
        string res = string.Empty;
        try
        {
            if (jToken is JsonObject jObj && jObj.ContainsKey(field) && jObj[field] != null)
            {
                res = (string)jObj[field];
            }
        }
        catch (ArgumentNullException e)
        {
            // Something went wrong on object parsing
            throw new MetasysObjectException(e);
        }
        return res;
    }

    /// <summary>
    /// Get the date value of a JToken field.
    /// </summary>
    /// <param name="jToken"></param>
    /// <param name="field"></param>
    /// <returns></returns>
    public static DateTime GetJTokenDate(JsonNode jToken, string field)
    {
        DateTime res = DateTime.UtcNow;
        try
        {
            if (jToken is JsonObject jObj && jObj.ContainsKey(field) && jObj[field] != null)
            {
                res = jObj[field].GetValue<DateTime>();
            }
        }
        catch (ArgumentNullException e)
        {
            // Something went wrong on object parsing
            throw new MetasysObjectException(e);
        }
        return res;
    }

}
