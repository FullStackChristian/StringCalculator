using System;

namespace StringCalculator
{
    class Program
    {
        public static Calculator calc = new Calculator();
        static void Main(string[] args)
        {
            
            //Call Add method
            int result = calc.Add("//;\n1;2");
            Console.WriteLine(result);
            
        }
    }
}
