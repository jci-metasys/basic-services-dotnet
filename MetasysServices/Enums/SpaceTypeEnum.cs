using System;
using System.Collections.Generic;
using System.Text;

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
        Generic=0,
        /// <summary>
        /// Space of Type Building.
        /// </summary>
        Building=1,
        /// <summary>
        /// Space of Type Floor.
        /// </summary>        
        Floor=2,
        /// <summary>
        /// Space of Type Room.
        /// </summary>
        Room=3
    }
}
