using System.Collections.Generic;

namespace CompressArrayNameSpace
{
    /// <summary>
    /// Class for meyhods of compression and uncompression of byte array.
    /// </summary>
    public class CompressionOfArray
    {
        /// <summary>
        /// Method to compress array.
        /// </summary>
        /// <param name="array">Current array.</param>
        /// <returns>New array.</returns>
        public byte[] Compression(byte[] array)
        {
            if (array.Length == 0)
            {
                throw new EmptyArrayException("Array is empty!");
            }

            var listForArray = new List<byte>();

            foreach (var item in array)
            {
                if (listForArray.Count == 0 || item != listForArray[listForArray.Count -1])
                {
                    listForArray.Add(1);
                    listForArray.Add(item);
                }
                else
                {
                    ++listForArray[listForArray.Count - 2];
                }
            }

            var newArray = new byte[listForArray.Count];

            for (int i = 0; i < listForArray.Count; ++i)
            {
                newArray[i] = listForArray[i];
            }

            return newArray;
        }

        /// <summary>
        /// Method to uncompress array.
        /// </summary>
        /// <param name="array">Current array.</param>
        /// <returns>New array.</returns>
        public byte[] UnCompression(byte[] array)
        {
            if (array.Length == 0)
            {
                throw new EmptyArrayException("Array is empty!");
            }

            var lentghForNewArray = 0;

            for (int i = 0; i < array.Length; i += 2)
            {
                lentghForNewArray += array[i];
            }

            var newArray = new byte[lentghForNewArray];
            var index = 0;

            for (int i = 1; i < array.Length; i += 2)
            {
                for (int j = 0; j < array[i - 1]; j++)
                {
                    newArray[index] = array[i];
                    ++index;
                }
            }

            return newArray;
        }
    }
}
