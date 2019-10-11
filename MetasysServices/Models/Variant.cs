using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace JohnsonControls.Metasys.BasicServices.Models
{
    /// <summary>
    /// Variant is a class that holds information about an attribute/property
    /// value from a single Metasys object.
    /// </summary>
    /// <remarks>
    /// If the returned property is an array of values the ArrayValue will hold 
    /// each of these values in a new Variant object.
    /// </remarks>
    public class Variant
    {
        private const string Reliable = "reliabilityEnumSet.reliable";

        private const string Unsupported = "statusEnumSet.unsupportedObjectType";

        private const string Array = "dataTypeEnumSet.arrayDataType";

        /// <summary>The string representation of the value.</summary>
        /// <value>String value as specified in the MSSDA Bulletin stringValue.</value>
        public string StringValue { private set; get; }

        /// <summary>The numeric representation of the value.</summary>
        /// <value>
        /// Numeric value as specified in the MSSDA Bulletin rawValue.
        /// The numeric value for an Array will be 0.
        /// </value>
        public double NumericValue { private set; get; }

        /// <summary>The boolean representation of the value.</summary>
        /// <value>
        /// 0 if false, numeric value is 0, or attribute is non-numeric.
        /// 1 if true or numeric value not equal to 0.
        /// </value>
        public bool BooleanValue { private set; get; }

        /// <summary>An array of Variant values.</summary>
        /// <value>Null unless value is an array.</value>
        public Variant[] ArrayValue { private set; get; }

        /// <summary>The attribute from the Metasys object.</summary>
        public string Attribute { private set; get; }

        /// <summary>The id of the Metasys object.</summary>
        public Guid Id { private set; get; }

        /// <summary>The reliability of the value.</summary>
        /// <value>
        /// If the attribute is "presentValue": the reliability of the value.
        /// Otherwise reliable by default.
        /// </value>
        public string Reliability { private set; get; }

        /// <summary>The priority of the value.</summary>
        /// <value>
        /// If the attribute is "presentValue": the priority of the value.
        /// Otherwise null by default.
        /// </value>
        public string Priority { private set; get; }

        /// <summary>Boolean representation of the reliability of the value.</summary>
        /// <value>True if the reliability of the value is reliable.</value>
        public bool IsReliable => Reliability == MetasysClient.StaticLocalize(Reliable, _CultureInfo);

        private CultureInfo _CultureInfo;

        internal Variant(Guid id, JToken token, string attribute, CultureInfo cultureInfo)
        {
            _CultureInfo = cultureInfo;
            Id = id;
            Attribute = attribute;
            Reliability = MetasysClient.StaticLocalize(Reliable, _CultureInfo);
            Priority = null;
            StringValue = null;
            NumericValue = 1;
            ArrayValue = null;
            BooleanValue = false;

            ProcessToken(token);
        }

        /// <summary>
        /// Parses the JToken type and assigns values as specified in the MSSDA Bulletin.
        /// </summary>
        private void ProcessToken(JToken token)
        {
            if (token == null)
            {
                NumericValue = 1;
                StringValue = MetasysClient.StaticLocalize(Unsupported, _CultureInfo);
                return;
            }
            // switch on token type and set the fields appropriately
            switch (token.Type)
            {
                case JTokenType.Integer:
                    NumericValue = token.Value<double>();
                    StringValue = NumericValue.ToString(_CultureInfo);
                    BooleanValue = Convert.ToBoolean(NumericValue);
                    ArrayValue = null;
                    break;
                case JTokenType.Float:
                    NumericValue = token.Value<double>();
                    StringValue = NumericValue.ToString(_CultureInfo);
                    BooleanValue = Convert.ToBoolean(NumericValue);
                    break;
                case JTokenType.String:
                    NumericValue = 0;
                    StringValue = MetasysClient.StaticLocalize(token.Value<string>(), _CultureInfo);
                    break;
                case JTokenType.Array:
                    ProcessArray(token);
                    break;
                case JTokenType.Boolean:
                    if ((bool)(token) == true)
                    {
                        NumericValue = 1;
                        BooleanValue = true;
                        StringValue = Convert.ToString(BooleanValue, _CultureInfo);
                    }
                    else
                    {
                        NumericValue = 0;
                        BooleanValue = false;
                        StringValue = Convert.ToString(BooleanValue, _CultureInfo);
                    }
                    break;
                case JTokenType.Object:
                    // It is assumed the attribute read was the presentValue
                    ProcessPresentValue(token);
                    break;
                default:
                    NumericValue = 1;
                    StringValue = MetasysClient.StaticLocalize(Unsupported, _CultureInfo);
                    break;
            }
        }

        /// <summary>Parses a JArray and adds each item as a Variant.</summary>
        private void ProcessArray(JToken token)
        {
            JArray arr = JArray.Parse(token.ToString());
            ArrayValue = new Variant[arr.Count];
            int index = 0;
            foreach (var item in arr.Children())
            {
                ArrayValue[index] = new Variant(Id, item, Attribute, _CultureInfo);
                index++;
            }
            NumericValue = 0;
            StringValue = MetasysClient.StaticLocalize(Array, _CultureInfo);
        }

        /// <summary>Searches the JObject for reliability and priority fields and uses the field called "value" as value for result.</summary>
        internal void ProcessPresentValue(JToken token)
        {
            if (Attribute.Equals("presentValue"))
            {
                JToken valueToken = token["value"];
                JToken reliabilityToken = token["reliability"];
                JToken priorityToken = token["priority"];

                if (reliabilityToken != null)
                {
                    Reliability = MetasysClient.StaticLocalize(reliabilityToken.ToString(), _CultureInfo);
                }
                if (priorityToken != null)
                {
                    Priority = MetasysClient.StaticLocalize(priorityToken.ToString(), _CultureInfo);
                }
                ProcessToken(valueToken);
            }
            else
            {
                ProcessToken(null);
            }
        }
    }
}
