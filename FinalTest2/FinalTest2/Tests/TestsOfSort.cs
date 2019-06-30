using NUnit.Framework;
using FinalTest2;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            genericMethods = new GenericMethods<int>();
            genericMethods2 = new GenericMethods<string>();
            comparer = new Comparator<int>();
        }

        [Test]
        public void TestForIntTypes()
        {
            var currentList = new List<int>();
            var expectedList = new List<int> { 1, 2, 5, 6 };
            currentList.Add(5);
            currentList.Add(6);
            currentList.Add(1);
            currentList.Add(2);
            genericMethods.PubbleSort<int>(currentList, comparer);
            Assert.AreEqual(expectedList, currentList);
        }

        private GenericMethods<int> genericMethods;
        private GenericMethods<string> genericMethods2;
        private Comparer<int> comparer;
    }
}