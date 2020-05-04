namespace FiresideCore.Modules.Databases
{
    /// <summary>
    /// Represents database request container.
    /// </summary>
    public struct DatabaseRequest
    {
        #region Private_Members

        /// <summary>
        /// Request in SQL form.
        /// </summary>
        private readonly string context;
        
        /// <summary>
        /// Amount of parameters.
        /// </summary>
        private int tableParamsAmount;

        #endregion
        
        /// <summary>
        /// Create new database request container.
        /// </summary>
        /// <param name="context">SQL request</param>
        /// <param name="tableParamsAmount">Amount of all table parameters</param>
        public DatabaseRequest(string context, int tableParamsAmount = 0)
        {
            this.context = context;
            this.tableParamsAmount = tableParamsAmount;
        }
        
        /// <summary>
        /// Get amount of parameters.
        /// </summary>
        /// <returns>Amount of parameters</returns>
        public int GetTableParamsAmount()
        {
            return tableParamsAmount;
        }

        public override string ToString()
        {
            return context;
        }
    }
}