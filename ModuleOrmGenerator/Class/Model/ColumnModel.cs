using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleOrmGenerator.Class.Model
{
    public class ColumnModel
    {

        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public string Catalog { get; set; }
        public bool IsNullable { get; set; }

    }
}
