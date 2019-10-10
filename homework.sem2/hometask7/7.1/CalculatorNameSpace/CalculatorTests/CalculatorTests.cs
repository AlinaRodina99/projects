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
            box = new BoxOfExpressing();
        }

        [Test]
        public void SumTest()
        {
            var result = Calculator.Calculate("+", 6, 9);
            Assert.AreEqual(15, result);
        }

        [Test]
        public void SubtractionTest()
        {
            var result = Calculator.Calculate("-", 9, 6);
            Assert.AreEqual(-3, result);
        }

        [Test]
        public void MultiplyTest()
        {
            var result = Calculator.Calculate("*", 15, 3);
            Assert.AreEqual(45, result);
        }

        [Test]
        public void DivisionTest()
        {
            var result = Calculator.Calculate("/", 5, 20);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void SquareTest()
        {
            var result = Calculator.BinaryCalculation("^2", 9);
            Assert.AreEqual(81, result);
        }

        [Test]
        public void SqrtTest()
        {
            var result = Calculator.BinaryCalculation("√", 81);
            Assert.AreEqual(9, result);
        }

        [Test]
        public void SumZeroTest()
        {
            var result = Calculator.Calculate("+", 30, 0);
            Assert.AreEqual(30, result);
        }

        [Test]
        public void SubtractionZeroTest()
        {
            var result = Calculator.Calculate("-", 0, 30);
            Assert.AreEqual(30, result);
        }

        [Test]
        public void MultiplyZeroTest()
        {
            var result = Calculator.Calculate("*", 30, 0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void DivisionZeroTest()
        {
            Assert.Throws<DivideByZeroException>(() => Calculator.Calculate("/", 0, 60));
        }

        [Test]
        public void SqrtZeroTest()
        {
            var result = Calculator.BinaryCalculation("√", 0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void SquareZeroTest()
        {
            var result = Calculator.BinaryCalculation("^2", 0);
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

        [Test]
        public void ReadDigitTest()
        {
            box.ReadDigit("77");
            Assert.AreEqual("77", box.ExpressionBox);
            Assert.AreEqual("77", box.CurrentExpressionBox);
        }

        [Test]
        public void ReadOperationTest()
        {
            box.ReadDigit("66");
            box.ReadOperation("+");
            Assert.AreEqual("66", box.ExpressionBox);
            Assert.AreEqual("66+", box.CurrentExpressionBox);
        }

        [Test]
        public void ReadPointTest()
        {
            box.ReadDigit("12");
            box.ReadPoint();
            Assert.AreEqual("12,", box.ExpressionBox);
            Assert.AreEqual("12,", box.CurrentExpressionBox);
        }

        [Test]
        public void ReadCalculateSignAfterPlusTest()
        {
            box.ReadDigit("12");
            box.ReadOperation("+");
            box.ReadDigit("2");
            box.ReadCalculateSign();
            Assert.AreEqual("14", box.ExpressionBox);
            Assert.AreEqual("14", box.CurrentExpressionBox);
        }

        [Test]
        public void ReadCalculateSignAfterMinusTest()
        {
            box.ReadDigit("12");
            box.ReadOperation("-");
            box.ReadDigit("2");
            box.ReadCalculateSign();
            Assert.AreEqual("10", box.ExpressionBox);
            Assert.AreEqual("10", box.CurrentExpressionBox);
        }

        [Test]
        public void ReadCalculateSignAfterMultiplyTest()
        {
            box.ReadDigit("12");
            box.ReadOperation("*");
            box.ReadDigit("2");
            box.ReadCalculateSign();
            Assert.AreEqual("24", box.ExpressionBox);
            Assert.AreEqual("24", box.CurrentExpressionBox);
        }

        [Test]
        public void ReadCalculateSignAfterDivideTest()
        {
            box.ReadDigit("12");
            box.ReadOperation("/");
            box.ReadDigit("2");
            box.ReadCalculateSign();
            Assert.AreEqual("6", box.ExpressionBox);
            Assert.AreEqual("6", box.CurrentExpressionBox);
        }

        [Test]
        public void ReadSquareTest()
        {
            box.ReadDigit("3");
            box.ReadOperation("^2");
            Assert.AreEqual("9", box.ExpressionBox);
            Assert.AreEqual("9", box.CurrentExpressionBox);
        }

        [Test]
        public void ReadSqrtTest()
        {
            box.ReadDigit("36");
            box.ReadOperation("√");
            Assert.AreEqual("6", box.ExpressionBox);
            Assert.AreEqual("6", box.CurrentExpressionBox);
        }

        [Test]
        public void TwoTimesPointReadTest()
        {
            box.ReadDigit("45");
            box.ReadPoint();
            box.ReadPoint();
            Assert.AreEqual("45,", box.ExpressionBox);
            Assert.AreEqual("45,", box.CurrentExpressionBox);
        }

        [Test]
        public void TwoTimesOperationReadTest()
        {
            box.ReadDigit("45");
            box.ReadOperation("+");
            box.ReadOperation("+");
            Assert.AreEqual("45", box.ExpressionBox);
            Assert.AreEqual("45+", box.CurrentExpressionBox);
        }

        [Test]
        public void ZeroDivisionTest()
        {
            box.ReadDigit("45");
            box.ReadOperation("/");
            box.ReadDigit("0");
            box.ReadCalculateSign();
            Assert.AreEqual("∞", box.ExpressionBox);
            Assert.AreEqual("You can not divide number by zero! Click c to clear", box.CurrentExpressionBox);
        }

        private BoxOfExpressing box;
    }
}