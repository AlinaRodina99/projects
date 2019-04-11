namespace HashTableNameSpace
{
    /// <summary>
    ///Interface for implementing different types of hash functions.
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// Method of hash function calculation.
        /// </summary>
        /// <param name="key">Unique key of element.</param>
        /// <param name="size">Size of hash table.</param>
        /// <returns>Integer value of hash-function.</returns>
        int HashFunction(int key, int size);
    }
}

