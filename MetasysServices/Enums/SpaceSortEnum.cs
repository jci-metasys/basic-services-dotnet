using System.ComponentModel;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Enumeration of possible sort types for a Space.
    /// </summary>
    public enum SpaceSortEnum : uint
    {
        /// <summary>
        /// Item Reference (ascending).
        /// </summary>
        [Description("itemReference")]
        ItemReference = 0,
        /// <summary>
        /// Item Reference (descending).
        /// </summary>
        [Description("-itemReference")]
        MinusItemReference = 1,
        /// <summary>
        /// Name (ascending).
        /// </summary>        
        [Description("name")]
        Name = 2,
        /// <summary>
        /// Name (descending).
        /// </summary>        
        [Description("-name")]
        MinusName = 3,
        /// <summary>
        /// Space of Type Room.
        /// </summary>
        [Description("3 (= Room)")]
        Room = 3


    }
}
