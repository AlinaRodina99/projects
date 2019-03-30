using System;

namespace HashTable
{
    /// <summary>
    /// Class for multiplicative hash function.
    /// </summary>
    public class MultiplicativeHashFunction : IHashFunction
    {
        /// <summary>
        ///Implementation of multiplicative hash function.
        /// </summary>
        /// <param name="key">Unique key of element.</param>
        /// <param name="size">Size of table.</param>
        /// <returns>Integer address of element to search in table.</returns>
        public int HashFunction(int key, int size)
        {
            return (int)Math.Floor(size * (key * 0.618033 - Math.Floor(key * 0.618033)));
        }
    }
}
