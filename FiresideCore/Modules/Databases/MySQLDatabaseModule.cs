using MySql.Data;

namespace FiresideCore.Modules.Databases
{
    public class MySQLDatabaseModule : CloudDatabaseModule
    {
        public MySQLDatabaseModule()
        {
            AddDefaultRequest(
                "Test", 
                new DatabaseRequest("SELECT name FROM cards", 4)
            );
        }
    }
}