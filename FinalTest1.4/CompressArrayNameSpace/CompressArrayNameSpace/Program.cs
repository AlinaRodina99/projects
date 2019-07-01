using System;

namespace CompressArrayNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new byte[4] { 1, 2, 2, 3 };
            CompressionOfArray compressionOf = new CompressionOfArray();
            var newArr = compressionOf.Compression(array);
            foreach (var i in newArr)
            {
                Console.WriteLine(i);
            }
        }
    }
}
