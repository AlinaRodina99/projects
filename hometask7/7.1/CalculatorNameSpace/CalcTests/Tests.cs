using CalculatorNameSpace;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalcTests
{
    [TestClass]
    public class Tests
    {
        [TestInitialize]
        public void Initialize()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void SumTest()
        {
            var result = calculator.Calculate("+", 6, 9);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void SubtractionTest()
        {
            var result = calculator.Calculate("-", 9, 6);
            Assert.AreEqual(-3, result);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            var result = calculator.Calculate("*", 15, 3);
            Assert.AreEqual(45, result);
        }

        [TestMethod]
        public void DivisionTest()
        {
            var result = calculator.Calculate("/", 5, 20);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void SquareTest()
        {
            var result = calculator.BinaryCalculation("^2", 9);
            Assert.AreEqual(81, result);
        }

        [TestMethod]
        public void SqrtTest()
        {
            var result = calculator.BinaryCalculation("√", 81);
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void SumZeroTest()
        {
            var result = calculator.Calculate("+", 30, 0);
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void SubtractionZeroTest()
        {
            var result = calculator.Calculate("-", 0, 30);
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void MultiplyZeroTest()
        {
            var result = calculator.Calculate("*", 30, 0);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void DivisionZeroTest()
        {
            Assert.ThrowsException<DivideByZeroException>(() => calculator.Calculate("/", 0, 60));
        }

        [TestMethod]
        public void SqrtZeroTest()
        {
            var result = calculator.BinaryCalculation("√", 0);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SquareZeroTest()
        {
            var result = calculator.BinaryCalculation("^2", 0);
            Assert.AreEqual(0, result);
        }

        public void BigNumbersTest(string operation)
        {
            double firstNumber = 45678;
            double secondNumber = 500000;
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = secondNumber + firstNumber;
                    Assert.AreEqual(545678, result);
                    break;
                case "*":
                    result = secondNumber * firstNumber;
                    Assert.AreEqual(22839000000, result);
                    break;
                case "^2":
                    result = firstNumber * firstNumber;
                    Assert.AreEqual(2086479684, result);
                    break;
            }
        }

        [TestMethod]
        public void BigNumbersTestForSum() => BigNumbersTest("+");

        [TestMethod]
        public void BigNumbersTestForMultiply() => BigNumbersTest("*");

        [TestMethod]
        public void BigNumbersTestForSquare() => BigNumbersTest("^2");

        private Calculator calculator;
    }
}
