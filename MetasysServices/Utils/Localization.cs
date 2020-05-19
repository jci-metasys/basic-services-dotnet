using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Resources;


namespace JohnsonControls.Metasys.BasicServices.Utils
{
    /// <summary>
    /// Utility that allows to localize strings.
    /// </summary>
    public static class Localization
    {
        /// <summary>Resource Manager to provide localized translations.</summary>
        static ResourceManager Resource = new ResourceManager("JohnsonControls.Metasys.BasicServices.Resources.MetasysResources", typeof(MetasysClient).Assembly);

        private static CultureInfo CultureEnUS = new CultureInfo(1033);

        /// <summary>
        /// Localizes the specified resource key for the current MetasysClient locale or specified culture.
        /// </summary>
        /// <remarks>
        /// The resource parameter must be the key of a Metasys enumeration resource,
        /// otherwise no translation will be found.
        /// </remarks>
        /// <param name="resource">The key for the localization resource.</param>
        /// <param name="cultureInfo">Optional culture specification.</param>
        /// <returns>
        /// Localized string if the resource was found, the default en-US localized string if not found,
        /// or the resource parameter value if neither resource is found.
        /// </returns>
        public static string Localize(string resource, CultureInfo cultureInfo = null)
        {
            try
            {
                return Resource.GetString(resource, cultureInfo);
            }
            catch (MissingManifestResourceException)
            {
                try
                {
                    // Fallback to en-US language if no resource found. 
                    return Resource.GetString(resource, CultureEnUS);
                }
                catch (MissingManifestResourceException)
                {
                    // Just return resource placeholder when no translation found. 
                    return resource;
                }
            }
        }

    }
}
