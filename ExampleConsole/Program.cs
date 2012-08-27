using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExampleConsole.Types;
using WellGuarded.Samples.Parsing;
using WellGuarded;

namespace ExampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IType> tokens = new List<IType>();
            Console.WriteLine("Write something to be parsed.");
            string s = Console.ReadLine();
            foreach(char c in s)
            {
                Func<bool> isInt = () => 
                {
                    return char.IsNumber(c);
                };

                Func<object> makeInt = () => 
                {
                    return new Number((int)c);
                };

                Func<bool> isChar = () =>
                {
                    return char.IsLetter(c) || char.IsWhiteSpace(c);
                };

                Func<object> makeChar = () =>
                {
                    return new Chars(c.ToString());
                };

                LanguageGuard intGuard = new LanguageGuard(isInt, makeInt);
                LanguageGuard charGuard = new LanguageGuard(isChar, makeChar);

                Guard g = intGuard | charGuard;
                if (g != null)
                {
                    tokens.Add((IType)g.Action.Invoke());
                }
            }

            tokens.ForEach(x => Console.WriteLine(string.Format("{0} - {1}",x,x.GetValue())));

            Console.ReadLine();
        }
    }
}
