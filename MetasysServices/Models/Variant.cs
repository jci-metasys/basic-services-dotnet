using System;
using System.Globalization;
using Newtonsoft.Json.Linq;


namespace JohnsonControls.Metasys.BasicServices.Models
{
    public struct Variant
    {
        private const string Reliable = "reliabilityEnumSet.reliable";

        private const string Unsupported = "statusEnumSet.unsupportedObjectType";

        private const string Array = "dataTypeEnumSet.arrayDataType";

        // Follow rules for stringValue in MSSDA Bulletin, with the following
        // addendum. The string value for an Array will be "Array".
        public string StringValue { private set; get; }
        
        // Follow rules for rawValue in MSSDA Bulletin, with the following 
        // addendum. The numeric value for an Array will be 0
        // Enums will also be 0 (since we don't expose their numbers, we just expose them as strings)
        public double NumericValue { private set; get; }
        
        public bool BooleanValue { private set; get; }
        
        // This is new. MSSDA required you to read just one element of an array.
        // We will support reading the entire array (asusming it's an array of primitives)
        // This will be null for non-array data types.
        // Alternatively, we could have this return a single element array 
        public Variant[] ArrayValue { private set; get; }
        
        public string Attribute { private set; get; }

        public Guid Id { private set; get; }

        // This will be an enum value
        public string Reliability { private set; get; }
        
        // This would be an enum value. It may make sense to have a PriorityNumber property as well
        // which would have the value 0 - 15 since that is often used in the UI of Metasys.
        public string Priority { private set; get; }
        
        // Helper 
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

        /// <summary>Parses the JToken type and assigns struct values appropriately.</summary>
        private void ProcessToken(JToken token)
        {
            if (token == null) {
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
                    if ((bool)(token) == true) {
                        NumericValue = 1;
                        BooleanValue = true;
                        StringValue = Convert.ToString(BooleanValue, _CultureInfo);
                    } else {
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
        private void ProcessArray(JToken token) {
            JArray arr = JArray.Parse(token.ToString());
            ArrayValue = new Variant[arr.Count];
            int index = 0;
            foreach(var item in arr.Children())
            {
                ArrayValue[index] = new Variant(Id, item, Attribute, _CultureInfo);
                index++;
            }
            NumericValue = 0;
            StringValue = MetasysClient.StaticLocalize(Array, _CultureInfo);
        }

        /// <summary>Searches the JObject for reliability and priority fields and uses the field called 'value' as value for result.</summary>
        internal void ProcessPresentValue(JToken token) {
            if (Attribute.Equals("presentValue")) {
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
