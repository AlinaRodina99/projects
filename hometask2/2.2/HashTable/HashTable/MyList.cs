using System;

namespace LinkedList
{
    class MyList
    {
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

        private ElementOfList head;

        public int Size { get; private set; }

        public bool IsEmpty => Size == 0;

        public void AddAt(int index, string data, int key)
        {
            if (index < 0 || index > Size)
            {
                Console.WriteLine("Index is negative or larger than the list size!");
            }
            else
            {
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
        }

        public void PrintList()
        {
            var current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > Size)
            {
                Console.WriteLine("Index is negative or larger than the list size!");
            }
            else
            {
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
        }

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

