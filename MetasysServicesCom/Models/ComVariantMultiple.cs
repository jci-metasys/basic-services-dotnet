﻿using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{

    /// <summary>
    /// A specialized COM structure for grouping Variant values with the same id.
    /// </summary>    
    [Guid("57946469-9f3a-46f7-a7d8-6c38a406ed4f")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]   
    public class ComVariantMultiple:IComVariantMultiple
    {
        // Note: in order to correctly work with VBA registered types, class need to implement a defined interface. Neither inheritance nor encapsulation will work when the defined class is in another assembly.

        /// <inheritdoc />
        public string Id { set; get; }

        /// <inheritdoc />
        public object Variants { set; get; }
    }
}
