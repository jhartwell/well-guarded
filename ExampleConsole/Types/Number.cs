using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole.Types
{
    public class Number : IType
    {
        int value;

        public Number(int value)
        {
            this.value = value;
        }


        public object GetValue()
        {
            return value;
        }
    }
}
