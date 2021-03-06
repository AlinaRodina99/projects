using NUnit.Framework;
using ParseTree;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            tree = new BinaryTree();
        }

        [Test]
        public void SumTest()
        {
            Assert.AreEqual(5, tree.CalculateTree(addTest));
        }

        [Test]
        public void SubtractionTest()
        {
            Assert.AreEqual(1, tree.CalculateTree(subtractTest));
        }

        [Test]
        public void MultiplicationTest()
        {
             Assert.AreEqual(200, tree.CalculateTree(multuplyTest));
        }

        [Test]
        public void DivisionTest()
        {
            Assert.AreEqual(5, tree.CalculateTree(divideTest));
        }

        [Test]
        public void NumberPlusZeroTest()
        {
            Assert.AreEqual(2, tree.CalculateTree(numPlusZeroTest));
        }

        [Test]
        public void ReadFromNotFoundFile()
        {
            Assert.AreEqual(0, tree.CalculateTree("NotFoundFile"));
        }

        [Test]
        public void LongExpressionTest()
        {
            Assert.AreEqual(-1, tree.CalculateTree(longExpressTest));
        }

        [Test]
        public void NonNegativeNumbersTest()
        {
            Assert.AreEqual(11, tree.CalculateTree(negativeNumTest));
        }

        [Test]
        public void DivideByZeroTest()
        {
            Assert.Throws<DivideByZeroException>(() => tree.CalculateTree(divideZeroTest));
        }

        [Test]
        public void AnotherLongExpressionTest()
        {
            Assert.AreEqual(16, tree.CalculateTree(anotherLongExpressTest));
        }

        [Test]
        public void BothNumbersAreZeroTest()
        {
            Assert.AreEqual(0, tree.CalculateTree(bothNumsAreZeroTest));
        }

        [Test]
        public void BigNumbersTest()
        {
            Assert.AreEqual(66791669, tree.CalculateTree(bigNumsTest));
        }

        private BinaryTree tree;
        private string addTest = "TestFiles/AddTest.txt";
        private string subtractTest = "TestFiles/SubtractionTest.txt";
        private string multuplyTest = "TestFiles/MultiplicationTest.txt";
        private string divideTest = "TestFiles/DivisionTest.txt";
        private string numPlusZeroTest = "TestFiles/NumberPlusZeroTest.txt";
        private string longExpressTest = "TestFiles/LongExpressionTest.txt";
        private string negativeNumTest = "TestFiles/NegativeNumbersTest.txt";
        private string divideZeroTest = "TestFiles/DivideByZeroTest.txt";
        private string anotherLongExpressTest = "TestFiles/AnotherLongExpressionTest.txt";
        private string bothNumsAreZeroTest = "TestFiles/BothNumbersAreZeroTest.txt";
        private string bigNumsTest = "TestFiles/BigNumbersTest.txt";
    }
}