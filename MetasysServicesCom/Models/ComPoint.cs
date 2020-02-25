using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM Command is a specialized structure that holds information about a Command.
    /// </summary>
    [Guid("028b6c6f-9730-4424-aed6-325e43fef6ef")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComPoint : IComPoint
    {
        /// <summary>
        /// The name of the Equipment that contains the Point
        /// </summary>
        public string EquipmentName { get; set; }
        /// <summary>The Short name of the Point.</summary>
        public string ShortName { set; get; }
        /// <summary>The Label of the Point.</summary>
        public string Label { set; get; }
        /// <summary>
        /// Category of the Point.
        /// </summary>
        public string Category { set; get; }
        /// <summary>
        /// Flag that states when the attribute object contains data suitable to display
        /// </summary>
        public bool IsDisplayData { set; get; }
        /// <summary>
        /// The ID of the object where the point is mapped
        /// </summary>
        public string ObjectId { get; set; }
        /// <summary>
        /// Full URL of the attribute where the point is mapped
        /// </summary>
        public string AttributeUrl { get; set; }
        /// <summary>
        /// Full URL of the object where the point is mapped
        /// </summary>
        public string ObjectUrl { get; set; }
        /// <summary>
        /// Value of the attribute where the point is mapped
        /// </summary>
        public IComVariant PresentValue { get; set; }
    }
}
