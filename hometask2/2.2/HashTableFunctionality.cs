using System;
using LinkedList;

namespace HashTable
{
    class HashTableFunctionality
    {
        private readonly int size;
        private readonly MyList[] items;

        public HashTableFunctionality(int size)
        {
            this.size = size;
            items = new MyList[size];
        }

        private int GetArrayPosition(int key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        public bool FindValue(int key)
        {
            int position = GetArrayPosition(key);
            MyList linkedList = GetLinkedList(position);
            ElementOfList currentElement = new ElementOfList(linkedList[0], key);
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

        public void Add(int key, string data)
        {
            int position = GetArrayPosition(key);
            MyList linkedlist = GetLinkedList(position);
            ElementOfList currentElement = new ElementOfList(data, key);
            linkedlist.AddAt(linkedlist.Size, data, key);
        }

        public void Remove(int key)
        {
            int position = GetArrayPosition(key);
            MyList linkedList = GetLinkedList(position);
            ElementOfList currentElement = new ElementOfList(linkedList[0], key);
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
    }
}
