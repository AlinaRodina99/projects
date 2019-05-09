using NUnit.Framework;
using CalculatorNameSpace;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void SumTest()
        {
            var result = calculator.Calculate("+", 6, 9);
            Assert.AreEqual(15, result);
        }

        [Test]
        public void SubtractionTest()
        {
            var result = calculator.Calculate("-", 9, 6);
            Assert.AreEqual(-3, result);
        }

        [Test]
        public void MultiplyTest()
        {
            var result = calculator.Calculate("*", 15, 3);
            Assert.AreEqual(45, result);
        }

        [Test]
        public void DivisionTest()
        {
            var result = calculator.Calculate("/", 5, 20);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void SquareTest()
        {
            var result = calculator.BinaryCalculation("^2", 9);
            Assert.AreEqual(81, result);
        }

        [Test]
        public void SqrtTest()
        {
            var result = calculator.BinaryCalculation("√", 81);
            Assert.AreEqual(9, result);
        }

        [Test]
        public void SumZeroTest()
        {
            var result = calculator.Calculate("+", 30, 0);
            Assert.AreEqual(30, result);
        }

        [Test]
        public void SubtractionZeroTest()
        {
            var result = calculator.Calculate("-", 0, 30);
            Assert.AreEqual(30, result);
        }

        [Test]
        public void MultiplyZeroTest()
        {
            var result = calculator.Calculate("*", 30, 0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void DivisionZeroTest()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Calculate("/", 0, 60));
        }

        [Test]
        public void SqrtZeroTest()
        {
            var result = calculator.BinaryCalculation("√", 0);
            Assert.AreEqual(0, result);
        }

        [Test]
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

        [Test]
        public void BigNumbersTestForSum() => BigNumbersTest("+");

        [Test]
        public void BigNumbersTestForMultiply() => BigNumbersTest("*");

        [Test]
        public void BigNumbersTestForSquare() => BigNumbersTest("^2");

        private Calculator calculator;
    }
}