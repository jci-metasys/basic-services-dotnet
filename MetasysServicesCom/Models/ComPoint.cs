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
        /// <inheritdoc />
        public string EquipmentName { get; set; }
        /// <inheritdoc />
        public string ShortName { set; get; }
        /// <inheritdoc />
        public string Label { set; get; }
        /// <inheritdoc />
        public string Category { set; get; }
        /// <inheritdoc />
        public bool IsDisplayData { set; get; }
        /// <inheritdoc />
        public string ObjectId { get; set; }
        /// <inheritdoc />
        public string AttributeUrl { get; set; }
        /// <inheritdoc />
        public string ObjectUrl { get; set; }
        /// <inheritdoc />
        public IComVariant PresentValue { get; set; }
    }
}
