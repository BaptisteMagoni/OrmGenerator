using ModuleOrmGenerator.dal.interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
                        MySqlConnection conn = (MySqlConnection)connector;
                        conn.Open();
                        break;
                    case SqlconnectorType.SQLSERVER:
                        break;
                }
            }
            catch(Exception e)
            {

            }

            return tables;
        }
    }
}
