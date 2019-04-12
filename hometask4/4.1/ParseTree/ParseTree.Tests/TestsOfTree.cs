using NUnit.Framework;
using ParseTree;

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
            Assert.AreEqual(-1, tree.CalculateTree(divideZeroTest));
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
        private string addTest = "AddTest.txt";
        private string subtractTest = "SubtractionTest.txt";
        private string multuplyTest = "MultiplicationTest.txt";
        private string divideTest = "DivisionTest.txt";
        private string numPlusZeroTest = "NumberPlusZeroTest.txt";
        private string longExpressTest = "LongExpressionTest.txt";
        private string negativeNumTest = "NegativeNumbersTest.txt";
        private string divideZeroTest = "DivideByZeroTest.txt";
        private string anotherLongExpressTest = "AnotherLongExpressionTest.txt";
        private string bothNumsAreZeroTest = "BothNumbersAreZeroTest.txt";
        private string bigNumsTest = "BigNumbersTest.txt";
    }
}