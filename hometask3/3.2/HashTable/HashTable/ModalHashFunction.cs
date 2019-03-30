using System;

namespace HashTable
{
    /// <summary>
    /// Class for modular hash function.
    /// </summary>
    public class ModalHashFunction : IHashFunction
    {
        /// <summary>
        ///Implementation of modular hash function.
        /// </summary>
        /// <param name="key">Unique key of element.</param>
        /// <param name="size">Size of hash table.</param>
        /// <returns>Integer address of element to search in table.</returns>
        public int HashFunction(int key, int size)
        {
            return key % size;
        }
    }
}

