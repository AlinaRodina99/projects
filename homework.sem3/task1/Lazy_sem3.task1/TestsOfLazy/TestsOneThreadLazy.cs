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
            var lazy = LazyFactory<int>.CreateOneThreadLazy(null);
            Assert.Throws<NullReferenceException>(() => lazy.Get());
        }

        [Test]
        public void FuncReturnsExceptionTest()
        {
            var lazy = LazyFactory<int>.CreateOneThreadLazy(() => throw new ArgumentException());
            Assert.Throws<ArgumentException>(() => lazy.Get());
        }

        [Test]
        public void FuncReturnsNullTest()
        {
            var lazy = LazyFactory<object>.CreateOneThreadLazy(() => null);
            Assert.AreSame(null, lazy.Get());
        }
    }
}