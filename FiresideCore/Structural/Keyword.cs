using FiresideCore.Database;

namespace FiresideCore.Structural
{
    /// <summary>
    /// Represents keyword (card special static ability).
    /// </summary>
    public class Keyword
    {
        #region Private_Members
        
        /// <summary>
        /// Keyword metadata (immutable).
        /// </summary>
        private readonly KeywordInfo metaData;

        #endregion
        
        public Keyword(KeywordInfo metaData)
        {
            this.metaData = metaData;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Keyword)) return false;

            var k = (Keyword) obj;
            return metaData.Id == k.metaData.Id;
        }
        
        /// <summary>
        /// Get keyword base id from metadata.
        /// </summary>
        /// <returns>Meta id</returns>
        public int GetMetaId()
        {
            return metaData.Equals(default) ? -1 : metaData.Id;
        }
    }
}