using NUnit.Framework;
using Lazy_sem3.task1;
using System.Threading;
using System;

namespace Tests
{
    public class TestsOneThreadLazy
    {
        [Test]
        public void WhenItAllWorksTest()
        {
            var lazy = LazyFactory<int>.CreateOneThreadLazy(() => 34);
            Assert.AreEqual(34, lazy.Get());
        }

        [Test]
        public void SupplierIsNullTest()
        {
            OneThreadLazy<int> lazy;
            Assert.Throws<ArgumentNullException>(() => lazy = LazyFactory<int>.CreateOneThreadLazy(null));
        }

        [Test]
        public void FuncReturnsExceptionTest()
        {
            var lazy = LazyFactory<int>.CreateOneThreadLazy(() => throw new ArgumentException());
            Assert.Throws<ArgumentException>(() => lazy.Get());
        }

        [Test]
        public void FuncReturnsNullTests()
        {
            var lazy = LazyFactory<object>.CreateOneThreadLazy(() => null);
            Assert.AreEqual(null, lazy.Get());
        }

        [Test]
        public void GetCalculatedOnceTest()
        {
            var current = 6;
            var lazy = LazyFactory<int>.CreateOneThreadLazy(() => ++current);
            Assert.AreEqual(7, lazy.Get());
            Assert.AreEqual(7, lazy.Get());
        }

        [Test]
        public void AreObjectsSameWithOneThreadLazyTest()
        {
            var func = new Func<string>(() => "Test");
            var lazy = LazyFactory<string>.CreateOneThreadLazy(func);
            var result = lazy.Get();
            Assert.IsTrue(result.Equals(lazy.Get()));
            Assert.IsTrue(result.Equals(lazy.Get()));
        }

        [Test]
        public void AreObjectsSameWithMultiThreadedLazyTest()
        {
            const int n = 5;
            var func = new Func<int>(() => 5 * 2);
            var lazy = LazyFactory<int>.CreateMultiThreadLazy(func);
            var threads = new Thread[n];
            var results = new int[n];
            for (var i = 0; i < n; ++i)
            {
                var current = i;
                threads[i] = new Thread(() => results[current] = lazy.Get());
            }

            for (var i = 0; i < n; ++i)
            {
                threads[i].Start();
            }

            for (var i = 0; i < n; ++i)
            {
                threads[i].Join();
            }

            for (var i = 0; i < n - 1; ++i)
            {
                Assert.IsTrue(results[i].Equals(results[i + 1]));
            }
        }
    }
}