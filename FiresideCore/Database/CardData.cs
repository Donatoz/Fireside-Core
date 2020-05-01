using System;
using System.Collections.Generic;

namespace FiresideCore.Database
{
    /// <summary>
    /// Represents card-level metadata.
    /// </summary>
    [Serializable]
    public class CardData : ActorData
    {
        /// <summary>
        /// Information about all card's default keywords.
        /// </summary>
        public List<KeywordInfo> Keywords = new List<KeywordInfo>();
    }
}