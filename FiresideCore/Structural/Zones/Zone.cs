using System.Collections.Generic;
using FiresideCore.Interfaces;

namespace FiresideCore.Structural.Zones
{
    /// <summary>
    /// Represents game zone which holds content of specific type (cards, units, etc...) and which can be modified.
    /// </summary>
    public abstract class Zone<T> where T : IPlayable
    {
        #region Protected_Members
        
        /// <summary>
        /// All playables objects in this zone.
        /// </summary>
        protected List<T> content;

        #endregion
    }
}