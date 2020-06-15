using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized DTO for COM that holds information about an attribute/property
    /// value from a single Metasys object.
    /// </summary>
    [ComVisible(true)]
    [Guid("dbe02a6d-986b-4ebf-b543-f66c65afdd00")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]    
    public interface IComVariant
    {     
        /// <summary>The string representation of the value.</summary>
        /// <value>
        /// String value as specified in the MSSDA Bulletin stringValue or a translated string if
        /// a type of enumeration.
        /// </value>
        string StringValue {  set; get; }

        /// <summary>The enumeration key of the StringValue.</summary>
        /// <value>
        /// The pre-translated StringValue as an enumeration key or the StringValue if it 
        /// was not an enumeration key. Null if value is not a string, array, or unsupported type.
        /// </value>
        string StringValueEnumerationKey {  set; get; }

        /// <summary>The numeric representation of the value.</summary>
        /// <value>
        /// Numeric value as specified in the MSSDA Bulletin rawValue.
        /// The numeric value for an Array will be 0.
        /// </value>
        double NumericValue {  set; get; }

        /// <summary>The boolean representation of the value.</summary>
        /// <value>
        /// 0 if false, numeric value is 0, or attribute is non-numeric.
        /// 1 if true or numeric value not equal to 0.
        /// </value>
        bool BooleanValue {  set; get; }

        /// <summary>An array of Variant values.</summary>
        /// <value>Null unless value is an array.</value>
        object ArrayValue {  set; get; } // Note: need a generic object as return type in order to map correctly to VBA type array (can't assign to array error)

        /// <summary>The attribute from the Metasys object.</summary>
        string Attribute {  set; get; }

        /// <summary>The id of the Metasys object.</summary>
        string Id {  set; get; }

        /// <summary>The reliability of the value.</summary>
        /// <value>
        /// If the attribute is "presentValue": the reliability of the value.
        /// Otherwise reliable by default.
        /// </value>
        string Reliability {  set; get; }

        /// <summary>The reliability enumeration key of the reliability.</summary>
        /// <value>
        /// If the attribute is "presentValue": the reliability enumeration key of the reliability.
        /// Otherwise reliabilityEnumSet.reliable by default.
        /// </value>
        string ReliabilityEnumerationKey {  set; get; }

        /// <summary>The priority of the value.</summary>
        /// <value>
        /// If the attribute is "presentValue": the priority of the value.
        /// Otherwise null by default.
        /// </value>
        string Priority {  set; get; }

        /// <summary>The priority enumeration key of the priority.</summary>
        /// <value>
        /// If the attribute is "presentValue": the priority enumeration key of the priority.
        /// Otherwise null by default.
        /// </value>
        string PriorityEnumerationKey {  set; get; }
    }
}
