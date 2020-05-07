using System;
using System.Collections.Generic;
using Attributes;
using System.Threading;

namespace SuccesfulTests
{
    public class TestClass1
    {
        [Test]
        public void EmptyTest() { }

        [Test]
        public void SumTest()
        {
            var sum = 0;
            var list = new List<int>() { 1, 2, 3, 4 };

            foreach (var integer in list)
            {
                sum += integer;
            }

            if (sum != 10)
            {
                throw new Exception();
            }
        }

        [Test]
        public void StringTest()
        {
            var testString = "Test passed";

            if (testString != "Test passed")
            {
                throw new Exception();
            }
        }

        [Test]
        public void NumberTests()
        {
            var testNumber = 10;

            if (testNumber != 10)
            {
                throw new Exception();
            }
        }
    }
}
