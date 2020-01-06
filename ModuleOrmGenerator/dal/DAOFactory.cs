using ModuleOrmGenerator.dal.tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ModuleOrmGenerator.dal
{
    public class DAOFactory
    {

        private Object connection;
        
        public Object GetConnection(SqlconnectorType type)
        {
            if(connection == null)
            {
                switch (type)
                {
                    case SqlconnectorType.MYSQL:
                        ConnectionManager mysql = new ConnectionManager("127.0.0.1", "bdd_jeux", "orm", "orm");
                        connection = mysql.GetMySqlConnection();
                        break;
                    case SqlconnectorType.SQLSERVER:
                        ConnectionManager sqlserver = new ConnectionManager("(local)", "bdd_jeux");
                        connection = sqlserver.GetSqlConnection();
                        break;
                }
            }

            return connection;
        }

        public DAOTable GetDAOTable()
        {
            return new DAOTable();
        }

    }
}
