using NUnit.Framework;
using StackCalculatorNameSpace;

namespace Tests
{
    public class Tests
    {
        public void PushTest(IStack<double> stack)
        {
            stack.Push(3);
            Assert.IsFalse(stack.IsEmpty);
        }

        public void PopTest(IStack<double> stack)
        {
            stack.Push(4);
            Assert.AreEqual(4, stack.Pop());
        }

        public void PeekTest(IStack<double> stack)
        {
            stack.Push(4);
            Assert.AreEqual(4, stack.Peek());
        }

        public void PopFfromEmptyStackTest(IStack<double> stack)
        {
            stack.Pop();
        }

        public void PeekFormEmptyStackTest(IStack<double> stack)
        {
            stack.Peek();
        }

        public void TwoElementsPopTest(IStack<double> stack)
        {
            stack.Push(3);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(3, stack.Pop());
        }

        public void ManyPushTest(IStack<double> stack)
        {
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);
            Assert.AreEqual(9, stack.Pop());
            Assert.AreEqual(8, stack.Pop());
            Assert.AreEqual(7, stack.Pop());
            Assert.AreEqual(6, stack.Pop());
            Assert.AreEqual(5, stack.Pop());
            Assert.AreEqual(4, stack.Pop());
        }

        public void PushAndPopElementsTest(IStack<double> stack)
        {
            stack.Push(3);
            stack.Push(2);
            stack.Pop();
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty);
        }
        public void SumTest(IStack<double> stack)
        {
            stack.Push(3);
            stack.Push(4);
            StackCalculator.Counting("3 4 +", stack);
            Assert.AreEqual(7, stack.Peek());
        }

        public void SubtractionTest(IStack<double> stack)
        {
            stack.Push(6);
            stack.Push(4);
            StackCalculator.Counting("6 4 -", stack);
            Assert.AreEqual(2, stack.Peek());
        }

        public void MultiplicationTest(IStack<double> stack)
        {
            stack.Push(20);
            stack.Push(4);
            StackCalculator.Counting("20 4 *", stack);
            Assert.AreEqual(80, stack.Peek());
        }

        public void DivisionTest(IStack<double> stack)
        {
            stack.Push(5);
            stack.Push(10);
            StackCalculator.Counting("10 5 /", stack);
            Assert.AreEqual(2, stack.Peek());
        }

        public void ZeroPlusNumber(IStack<double> stack)
        {
            stack.Push(5);
            stack.Push(0);
            StackCalculator.Counting("5 0 +", stack);
            Assert.AreEqual(5, stack.Peek());
        }

        public void NumberMinusZero(IStack<double> stack)
        {
            stack.Push(5);
            stack.Push(0);
            StackCalculator.Counting("5 0 -", stack);
            Assert.AreEqual(5, stack.Peek());
        }

        public void SumBigNumbers(IStack<double> stack)
        {
            stack.Push(567899);
            stack.Push(5463795);
            StackCalculator.Counting("567899 5463795 +", stack);
            Assert.AreEqual(6031694, stack.Peek());
        }

        public void MultiplyBigNumbers(IStack<double> stack)
        {
            stack.Push(56788);
            stack.Push(54367);
            StackCalculator.Counting("56788 54367 *", stack);
            Assert.AreEqual(3087393196, stack.Peek());
        }

        public void SumManyNumbers(IStack<double> stack)
        {
            stack.Push(50);
            stack.Push(45);
            stack.Push(30);
            stack.Push(25);
            stack.Push(20);
            StackCalculator.Counting("50 45 30 25 20 + + + +", stack);
            Assert.AreEqual(170, stack.Peek());
        }

        public void SubtractManyNumbers(IStack<double> stack)
        {
            stack.Push(200);
            stack.Push(30);
            stack.Push(10);
            stack.Push(25);
            stack.Push(5);
            StackCalculator.Counting("200 30 25 10 5 - - - -", stack);
            Assert.AreEqual(190, stack.Peek());
        }

        public void MultiplyManyNumbers(IStack<double> stack)
        {
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
            stack.Push(2);
            StackCalculator.Counting("3 4 5 6 2 * * * *", stack);
            Assert.AreEqual(720, stack.Peek());
        }

        public void DivideManyNumbers(IStack<double> stack)
        {
            stack.Push(60);
            stack.Push(30);
            stack.Push(10);
            stack.Push(5);
            stack.Push(1);
            StackCalculator.Counting("60 30 10 5 1 / / / /", stack);
            Assert.AreEqual(4, stack.Peek());
        }

        [SetUp]
        public void Setup()
        {
            arrayStack = new ArrayStack<double>();
            arrayStack.Clear();
            stackOnList = new StackOnList<double>();
            stackOnList.Clear();
        }

        [Test]
        public void PushTestForArrayStack() => PushTest(arrayStack);

        [Test]
        public void PushTestForStackOnList() => PushTest(stackOnList);

        [Test]
        public void PopTestForArrayStack() => PopTest(arrayStack);

        [Test]
        public void PopTestForStackOnList() => PopTest(stackOnList);

        [Test]
        public void PeekTestForArrayStack() => PeekTest(arrayStack);

        [Test]
        public void PeekTestForStackOnList() => PeekTest(stackOnList);

        [Test]
        public void PopFromEmptyStackForStackOnList() => PopFfromEmptyStackTest(stackOnList);

        [Test]
        public void PopFromEmptyStackForArrayStack() => PopFfromEmptyStackTest(arrayStack);

        [Test]
        public void PeekFromEmptyStackTestForStackOnList() => PeekFormEmptyStackTest(stackOnList);

        [Test]
        public void PeekFromEmptyStackTestForArrayStack() => PeekFormEmptyStackTest(arrayStack);

        [Test]
        public void TwoElementsPopTestForStackOnList() => TwoElementsPopTest(stackOnList);

        [Test]
        public void TwoElementsPopTestForArrayStack() => TwoElementsPopTest(arrayStack);

        [Test]
        public void ManyPushTestForStackOnList() => ManyPushTest(stackOnList);

        [Test]
        public void ManyPushTestForArrayStack() => ManyPushTest(arrayStack);

        [Test]
        public void PushAndPopElementsTestForStackOnList() => PushAndPopElementsTest(stackOnList);

        [Test]
        public void PushAndPopElementsTestForArrayStack() => PushAndPopElementsTest(arrayStack);

        [Test]
        public void SumTestForArrayStack() => SumTest(arrayStack);

        [Test]
        public void SumTestForStackOnList() => SumTest(stackOnList);

        [Test]
        public void SubtractionTestForStackOnList() => SubtractionTest(stackOnList);

        [Test]
        public void SubtractionTestForArrayStack() => SubtractionTest(arrayStack);

        [Test]
        public void MultiplicationTestForStackOnList() => MultiplicationTest(stackOnList);

        [Test]
        public void MuptiplicationTestForArrayStack() => MultiplicationTest(arrayStack);

        [Test]
        public void DivisionTestForStackOnList() => DivisionTest(stackOnList);

        [Test]
        public void DivisionTestForArrayStack() => DivisionTest(arrayStack);

        [Test]
        public void ZeroPlusNumberTestForStackOnList() => ZeroPlusNumber(stackOnList);

        [Test]
        public void ZeroPlusNumberTestForArrayStack() => ZeroPlusNumber(arrayStack);

        [Test]
        public void NumberMinusZeroTestForStackOnList() => NumberMinusZero(stackOnList);

        [Test]
        public void NumberMinusZeroTestForArrayStack() => NumberMinusZero(arrayStack);

        [Test]
        public void SumBigNumbersTestForStackOnList() => SumBigNumbers(stackOnList);

        [Test]
        public void SumBigNumbersTestForArrayStack() => SumBigNumbers(arrayStack);

        [Test]
        public void MultiplyBigNumbersTestForStackOnList() => MultiplyBigNumbers(stackOnList);

        [Test]
        public void MultiplyBigNumbersTestForArrayStack() => MultiplyBigNumbers(arrayStack);

        [Test]
        public void SumManyNumbersTestForStackOnList() => SumManyNumbers(stackOnList);

        [Test]
        public void SumManyNUmbersTestForArrayStack() => SumManyNumbers(arrayStack);

        [Test]
        public void SubtractManyNumbersTestForStackOnList() => SubtractManyNumbers(stackOnList);

        [Test]
        public void SubtractManyNumbersTestForArrayStack() => SubtractManyNumbers(arrayStack);

        [Test]
        public void MultiplyManyNumbersTestForStackOnList() => MultiplyManyNumbers(stackOnList);

        [Test]
        public void MultiplyManyNumbersTestForArrayStack() => MultiplyManyNumbers(arrayStack);

        [Test]
        public void DivideManyNumbersTestForStackOnList() => DivideManyNumbers(stackOnList);

        [Test]
        public void DivideManyNumbersTestForArrayStack() => DivideManyNumbers(arrayStack);

        ArrayStack<double> arrayStack;
        StackOnList<double> stackOnList;
    }
}