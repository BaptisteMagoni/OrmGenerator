using ModuleOrmGenerator.Class.Model;
using ModuleOrmGenerator.dal.constant;
using ModuleOrmGenerator.dal.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ModuleOrmGenerator.dal.tables
{
    public class DAOTable
    {
        public DAOTable() { }

        public List<ColumnModel> GetColumnsByTableName(SqlconnectorType type, Object connector, string databaseName, string tableName)
        {
            List<ColumnModel> tables = new List<ColumnModel>();

            try
            {
                switch (type)
                {
                    case SqlconnectorType.MYSQL:
                        using (MySqlConnection conn = (MySqlConnection)connector)
                        {
                            conn.Open();
                            MySqlCommand command = new MySqlCommand(string.Format(QueryMYSQL.SELECT_COLUMNS_OF_TABLE, databaseName, tableName), conn);
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    tables.Add(new ColumnModel()
                                    {
                                        Name = reader.GetString("column_name"),
                                        Catalog = reader.GetString("table_catalog"),
                                        IsNullable = reader.GetString("is_nullable") == "NO" ? false : true,
                                        Size = reader.GetInt32("character_maximum_length"),
                                        Type = reader.GetString("data_type")
                                    });
                                }
                            }
                            conn.Close();
                        }
                        break;
                    case SqlconnectorType.SQLSERVER:
                        using (SqlConnection conn = (SqlConnection)connector)
                        {
                            SqlCommand command = new SqlCommand(String.Format(QuerySQLSERVER.SELECT_COLUMNS_OF_TABLE, "Employees"), conn);
                            command.Connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    for (int i = 0; i < reader.FieldCount; i++)
                                        tables.Add(null);
                            }
                            conn.Close();
                        }
                        break;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return tables;
        }

        public List<string> GetTableOfDatabase(SqlconnectorType type, object connector, string databaseName)
        {
            List<string> tables = new List<string>();

            try
            {
                switch (type)
                {
                    case SqlconnectorType.MYSQL:
                        using (MySqlConnection conn = (MySqlConnection)connector)
                        {
                            conn.Open();
                            MySqlCommand command = new MySqlCommand(string.Format(QueryMYSQL.SELECT_TABLE_OF_DATABASE, databaseName), conn);
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    tables.Add(reader.GetString("Tables_in_" + databaseName));
                            }
                            conn.Close();
                        }
                        break;
                    case SqlconnectorType.SQLSERVER:
                        using (SqlConnection conn = (SqlConnection)connector)
                        {
                            SqlCommand command = new SqlCommand(String.Format(QuerySQLSERVER.SELECT_COLUMNS_OF_TABLE, "Employees"), conn);
                            command.Connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    for (int i = 0; i < reader.FieldCount; i++)
                                        tables.Add(reader.GetValue(i).ToString());
                            }
                            conn.Close();
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return tables;
        }

        public List<string> GetAllDataBase(SqlconnectorType type, Object connector)
        {
            List<string> databases = new List<string>();

            switch (type)
            {
                case SqlconnectorType.MYSQL:
                    using (MySqlConnection conn = (MySqlConnection)connector)
                    {
                        conn.Open();
                        MySqlCommand command = new MySqlCommand(QueryMYSQL.SELECT_ALL_DATABASE, conn);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                databases.Add(reader.GetString("Database"));
                        }
                        conn.Close();
                    }
                    break;
                case SqlconnectorType.SQLSERVER:
                    break;
            }

            return databases;
        }
    }
}
