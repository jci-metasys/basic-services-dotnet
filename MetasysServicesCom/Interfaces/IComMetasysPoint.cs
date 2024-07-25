﻿using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// COM specialized structure that holds information about a  Metasys Point.
    /// </summary>
    [Guid("eb26acd8-3928-41ad-bbc3-bb02277041ee")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComMetasysPoint
    {
        /// <summary>
        /// The name of the Equipment that contains the Point
        /// </summary>
        string EquipmentName { get; set; }

        /// <summary>The Short name of the Point.</summary>
        string ShortName { set; get; }

        /// <summary>The Label of the Point.</summary>
        string Label { set; get; }

        /// <summary>
        /// Category of the Point.
        /// </summary>
        string Category { set; get; }

        /// <summary>
        /// Flag that states when the attribute object contains data suitable to display
        /// </summary>
        bool IsDisplayData { set; get; }

        /// <summary>
        /// The ID of the object where the point is mapped
        /// </summary>
        string ObjectId { get; set; }

        /// <summary>
        /// Full URL of the attribute where the point is mapped
        /// </summary>
        string AttributeUrl { get; set; }

        /// <summary>
        /// Full URL of the object where the point is mapped
        /// </summary>
        string ObjectUrl { get; set; }

        /// <summary>
        /// Value of the attribute where the point is mapped
        /// </summary>
        IComVariant PresentValue { get; set; }
    }
}
