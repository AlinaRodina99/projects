using System.Threading;
using NUnit.Framework;
using Lazy_sem3.task1;

namespace TestsOfLazy
{
    public class TestsMultiThreadLazy
    {
        [Test]
        public void DoesItWorkWithIncrementTest()
        {
            var current = 6;
            var lazy = LazyFactory<int>.CreateMultiThreadLazy(() => ++current);
            var threads = new Thread[3];
            for (var i = 0; i < 3; ++i)
            {
                threads[i] = new Thread(() => lazy.Get());
            }

            for (var i = 0; i < 3; ++i)
            {
                threads[i].Start();
            }

            for (var i = 0; i < 3; ++i)
            {
                threads[i].Join();
            }
            Assert.AreEqual(7, lazy.Get());
        }

        [Test]
        public void FuncReturnsNullTest()
        {
            var lazy = LazyFactory<object>.CreateMultiThreadLazy(() => null);
            var threads = new Thread[3];
            for (var i = 0; i < 3; ++i)
            {
                threads[i] = new Thread(() => lazy.Get());
            }

            for (var i = 0; i < 3; ++i)
            {
                threads[i].Start();
            }

            for (var i = 0; i < 3; ++i)
            {
                threads[i].Join();
            }
            Assert.IsNull(lazy.Get());
        }

        [Test]
        public void DoesItWorkWithDecrementTest()
        {
            var current = 7;
            var lazy = LazyFactory<int>.CreateMultiThreadLazy(() => --current);
            var threads = new Thread[3];
            for (var i = 0; i < 3; ++i)
            {
                threads[i] = new Thread(() => lazy.Get());
            }

            for (var i = 0; i < 3; ++i)
            {
                threads[i].Start();
            }

            for (var i = 0; i < 3; ++i)
            {
                threads[i].Join();
            }
            Assert.AreEqual(6, lazy.Get());
        }
    }
}
