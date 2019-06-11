using NUnit.Framework;
using GenericListNameSpace;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            myList = new GenericList<string>();
        }

        [Test]
        public void AddTest()
        {
            myList.Add("John");
            myList.Add("Mary");
            myList.Add("Mark");
            Assert.AreEqual(3, myList.Count);
            Assert.AreEqual("John", myList[0]);
            Assert.AreEqual("Mary", myList[1]);
            Assert.AreEqual("Mark", myList[2]);
        }

        [Test]
        public void RemoveTest()
        {
            myList.Add("John");
            myList.Add("Mary");
            myList.Add("Mark");
            Assert.AreEqual(true, myList.Remove("Mary"));
            Assert.AreEqual(2, myList.Count);
            Assert.AreEqual("John", myList[0]);
            Assert.AreEqual("Mark", myList[1]);
        }

        [Test]
        public void InsertTest()
        {
            myList.Add("Mary");
            myList.Add("Mark");
            myList.Insert(1, "Paul");
            Assert.AreEqual(3, myList.Count);
            Assert.AreEqual("Paul", myList[1]);
        }

        [Test]
        public void RemoveAtTest()
        {
            myList.Add("Mark");
            myList.Add("Liza");
            myList.Add("John");
            myList.RemoveAt(1);
            Assert.AreEqual("John", myList[1]);
            Assert.AreEqual(2, myList.Count);
        }

        [Test]
        public void IndexOfTest()
        {
            myList.Add("Mark");
            myList.Add("Liza");
            myList.Add("John");
            Assert.AreEqual(1, myList.IndexOf("Liza"));
        }

        [Test]
        public void ContainsTest()
        {
            myList.Add("Mark");
            myList.Add("Liza");
            myList.Add("John");
            Assert.IsFalse(myList.Contains("Michael"));
            Assert.IsTrue(myList.Contains("Liza"));
        }

        [Test]
        public void CopyToArraySmallerThanListTest()
        {
            var array = new string[2];
            myList.Add("Mark");
            myList.Add("Liza");
            myList.Add("John");
            myList.CopyTo(array, 0);
            Assert.AreEqual("Mark", array[0]);
            Assert.AreEqual("Liza", array[1]);
        }

        [Test]
        public void CopyToArrayBiggerThanList()
        {
            var array = new string[5];
            myList.Add("Mark");
            myList.Add("Liza");
            myList.Add("John");
            myList.CopyTo(array, 0);
            Assert.AreEqual("Mark", array[0]);
            Assert.AreEqual("Liza", array[1]);
            Assert.AreEqual("John", array[2]);
            Assert.IsNull(array[3]);
            Assert.IsNull(array[4]);
        }

        [Test]
        public void RemoveAllElementsTest()
        {
            myList.Add("Mark");
            myList.Add("Liza");
            myList.Add("John");
            myList.Add("Michael");
            myList.Add("Paul");
            Assert.IsTrue(myList.Remove("Mark"));
            Assert.IsTrue(myList.Remove("Liza"));
            Assert.IsTrue(myList.Remove("John"));
            Assert.IsTrue(myList.Remove("Michael"));
            Assert.IsTrue(myList.Remove("Paul"));
            Assert.AreEqual(0, myList.Count);
        }

        [Test]
        public void RemovaAtAllElementsTest()
        {
            myList.Add("Mark");
            myList.Add("Liza");
            myList.Add("John");
            myList.Add("Michael");
            myList.Add("Paul");
            myList.RemoveAt(0);
            myList.RemoveAt(0);
            myList.RemoveAt(0);
            myList.RemoveAt(0);
            myList.RemoveAt(0);
            Assert.AreEqual(0, myList.Count);
        }

        [Test]
        public void IndexOfNotFoundElement()
        {
            myList.Add("Mark");
            myList.Add("Liza");
            myList.Add("John");
            myList.Add("Michael");
            myList.Add("Paul");
            Assert.AreEqual(-1, myList.IndexOf("Laura"));
        }

        [Test]
        public void RemoveNotFoundElementTest()
        {
            myList.Add("Mark");
            myList.Add("Liza");
            myList.Add("John");
            myList.Add("Michael");
            myList.Add("Paul");
            Assert.IsFalse(myList.Remove("Laura"));
        }

        private GenericList<string> myList; 
    }
}