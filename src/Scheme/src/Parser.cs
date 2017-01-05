using System.Collections.Generic;
using Scheme.Storage;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Scheme
{
    internal class Parser
    {
        private Queue<string> tokens = new Queue<string>();

        public IEnumerable<Object> Parse(string source)
        {
            Debug.Assert(tokens.Count == 0);
            tokens = new Queue<string>(Tokenize(source));
            var topLevelList = Read();
            return topLevelList.GetListItems();
        }

        private string[] Tokenize(string source)
        {
            var openParens = new Regex(@"\(");
            var closeParens = new Regex(@"\)");
            var multispaces = new Regex(@"\s+");
            string temp = source;
            temp = openParens.Replace(temp, " ( ");
            temp = closeParens.Replace(temp, " ) ");
            temp = temp.Trim();
            return multispaces.Split(temp);
        }

        private ConsCell Read()
        {
            if (tokens.Count == 0)
                return ConsCell.Nil;
            var token = tokens.Dequeue();
            Object car, cdr;
            if (token == "(")
            {
                car = Read();
                cdr = Read();
                return new ConsCell(car, cdr);
            }
            if (token == ")")
                return ConsCell.Nil;

            car = Atom.Parse(token);
            cdr = Read();
            return new ConsCell(car, cdr);
        }
    }
}