using System;
using Attributes;

namespace FailedTesting
{
    public class TestClass2
    {
        private readonly int number = 10;

        [Test]
        public void ExceptionTest() => throw new Exception();

        [Test]
        public void WrongCountingTest()
        {
            var result = 50 * 10;

            if (result == 500)
            {
                throw new Exception();
            }
        }

        [Test]
        public void BoolTest()
        {
            var testBoolString = true;

            if (testBoolString)
            {
                throw new Exception();
            }
        }

        [Test]
        public void WrongNumberTest()
        {
            if (number == 10)
            {
                throw new Exception(":)))");
            }
        }
    }
}
