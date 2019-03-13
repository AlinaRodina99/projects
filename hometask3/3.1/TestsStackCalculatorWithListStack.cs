using NUnit.Framework;
using StackCalculator;
using System.Collections;

namespace Tests
{
    class TestsStackCalculatorWithListStack
    {
        [SetUp]
        public void Setup()
        {
            calculator = new StackCalculatorFunctionality();
            stack = new StackOnList<double>();
        }

        [Test]
        public void SumTest()
        {
            stack.Push(3);
            stack.Push(4);
            calculator.Counting("3 4 +", stack);
            Assert.AreEqual(7, stack.Peek());
        }

        [Test]
        public void SubtractionTest()
        {
            stack.Push(6);
            stack.Push(4);
            calculator.Counting("6 4 -", stack);
            Assert.AreEqual(2, stack.Peek());
        }

        [Test]
        public void MultiplicationTest()
        {
            stack.Push(20);
            stack.Push(4);
            calculator.Counting("20 4 *", stack);
            Assert.AreEqual(80, stack.Peek());
        }

        [Test]
        public void DivisionTest()
        {
            stack.Push(5);
            stack.Push(10);
            calculator.Counting("10 5 /", stack);
            Assert.AreEqual(2, stack.Peek());
        }

        [Test]
        public void ZeroPlusNumber()
        {
            stack.Push(5);
            stack.Push(0);
            calculator.Counting("5 0 +", stack);
            Assert.AreEqual(5, stack.Peek());
        }

        [Test]
        public void NumberMinusZero()
        {
            stack.Push(5);
            stack.Push(0);
            calculator.Counting("5 0 -", stack);
            Assert.AreEqual(5, stack.Peek());
        }

        [Test]
        public void SumBigNumbers()
        {
            stack.Push(567899);
            stack.Push(5463795);
            calculator.Counting("567899 5463795 +", stack);
            Assert.AreEqual(6031694, stack.Peek());
        }
        [Test]
        public void  MultiplyBigNumbers()
        {
            stack.Push(56788);
            stack.Push(54367);
            calculator.Counting("56788 54367 *", stack);
            Assert.AreEqual(3087393196, stack.Peek());
        }

        [Test]
        public void SumManyNumbers()
        {
            stack.Push(50);
            stack.Push(45);
            stack.Push(30);
            stack.Push(25);
            stack.Push(20);
            calculator.Counting("50 45 30 25 20 + + + +", stack);
            Assert.AreEqual(170, stack.Peek());
        }

        [Test]
        public void SubtractManyNumbers()
        {
            stack.Push(200);
            stack.Push(30);
            stack.Push(10);
            stack.Push(25);
            stack.Push(5);
            calculator.Counting("200 30 25 10 5 - - - -", stack);
            Assert.AreEqual(190, stack.Peek());
        }

        [Test]
        public void MultiplyManyNumbers()
        {
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
            stack.Push(2);
            calculator.Counting("3 4 5 6 2 * * * *", stack);
            Assert.AreEqual(720, stack.Peek());
        }

        [Test]
        public void DivideManyNumbers()
        {
            stack.Push(60);
            stack.Push(30);
            stack.Push(10);
            stack.Push(5);
            stack.Push(1);
            calculator.Counting("60 30 10 5 1 / / / /", stack);
            Assert.AreEqual(4, stack.Peek());
        }

        
        private StackCalculatorFunctionality calculator;
        private StackOnList<double> stack;
    }
}

