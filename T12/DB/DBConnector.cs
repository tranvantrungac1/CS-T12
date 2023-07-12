using System;
using System.Data.SqlClient;

namespace T12.DB
{
    public class DBConnector
    {

        public string Database { get; set; }
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public DBConnector()
        {
            Server = "172.20.10.2";
            Database = "T11";
            User = "sa";
            Password = "123123";
        }

        public DBConnector(string database, string server, string user, string password)
        {
            Database = database;
            Server = server;
            User = user;
            Password = password;
        }

        public SqlConnection GetConnection()
        {
            string connStr = BuildConnectionString();
            return new SqlConnection(connStr);
        }

        private string BuildConnectionString()
        {
            return string.Format("Data Source={0},1433;Initial Catalog={1};User Id={2};Password={3}",
                Server, Database, User, Password);
        }
    }
}

