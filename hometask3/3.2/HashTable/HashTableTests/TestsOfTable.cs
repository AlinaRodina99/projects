using NUnit.Framework;
using HashTableNameSpace;

namespace Tests
{
    public class Tests
    {
        public void AddTest(IHashFunction hashFunction)
        {
            hashTable.Add(6, "apple", hashFunction);
            Assert.IsTrue(hashTable.FindValue(6, hashFunction));
        }

        public void RemoveTest(IHashFunction hashFunction)
        {
            hashTable.Add(5, "lemon", hashFunction);
            hashTable.Remove(5, hashFunction);
            Assert.IsFalse(hashTable.FindValue(5, hashFunction));
        }

        public void AddManyElementsTest(IHashFunction hashFunction)
        {
            hashTable.Add(7, "melon", hashFunction);
            hashTable.Add(3, "banana", hashFunction);
            hashTable.Add(10, "John", hashFunction);
            hashTable.Add(12, "Mark", hashFunction);
            hashTable.Add(20, "Karl", hashFunction);
            hashTable.Add(30, "Leon", hashFunction);
            hashTable.Add(50, "Robin", hashFunction);
            Assert.AreEqual(7, hashTable.CountOfElements);
        }

        public void RemoveManyElementsTest(IHashFunction hashFunction)
        {
            hashTable.Add(7, "melon", hashFunction);
            hashTable.Add(3, "banana", hashFunction);
            hashTable.Add(10, "John", hashFunction);
            hashTable.Add(12, "Mark", hashFunction);
            hashTable.Add(20, "Karl", hashFunction);
            hashTable.Add(30, "Leon", hashFunction);
            hashTable.Add(50, "Robin", hashFunction);
            hashTable.Remove(7, hashFunction);
            hashTable.Remove(3, hashFunction);
            hashTable.Remove(10, hashFunction);
            hashTable.Remove(12, hashFunction);
            hashTable.Remove(20, hashFunction);
            Assert.AreEqual(2, hashTable.CountOfElements);
        }

        public void AddRemoveAgainAddTest(IHashFunction hashFunction)
        {
            hashTable.Add(3, "apple", hashFunction);
            hashTable.Remove(3, hashFunction);
            hashTable.Add(3, "apple", hashFunction);
            Assert.IsTrue(hashTable.FindValue(3, hashFunction));
        }

        public void FindNonexistentValueTest(IHashFunction hashFunction)
        {
            hashTable.Add(3, "banana", hashFunction);
            Assert.IsFalse(hashTable.FindValue(4, hashFunction));
        }

        public void AddValuesWithSameKeysTest(IHashFunction hashFunction)
        {
            hashTable.Add(3, "lemon", hashFunction);
            hashTable.Add(3, "banana", hashFunction);
            hashTable.Add(3, "apple", hashFunction);
            Assert.AreEqual(3, hashTable.CountOfElements);
        }

        public void AddElementsWithSameKeysAndThenRemoveOneOfThemTest(IHashFunction hashFunction)
        {
            hashTable.Add(3, "apple", hashFunction);
            hashTable.Add(3, "banana", hashFunction);
            hashTable.Remove(3, hashFunction);
            Assert.IsTrue(hashTable.FindValue(3, hashFunction));
        }

        [SetUp]
        public void SetUp()
        {
            hashTable = new HashTable(10);
            modalHash = new ModalHashFunction();
            multHash = new MultiplicativeHashFunction();
        }

        [Test]
        public void AddTestForModalHash() => AddTest(modalHash);

        [Test]
        public void AddTestForMultiplicativeHash() => AddTest(multHash);

        [Test]
        public void RemoveTestForModalHash() => RemoveTest(modalHash);

        [Test]
        public void RemoveTestForMultiplicativeHash() => RemoveTest(multHash);

        [Test]
        public void AddManyElementsForModalHash() => AddManyElementsTest(modalHash);

        [Test]
        public void AddManyElementsForMultiplicativeHash() => AddManyElementsTest(multHash);

        [Test]
        public void RemoveManyElementsForModalHash() => RemoveManyElementsTest(modalHash);

        [Test]
        public void RemoveManyElemetsForMultiplicative() => RemoveManyElementsTest(multHash);

        [Test]
        public void FindNonexistentValueTestForModalHash() => FindNonexistentValueTest(modalHash);

        [Test]
        public void FindNonExistentValueTestForMultiplicativeHash() => FindNonexistentValueTest(multHash);

        [Test]
        public void AddRemoveAgainAddTestForModalHash() => AddRemoveAgainAddTest(modalHash);

        [Test]
        public void AddRemoveAgainAddTestForMultiplicativeHash() => AddRemoveAgainAddTest(multHash);

        [Test]
        public void AddValuesWithSameKeysForModalHash() => AddValuesWithSameKeysTest(modalHash);

        [Test]
        public void AddValuesWithSameKeysForMultiplicativeHash() => AddValuesWithSameKeysTest(multHash);

        [Test]
        public void AddElementsWithSameKeysAndThenRemoveOneOfThemTestForModalHash() => AddElementsWithSameKeysAndThenRemoveOneOfThemTest(modalHash);

        [Test]
        public void AddElementsWithSameKeysAndThenRemoveOneOfThemTestForMultiplicativeHash() => AddElementsWithSameKeysAndThenRemoveOneOfThemTest(multHash);
        
        private HashTable hashTable;
        private ModalHashFunction modalHash;
        private MultiplicativeHashFunction multHash;
    }
}