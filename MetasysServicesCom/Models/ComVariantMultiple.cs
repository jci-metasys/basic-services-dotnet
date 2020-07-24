using System;
using System.Runtime.InteropServices;

namespace JohnsonControls.Metasys.ComServices
{
    /// <summary>
    /// A specialized COM structure for grouping Variant values with the same id.
    /// </summary>    
    [Guid("4e6ce75b-8495-442a-ad97-85721e2ab876")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]   
    public class ComVariantMultiple:IComVariantMultiple
    {
        // Note: in order to correctly work with VBA registered types, class need to implement a defined interface. Neither inheritance nor encapsulation will work when the defined class is in another assembly.

        /// <inheritdoc/>
        public string Id { set; get; }

        /// <inheritdoc/>
        public object Values { set; get; }
    }
}
