using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FiresideCore.Entities;

namespace FiresideCore.Structural.Zones
{
    /// <summary>
    /// Represents IEnumerable with maximum size.
    /// </summary>
    public class Zone<T> : IEnumerable<T>, IZoneAdapter<T> where T : Entity
    {
        #region Public_Members
        
        /// <summary>
        /// Maximum amount of items this zone can have.
        /// </summary>
        public int MaxSize;

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
        public delegate void ContentChanged(T item);
        
        /// <summary>
        /// Invokes when item HAS been added to the zone.
        /// </summary>
        public event ContentChanged OnItemAdded;
        
        /// <summary>
        /// Invokes when item HAS been removed from the zone.
        /// </summary>
        public event ContentChanged OnItemRemoved;
        
        #endregion

        public Zone(params T[] startContent)
        {
            content = new List<T>();
            foreach (var item in startContent)
            {
                Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (content.Contains(item) || content.Count >= MaxSize) return;
            content.Add(item);
            OnItemAdded?.Invoke(item);
        }

        public void Remove(T item)
        {
            if (!content.Contains(item)) return;
            content.Remove(item);
            OnItemRemoved?.Invoke(item);
        }

        public bool Contains(T item)
        {
            return content.Contains(item);
        }
        
        /// <summary>
        /// Move some entity from one zone to another.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <typeparam name="TMoveFrom"></typeparam>
        /// <typeparam name="TMoveTo"></typeparam>
        public static void Move<TMoveFrom, TMoveTo>(Entity target, Zone<TMoveFrom> from, Zone<TMoveTo> to) 
            where TMoveFrom : Entity 
            where TMoveTo : Entity
        {
            
        }
    }
}