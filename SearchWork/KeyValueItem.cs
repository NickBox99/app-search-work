using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWork
{
    public class KeyValueItem
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public KeyValueItem(int key, string value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
