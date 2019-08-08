using System;
using Newtonsoft.Json.Linq;


namespace JohnsonControls.Metasys.BasicServices
{
    public struct ReadPropertyResult
    {
        // Follow rules for stringValue in MSSDA Bulletin, with the following
        // addendum. The string value for an Array will be "Array".
        public string StringValue { private set; get; }
        
        // Follow rules for rawValue in MSSDA Bulletin, with the following 
        // addendum. The numeric value for an Array will be 0
        // Enums will also be 0 (since we don't expose their numbers, we just expose them as strings)
        public double NumericValue { private set; get; }
        
        // This is new. MSSDA required you to read just one element of an array.
        // We will support reading the entire array (asusming it's an array of primitives)
        // This will be null for non-array data types.
        public (string, double)[] ArrayValue { private set; get; }
        
        public string Attribute { private set; get; }

        public string Reliability { private set; get; }
        public string Priority { private set; get; }
        public bool IsReliable => Reliability == "reliabilityEnumSet.reliable";

        internal ReadPropertyResult(JToken token, string attribute, string reliability = null, string priority = null)
        {
            Attribute = attribute;
            Reliability = reliability;
            Priority = priority;
            StringValue = null;
            NumericValue = 1;
            ArrayValue = null;

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
                    NumericValue = (double) token.Value<double>();
                    StringValue = NumericValue.ToString();
                    break;
                case JTokenType.Float:
                    NumericValue = (double) token.Value<double>();
                    StringValue = NumericValue.ToString();
                    break;
                case JTokenType.String:
                    NumericValue = 0;
                    StringValue = (string) token.Value<string>();
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
            ArrayValue = new (string, double)[arr.Count];
            int index = 0;
            foreach(var item in arr.Children())
            {
                double value = 0;
                switch (item.Type)
                {
                    case JTokenType.Integer:
                        value = (double) item.Value<double>();
                        ArrayValue[index] = (value.ToString(), value);
                        break;
                    case JTokenType.Float:
                        value = (double) item.Value<double>();
                        ArrayValue[index] = (value.ToString(), value);
                        break;
                    case JTokenType.String:
                        ArrayValue[index] = ((string) item.Value<string>(), value);
                        break;
                    default:
                        ArrayValue[index] = ("Unsupported Data Type", 1);
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
