using System;

namespace HashTableNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new HashTable(3);
            hashTable.Add(2, "apple");
            hashTable.Add(3, "melon");
            hashTable.Add(5, "lemon");
            hashTable.Remove(2);
            hashTable.PrintHashTable();
            Console.WriteLine(hashTable.FindValue(2));
        }
    }
}

