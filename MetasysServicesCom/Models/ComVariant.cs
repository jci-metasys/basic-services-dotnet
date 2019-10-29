using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized COM structure that holds information about an attribute/property
    /// value from a single Metasys object.
    /// </summary>    
    [Guid("e4df7bb3-3be4-420d-8a73-f93ddad4681f")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComVariant:IComVariant
    { // Note: in order to correctly work with VBA registered types, class need to implement a defined interface. Neither inheritance nor encapsulation will work when the defined class is in another assembly
  

        /// <summary>The string representation of the value.</summary>
        /// <value>
        /// String value as specified in the MSSDA Bulletin stringValue or a translated string if
        /// a type of enumeration.
        /// </value>
        public string StringValue { set; get; }

        /// <summary>The enumeration key of the StringValue.</summary>
        /// <value>
        /// The pre-translated StringValue as an enumeration key or the StringValue if it 
        /// was not an enumeration key. Null if value is not a string, array, or unsupported type.
        /// </value>
        public string StringValueEnumerationKey { set; get; }

        /// <summary>The numeric representation of the value.</summary>
        /// <value>
        /// Numeric value as specified in the MSSDA Bulletin rawValue.
        /// The numeric value for an Array will be 0.
        /// </value>
        public double NumericValue { set; get; }

        /// <summary>The boolean representation of the value.</summary>
        /// <value>
        /// 0 if false, numeric value is 0, or attribute is non-numeric.
        /// 1 if true or numeric value not equal to 0.
        /// </value>
        public bool BooleanValue { set; get; }

        /// <summary>An array of Variant values.</summary>
        /// <value>Null unless value is an array.</value>
        public ComVariant[] ArrayValue { set; get; }

        /// <summary>The attribute from the Metasys object.</summary>
        public string Attribute { set; get; }

        /// <summary>The id of the Metasys object.</summary>
        public string Id { set; get; }

        /// <summary>The reliability of the value.</summary>
        /// <value>
        /// If the attribute is "presentValue": the reliability of the value.
        /// Otherwise reliable by default.
        /// </value>
        public string Reliability { set; get; }

        /// <summary>The reliability enumeration key of the reliability.</summary>
        /// <value>
        /// If the attribute is "presentValue": the reliability enumeration key of the reliability.
        /// Otherwise reliabilityEnumSet.reliable by default.
        /// </value>
        public string ReliabilityEnumerationKey { set; get; }

        /// <summary>The priority of the value.</summary>
        /// <value>
        /// If the attribute is "presentValue": the priority of the value.
        /// Otherwise null by default.
        /// </value>
        public string Priority { set; get; }

        /// <summary>The priority enumeration key of the priority.</summary>
        /// <value>
        /// If the attribute is "presentValue": the priority enumeration key of the priority.
        /// Otherwise null by default.
        /// </value>
        public string PriorityEnumerationKey { set; get; }
     
    }
}
