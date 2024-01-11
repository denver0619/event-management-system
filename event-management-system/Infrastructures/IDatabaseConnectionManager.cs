using MySql.Data.MySqlClient;

namespace event_management_system.Infrastructures
{
    public interface IDatabaseConnectionManager
    {
        public string ConnectionString { get; set; }
        public MySqlConnection Connection { get; set; }

        public void OpenConnection();
        public void CloseConnection(IDatabaseConnectionManager dbManager);
    }
}
