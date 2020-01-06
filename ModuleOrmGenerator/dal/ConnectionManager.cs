using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ModuleOrmGenerator.dal
{
    class ConnectionManager
    {

        private string m_hostname;
        private string m_database;
        private string m_user;
        private string m_password;

        public ConnectionManager(string hostname, string database, string user, string password)
        {
            this.m_hostname = hostname;
            this.m_database = database;
            this.m_user = user;
            this.m_password = password;
        }

        public ConnectionManager(string hostname, string database)
        {
            this.m_hostname = hostname;
            this.m_database = database;
        }

        public MySqlConnection GetMySqlConnection()
        {
            
            MySqlConnection c = new MySqlConnection(String.Format("server={0};database={1};uid={2};pwd={3}", m_hostname, m_database, m_user, m_password));
            c.Open();
            return c;
        }

        public SqlConnection GetSqlConnection()
        {

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder
            {
                DataSource = this.m_hostname,
                InitialCatalog = this.m_database, 
                IntegratedSecurity = true,
            };
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = scsb.ConnectionString;
            return connection;
        }

    }
}
