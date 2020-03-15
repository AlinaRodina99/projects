using System;
using System.Collections.Generic;
using Attributes;
using System.Threading;

namespace SuccesfulTests
{
    public class TestClass
    {
        public static List<int> List { get; set; }
        public  static string TestString { get; set; }
        private static readonly object locker = new object();

        [BeforeClass]
        public static void BeforeClassInitializeList()
        {
            lock (locker)
            {
                List = new List<int>() { 1, 2, 3, 4 };
            }
        }

        [BeforeClass]
        public static void BeforeClassInitializeString()
        {
            lock (locker)
            {
                TestString = "Test passed";
            }
        }

        [Before]
        public void BeforeTestChangeList()
        {
            lock (locker)
            {
                List[0] = 0;
            }
        }

        [Test]
        public void EmptyTest() { }

        [Test]
        public void SumTest()
        {
            var sum = 0;

            lock (locker)
            {
                foreach (var integer in List)
                {
                    sum += integer;
                }

                if (sum != 9)
                {
                    throw new Exception();
                }
            }
        }

        [Test]
        public void StringTest()
        {
            lock (locker)
            {
                if (TestString != "Test passed")
                {
                    throw new Exception();
                }
            }
        }

        [After]
        public void After() => Thread.Sleep(1000);

        [AfterClass]
        public static void AfterClass()
        {
            lock (locker)
            {
                TestString = "Testing finished";
                List = null;
            }
        }
    }
}
