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
            Assert.AreEqual(5, tree.CalculateTree(firstFile));
        }

        [Test]
        public void SubtractionTest()
        {
            Assert.AreEqual(1, tree.CalculateTree(secondFile));
        }

        [Test]
        public void MultiplicationTest()
        {
             Assert.AreEqual(200, tree.CalculateTree(thirdFile));
        }

        [Test]
        public void DivisionTest()
        {
            Assert.AreEqual(5, tree.CalculateTree(forthFile));
        }

        [Test]
        public void NumberPlusZeroTest()
        {
            Assert.AreEqual(2, tree.CalculateTree(fifthFile));
        }

        [Test]
        public void ReadFromNotFoundFile()
        {
            Assert.AreEqual(0, tree.CalculateTree("NotFoundFile"));
        }

        [Test]
        public void LongExpressionTest()
        {
            Assert.AreEqual(-1, tree.CalculateTree(sixthFile));
        }

        [Test]
        public void NonNegativeNumbersTest()
        {
            Assert.AreEqual(11, tree.CalculateTree(seventhFile));
        }

        [Test]
        public void DivideByZeroTest()
        {
            Assert.AreEqual(-1, tree.CalculateTree(eighthFile));
        }

        [Test]
        public void AnotherLongExpressionTest()
        {
            Assert.AreEqual(16, tree.CalculateTree(ninthFile));
        }

        [Test]
        public void BothNumbersAreZeroTest()
        {
            Assert.AreEqual(0, tree.CalculateTree(tenthFile));
        }

        [Test]
        public void BigNumbersTest()
        {
            Assert.AreEqual(66791669, tree.CalculateTree(eleventhFile));
        }

        private BinaryTree tree;
        private string firstFile = "AddTest.txt";
        private string secondFile = "SubtractionTest.txt";
        private string thirdFile = "MultiplicationTest.txt";
        private string forthFile = "DivisionTest.txt";
        private string fifthFile = "NumberPlusZeroTest.txt";
        private string sixthFile = "LongExpressionTest.txt";
        private string seventhFile = "NegativeNumbersTest.txt";
        private string eighthFile = "DivideByZeroTest.txt";
        private string ninthFile = "AnotherLongExpressionTest.txt";
        private string tenthFile = "BothNumbersAreZeroTest.txt";
        private string eleventhFile = "BigNumbersTest.txt";
    }
}