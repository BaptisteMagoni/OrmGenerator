using ModuleOrmGenerator.Class;
using ModuleOrmGenerator.dal.tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ModuleOrmGenerator.dal
{
    public class DAOFactory
    {

        public ConnectionString DataConnection { get; set; }
        public Boolean AuthentificationWidnows { get; set; }

        private Object connection;
        
        public Object GetConnection(SqlconnectorType type)
        {
            if(connection == null)
            {
                switch (type)
                {
                    case SqlconnectorType.MYSQL:
                        ConnectionManager mysql = new ConnectionManager(DataConnection.Address, DataConnection.Database, DataConnection.Username, DataConnection.Password);
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
