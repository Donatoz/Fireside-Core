using System;

namespace FiresideCore.Database
{
    /// <summary>
    /// Represents stat metadata.
    /// </summary>
    [Serializable]
    public struct StatInfo
    {
        /// <summary>
        /// Stat default name.
        /// </summary>
        public string Name;
        /// <summary>
        /// Stat default value.
        /// </summary>
        public int Value;

        public StatInfo(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}