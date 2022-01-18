using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public  class Delimiter
    {
        public  List<char> AddDelimiter(string input)
        {
            List<char> delimitersList = new List<char>();
            delimitersList.Add(',');
            delimitersList.Add('\n');
            if (input.StartsWith("//"))
            {
                string customDelim = input.Substring(2, 1);
                char charDelim = char.Parse(customDelim);
                delimitersList.Add(charDelim);
                return delimitersList;
            }
            return delimitersList;
        }
    }
}
