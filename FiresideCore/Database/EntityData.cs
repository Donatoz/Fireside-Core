using System;

namespace FiresideCore.Database
{
    /// <summary>
    /// Represents entity-level metadata.
    /// </summary>
    [Serializable]
    public class EntityData
    {
        /// <summary>
        /// Default entity name.
        /// </summary>
        public string Name;
        /// <summary>
        /// Data unique id in database.
        /// </summary>
        public int DataId;
    }
}