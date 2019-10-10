using NUnit.Framework;
using CompressArrayNameSpace;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            firstArray = new byte[6] { 1, 2, 4, 4, 5, 6 };
            secondArray = new byte[3] { 1, 2, 2 };
            emptyArray = new byte[0];
            compressionOf = new CompressionOfArray();
        }

        [Test]
        public void CompressionTestForFirstArray()
        {
            var newArray = compressionOf.Compression(firstArray);
            Assert.AreEqual(1, newArray[0]);
            Assert.AreEqual(1, newArray[1]);
            Assert.AreEqual(1, newArray[2]);
            Assert.AreEqual(2, newArray[3]);
            Assert.AreEqual(2, newArray[4]);
            Assert.AreEqual(4, newArray[5]);
            Assert.AreEqual(1, newArray[6]);
            Assert.AreEqual(5, newArray[7]);
            Assert.AreEqual(1, newArray[8]);
            Assert.AreEqual(6, newArray[9]);
        }

        [Test]
        public void UnCompressionTestForFirstArray()
        {
            var newArray = compressionOf.Compression(firstArray);
            var originArray = compressionOf.UnCompression(newArray);
            Assert.AreEqual(1, originArray[0]);
            Assert.AreEqual(2, originArray[1]);
            Assert.AreEqual(4, originArray[2]);
            Assert.AreEqual(4, originArray[3]);
            Assert.AreEqual(5, originArray[4]);
            Assert.AreEqual(6, originArray[5]);
        }

        [Test]
        public void CompressionTestForSecondArray()
        {
            var newArray = compressionOf.Compression(secondArray);
            Assert.AreEqual(1, newArray[0]);
            Assert.AreEqual(1, newArray[1]);
            Assert.AreEqual(2, newArray[2]);
            Assert.AreEqual(2, newArray[3]);
        }

        [Test]
        public void UnCpmtressionTestForSecondArray()
        {
            var newArray = compressionOf.Compression(secondArray);
            var originArray = compressionOf.UnCompression(newArray);
            Assert.AreEqual(1, originArray[0]);
            Assert.AreEqual(2, originArray[1]);
            Assert.AreEqual(2, originArray[2]);
        }

        [Test]
        public void EmptyArrayTest()
        {
            Assert.Throws<EmptyArrayException>(() => compressionOf.Compression(emptyArray));
        }

        [Test]
        public void EmptyArrayUnCompressionTest()
        {
            Assert.Throws<EmptyArrayException>(() => compressionOf.UnCompression(emptyArray));
        }

        private byte[] firstArray;
        private byte[] secondArray;
        private byte[] emptyArray;
        private CompressionOfArray compressionOf;
    }
}