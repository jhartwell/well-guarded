using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole.Types
{
    public class Chars : IType
    {
        string value;

        public Chars(string val)
        {
            value = val;
        }

        public object GetValue()
        {
            return value;
        }
    }
}
