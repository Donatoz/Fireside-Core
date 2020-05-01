using System;
using System.Collections.Generic;

namespace FiresideCore.Database
{
    /// <summary>
    /// Represents actor-level metadata.
    /// </summary>
    [Serializable]
    public class ActorData : EntityData
    {
        /// <summary>
        /// Information about all actor's default stats.
        /// </summary>
        public List<StatInfo> Stats = new List<StatInfo>();
    }
}