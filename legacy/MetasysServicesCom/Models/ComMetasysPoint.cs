using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM Command is a specialized structure that holds information about a Command.
    /// </summary>
    [Guid("ddf6f3a0-46de-4ec0-92b4-87cf78f0c666")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ComMetasysPoint : IComMetasysPoint
    {
        /// <inheritdoc/>
        public string EquipmentName { get; set; }

        /// <inheritdoc/>
        public string ShortName { set; get; }

        /// <inheritdoc/>
        public string Label { set; get; }

        /// <inheritdoc/>
        public string Category { set; get; }

        /// <inheritdoc/>
        public bool IsDisplayData { set; get; }

        /// <inheritdoc/>
        public string ObjectId { get; set; }

        /// <inheritdoc/>
        public string AttributeUrl { get; set; }

        /// <inheritdoc/>
        public string ObjectUrl { get; set; }

        /// <inheritdoc/>
        public IComVariant PresentValue { get; set; }
    }
}
