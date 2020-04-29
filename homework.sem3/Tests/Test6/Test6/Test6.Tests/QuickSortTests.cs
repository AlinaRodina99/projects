using NUnit.Framework;

namespace Test6.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            QuickSort = new QuickSort();
        }

        [Test]
        public void TestForFirstArray()
        {
            var result = QuickSort.Compare(firstArray);
            Assert.AreEqual(-1, result);
        }

        private QuickSort QuickSort;
        private int[] firstArray = new int[6] { 2, 4, 1, 6, 7, 0 };
    }
}