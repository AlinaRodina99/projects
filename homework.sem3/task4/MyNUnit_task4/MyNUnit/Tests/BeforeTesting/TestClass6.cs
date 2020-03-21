using System;
using Attributes;

namespace BeforeTesting
{
    public class TestClass6
    {
        private volatile int number = 5;

        [Before]
        public void BeforeTest() => number = 100;

        [Test]
        public void CheckNumber1()
        {
            if (number != 100)
            {
                throw new Exception();
            }
        }
    }
}
