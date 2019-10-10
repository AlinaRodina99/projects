using NUnit.Framework;
using ListMethodsNameSpace;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        /// <summary>
        /// Class for defining zero elements if they are integer.
        /// </summary>
        private class NullElementForInt : INullElement<int>
        {
            public bool IsNull(int number) => number == 0;
        }

        /// <summary>
        /// Class for defining zero elements if they are string.
        /// </summary>
        private class NullElementForString : INullElement<string>
        {
            public bool IsNull(string item) => item == null;
            
        }

        /// <summary>
        /// Class for defining zero elements if they are char.
        /// </summary>
        private class NullElementForChar : INullElement<char>
        {
            public bool IsNull(char item) => item == 0;
        }

        [Test]
        public void NullElementForIntTest()
        {
            var list = new List<int>() { 1, 2, 3, 0, 7 };
            var nullElementForInt = new NullElementForInt();
            Assert.AreEqual(1, ListMethods<int>.CountOfZeroElements(list, nullElementForInt));
        }

        [Test]
        public void NullElementForStringTest()
        {
            var list = new List<string>() { "apple", "lemon", null, null, "banana" };
            var nullElementForString = new NullElementForString();
            Assert.AreEqual(2, ListMethods<string>.CountOfZeroElements(list, nullElementForString));
        }

        [Test]
        public void NullElementForCharTest()
        {
            var list = new List<char>() { 'a', '\0' , 'b', 'c' };
            var nullElementForChar = new NullElementForChar();
            Assert.AreEqual(1, ListMethods<char>.CountOfZeroElements(list, nullElementForChar));
        }
    }
}