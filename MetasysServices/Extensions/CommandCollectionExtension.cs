using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// A helper to work with Command collections.
    /// </summary>
    public static class CommandCollectionExtension
    {      
        /// <summary>
        /// Returns the Command in the collection with the given ID.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="id">The Id of the Command.</param>
        /// <returns></returns>
        public static Command FindById(this IEnumerable<Command> source, string id)
        {
            var command = source.FirstOrDefault(f => f.CommandId == id);
            if (command == null)
            {
                throw new Exception($"Metasys object not found in the collection ({id}).");
            }
            return command;
        }
    }
}
