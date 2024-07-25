using JohnsonControls.Metasys.BasicServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;

namespace JohnsonControls.Metasys.BasicServices.Utils
{
    /// <summary>
    /// Utility that helps the management of resources.
    /// </summary>
    public static class ResourceManager
    {
        /// <summary>Resource Manager to provide localized translations.</summary>
        static System.Resources.ResourceManager Resource = new System.Resources.ResourceManager("JohnsonControls.Metasys.BasicServices.Resources.MetasysResources", typeof(MetasysClient).Assembly);

        /// <summary>Dictionary to provide keys from the commandIdEnumSet.</summary>
        /// <value>Keys as en-US translations, values as the commandIdEnumSet Enumerations.</value>
        static Dictionary<string, string> CommandEnumerations;

        /// <summary>Dictionaries to provide keys from the objectTypeEnumSet since there are duplicate keys.</summary>
        /// <value>Keys as en-US translations, values as the objectTypeEnumSet Enumerations.</value>
        static List<Dictionary<string, string>> ObjectTypeEnumerations;

        /// <summary>Get the default Culture as English-US.</summary>
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

        /// <summary>
        /// Attempts to get the enumeration key of a given en-US localized command.
        /// </summary>
        /// <remarks>
        /// The resource parameter must be the value of a Metasys commandIdEnumSet en-US value,
        /// otherwise no key will be found.
        /// </remarks>
        /// <param name="resource">The en-US value for the localization resource.</param>
        /// <returns>
        /// The enumeration key of the en-US command if found, original resource if not.
        /// </returns>
        public static string GetCommandEnumeration(string resource)
        {
            if (CommandEnumerations == null)
            {
                SetEnumerationDictionaries();
            }

            if (CommandEnumerations.TryGetValue(resource, out string value))
            {
                return value;
            }
            return resource;
        }

        /// <summary>
        /// Attempts to get the enumeration key of a given en-US localized objectType.
        /// </summary>
        /// <remarks>
        /// The resource parameter must be the value of a Metasys objectTypeEnumSet en-US value,
        /// otherwise no key will be found.
        /// </remarks>
        /// <param name="resource">The en-US value for the localization resource.</param>
        /// <returns>
        /// The enumeration key of the en-US objectType if found, original resource if not.
        /// </returns>
        public static string GetObjectTypeEnumeration(string resource)
        {
            if (ObjectTypeEnumerations == null)
            {
                SetEnumerationDictionaries();
            }

            foreach (var dict in ObjectTypeEnumerations)
            {
                if (dict.TryGetValue(resource, out string value))
                {
                    return value;
                }
            }

            return resource;
        }

        /// <summary>
        /// Populates the needed enumeration Dictionaries for translating en-US strings by 
        /// transversing the en-US resource file and finding the appropriate EnumSets.
        /// </summary>
        /// <remarks>
        /// This method should be faster than using the enumSets/{id}/members api endpoint.
        /// This method has a potential for value mismatch if the local enumeration values differ 
        /// from the server. This will cause the translation functionality to fail since no matching
        /// enumeration key will be found in dictionaries.
        /// </remarks>
        private static void SetEnumerationDictionaries()
        {
            // First time setup, there are about 349 values in the command set, 800 in the objectType set
            CommandEnumerations = new Dictionary<string, string>();
            ObjectTypeEnumerations = new List<Dictionary<string, string>>();
            var ObjectTypeEnumerations1 = new Dictionary<string, string>();
            var ObjectTypeEnumerations2 = new Dictionary<string, string>();
            ResourceSet ResourcesEnUS = Resource.GetResourceSet(CultureEnUS, true, true);
            IDictionaryEnumerator ide = ResourcesEnUS.GetEnumerator();
            while (ide.MoveNext())
            {
                if (ide.Key.ToString().Contains("commandIdEnumSet."))
                {
                    CommandEnumerations.Add(ide.Value.ToString(), ide.Key.ToString());
                }
                else if (ide.Key.ToString().Contains("objectTypeEnumSet."))
                {
                    try
                    {
                        ObjectTypeEnumerations1.Add(ide.Value.ToString(), ide.Key.ToString());
                    }
                    catch
                    {
                        ObjectTypeEnumerations2.Add(ide.Value.ToString(), ide.Key.ToString());
                    }
                }
            }
            ObjectTypeEnumerations.Add(ObjectTypeEnumerations1);
            ObjectTypeEnumerations.Add(ObjectTypeEnumerations2);
        }


    }
}
