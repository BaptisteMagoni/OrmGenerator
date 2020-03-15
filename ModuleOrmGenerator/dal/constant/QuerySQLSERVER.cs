using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleOrmGenerator.dal.constant
{
    class QuerySQLSERVER
    {

        public const string SELECT_COLUMNS_OF_TABLE = "SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('{0}')";

    }
}
