using System;
using UniqueListNameSpace;

namespace LinkedList
{
    /// <summary>
    /// Class for the linked list.
    /// </summary>
    public class MyList
    {
        /// <summary>
        /// Private class for element of the list with all nesessary properties.
        /// </summary>
        private class ElementOfList
        {
            /// <summary>
            /// Property for value of the element.
            /// </summary>
            public string Data { get; set; }

            /// <summary>
            /// Property for the next element.
            /// </summary>
            public ElementOfList Next { get; set; }

            /// <summary>
            /// Property for the previous element.
            /// </summary>
            public ElementOfList Previous { get; set; }

            /// <summary>
            /// Constructor that sets value of the element.
            /// </summary>
            /// <param name="data">Value of the element.</param>
            public ElementOfList(string data)
            {
                Data = data;
            }
        }

        /// <summary>
        /// Top of the list.
        /// </summary>
        private ElementOfList Head { get; set; }

        /// <summary>
        /// Property for the size of the list.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Property to find out whether list is empty or not.
        /// </summary>
        public bool IsEmpty => Size == 0;

        /// <summary>
        /// Method for adding elements by its position.
        /// </summary>
        /// <param name="index">Position of the element.</param>
        /// <param name="data">Value of the element.</param>
        public virtual void AddAt(int index, string data)
        {
            if (index < 0 || index > Size)
            {
                Console.WriteLine("Index is negative or larger than the list size!");
                return;
            }
            var thisElement = new ElementOfList(data);
            ElementOfList current = Head;
            int currentIndex = 0;
            if (index == 0)
            {
                ElementOfList temp = Head;
                Head = thisElement;
                Head.Next = temp;
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
            ElementOfList current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        /// <summary>
        /// Method for removing element by its position.
        /// </summary>
        /// <param name="index">Position of the element.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index > Size)
            {
                Console.WriteLine("Index is negative or larger than the list size!");
                return;
            }

            ElementOfList current = Head;
            ElementOfList currentPrevious = null;
            int currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    if (currentPrevious == null)
                    {
                        Head = Head.Next;
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
        /// Method to set value of the element by its position.
        /// </summary>
        /// <param name="index">Position of the element in the list.</param>
        /// <param name="data">Value of the element.</param>
        public virtual void SetValueByPosition(int index, string data)
        {
            if (index < 0 || index > Size)
            {
                throw new ArgumentOutOfRangeException();
            }

            var currentElement = FindingElement(index);
            currentElement.Data = data;
        }

        /// <summary>
        /// Mathod to find element.
        /// </summary>
        /// <param name="index">Position of the element in the list.</param>
        /// <returns>Elemenent to find.</returns>
        private ElementOfList FindingElement(int index)
        {
            var currentElement = Head;
            for (int i = 0; i < index; ++i)
            {
                currentElement = currentElement.Next;
            }
            return currentElement;
        }

        /// <summary>
        /// Method to get element by its position.
        /// </summary>
        /// <param name="index">Position of the element in the list.</param>
        /// <returns>Value of the element.</returns>
        public string GetElementByPosition(int index)
        {
            if (index < 0 || index > Size)
            {
                throw new ArgumentOutOfRangeException();
            }

            var currentElement = FindingElement(index);
            return currentElement.Data;
        }

        /// <summary>
        /// Method for removing element by its value;
        /// </summary>
        /// <param name="data">Value of the element.</param>
        public virtual void RemoveByData(string data)
        {
            var current = Head;
            ElementOfList currentPrevious = null;
            for (int i = 0; i < Size; i++)
            {
                if (current.Data == data)
                {
                   if (currentPrevious == null)
                   {
                        Head = Head.Next;
                        --Size;
                   }
                   else
                   {
                        currentPrevious.Next = current.Next;
                        --Size;
                   }
                }
                currentPrevious = current;
                current = current.Next;
            }
        }

        /// <summary>
        /// Method to find out whether element is in the list or not.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        /// <returns>Bool result.</returns>
        public bool DoesElementExist(string data)
        {
            var currentElement = Head;
            while (currentElement != null)
            {
                if (currentElement.Data == data)
                {
                    return true;
                }
                currentElement = currentElement.Next;
            }
            return false;
        }
    }
}
