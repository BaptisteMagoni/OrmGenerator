using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleOrmGenerator.dal.constant
{
    class QueryMYSQL
    {
        public const string SELECT_COLUMNS_OF_TABLE = "SELECT column_name FROM information_schema.columns WHERE table_schema = 'bdd_jeux' AND table_name = 'games';";
    }
}
