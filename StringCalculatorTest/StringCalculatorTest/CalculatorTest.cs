using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
using System;

namespace StringCalculatorTest
{
    [TestClass]
    public class CalculatorTest
    {
        public Calculator calc = new Calculator();
        [TestMethod]
        public void TestAdd0Numbers()
        {
            int result = calc.Add("");
            Assert.AreEqual(0,result);
        }
        [TestMethod]
        public void TestAdd1Number()
        {
            string numbers = "1";
            int result = calc.Add(numbers);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void TestAdd2Numbers()
        {
            string numbers = "1,2";
            int result = calc.Add(numbers);
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void TestAddUnknownAmountOfNumbers()
        {
            string numbers = "1,2,3,4";
            int result = calc.Add(numbers);
            Assert.AreEqual(10, result);
        }
        [TestMethod]
        public void TestAddNumbersAllowingTwoDifferentDelimiters()
        {
            string numbers = "1\n2,3";
            int result = calc.Add(numbers);
            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void TestAddNumbersAllowingDifferentDelimiters()
        {
            string numbers = "//;\n3;5\n6";
            int result = calc.Add(numbers);
            Assert.AreEqual(14, result);
        }
        [TestMethod]
        public void TestAddNumbersRejectNegatives()
        {
            string numbers = "-1,-2";
            string ex = "negative Numbers not allowed: -1 -2";
            var exceptionThrown = Assert.ThrowsException<Exception>(() => calc.Add(numbers));
            Assert.AreEqual(exceptionThrown.Message, ex);
        }
        [TestMethod]
        public void TestAddNumbersDisregardNumbersGreaterThanAThousand()
        {
            string numbers = "1002,2";
            int result = calc.Add(numbers);
            Assert.AreEqual(2,result);
        }
    }
}
