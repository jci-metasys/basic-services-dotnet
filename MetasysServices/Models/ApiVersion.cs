namespace JohnsonControls.Metasys.BasicServices
{
    /// <summary>
    /// The supported Metasys server Api versions.
    /// </summary>
    /// <remarks>
    /// Metasys 10.0 is not supported by this software development kit. To utilize this sdk
    /// please upgrade your Metasys server to a later release.
    /// </remarks>
    public enum ApiVersion
    {
        /// <summary>
        /// Metasys 10.1
        /// </summary>
        v2,
        /// <summary>
        /// Metasys 11.x
        /// </summary>
        v3,
        /// <summary>
        /// Metasys 12.x
        /// </summary>
        v4,
        /// <summary>
        /// Metasys 13.x
        /// </summary>
        v5,
        /// <summary>
        /// Metasys 14.x
        /// </summary>
        v6
    }
}