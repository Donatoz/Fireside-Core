using System.Collections.Generic;

namespace FiresideCore.Database.Categories
{
    /// <summary>
    /// Represents database with it's own content and option to get item by specific key.
    /// It is not necessary to use this variant of database implementation (for example, in Unity).
    /// </summary>
    /// <typeparam name="T">Content type (which type this database items have)</typeparam>
    /// <typeparam name="K">Key type (which type has key for searching specific items)</typeparam>
    public abstract class Database<T, K>
    {
        /// <summary>
        /// All items this database has stored here.
        /// </summary>
        protected List<T> content;

        protected Database()
        {
            content = new List<T>();
        }

        /// <summary>
        /// Get specific item by key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract T GetItem(K key);
        
        /// <summary>
        /// Add new item to the database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Always true</returns>
        public virtual bool AddItem(T item)
        {
            content.Add(item);
            return true;
        }
        
        /// <summary>
        /// Get database items amount.
        /// </summary>
        /// <returns>Amount of item this database stores.</returns>
        public int GetContentSize()
        {
            return content.Count;
        }
        
        /// <summary>
        /// Put items in this database.
        /// </summary>
        /// <param name="items">Items to put</param>
        internal void Initialize(params T[] items)
        {
            content.AddRange(items);
        }
    }
}