using System.Collections;
using System.Collections.Generic;
using FiresideCore.Entities;

namespace FiresideCore.Structural.Zones
{
    /// <summary>
    /// Represents IEnumerable with maximum size.
    /// </summary>
    public class Zone<T> : IEnumerable<T>
    {
        #region Public_Members
        
        /// <summary>
        /// Maximum amount of items this zone can have.
        /// </summary>
        public readonly int MaxSize;

        #endregion
        
        #region Protected_Members
        
        /// <summary>
        /// All playables objects in this zone.
        /// </summary>
        protected List<T> content;

        #endregion

        #region Events
        
        /// <summary>
        /// Delegate for all content changes inside zone.
        /// </summary>
        /// <param name="item"></param>
        public delegate T ContentChanged(T item);
        
        /// <summary>
        /// Invokes when item HAS been added to the zone.
        /// </summary>
        public event ContentChanged OnItemAdded;
        
        /// <summary>
        /// Invokes when item HAS been removed from the zone.
        /// </summary>
        public event ContentChanged OnItemRemoved;
        
        #endregion

        public IEnumerator<T> GetEnumerator()
        {
            return content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}