using System;

namespace FiresideCore.Database
{
    /// <summary>
    /// Represents keyword metadata.
    /// </summary>
    [Serializable]
    public struct KeywordInfo
    {
        /// <summary>
        /// Keyword default name.
        /// </summary>
        public string Name;
        
        /// <summary>
        /// Keyword database id.
        /// </summary>
        public int Id;

        public KeywordInfo(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}