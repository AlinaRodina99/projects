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
            public ElementOfList(string data)
            {
                Data = data;
            }
        }

        private ElementOfList head;

        public int Size { get; private set; }

        public bool IsEmpty => Size == 0;

        public void AddAt(int index, string data)
        {
            if (index < 0 || index > Size)
            {
                Console.WriteLine("Index is negative or larger than the list size!");
                return;
            }
            var thisElement = new ElementOfList(data);
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

        public void PrintList()
        {
            ElementOfList current = head;
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
                return;
            }
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
                    --Size;
                }
                ++currentIndex;
                currentPrevious = current;
                current = current.Next;
            }
        }

        public string this[int index]
        {
            get => GetElement(index);
            set 
            {
                string currentElement = value;
            }
        }

        private string GetElement(int index)
        {
            if (index < 0 || index > Size)
            {
                return "Your index is negative or larger than the list size!";
            }
            else
            {
                ElementOfList current = head;
                for (int i = 0; i < index; ++i)
                {
                    current = current.Next;
                }
                return current.Data;
            }
        }
    }
}
