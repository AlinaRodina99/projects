using System;
using System.Collections.Generic;
using Attributes;

namespace BeforeClassTesting
{
    public class TestClass7
    {
        private static volatile List<int> integerList;

        [BeforeClass]
        public static void BeforeClass()
        {
            integerList = new List<int>() { 1, 2, 3, 4 };
        }

        [Test]
        public void CheckArray()
        {
            for (var i = 0; i < integerList.Count; ++i)
            {
                if (integerList[i] != i + 1)
                {
                    throw new Exception();
                }
            }
        }
    }
}
