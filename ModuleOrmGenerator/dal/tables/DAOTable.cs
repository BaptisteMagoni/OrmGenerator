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

        public List<string> ShowColumnsByTableName(SqlconnectorType type, Object connector)
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
                            MySqlCommand command = new MySqlCommand(QueryMYSQL.SELECT_COLUMNS_OF_TABLE, conn);
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    tables.Add(reader.GetString("column_name"));
                            }
                            conn.Close();
                        }
                        break;
                    case SqlconnectorType.SQLSERVER:
                        using (SqlConnection conn = (SqlConnection)connector)
                        {
                            SqlCommand command = new SqlCommand(QuerySQLSERVER.SELECT_COLUMNS_OF_TABLE, conn);
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
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return tables;
        }
    }
}
