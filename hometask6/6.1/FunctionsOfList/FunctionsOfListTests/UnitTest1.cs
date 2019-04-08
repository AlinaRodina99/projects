using NUnit.Framework;
using FunctionsOfList;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            functions = new Functions();
        }

        [Test]
        public void MapTest()
        {
            var newList = functions.Map(new List<int> { 2, 4, 6 }, x => x * 2);
            Assert.AreEqual(4, newList[0]);
            Assert.AreEqual(8, newList[1]);
            Assert.AreEqual(12, newList[2]);
        }

        [Test]
        public void FilterTest()
        {
            var newList = functions.Filter(new List<int> { 2, 4, 6 }, x => x > 2);
            Assert.AreEqual(4, newList[0]);
            Assert.AreEqual(6, newList[1]);
        }

        [Test]
        public void FoldTest()
        {
            int result = functions.Fold(new List<int> { 2, 4, 6 }, 2, (acc, elem) => acc * elem);
            Assert.AreEqual(96, result);
        }

        [Test]
        public void MapTestWithZero()
        {
            var newList = functions.Map(new List<int>() { 1, 2, 3 }, x => x * 0);
            Assert.AreEqual(0, newList[0]);
            Assert.AreEqual(0, newList[1]);
            Assert.AreEqual(0, newList[2]);
        }

        [Test]
        public void MapTestWithNegativeNumbers()
        {
            var newList = functions.Map(new List<int>() { 1, 2, 3 }, x => x * -1);
            Assert.AreEqual(-1, newList[0]);
            Assert.AreEqual(-2, newList[1]);
            Assert.AreEqual(-3, newList[2]);
        }

        [Test]
        public void ManyNumbersMapTest()
        {
            var newList = functions.Map(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, x => x * 2);
            Assert.AreEqual(2, newList[0]);
            Assert.AreEqual(4, newList[1]);
            Assert.AreEqual(6, newList[2]);
            Assert.AreEqual(8, newList[3]);
            Assert.AreEqual(10, newList[4]);
            Assert.AreEqual(12, newList[5]);
            Assert.AreEqual(14, newList[6]);
            Assert.AreEqual(16, newList[7]);
            Assert.AreEqual(18, newList[8]);
            Assert.AreEqual(20, newList[9]);
            Assert.AreEqual(22, newList[10]);
            Assert.AreEqual(24, newList[11]);
        }

        [Test]
        public void ManyNumbersFilterTest()
        {
            var newList = functions.Filter(new List<int>() { 3, 10, 11, 1, 18, 19, 0, 20, -1, 30, 35, -2, 40, 50 }, x => x > 3);
            Assert.AreEqual(10, newList[0]);
            Assert.AreEqual(11, newList[1]);
            Assert.AreEqual(18, newList[2]);
            Assert.AreEqual(19, newList[3]);
            Assert.AreEqual(20, newList[4]);
            Assert.AreEqual(30, newList[5]);
            Assert.AreEqual(35, newList[6]);
            Assert.AreEqual(40, newList[7]);
            Assert.AreEqual(50, newList[8]);
        }

        [Test]
        public void ManyNumbersFoldTest()
        {
            int result = functions.Fold(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, (acc, elem) => acc * elem);
            Assert.AreEqual(3628800, result);
        }

        [Test]
        public void BigNumbersFoldTest()
        {
            int result = functions.Fold(new List<int>() { 234, 200, 190 }, 234, (acc, elem) => acc * elem);
            Assert.AreEqual(2080728000, result);
        }

        [Test]
        public void FoldTestWithZero()
        {
            int result = functions.Fold(new List<int>() { 1, 0, 4 }, 1, (acc, elem) => acc * elem);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FoldTestWithNegativeNumbers()
        {
            int result = functions.Fold(new List<int>() { 1, 2, -1 }, 1, (acc, elem) => acc * elem);
            Assert.AreEqual(-2, result);
        }

        [Test]
        public void FilterTestWithNegativeNumbers()
        {
            var newList = functions.Filter(new List<int>() { -2, 2, 3, 4 }, x => x > -1);
            Assert.AreEqual(2, newList[0]);
            Assert.AreEqual(3, newList[1]);
            Assert.AreEqual(4, newList[2]);
        }

        [Test]
        public void FilterTestWithZero()
        {
            var newList = functions.Filter(new List<int>() { -1, 0, 3, 4 }, x => x > 0);
            Assert.AreEqual(3, newList[0]);
            Assert.AreEqual(4, newList[1]);
        }

        [Test]
        public void BigNumbersMapTest()
        {
            var newList = functions.Map(new List<int>() { 1, 2, 3 }, x => x * 23678568);
            Assert.AreEqual(23678568, newList[0]);
            Assert.AreEqual(47357136, newList[1]);
            Assert.AreEqual(71035704, newList[2]);
        }

        [Test]
        public void BigNumbersFilterTest()
        {
            var newList = functions.Filter(new List<int>() { 2345678, 36678590, 34567 }, x => x > 35000000);
            Assert.AreEqual(36678590, newList[0]);
        }

        [Test]
        public void NoNumbersInListFilterTest()
        {
            var newList = functions.Filter(new List<int>() { -1, -2, -3 }, x => x > 0);
            Assert.AreEqual(0, newList.Count);
        }

        private Functions functions;
    }
}