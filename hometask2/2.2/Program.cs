using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTableFunctionality hashTable = new HashTableFunctionality(3);
            hashTable.Add(2, "apple");
            hashTable.Add(3, "melon");
            hashTable.Add(5, "lemon");
            hashTable.Remove(2);
            hashTable.PrintHashTable();
            Console.WriteLine(hashTable.FindValue(2));
        }
    }
}
