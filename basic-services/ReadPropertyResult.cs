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
        
        
        // This will be an enum value
        public string Reliability { private set; get; }
        
        // This would be an enum value. It may make sense to have a PriorityNumber property as well
        // which would have the value 0 - 15 since that is often used in the UI of Metasys.
        public string Priority { private set; get; }
        
        // Helper 
        public bool IsReliable => Reliability == Reliable;

        internal ReadPropertyResult(JToken token, CultureInfo cultureInfo, string reliability = null, string priority = null)
        {
            Reliability = reliability ?? Reliable;
            Priority = priority;
            
            // switch on token type and set the fields appropriately
            switch (token.Type)
            {
                case JTokenType.Integer:
                    NumericValue = token.Value<double>();
                    StringValue = NumericValue.ToString(cultureInfo);
                    BooleanValue = Convert.ToBoolean(NumericValue);
                    ArrayValue = null;

                    break;
                case JTokenType.Float:
                    //todo
                case JTokenType.String:
                    // todo
                case JTokenType.Array:
                    // todo
                case JTokenType.Boolean:
                    // todo
                default:
                    StringValue = null;
                    NumericValue = 0;
                    ArrayValue = null;
                    BooleanValue = false;
                    break;
            }
            
        }

    }

    


}