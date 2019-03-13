using NUnit.Framework;
using StackCalculator;

namespace Tests
{
    class TestsArrayStack
    {
        private ArrayStack<double> stack;

        [SetUp]
        public void Setup()
        {
            stack = new ArrayStack<double>();
        }

        [Test]
        public void PushTest()
        {
            stack.Push(3);
            Assert.IsFalse(stack.IsEmpty);
        }

        [Test]
        public void PopTest()
        {
            stack.Push(4);
            Assert.AreEqual(4, stack.Pop());
        }

        [Test]
        public void PeekTest()
        {
            stack.Push(4);
            Assert.AreEqual(4, stack.Peek());
        }

        [Test]
        public void PopFfromEmptyStack()
        {
            stack.Pop();
        }

        [Test]
        public void PeekFormEmptyStack()
        {
            stack.Peek();
        }

        [Test]
        public void TwoElementsPopTest()
        {
            stack.Push(3);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(3, stack.Pop());
        }

        [Test]
        public void ManyPushTest()
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

        [Test]
        public void PushAndPopElements()
        {
            stack.Push(3);
            stack.Push(2);
            stack.Pop();
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty);
        }
    }
}

