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
            uniqueList.AddAt(0, "lemon");
            Assert.IsTrue(uniqueList.DoesElementExist("lemon"));
        }

        [Test]
        public void RemoveTest()
        {
            uniqueList.AddAt(0, "melon");
            uniqueList.RemoveByData("melon");
            Assert.IsFalse(uniqueList.DoesElementExist("melon"));
        }

        [Test]
        public void AddSameElementsToTheUniqueList()
        {
            uniqueList.AddAt(0, "apple");
            Assert.Throws<AddSameElementsException>(() => uniqueList.AddAt(0, "apple"));
        }

        [Test]
        public void RemoveNotExistentElementFromTheUniqueList()
        {
            Assert.Throws<RemoveNotExistentElementException>(() => uniqueList.RemoveByData("banana"));
        }

        [Test]
        public void AddManyElementsToTheUniqueList()
        {
            uniqueList.AddAt(0, "apple");
            uniqueList.AddAt(1, "melon");
            uniqueList.AddAt(2, "pineapple");
            uniqueList.AddAt(3, "lemon");
            uniqueList.AddAt(4, "banana");
            uniqueList.AddAt(5, "orange");
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
            uniqueList.AddAt(0, "apple");
            uniqueList.AddAt(1, "melon");
            uniqueList.AddAt(2, "pineapple");
            uniqueList.AddAt(3, "lemon");
            uniqueList.AddAt(4, "banana");
            uniqueList.AddAt(5, "orange");
            uniqueList.RemoveByData("apple");
            uniqueList.RemoveByData("melon");
            uniqueList.RemoveByData("pineapple");
            uniqueList.RemoveByData("lemon");
            uniqueList.RemoveByData("banana");
            uniqueList.RemoveByData("orange");
            Assert.IsTrue(uniqueList.IsEmpty);
        }

        [Test]
        public void AddRemoveAgainAddTest()
        {
            uniqueList.AddAt(0, "apple");
            uniqueList.RemoveByData("apple");
            uniqueList.AddAt(0, "apple");
            Assert.IsTrue(uniqueList.DoesElementExist("apple"));
        }

        private UniqueList uniqueList;
    }
}