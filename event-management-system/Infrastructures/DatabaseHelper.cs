using MySql.Data.MySqlClient;
using event_management_system.Configurations;
using System.Data;
using System.Reflection;
using System.Diagnostics;

namespace event_management_system.Infrastructures
{public class DatabaseHelper<Entity> : IDisposable
    {
        private IDatabaseConnectionManager _connectionManager;
        private MySqlConnection _connection;

        public DatabaseHelper()
        {
            Configuration.MySQL.ConnectionString = "server=localhost;port=3307;user=root;database=eventmanagementdb;password=;Convert Zero Datetime=True;"; //Temporary
            _connectionManager = new DatabaseConnectionManager(Configuration.MySQL.ConnectionString);
            _connection = _connectionManager.Connection;
        }

        public void InsertRecord(string tableName, Entity entity)
        {
            _connection.Open();
            string querytype = "INSERT INTO ";
            string fields = this.GetInsertFields(tableName, entity);
            string recordValues = " VALUES ";
            List<string> values = this.GetInsertValues(tableName, new List<Entity> { entity });
            string terminator = ";";
            foreach (string value in values)
            {
                recordValues += value + " ";
            }
            string query = querytype + tableName + " " + fields + recordValues + terminator;
            
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void InsertRecordEvent(string query)
        {
            _connection.Open();
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void InsertRecordWithParam(string tableName, Entity entity, MySqlParameter mySqlParameter)
        {
            _connection.Open();
            string querytype = "INSERT INTO ";
            string fields = this.GetInsertFields(tableName, entity);
            string recordValues = " VALUES ";
            List<string> values = this.GetInsertValuesWithParam(tableName, new List<Entity> { entity }, mySqlParameter);
            string terminator = ";";
            foreach (string value in values)
            {
                recordValues += value + " ";
            }
            string query = querytype + tableName + " " + fields + recordValues + terminator;
        
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.Add(mySqlParameter);           
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public DataTable SelectRecord(string tableName, string constraints)
        {
            _connection.Open();
            DataTable dataTable = new DataTable();
            string queryType = "SELECT * FROM ";
            string whereClause = " WHERE ";
            string terminator = ";";
            string query = queryType + tableName + whereClause + constraints + terminator;
            
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);
            _connection.Close();
            return dataTable;
        }
        public DataTable SelectAllRecord(string tableName)
        {
            _connection.Open();
            DataTable dataTable = new DataTable();
            string queryType = "SELECT * FROM ";
            string terminator = ";";
            string query = queryType + tableName + terminator;

            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);
            _connection.Close();
            return dataTable;
        }
        public DataTable SelectAllRecordWith(string tableName, string constraints)
        {
            _connection.Open();
            DataTable dataTable = new DataTable();
            string queryType = "SELECT * FROM ";
            string whereClause = " WHERE ";
            string terminator = ";";
            string query = queryType + tableName + whereClause + constraints + terminator;
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);
            _connection.Close();
            return dataTable;
        }

        public void UpdateRecord(string tableName, Entity entity)
        {
            _connection.Open();
            string queryType = "UPDATE ";
            string setValues = " SET ";
            string values = this.ConvertUpdateValuesToString(entity);
            string whereClause = " WHERE ";
            string constraints = this.GetIDConstraint(tableName, entity);
            string terminator = ";";
            string query = queryType + tableName + setValues + values + whereClause + constraints + terminator;

            MySqlCommand command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void UpdateRecordWithConstraint(string tableName, Entity entity, string constraints)
        {
            _connection.Open();
            string queryType = "UPDATE ";
            string setValues = " SET ";
            string values = this.ConvertUpdateValuesToString(entity);
            string whereClause = " WHERE ";
            /*string constraints = this.GetIDConstraint(tableName, entity);*/
            string terminator = ";";
            string query = queryType + tableName + setValues + values + whereClause + constraints + terminator;

            MySqlCommand command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void UpdateRecordWithParam(string tableName, Entity entity, MySqlParameter parameter)
        {
            _connection.Open();
            string queryType = "UPDATE ";
            string setValues = " SET ";
            string values = this.ConvertUpdateValuesToStringWithParam(entity, parameter);
            string whereClause = " WHERE ";
            string constraints = this.GetIDConstraint(tableName, entity);
            string terminator = ";";
            string query = queryType + tableName + setValues + values + whereClause + constraints + terminator;

            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.Add(parameter);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void DeleteRecord(string tableName, string constraints)
        {
            _connection.Open();
            string queryType = "DELETE FROM ";
            string whereClaues = " WHERE ";
            string query = queryType + tableName + whereClaues + constraints;

            MySqlCommand command = new MySqlCommand(query, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public string ConvertUpdateValuesToString(Entity entity)
        {
            Type type = entity!.GetType();
            List<string> output = new List<string>();
            List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(string) && !(property.Name.EndsWith("ID")))
                {
                    output.Add(property.Name + " = \'" + property.GetValue(entity) + "\'");
                }
                else if (property.Name.Contains("Date"))
                {
                    DateTime date = (DateTime)property.GetValue(entity)!;
                    output.Add(property.Name + " = \'" + date.ToString("yyyy-MM-dd hh:mm:ss ") + date.ToString("tt").ToUpper() + "\'");
                }
                else
                {
                    output.Add(property.Name + " = " + property.GetValue(entity));
                }
            }
            return String.Join(",", output);
        }
        public string ConvertUpdateValuesToStringWithParam(Entity entity, MySqlParameter mySqlParameter)
        {
            Type type = entity!.GetType();
            List<string> output = new List<string>();
            List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
            foreach (PropertyInfo property in properties)
            {
                if (mySqlParameter.ParameterName.Contains(property.Name))
                {
                    output.Add(property.Name + " = " + mySqlParameter.ParameterName);
                    continue;
                }
                if (property.PropertyType == typeof(string) && !(property.Name.EndsWith("ID")))
                {
                    output.Add(property.Name + " = \'" + property.GetValue(entity) + "\'");
                }
                else
                {
                    output.Add(property.Name + " = " + property.GetValue(entity));
                }
            }
            return String.Join(",", output);
        }

        public string GetIDConstraint (string tableName, Entity entity)
        {
            string output = "";
            Type type = entity!.GetType();
            List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name.EndsWith("ID") && property.Name.Contains(tableName.Substring(1, tableName.Length - 2)))
                {
                    output = property.Name + " = " + property.GetValue(entity);
                }
            }
            return output;
        }

        public string GetInsertFields(string tableName, Entity entity)
        {
            Type type = entity!.GetType();
            List<string> fields = new List<string>(); 
            List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name.EndsWith("ID") && property.Name.ToLower().Contains(tableName.Substring(1, tableName.Length - 2))) continue;
                fields.Add(property.Name);
            }
            return "(" + String.Join(",", fields) + ")";
        }


        public List<string> GetInsertValues(String tableName, List<Entity> entities)
        {
            List<string> values = new List<string>();
            foreach (Entity? entity in entities)
            {
                if (entity != null)
                {
                    Type type = entity.GetType();
                    List<string> currentEntityValue = new List<string>();
                    List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
                    foreach (PropertyInfo property in properties)
                    {
                        object? value = property.GetValue(entity);
                        if (property.Name.EndsWith("ID") && property.Name.ToLower().Contains(tableName.Substring(1, tableName.Length - 2))) continue;
                        if (value != null)
                        {
                            if ((property.PropertyType == typeof(string) && !property.Name.EndsWith("ID")))
                            {
                                currentEntityValue.Add("\'"+value.ToString()!+ "\'");
                            }
                            else if ( property.Name.Contains("Date"))
                            {
                                DateTime date = (DateTime)value;
                                currentEntityValue.Add("\'"+ date.ToString("yyyy-MM-dd hh:mm:ss ") + date.ToString("tt").ToUpper() + "\'");
                            }
                            else
                            {
                                currentEntityValue.Add(value.ToString()!);
                            }
                        }
                        else
                        {
                            currentEntityValue.Add("NULL");
                        }
                    }
                    values.Add("(" + string.Join(",", currentEntityValue) + ")");
                }
            }
            return values;
        }

        public List<string> GetInsertValuesWithParam(String tableName, List<Entity> entities, MySqlParameter mySqlParameter)
        {
            List<string> values = new List<string>();
            foreach (Entity? entity in entities)
            {
                if (entity != null)
                {
                    Type type = entity.GetType();
                    List<string> currentEntityValue = new List<string>();
                    List<PropertyInfo> properties = type.GetProperties().OrderBy(property => property.Name).ToList();
                    foreach (PropertyInfo property in properties)
                    {
                        object? value = property.GetValue(entity);
                        if (property.Name.EndsWith("ID") && property.Name.ToLower().Contains(tableName.Substring(1, tableName.Length - 2))) continue;
                        if (mySqlParameter.ParameterName.Contains(property.Name))
                        {
                            currentEntityValue.Add(mySqlParameter.ParameterName);
                            continue;
                        }
                        if (value != null)
                        {
                            if ((property.PropertyType == typeof(string) && !property.Name.EndsWith("ID")))
                            {
                                currentEntityValue.Add("\'" + value.ToString()! + "\'");
                            }
                            else if (property.Name.Contains("Date"))
                            {
                                DateTime date = (DateTime)value;
                                currentEntityValue.Add("\'" + date.ToString("yyyy-MM-dd hh:mm:ss ") + date.ToString("tt").ToUpper() + "\'");
                            }
                            else
                            {
                                currentEntityValue.Add(value.ToString()!);
                            }
                        }
                        else
                        {
                            currentEntityValue.Add("NULL");
                        }
                    }
                    values.Add("(" + string.Join(",", currentEntityValue) + ")");
                }
            }
            return values;
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }
    }
}
