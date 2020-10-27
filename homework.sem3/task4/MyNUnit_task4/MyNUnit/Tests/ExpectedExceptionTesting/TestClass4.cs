using System;
using Attributes;

namespace ExpectedExceptionTesting
{
    public class TestClass4
    {
        [Test(ExpectedException = typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            var number = 6;
            var result = number / 0;
        }

        [Test(ExpectedException = typeof(NullReferenceException))]
        public void NullReferenceTest() => throw new NullReferenceException();

        [Test(ExpectedException = typeof(ArgumentException))]
        public void ArgumentException()
        {
            var age = 17;

            if (age < 18)
            {
                throw new ArgumentException("Age must be 18 or older!");
            }
        }
    }
}
