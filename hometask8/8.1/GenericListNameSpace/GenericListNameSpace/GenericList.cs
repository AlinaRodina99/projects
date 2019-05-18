using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericListNameSpace
{
    /// <summary>
    /// Class for linked list that implements IList interface.
    /// </summary>
    /// <typeparam name="T">Generic parameter.</typeparam>
    public class GenericList<T> : IList<T>
    {
        /// <summary>
        /// Private class for the element of the list.
        /// </summary>
        /// <typeparam name="W">Generic parameter.</typeparam>
        private class ElementOfList<W>
        {
            public ElementOfList(W data)
            {
                Data = data;
            }
            public W Data { get; set; }
            public ElementOfList<W> Next { get; set; }
            public ElementOfList<W> Previous { get; set; }
        }

        /// <summary>
        /// Private variable for the top of the list.
        /// </summary>
        private ElementOfList<T> head = null;

        /// <summary>
        /// Indexer to get list item by index or set value by index.
        /// </summary>
        /// <param name="index">Index of the element.</param>
        /// <returns>Value of the element.</returns>
        public T this[int index]
        {
            get
            {
                if (GetElement(index) == null)
                {
                    return default;
                }
                return GetElement(index).Data;
            }
            set
            {
                if (GetElement(index) == null)
                {
                    return;
                }
                GetElement(index).Data = value;
            }
        }

        /// <summary>
        /// Private method that is used in indexer.
        /// </summary>
        /// <param name="index">Index of the element.</param>
        /// <returns>Element that user wants.</returns>
        private ElementOfList<T> GetElement(int index)
        {
            if (index < 0 || index > Count)
            {
                return default;
            }
            ElementOfList<T> current = head;
            for (int i = 0; i < index; ++i)
            {
                current = current.Next;
            }
            return current;
        }
        
        /// <summary>
        /// Property for the size of the list.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Зroperty to see if the list is read-only or not.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Mathod to add element by its item.
        /// </summary>
        /// <param name="item">Value of the element.</param>
        public void Add(T item)
        {
            if (head == null)
            {
                head = new ElementOfList<T>(item);
                ++Count;
            }
            else
            {
                var currentElement = head;
                while (currentElement.Next != null)
                {
                    currentElement = currentElement.Next;
                }
                currentElement.Next = new ElementOfList<T>(item);
                currentElement.Next.Previous = currentElement; 
                ++Count;
            }
        }

        /// <summary>
        /// Method to clear list.
        /// </summary>
        public void Clear()
        {
            for (int i = Count - 1; i > 0; --i)
            {
                RemoveAt(i);
                --Count;
            }
        }

        /// <summary>
        /// Method to know if element is in the list or not.
        /// </summary>
        /// <param name="item">Value of the element.</param>
        /// <returns>Boolean result.</returns>
        public bool Contains(T item)
        {
            var currentElement = head;
            while (currentElement != null)
            { 
                if (currentElement.Data.Equals(item))
                {
                    return true;
                }
                currentElement = currentElement.Next;
            }
            return false;
        }

        /// <summary>
        /// Method to copy list in the array.
        /// </summary>
        /// <param name="array">Current array.</param>
        /// <param name="arrayIndex">Index from which to start copying.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            var currentElement = head;
            for (int i = arrayIndex; i < array.Length; ++i)
            {
                if (currentElement != null)
                {
                    array[i] = currentElement.Data;
                    currentElement = currentElement.Next;
                }
            }
        }

        /// <summary>
        /// Method to get the index of the element by its item.
        /// </summary>
        /// <param name="item">Value of the element.</param>
        /// <returns>Integer index of the element.</returns>
        public int IndexOf(T item)
        {
            var currentElement = head;
            var currIndex = 0;
            while (currentElement != null)
            {
                if (currentElement.Data.Equals(item))
                {
                    return currIndex;
                }
                ++currIndex;
                currentElement = currentElement.Next;
            }
            return -1;
        }

        /// <summary>
        /// Method to insert element by position.
        /// </summary>
        /// <param name="index">Position of the element.</param>
        /// <param name="item">Value of the element.</param>
        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                Console.WriteLine("Index is negative or larger than the list size!");
                return;
            }
            var thisElement = new ElementOfList<T>(item);
            ElementOfList<T> current = head;
            int currentIndex = 0;
            if (index == 0)
            {
                ElementOfList<T> temp = head;
                head = thisElement;
                head.Next = temp;
                ++Count;
            }
            else if (index == Count)
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = thisElement;
                ++Count;
            }
            else
            {
                while (current != null)
                {
                    if (currentIndex == index)
                    {
                        thisElement.Next = current;
                        thisElement.Previous = current.Previous;
                        if (thisElement.Previous != null)
                        {
                            thisElement.Previous.Next = thisElement;
                        }
                        ++Count;
                    }
                    current = current.Next;
                    ++currentIndex;
                }
            }
        }

        /// <summary>
        /// Method to kno
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            var currentElement = head;
            for (int i = 0; i < Count; ++i)
            {
                if (currentElement != null && currentElement.Data.Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
                currentElement = currentElement.Next;
            }
            return false;
        }

        /// <summary>
        /// Method to remove element by its position.
        /// </summary>
        /// <param name="index">Index of the element.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
                Console.WriteLine("Index is negative or larger than the list size!");
                return;
            }
            ElementOfList<T> current = head;
            ElementOfList<T> currentPrevious = null;
            int currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    if (currentPrevious == null)
                    {
                        head = head.Next;
                    }
                    else
                    {
                        currentPrevious.Next = current.Next;
                    }
                    --Count;
                }
                ++currentIndex;
                currentPrevious = current;
                current = current.Next;
            }
        }
        
        /// <summary>
        /// Method to list elements in the list.
        /// </summary>
        /// <returns>Value of the current element.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = head;
            while (currentElement != null)
            {
                yield return currentElement.Data;
                currentElement = currentElement.Next;
            }
        }

        /// <summary>
        /// Method which returns enumerator of the list.
        /// </summary>
        /// <returns>Method to list elements.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
