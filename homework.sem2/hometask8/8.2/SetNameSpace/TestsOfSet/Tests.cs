using NUnit.Framework;
using SetNameSpace;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            set = new Set<int>();
        }

        [Test]
        public void AddTest()
        {
            Assert.IsTrue(set.Add(6));
            Assert.IsTrue(set.Add(0));
            Assert.IsFalse(set.Add(6));
            Assert.IsFalse(set.Add(0));
        }

        [Test]
        public void RemoveTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            Assert.IsTrue(set.Remove(1));
            Assert.IsFalse(set.Remove(4));
            Assert.IsFalse(set.Remove(1));
        }

        [Test]
        public void UnionWithTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            var anotherSet = new Set<int>() { 4, 5 };
            set.UnionWith(anotherSet);
            int i = 1;
            foreach (var item in set)
            {
                Assert.AreEqual(item, i);
                ++i;
            }
        }

        [Test]
        public void IntersectWithTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            var anotherSet = new Set<int>() { 1, 3, 5 };
            set.IntersectWith(anotherSet);
            int i = 1;
            foreach (var item in set)
            {
                Assert.AreEqual(item, i);
                i += 2;
            }
        }

        [Test]
        public void ExceptWithTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            var anotherSet = new Set<int>() { 3, 5 };
            set.ExceptWith(anotherSet);
            int i = 1;
            foreach (var item in set)
            {
                Assert.AreEqual(item, i);
                ++i;
            }
        }

        [Test]
        public void SymmetricExceptionWithTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            var anotherSet = new Set<int>() { 3, 5 };
            set.SymmetricExceptWith(anotherSet);
            int i = 1;
            foreach (var item in set)
            {
                Assert.AreEqual(item, i);
                if (i == 2)
                {
                    i += 2;
                }
                ++i;
            }
        }

        [Test]
        public void IsSubsetOfTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            var anotherSet = new Set<int>() { 1, 2, 3, 4, 5, 6, 7 };
            Assert.IsTrue(set.IsSubsetOf(anotherSet));
        }

        [Test]
        public void IsSuperSetOfTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var anotherSet = new Set<int>() { 1, 2, 4 };
            Assert.IsTrue(set.IsSupersetOf(anotherSet));
        }

        [Test]
        public void IsProperSubsetOfTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var anotherSet = new Set<int>() { 1, 2, 3, 4, 5, 6 };
            Assert.IsTrue(set.IsProperSubsetOf(anotherSet));
        }

        [Test]
        public void IsProperSuperSetTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var anotherSet = new Set<int>() { 1, 2, 3, 4 };
            Assert.IsTrue(set.IsProperSupersetOf(anotherSet));
        }

        [Test]
        public void OverLapsTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var anotherSet = new Set<int>() { 1, 2, 3 };
            Assert.IsTrue(set.Overlaps(anotherSet));
        }

        [Test]
        public void SetEqualsTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var anotherSet = new Set<int>() { 1, 2, 3, 4, 5 };
            Assert.AreEqual(true, set.SetEquals(anotherSet));
        }

        [Test]
        public void CopyToTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var array = new int[5];
            set.CopyTo(array, 0);
            Assert.AreEqual(array[0], 1);
            Assert.AreEqual(array[1], 2);
            Assert.AreEqual(array[2], 3);
            Assert.AreEqual(array[3], 4);
            Assert.AreEqual(array[4], 5);
        }

        [Test]
        public void RemoveFromEmptySetTest()
        {
            Assert.AreEqual(false, set.Remove(3));
        }

        [Test]
        public void CopyToArrayBiggerThanSetTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var array = new int[6];
            set.CopyTo(array, 0);
            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(3, array[2]);
            Assert.AreEqual(4, array[3]);
            Assert.AreEqual(5, array[4]);
            Assert.AreEqual(0, array[5]);
        }

        public void CopyToArraySmallerThanSetTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var array = new int[3];
            set.CopyTo(array, 0);
            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(3, array[2]);
        }

        [Test]
        public void CopyToArrayIndexIsNotZeroTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var array = new int[3];
            set.CopyTo(array, 2);
            Assert.AreEqual(0, array[0]);
            Assert.AreEqual(0, array[1]);
            Assert.AreEqual(1, array[2]);
        }

        [Test]
        public void ContainsTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(2));
            Assert.IsTrue(set.Contains(3));
            Assert.IsTrue(set.Contains(4));
            Assert.IsTrue(set.Contains(5));
            Assert.IsFalse(set.Contains(-1));
        }

        [Test]
        public void IntersectionEmptyTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var anotherSet = new Set<int>() { 6, 7, 8 };
            set.IntersectWith(anotherSet);
            foreach (var item in set)
            {
                Assert.IsNull(item);
            }
        }

        [Test]
        public void IsNotSubsetOfTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var anotherSet = new Set<int>() { 1, 2, 3 };
            Assert.IsFalse(set.IsSubsetOf(anotherSet));
        }

        [Test]
        public void IsNotProperSubsetOfTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var anotherSet = new Set<int>() { 1, 2, 3, 4, 5 };
            Assert.IsFalse(set.IsProperSubsetOf(anotherSet));
        }

        [Test]
        public void IsNotSuperSetOfTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var anotherSet = new Set<int>() { 1, 2, 3, 4, 5, 6 };
            Assert.IsFalse(set.IsSupersetOf(anotherSet));
        }

        [Test]
        public void IsNotProperSuperSetTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            var anotherSet = new Set<int>() { 1, 2, 3, 4, 5 };
            Assert.IsFalse(set.IsProperSupersetOf(anotherSet));
        }

        [Test]
        public void ExceptWithEmptyTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            var anotherSet = new Set<int>() { 1, 2, 3 };
            set.ExceptWith(anotherSet);
            foreach (var item in set)
            {
                Assert.IsNull(item);
            }
        }

        [Test]
        public void IsNotOverlapsTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            var anotherSet = new Set<int>() { 4, 5, 6 };
            Assert.IsFalse(set.Overlaps(anotherSet));
        }

        [Test]
        public void IsNotSetEqualsTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            var anotherSet = new Set<int>() { 1, 2, 5 };
            Assert.AreEqual(false, set.SetEquals(anotherSet));
        }

        [Test]
        public void ClearTest()
        {
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Clear();
            foreach (var item in set)
            {
                Assert.IsNull(item);
            }
        }

        private Set<int> set;
    }
}