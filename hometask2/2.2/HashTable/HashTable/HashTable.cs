using System;
using LinkedList;

namespace HashTableNameSpace
{
    class HashTable
    {
        private readonly int size;
        private readonly MyList[] items;

        public HashTable(int size)
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
            var linkedList = GetLinkedList(position);
            return linkedList.FindValueInList(key);
        }

        public void Add(int key, string data)
        {
            int position = GetArrayPosition(key);
            var linkedlist = GetLinkedList(position);
            linkedlist.AddAt(linkedlist.Size, data, key);
        }

        public void Remove(int key)
        {
            int position = GetArrayPosition(key);
            var linkedList = GetLinkedList(position);
            linkedList.Remove(key);
        }

        private MyList GetLinkedList(int position)
        {
            var linkedlist = items[position];
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
