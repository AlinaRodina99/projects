using System;

namespace LinkedList
{
    class MyList
    {
        /// <summary>
        /// Private class of the element of the list.
        /// </summary>
        private class ElementOfList
        {
            public string Data { get; set; }
            public ElementOfList Next { get; set; }
            public ElementOfList Previous { get; set; }
            public int Key { get; set; }
            public ElementOfList(string data, int key)
            {
                Key = key;
                Data = data;
            }
        }

        /// <summary>
        /// Top of the list.
        /// </summary>
        private ElementOfList head;

        /// <summary>
        /// Property for the size of the list.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Property to find out whether list is empty or not.
        /// </summary>
        public bool IsEmpty => Size == 0;

        /// <summary>
        /// Method of adding elements to the list by its position and its key.
        /// </summary>
        /// <param name="index">Position of the element.</param>
        /// <param name="data">String value.</param>
        /// <param name="key">Key of the element.</param>
        public void AddAt(int index, string data, int key)
        {
            if (index < 0 || index > Size)
            {
                Console.WriteLine("Index is negative or larger than the list size!");
                return;
            }
            var thisElement = new ElementOfList(data, key);
            ElementOfList current = head;
            int currentIndex = 0;
            if (index == 0)
            {
                ElementOfList temp = head;
                head = thisElement;
                head.Next = temp;
                ++Size;
            }
            else if (index == Size)
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = thisElement;
                ++Size;
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
                        ++Size;
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
            var current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        /// <summary>
        /// Method for removing elements by its position.
        /// </summary>
        /// <param name="index">Position of the element.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index > Size)
            {
                Console.WriteLine("Index is negative or larger than the list size!");
                return;
            }
            var current = head;
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
                    --Size;
                }
                ++currentIndex;
                currentPrevious = current;
                current = current.Next;
            }
        }

        /// <summary>
        /// Method for removing elements by its key.
        /// </summary>
        /// <param name="key">Key of the element.</param>
        public void Remove(int key)
        {
            var currentElement = head;
            for (int i = 0; i < Size; ++i)
            {
                if (currentElement.Key == key)
                {
                    string currentData = currentElement.Data;
                    RemoveFromTheList(currentData);
                }
                currentElement = currentElement.Next;
            }
        }

        /// <summary>
        /// Method for finding value by its key which is used in method of hash-table.
        /// </summary>
        /// <param name="key">Key of the element.</param>
        /// <returns>Bool result if there is current value in the list.</returns>
        public bool FindValueInList(int key)
        {
            var currentElement = head;
            for (int i = 0; i < Size; ++i)
            {
                if (currentElement.Key == key)
                {
                    return true;
                }
                currentElement = currentElement.Next;
            }
            return false;
        }

        /// <summary>
        /// Method for removing elements by its data.
        /// </summary>
        /// <param name="data">String value.</param>
        private void RemoveFromTheList(string data)
        {
            var currentElement = head;
            ElementOfList previous = null;
            while (currentElement != null)
            {
                if (currentElement.Data == data)
                {
                    if (previous != null)
                    {
                        previous.Next = currentElement.Next;
                    }
                    else
                    {
                        head = head.Next;
                    }
                    --Size;
                }
                previous = currentElement;
                currentElement = currentElement.Next;
            }
        }
    }
}

