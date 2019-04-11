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
            var hashTable = new HashTable(6);
            Console.WriteLine("Select type of hash-function:1 - Modal,2 - Multiplicative");
            string choice = Console.ReadLine();
            var hashFunction = SelectionOfHashFunction(choice);
            if (hashFunction == null)
            {
                Console.WriteLine("Hash-function was not selected!");
                return;
            }
            hashTable.Add(2, "John", hashFunction);
            hashTable.Add(3, "Ann", hashFunction);
            hashTable.Add(4, "Mark", hashFunction);
            hashTable.Add(3, "Kurt", hashFunction);
            hashTable.Add(4, "Paul", hashFunction);
            hashTable.Add(10, "Leon", hashFunction);
            hashTable.Remove(10, hashFunction);
            hashTable.PrintHashTable();
            Console.WriteLine(hashTable.FindValue(3, hashFunction));
            Console.WriteLine(hashTable.FindValue(10, hashFunction));
        }
    }
}
