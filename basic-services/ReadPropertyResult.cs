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
        
        
        public string Reliability { private set; get; }
        public string Priority { private set; get; }
        public bool IsReliable => Reliability == "reliabilityEnumSet.reliable";

        internal ReadPropertyResult(JToken token, string reliability = null, string priority = null)
        {
            Reliability = reliability;
            Priority = priority;
            
            // switch on token type and set the fields appropriately
            switch (token.Type)
            {
                case JTokenType.Integer:
                    NumericValue = (double) token.Value<double>();
                    StringValue = NumericValue.ToString();
                    ArrayValue = null;
                    break;
                case JTokenType.Float:
                    NumericValue = (double) token.Value<double>();
                    StringValue = NumericValue.ToString();
                    ArrayValue = null;
                    break;
                case JTokenType.String:
                    NumericValue = 0;
                    StringValue = (string) token.Value<string>();
                    ArrayValue = null;
                    break;
                case JTokenType.Array:
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
                    break;
                case JTokenType.Boolean:
                    if ((bool)(token) == true) {
                        NumericValue = 1;
                        StringValue = "True";
                    } else {
                        NumericValue = 0;
                        StringValue = "False";
                    }
                    ArrayValue = null;
                    break;
                default:
                    NumericValue = 1;
                    StringValue = "Unsupported Data Type";
                    ArrayValue = null;
                    break;
            }
        }
    }
}
