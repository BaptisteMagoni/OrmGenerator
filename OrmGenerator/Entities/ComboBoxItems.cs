using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmGenerator.Entities
{
    class ComboBoxItems
    {

        public string Value { get; set; }
        public object Data { get; set; }

        public ComboBoxItems(string Value, object Data)
        {
            this.Value = Value;
            this.Data = Data;
        }
    }
}
