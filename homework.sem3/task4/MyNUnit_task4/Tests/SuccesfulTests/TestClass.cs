using System;
using Attributes;
using System.Collections.Generic;

namespace SuccesfulTests
{
    public class TestClass
    {
        [Test]
        public void FirstTest()
        {
            var result = Math.Sqrt(2);
        }

        [Test]
        public void SecondTest()
        {
            var integers = new List<int> { 1, 2, 4, 5 };

            foreach (var number in integers)
            {
                
            }
        }
    }
}
