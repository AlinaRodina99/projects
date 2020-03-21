using System;
using System.Threading;
using Attributes;

namespace AfterClassTesting
{
    public class TestClass9
    {
        private static volatile int counter = 1;

        [Test]
        public void CounterTest1() => Interlocked.Increment(ref counter);

        [Test]
        public void CounterTest2() => Interlocked.Increment(ref counter);

        [AfterClass]
        public static void AfterClass()
        {
            if (counter != 3)
            {
                throw new Exception("Something is wrong!");
            }
        }
    }
}
