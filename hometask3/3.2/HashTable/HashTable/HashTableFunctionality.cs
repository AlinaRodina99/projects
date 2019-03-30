using LinkedList;
using System;

namespace HashTable
{
    public class HashTableFunctionality
    {
        /// <summary>
        /// Property for count of elements in hash table.
        /// </summary>
        public int CountOfElements
        {
            get
            {
                for (int i = 0; i < size; ++i)
                {
                    if (items[i] != null)
                    {
                        countOfElements += items[i].Size;
                    }
                }
                return countOfElements;
            }
        }
        /// <summary>
        /// Variable for count of elements.
        /// </summary>
        private int countOfElements;
        /// <summary>
        /// Variable for hash-function.
        /// </summary>
        private IHashFunction hashFunction;
        /// <summary>
        /// Size of the table.
        /// </summary>
        private readonly int size;
        /// <summary>
        ///Array of lists for the implementation of the chaining method.
        /// </summary>
        private readonly MyList[] items;
        /// <summary>
        /// Class constructor that creates the hash table with a specific size.
        /// </summary>
        /// <param name="size">Size of table.</param>
        public HashTableFunctionality(int size)
        {
            this.size = size;
            items = new MyList[size];
        }
        /// <summary>
        /// Method for finding elements in the table by key.
        /// </summary>
        /// <param name="key">Unique key of element.</param>
        /// <returns></returns>
        public bool FindValue(int key)
        {
            MyList linkedList = GetLinkedList(hashFunction.HashFunction(key, size));
            ElementOfList currentElement = linkedList.Head;
            for (int i = 0; i < linkedList.Size; ++i)
            {
                if (currentElement.Key.Equals(key))
                {
                    return true;
                }
                currentElement = currentElement.Next;
            }
            return false;
        }
        /// <summary>
        /// Method for adding elements in the table by data and key.
        /// </summary>
        /// <param name="key">Unique key of element.</param>
        /// <param name="data">Element value.</param>
        public void Add(int key, string data)
        {
            MyList linkedlist = GetLinkedList(hashFunction.HashFunction(key, size));
            ElementOfList currentElement = new ElementOfList(data, key);
            linkedlist.AddAt(linkedlist.Size, data, key);
        }
        /// <summary>
        /// Method for removing element from the table by key.
        /// </summary>
        /// <param name="key">Unique key of element.</param>
        public void Remove(int key)
        {
            MyList linkedList = GetLinkedList(hashFunction.HashFunction(key, size));
            ElementOfList currentElement = linkedList.Head;
            string currentData;
            for (int i = 0; i < linkedList.Size; ++i)
            {
                if (currentElement.Key.Equals(key))
                {
                    currentData = currentElement.Data;
                    linkedList.Remove(currentData);
                }
                currentElement = currentElement.Next;
            }
        }
        /// <summary>
        /// Method for getting list by position in array of lists.
        /// </summary>
        /// <param name="position">Position of list in array of lists.</param>
        /// <returns></returns>
        private MyList GetLinkedList(int position)
        {
            MyList linkedlist = items[position];
            if (linkedlist == null)
            {
                linkedlist = new MyList();
                items[position] = linkedlist;
            }
            return linkedlist;
        }
        /// <summary>
        /// Method for printing hash table.
        /// </summary>
        public void PrintHashTable()
        {
            for (int i = 0; i < size; i++)
            {
                if (items[i] != null)
                {
                    items[i].PrintList();
                }
            }
        }
        /// <summary>
        /// Method for the selection of hash-function by user.
        /// </summary>
        public void SelectionOfHashFunction(string choice)
        {
            if (choice == "1")
            {
                hashFunction = new ModalHashFunction();
            }
            else if (choice == "2")
            {
                hashFunction = new MultiplicativeHashFunction();
            }
            else
            {
                Console.WriteLine("Incorrect data format!");
            }
        }
    }
}


