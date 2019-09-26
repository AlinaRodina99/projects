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
            var firstThread = new Thread(delegate() { lazy.Get(); });
            var secondThread = new Thread(delegate() { lazy.Get(); });
            var thirdThread = new Thread(delegate () { lazy.Get(); });
            Assert.AreEqual(lazy.Get(), 7);
        }

        [Test]
        public void OneThreadThrowsNullExceptionTest()
        {
            var lazy = LazyFactory<int>.CreateMultiThreadLazy(null);
            var firstThread = new Thread(delegate () { lazy.Get(); });
            var secondThread = new Thread(delegate () { lazy.Get(); });
            var thirdThread = new Thread(delegate () { lazy.Get(); });
            Assert.Throws<NullReferenceException>(() => lazy.Get());
        }

        [Test]
        public void OneThreadThrowsArgumentExceptionTest()
        {
            var lazy = LazyFactory<int>.CreateMultiThreadLazy(() => throw new ArgumentException());
            var firstThread = new Thread(delegate () { lazy.Get(); });
            var secondThread = new Thread(delegate () { lazy.Get(); });
            var thirdThread = new Thread(delegate () { lazy.Get(); });
            Assert.Throws<ArgumentException>(() => lazy.Get());
        }

        [Test]
        public void FuncReturnsNullTest()
        {
            var lazy = LazyFactory<object>.CreateMultiThreadLazy(() => null);
            var firstThread = new Thread(delegate () { lazy.Get(); });
            var secondThread = new Thread(delegate () { lazy.Get(); });
            var thirdThread = new Thread(delegate () { lazy.Get(); });
            Assert.AreEqual(lazy.Get(), null);
        }

        [Test]
        public void DoesItWorkWithDecrementTest()
        {
            var current = 7;
            var lazy = LazyFactory<int>.CreateMultiThreadLazy(() => --current);
            var firstThread = new Thread(delegate () { lazy.Get(); });
            var secondThread = new Thread(delegate () { lazy.Get(); });
            var thirdThread = new Thread(delegate () { lazy.Get(); });
            Assert.AreEqual(lazy.Get(), 6);
        }
    }
}
