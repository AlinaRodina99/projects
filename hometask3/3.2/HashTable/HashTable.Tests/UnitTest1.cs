using NUnit.Framework;
using HashTable;

namespace Tests
{
    public class Tests
    {
        public void AddTest()
        {
            hashTable.Add(6, "apple");
            Assert.IsTrue(hashTable.FindValue(6));
        }

        public void RemoveTest()
        {
            hashTable.Add(5, "lemon");
            hashTable.Remove(5);
            Assert.IsFalse(hashTable.FindValue(5));
        }

        public void AddManyElementsTest()
        {
            hashTable.Add(7, "melon");
            hashTable.Add(3, "banana");
            hashTable.Add(10, "John");
            hashTable.Add(12, "Mark");
            hashTable.Add(20, "Karl");
            hashTable.Add(30,"Leon");
            hashTable.Add(50, "Robin");
            Assert.AreEqual(7, hashTable.CountOfElements);
        }

        public void RemoveManyElementsTest()
        {
            hashTable.Add(7, "melon");
            hashTable.Add(3, "banana");
            hashTable.Add(10, "John");
            hashTable.Add(12, "Mark");
            hashTable.Add(20, "Karl");
            hashTable.Add(30, "Leon");
            hashTable.Add(50, "Robin");
            hashTable.Remove(7);
            hashTable.Remove(3);
            hashTable.Remove(10);
            hashTable.Remove(12);
            hashTable.Remove(20);
            Assert.AreEqual(2, hashTable.CountOfElements);
        }

        public void AddRemoveAgainAddTest()
        {
            hashTable.Add(3, "apple");
            hashTable.Remove(3);
            hashTable.Add(3, "apple");
            Assert.IsTrue(hashTable.FindValue(3));
        }

        public void FindNonexistentValueTest()
        {
            hashTable.Add(3, "banana");
            Assert.IsFalse(hashTable.FindValue(4));
        }

        public void AddValuesWithSameKeysTest()
        {
            hashTable.Add(3, "lemon");
            hashTable.Add(3, "banana");
            hashTable.Add(3, "apple");
            Assert.AreEqual(3, hashTable.CountOfElements);
        }

        public void AddElementsWithSameKeysAndThenRemoveOneOfThemTest()
        {
            hashTable.Add(3, "apple");
            hashTable.Add(3, "banana");
            hashTable.Remove(3);
            Assert.IsTrue(hashTable.FindValue(3));
        }

        public void SetUpForModalHash()
        {
            hashTable = new HashTableFunctionality(10);
            hashTable.SelectionOfHashFunction("1");
        }

        public void SetUpForMultiplicativeHash()
        {
            hashTable = new HashTableFunctionality(10);
            hashTable.SelectionOfHashFunction("2");
        }

        [Test]
        public void AddTestForModalHash()
        {
            SetUpForModalHash();
            AddTest();
        }

        [Test]
        public void AddTestForMultiplicativeHash()
        {
            SetUpForMultiplicativeHash();
            AddTest();
        }

        [Test]
        public void RemoveTestForModalHash()
        {
            SetUpForModalHash();
            RemoveTest();
        }

        [Test]
        public void RemoveTestForMultiplicativeHash()
        {
            SetUpForMultiplicativeHash();
            RemoveTest();
        }

        [Test]
        public void AddManyElementsForModalHash()
        {
            SetUpForModalHash();
            AddManyElementsTest();
        }

        [Test]
        public void AddManyElementsForMultiplicativeHash()
        {
            SetUpForMultiplicativeHash();
            AddManyElementsTest();
        }

        [Test]
        public void RemoveManyElementsForModalHash()
        {
            SetUpForMultiplicativeHash();
            RemoveManyElementsTest();
        }

        [Test]
        public void RemoveManyElemetsForMultiplicative()
        {
            SetUpForMultiplicativeHash();
            RemoveManyElementsTest();
        }

        [Test]
        public void FindNonexistentValueTestForModalHash()
        {
            SetUpForModalHash();
            FindNonexistentValueTest();
        }

        [Test]
        public void FindNonExistentValueTestForMultiplicativeHash()
        {
            SetUpForMultiplicativeHash();
            FindNonexistentValueTest();
        }

        [Test]
        public void AddRemoveAgainAddTestForModalHash()
        {
            SetUpForModalHash();
            AddRemoveAgainAddTest();
        }

        [Test]
        public void AddRemoveAgainAddTestForMultiplicativeHash()
        {
            SetUpForMultiplicativeHash();
            AddRemoveAgainAddTest();
        }

        [Test]
        public void AddValuesWithSameKeysForModalHash()
        {
            SetUpForModalHash();
            AddValuesWithSameKeysTest();
        }

        [Test]
        public void AddValuesWithSameKeysForMultiplicativeHash()
        {
            SetUpForMultiplicativeHash();
            AddValuesWithSameKeysTest();
        }

        [Test]
        public void AddElementsWithSameKeysAndThenRemoveOneOfThemTestForModalHash()
        {
            SetUpForModalHash();
            AddElementsWithSameKeysAndThenRemoveOneOfThemTest();
        }

        [Test]
        public void AddElementsWithSameKeysAndThenRemoveOneOfThemTestForMultiplicativeHash()
        {
            SetUpForMultiplicativeHash();
            AddElementsWithSameKeysAndThenRemoveOneOfThemTest();
        }

        private HashTableFunctionality hashTable;
    }
}