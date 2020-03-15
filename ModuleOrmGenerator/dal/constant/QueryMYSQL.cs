using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleOrmGenerator.dal.constant
{
    class QueryMYSQL
    {
        public const string SELECT_COLUMNS_OF_TABLE = "SELECT column_name FROM information_schema.columns WHERE table_schema = '{0}' AND table_name = '{1}';";
        public const string SELECT_TABLE_OF_DATABASE = "use {0}; show tables;";
        public const string SELECT_ALL_DATABASE = "SHOW DATABASES";
    }
}
