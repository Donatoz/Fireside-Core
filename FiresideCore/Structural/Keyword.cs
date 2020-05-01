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
        /// Keyword metadata.
        /// </summary>
        private KeywordInfo metaData;

        #endregion

        public Keyword(KeywordInfo metaData)
        {
            this.metaData = metaData;
        }
    }
}