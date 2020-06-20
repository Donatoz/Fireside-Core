using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FiresideCore.Entities;
using MySql.Data.MySqlClient;

namespace FiresideCore.Modules.Databases
{
    public abstract class CloudDatabaseModule : Module
    {
        #region Private_Members

        /// <summary>
        /// Easy-to-use default requests
        /// </summary>
        private Dictionary<string, DatabaseRequest> defaultRequests = new Dictionary<string, DatabaseRequest>();

        #endregion

        #region Protected_Members
        
        /// <summary>
        /// Connection request;
        /// </summary>
        protected string connectionRequest = "server=localhost:3306;user=root;database=fireside_cards;password=root";
        
        #endregion
        
        /// <summary>
        /// Setup database connection request.
        /// </summary>
        /// <param name="server">Server address</param>
        /// <param name="user">Username</param>
        /// <param name="pass">Password</param>
        /// <param name="dbName">Database name</param>
        public void SetupConnection(string server, string user, string pass, string dbName)
        {
            connectionRequest = $"server={server};user={user};database={dbName};password={pass}";
        }

        /// <summary>
        /// Add/replace default request.
        /// </summary>
        /// <param name="keyword">Request keyword</param>
        /// <param name="request">Request holder</param>
        internal void AddDefaultRequest(string keyword, DatabaseRequest request)
        {
            defaultRequests[keyword] = request;
        }
        
        /// <summary>
        /// Make asynchronous request to the database.
        /// </summary>
        /// <param name="databaseRequest"></param>
        public async Task<string> MakeRequest(DatabaseRequest databaseRequest)
        {
            return await Task.Factory.StartNew(() => Request(databaseRequest));
        }
        
        /// <summary>
        /// Connect to database using connection request.
        /// </summary>
        /// <param name="databaseRequest">SQL request</param>
        private string Request(DatabaseRequest databaseRequest)
        {
            
            var connection = new MySqlConnection(connectionRequest);
            connection.Open();
            var result = string.Empty;
            var parameters = Math.Clamp(databaseRequest.GetTableParamsAmount(), 0, int.MaxValue);
            
            var cmd = new MySqlCommand(databaseRequest.ToString(), connection);
            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows) return result;
                while (reader.Read())
                {
                    for (int i = 0; i < parameters; i++)
                    {
                        try
                        {
                            result += reader[i];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            break;
                        }
                    }
                }
            }
            connection.Close();
            return result;
        }

        protected CloudDatabaseModule(Entity attachedEntity) : base(attachedEntity)
        {
        }
    }
}