using System;

namespace HashTableNameSpace
{
    class Program
    {
        /// <summary>
        /// Method for the selection of hash-function by user.
        /// </summary>
        public static IHashFunction SelectionOfHashFunction(string choice)
        {
            if (choice == "1")
            {
                return new ModalHashFunction();
            }
            else if (choice == "2")
            {
                return new MultiplicativeHashFunction();
            }
            else
            {
                Console.WriteLine("Incorrect data format!");
                return null;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Select type of hash-function:1 - Modal,2 - Multiplicative");
            string choice = Console.ReadLine();
            var hashFunction = SelectionOfHashFunction(choice);
            if (hashFunction == null)
            {
                Console.WriteLine("Hash-function was not selected!");
                return;
            }
            var hashTable = new HashTable(6, hashFunction);
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
