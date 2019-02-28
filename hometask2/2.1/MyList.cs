using System;

namespace LinkedList
{
    class MyList
    {
        private ElementOfList head;
        private int size;
        public MyList()
        {
            size = 0;
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return size == 0;
            }
        }

        public void AddAt(int index, string data)
        {
            ElementOfList thisElement = new ElementOfList(data);
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

        public string this[int index]
        {
            get
            {
                ElementOfList current = head;
                for (int i = 0; i < index; ++i)
                {
                    current = current.Next;
                }
                return current.Data;
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
    }
}
