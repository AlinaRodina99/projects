using System;

namespace LinkedList
{
    /// <summary>
    /// Class of list which contains different values with standard methods:
    /// Pop, Push, Peek.
    /// </summary>
    public class MyList
    {
        /// <summary>
        /// Head of the list.
        /// </summary>
        private ElementOfList head;
        /// <summary>
        /// Size of the list.
        /// </summary>
        private int size;
        /// <summary>
        /// Class constructor initializing list size to zero.
        /// </summary>
        public MyList()
        {
            size = 0;
        }
        /// <summary>
        ///List size read-only properties.
        /// </summary>
        public int Size
        {
            get
            {
                return size;
            }
        }
        /// <summary>
        /// Read-only head properties.
        /// </summary>
        public ElementOfList Head
        {
            get
            {
                return head;
            }
        }
        /// <summary>
        ///Property to check the list for emptiness.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return size == 0;
            }
        }
        /// <summary>
        /// Method for adding elements by position in list.
        /// </summary>
        /// <param name="index">Position of element in list.</param>
        /// <param name="data">Element value.</param>
        /// <param name="key">Unique key of element.</param>
        public void AddAt(int index, string data, int key)
        {
            ElementOfList thisElement = new ElementOfList(data, key);
            ElementOfList current = head;
            int currentIndex = 0;
            if (index == 0)
            {
                ElementOfList temp = head;
                head = thisElement;
                head.Next = temp;
                ++size;
            }
            else if (index == size)
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = thisElement;
                ++size;
            }
            else
            {
                while (current != null)
                {
                    if (currentIndex == index)
                    {
                        ElementOfList currentPrevios = current.Previous;
                        current.Previous = thisElement;
                        ElementOfList newElement = current.Previous;
                        newElement.Next = current;
                        newElement.Previous = currentPrevios;
                        if (currentPrevios != null)
                        {
                            currentPrevios.Next = newElement;
                        }
                        ++size;
                    }
                    current = current.Next;
                }
            }
        }
        /// <summary>
        /// Method for printing list.
        /// </summary>
        public void PrintList()
        {
            ElementOfList current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        /// <summary>
        /// Method for removing elements by position.
        /// </summary>
        /// <param name="index">Position of element in list.</param>
        public void RemoveAt(int index)
        {
            ElementOfList current = head;
            ElementOfList currentPrevious = null;
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
                    --size;
                }
                ++currentIndex;
                currentPrevious = current;
                current = current.Next;
            }
        }
        /// <summary>
        ///indexer for getting element by position.
        /// </summary>
        /// <param name="index">Position of element in list.</param>
        /// <returns></returns>
        public string this[int index]
        {
            get
            {
                ElementOfList current = head;
                for (int i = 0; i < index; ++i)
                {
                    current = current.Next;
                }
                if (current != null)
                {
                    return current.Data;
                }
                else
                {
                    Console.WriteLine("Element was not found!");
                    return default(string);
                }
            }
            set
            {
                ElementOfList current = head;
                for (int i = 0; i < index; ++i)
                {
                    current = current.Next;
                }
                current.Data = value;
            }
        }
        /// <summary>
        /// Method for removing elements by data.
        /// </summary>
        /// <param name="data">Element value.</param>
        public void Remove(string data)
        {
            ElementOfList currentElement = head;
            ElementOfList previous = null;
            while (currentElement != null)
            {
                if (currentElement.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = currentElement.Next;
                    }
                    else
                    {
                        head = head.Next;
                    }
                    --size;
                }
                previous = currentElement;
                currentElement = currentElement.Next;
            }
        }
    }
}

