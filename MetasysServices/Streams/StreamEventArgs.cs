using System;

namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// Defines Stream event arguments.
    /// </summary>
    public class StreamEventArgs : EventArgs
    {
        /// <summary>
        /// Event value
        /// </summary>
        public StreamMessage Value;
    }
}
