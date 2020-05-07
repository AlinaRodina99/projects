using System;
using Attributes;

namespace IgnoredTesting
{
    public class TestClass3
    {
        [Test(Ignore = "This test is bad")]
        public void IgnoreTest1()
        {
            var squareOfTwo = 5;

            if (squareOfTwo != 5)
            {
                throw new Exception("))");
            }
        }

        [Test(Ignore = "This test can break your operation system.")]
        public void IgnoreTest2()
        {
            throw new AggregateException("Your computer is under threat!");
        }
    }
}
