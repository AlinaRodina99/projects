using NUnit.Framework;
using MoveToFrontNameSpace;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            moveTo = new MoveToFront();
        }

        [Test]
        public void BananaTest()
        {
            var list = moveTo.StringCoding("banana");
            var expectedList = new List<int>() { 33, 33, 45, 1, 1, 1 };
            CollectionAssert.AreEqual(expectedList, list);
        }

        [Test]
        public void BcabaaaTest()
        {
            var list = moveTo.StringCoding("bcabaaa");
            var expectedList = new List<int>() { 33, 34, 34, 2, 1, 0, 0 };
            CollectionAssert.AreEqual(expectedList, list);
        }

        [Test]
        public void BananaaaTest()
        {
            var list = moveTo.StringCoding("bananaaa");
            var expectedList = new List<int>() { 33, 33, 45, 1, 1, 1, 0, 0 };
            CollectionAssert.AreEqual(expectedList, list);
        }

        private MoveToFront moveTo;
    }
}