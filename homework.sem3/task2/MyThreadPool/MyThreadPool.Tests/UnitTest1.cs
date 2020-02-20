using NUnit.Framework;

namespace MyThreadPool.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            threadPool = new MyThreadPool(10);
        }

        [Test]
        public void Test()
        {
            Assert.Pass();
        }

        private MyThreadPool threadPool;
    }
}