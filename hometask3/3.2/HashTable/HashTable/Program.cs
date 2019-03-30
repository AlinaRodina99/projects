using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTableFunctionality hashTable = new HashTableFunctionality(6);
            Console.WriteLine("Select type of hash-function:1 - Modal,2 - Multiplicative");
            string choice = Console.ReadLine();
            hashTable.SelectionOfHashFunction(choice);
            hashTable.Add(2, "John");
            hashTable.Add(3, "Ann");
            hashTable.Add(4, "Mark");
            hashTable.Add(3, "Kurt");
            hashTable.Add(4, "Paul");
            hashTable.Add(10, "Leon");
            hashTable.Remove(10);
            hashTable.PrintHashTable();
            Console.WriteLine(hashTable.FindValue(3));
            Console.WriteLine(hashTable.FindValue(10));
        }
    }
}
