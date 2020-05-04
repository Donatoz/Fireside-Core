using System.Collections.Generic;
using FiresideCore.Entities.Realisations;
using FiresideCore.Modules.Databases;

namespace FiresideCore.Database.Categories
{
    /// <summary>
    /// Card database.
    /// </summary>
    public class CardDatabase : Database<CardData, int>
    {
        #region Singleton

        private static CardDatabase instance;
        
        private CardDatabase() {}
        
        /// <summary>
        /// Get global instance of the card database.
        /// </summary>
        /// <returns>Instance of card database</returns>
        public static CardDatabase GetInstance()
        {
            if(instance == null) 
                instance = new CardDatabase();
            return instance;
        }

        #endregion

        #region Private_Members
        
        /// <summary>
        /// Extern cloud card database.
        /// </summary>
        private CloudDatabaseModule cloudDatabase;

        #endregion
        
        /// <summary>
        /// Add new card to the database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if database doesn't contain data with same id, false otherwise.</returns>
        public override bool AddItem(CardData item)
        {
            if (content.Find(data => data.DataId == item.DataId) != null) return false;
            content.Add(item);
            return true;
        }

        public override CardData GetItem(int key)
        {
            return content.Find(card => card.DataId == key);
        }
    }
}