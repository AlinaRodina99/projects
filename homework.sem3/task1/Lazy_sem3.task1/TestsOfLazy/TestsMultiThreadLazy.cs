using System.Threading;
using NUnit.Framework;
using Lazy_sem3.task1;
using System;

namespace TestsOfLazy
{
    public class TestsMultiThreadLazy
    {
        [Test]
        public void DoesItWorkWithIncrementTest()
        {
            var current = 6;
            var lazy = LazyFactory<int>.CreateMultiThreadLazy(() => ++current);
            for (var i = 0; i < 3; ++i)
            {
                var currentThread = new Thread(delegate () { lazy.Get(); });
                currentThread.Start();
                currentThread.Join();
            }
            Assert.AreEqual(lazy.Get(), 7);
        }

        [Test]
        public void FuncReturnsNullTest()
        {
            var lazy = LazyFactory<object>.CreateMultiThreadLazy(() => null);
            for (var i = 0; i < 3; ++i)
            {
                var currentThread = new Thread(delegate () { lazy.Get(); });
                currentThread.Start();
                currentThread.Join();
            }
            Assert.AreEqual(lazy.Get(), null);
        }

        [Test]
        public void DoesItWorkWithDecrementTest()
        {
            var current = 7;
            var lazy = LazyFactory<int>.CreateMultiThreadLazy(() => --current);
            for (var i = 0; i < 3; ++i)
            {
                var currentThread = new Thread(delegate () { lazy.Get(); });
                currentThread.Start();
                currentThread.Join();
            }
            Assert.AreEqual(lazy.Get(), 6);
        }
    }
}
