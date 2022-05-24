using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Enumeration of possible types for a Space.
    /// </summary>
    public enum SpaceTypeEnum
    {
        /// <summary>
        /// Space of Type Generic.
        /// </summary>
        [Description("0 (= Generic)")]
        Generic = 0,
        /// <summary>
        /// Space of Type Building.
        /// </summary>
        [Description("1 (= Building)")]
        Building = 1,
        /// <summary>
        /// Space of Type Floor.
        /// </summary>        
        [Description("2 (= Floor)")]
        Floor = 2,
        /// <summary>
        /// Space of Type Room.
        /// </summary>
        [Description("3 (= Room)")]
        Room = 3
    }
}
