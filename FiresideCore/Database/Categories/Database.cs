using System.Collections.Generic;
using FiresideCore.Entities;
using FiresideCore.Modules.Databases;

namespace FiresideCore.Database.Categories
{
    /// <summary>
    /// Represents database with it's own content and option to get item by specific key.
    /// It is not necessary to use this variant of database implementation (for example, in Unity).
    /// </summary>
    /// <typeparam name="TContent">Content type (which type this database items have)</typeparam>
    /// <typeparam name="TKey">Key type (which type has key for searching specific items)</typeparam>
    public abstract class Database<TContent, TKey> where TContent : EntityData
    {
        #region Protected_Members

        /// <summary>
        /// All items in this database are stored here.
        /// </summary>
        protected List<TContent> content;
        
        /// <summary>
        /// Extern cloud card database.
        /// </summary>
        protected CloudDatabaseModule cloudDatabase;

        #endregion

        protected Database()
        {
            content = new List<TContent>();
        }

        /// <summary>
        /// Get specific item by key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract TContent GetItem(TKey key);
        
        /// <summary>
        /// Add new item to the database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Always true</returns>
        public virtual bool AddItem(TContent item)
        {
            content.Add(item);
            return true;
        }
        
        public virtual TContent CloudRequest()
        {
            return default;
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
        internal void Initialize(params TContent[] items)
        {
            content.AddRange(items);
        }
    }
}