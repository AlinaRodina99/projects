using NUnit.Framework;
using Lazy_sem3.task1;
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
        public void AreObjectsSameWithOneThreadLazyTest()
        {
            var lazy = LazyFactory<object>.CreateOneThreadLazy(() => DateTime.Now);
            var time = lazy.Get();
            Assert.AreEqual(time, lazy.Get());
            Assert.AreEqual(time, lazy.Get());
        }

        [Test]
        public void AreObjectsSameWithMultiThreadLazy()
        {
            var lazy = LazyFactory<object>.CreateMultiThreadLazy(() => DateTime.Now);
            var time = lazy.Get();
            Assert.AreEqual(time, lazy.Get());
            Assert.AreEqual(time, lazy.Get());
        }
    }
}