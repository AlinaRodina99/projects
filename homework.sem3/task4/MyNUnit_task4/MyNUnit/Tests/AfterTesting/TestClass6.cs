using System;
using Attributes;
using System.Threading;

namespace AfterTesting
{
    public class TestClass6
    {
        private volatile string testString = "Test";

        [Test]
        public void CheckTestString1()
        {
            if (testString != "Test")
            {
                throw new Exception();
            }
        }

        [After]
        public void After() => testString = "Test passed";

        [Test]
        public void CheckString2()
        {
            Thread.Sleep(1000);

            if (testString != "Test passed")
            {
                throw new Exception();
            }
        }
    }
}
