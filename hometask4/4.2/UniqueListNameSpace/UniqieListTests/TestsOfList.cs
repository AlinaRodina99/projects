using NUnit.Framework;
using UniqueListNameSpace;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            uniqueList = new UniqueList();
        }

        [Test]
        public void AddTest()
        {
            uniqueList.AddToTheUniqueList("lemon");
            Assert.IsTrue(uniqueList.DoesElementExist("lemon"));
        }

        [Test]
        public void RemoveTest()
        {
            uniqueList.AddToTheUniqueList("melon");
            uniqueList.RemoveFromTheUniqueList("melon");
            Assert.IsFalse(uniqueList.DoesElementExist("melon"));
        }

        [Test]
        public void AddSameElementsToTheUniqueList()
        {
            uniqueList.AddToTheUniqueList("apple");
            Assert.Throws<AddSameElementsException>(() => uniqueList.AddToTheUniqueList("apple"));
        }

        [Test]
        public void RemoveNotExistentElementFromTheUniqueList()
        {
            Assert.Throws<RemoveNotExistentElementException>(() => uniqueList.RemoveFromTheUniqueList("banana"));
        }

        [Test]
        public void AddManyElementsToTheUniqueList()
        {
            uniqueList.AddToTheUniqueList("apple");
            uniqueList.AddToTheUniqueList("melon");
            uniqueList.AddToTheUniqueList("pineapple");
            uniqueList.AddToTheUniqueList("lemon");
            uniqueList.AddToTheUniqueList("banana");
            uniqueList.AddToTheUniqueList("orange");
            Assert.IsTrue(uniqueList.DoesElementExist("apple"));
            Assert.IsTrue(uniqueList.DoesElementExist("melon"));
            Assert.IsTrue(uniqueList.DoesElementExist("pineapple"));
            Assert.IsTrue(uniqueList.DoesElementExist("lemon"));
            Assert.IsTrue(uniqueList.DoesElementExist("banana"));
            Assert.IsTrue(uniqueList.DoesElementExist("orange"));
        }

        [Test]
        public void RemoveManyElementsFromTheUniqueList()
        {
            uniqueList.AddToTheUniqueList("apple");
            uniqueList.AddToTheUniqueList("melon");
            uniqueList.AddToTheUniqueList("pineapple");
            uniqueList.AddToTheUniqueList("lemon");
            uniqueList.AddToTheUniqueList("banana");
            uniqueList.AddToTheUniqueList("orange");
            uniqueList.RemoveFromTheUniqueList("apple");
            uniqueList.RemoveFromTheUniqueList("melon");
            uniqueList.RemoveFromTheUniqueList("pineapple");
            uniqueList.RemoveFromTheUniqueList("lemon");
            uniqueList.RemoveFromTheUniqueList("banana");
            uniqueList.RemoveFromTheUniqueList("orange");
            Assert.IsTrue(uniqueList.IsEmpty);
        }

        [Test]
        public void AddRemoveAgainAddTest()
        {
            uniqueList.AddToTheUniqueList("apple");
            uniqueList.RemoveFromTheUniqueList("apple");
            uniqueList.AddToTheUniqueList("apple");
            Assert.IsTrue(uniqueList.DoesElementExist("apple"));
        }

        UniqueList uniqueList;
    }
}