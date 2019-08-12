using System;
using System.Globalization;
using Newtonsoft.Json.Linq;


namespace JohnsonControls.Metasys.BasicServices
{
    public struct ReadPropertyResult
    {
        private const string Reliable = "reliabilityEnumSet.reliable";

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
        public (string, double, bool)[] ArrayValue { private set; get; }
        
        public string Attribute { private set; get; }

        public Guid Id { private set; get; }

        // This will be an enum value
        public string Reliability { private set; get; }
        
        // This would be an enum value. It may make sense to have a PriorityNumber property as well
        // which would have the value 0 - 15 since that is often used in the UI of Metasys.
        public string Priority { private set; get; }
        
        // Helper 
        public bool IsReliable => Reliability == Reliable;

        private CultureInfo _CultureInfo;

        internal ReadPropertyResult(Guid id, JToken token, string attribute, CultureInfo cultureInfo = null, string reliability = null, string priority = null)
        {
            Id = id;
            Attribute = attribute;
            Reliability = reliability ?? Reliable;
            Priority = priority;
            StringValue = null;
            NumericValue = 1;
            ArrayValue = null;
            BooleanValue = false;
            _CultureInfo = cultureInfo;

            ReadToken(token);
        }

        /// <summary>Parses the JToken type and assigns struct values appropriately.</summary>
        internal void ReadToken(JToken token)
        {
            if (token == null) {
                NumericValue = 1;
                StringValue = "Unsupported Data Type";
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
                    StringValue = token.Value<string>();
                    break;
                case JTokenType.Array:
                    ReadArray(token);
                    break;
                case JTokenType.Boolean:
                    if ((bool)(token) == true) {
                        NumericValue = 1;
                        StringValue = "True";
                    } else {
                        NumericValue = 0;
                        StringValue = "False";
                    }
                    break;
                case JTokenType.Object:
                    ReadObject(token);
                    break;
                default:
                    NumericValue = 1;
                    StringValue = "Unsupported Data Type";
                    break;
            }
        }

        /// <summary>Parses a JArray and adds (string, double) pairs to an array based on JToken type.</summary>
        internal void ReadArray(JToken token) {
            JArray arr = JArray.Parse(token.ToString());
            ArrayValue = new (string, double, bool)[arr.Count];
            int index = 0;
            foreach(var item in arr.Children())
            {
                double value = 0;
                switch (item.Type)
                {
                    case JTokenType.Integer:
                        value = (double) item.Value<double>();
                        ArrayValue[index] = (value.ToString(), value, Convert.ToBoolean(NumericValue));
                        break;
                    case JTokenType.Float:
                        value = (double) item.Value<double>();
                        ArrayValue[index] = (value.ToString(), value, Convert.ToBoolean(NumericValue));
                        break;
                    case JTokenType.String:
                        ArrayValue[index] = ((string) item.Value<string>(), value, false);
                        break;
                    default:
                        ArrayValue[index] = ("Unsupported Data Type", 1, false);
                        break;
                }
                index++;
            }
            NumericValue = 0;
            StringValue = "Array";
        }

        /// <summary>Searches the JObject for reliability and priority fields and finds a value to use.</summary>
        internal void ReadObject(JToken token) {
            JToken valueToken = token["value"];
            JToken reliabilityToken = token["reliability"];
            JToken priorityToken = token["priority"];

            if (reliabilityToken != null) 
            {
                Reliability = reliabilityToken.ToString();
            }
            if (priorityToken != null)
            {
                Priority = priorityToken.ToString();
            }
            if (valueToken == null) {
                // Search for the first value to use as the value (there could exist more than 1)
                JObject obj = JObject.Parse(token.ToString());
                foreach (JProperty property in obj.Properties())
                {
                    if (!property.Name.Equals("reliability") && !property.Name.Equals("priority")) {
                        valueToken = property.Value;
                        break;
                    }
                }
            }
            ReadToken(valueToken);
        }
    }
}
