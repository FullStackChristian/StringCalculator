using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StringCalculator
{
    public class Calculator
    {
        /// <summary>
        /// String Calculator Add Method that can take in a unlimited amount of numbers 
        /// and handle custom delimiters if the string starts with //{delimiter}
        /// </summary>
        /// <param name="input"></param>
        /// <returns>all numbers added, ignoring negatives and numbers greater than 1000</returns>
        public int Add(string input)
        {
            StringParser parser = new StringParser();
            Delimiter delim = new Delimiter();
            //creating a list here so I can easily add to it rather than appending to a char array
            List<char> delimitersList = delim.AddDelimiter(input);
            List<int> negatives = new List<int>();

            //Handle case for no numbers entered
            if (input.Equals("")){ return 0; }

            //need to modify the input string and remove //;
            if (input.StartsWith("//"))
            {
                input = input.Substring(4);
            }
            //Not best practice as I am converting my list into a charArray to use the Split method on my input string
            char[] delimiters = delimitersList.ToArray();
            
            //Split string by delimiter into numbers array
            var numbers = input.Split(delimiters);
            //Handle case for multiple numbers
            int result = 0;

            foreach (string numStr in numbers)
            {
                int num = parser.ParseToInt(numStr);
                //ignore numbers greater than a thousand in the calculation
                if (num >= 1000)
                {
                    num = 0;
                }
                //collect negative numbers in a list
                else if (num < 0)
                {
                    negatives.Add(num);
                }
                result = result + num;
            }
            //concatenate all negative numbers to a readable string
            if (negatives.Count > 0)
            {
                string neg = "";
                for(int i = 0; i < negatives.Count; i++)
                {
                    //Concatinate all negative numbers
                    neg = neg + " " + negatives[i].ToString();
                }
                //Throw a custom exception for negative numbers
                throw new Exception($"negative Numbers not allowed:{neg}");
            }
            return result;

            ////-------Before Refactoring-------
            /////Split string by comma into numbers array
            //var numbers = input.Split(",");
            ////Handle case for one number entered
            //if (numbers.Length == 1)
            //{

            //    int num1 = int.Parse(numbers[0]);
            //    return num1;
            //}

            ////Handle case for 2 numbers entered
            //if (numbers.Length == 2)
            //{
            //    int num1 = int.Parse(numbers[0]);
            //    int num2 = int.Parse(numbers[1]);
            //    return num1 + num2;
            //}
            ////Handle case for x amount of numbers
            //if (numbers.Length > 1)
            //{
            //    int result = 0;
            //    foreach (string numStr in numbers)
            //    {
            //        int num = int.Parse(numStr);
            //        result = result + num;
            //    }
            //    return result;
            //}
            ////return 
            //return 404;
        }
    }
}
