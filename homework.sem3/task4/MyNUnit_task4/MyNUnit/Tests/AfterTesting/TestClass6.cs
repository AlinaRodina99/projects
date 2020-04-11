using System;
using Attributes;
using System.Threading;
using System.Collections.Generic;

namespace AfterTesting
{
    public class TestClass6
    {
        private int result = 0;
        public int Result { get; private set; }

        [Test]
        public void CalculateResult1() => result = 3 + 2;

        [After]
        public void After() => Result = result;
    }
}
