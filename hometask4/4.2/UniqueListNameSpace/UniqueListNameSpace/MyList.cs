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
        protected class ElementOfList
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
        protected ElementOfList Head { get; private set; }

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
        public void AddAt(int index, string data)
        {
            if (DoesElementExist(data))
            {
                throw new AddSameElementsException("You can not add this element!",data);
            }
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
        /// Indexor for getting element by its position and setting value of the element.
        /// </summary>
        /// <param name="index">Position of the element.</param>
        /// <returns>String value of the element.</returns>
        public string this[int index]
        {
            get
            {
                if (GetElement(index) == null)
                {
                    return "Index is negative or larger than the list size!";
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
        /// Method which is used in indexor.
        /// </summary>
        /// <param name="index">Position of the element.</param>
        /// <returns>Current element.</returns>
        private ElementOfList GetElement(int index)
        {
            if (index < 0 || index > Size)
            {
                return default(ElementOfList);
            }
            ElementOfList current = Head;
            for (int i = 0; i < index; ++i)
            {
                current = current.Next;
            }
            return current;
        }

        /// <summary>
        /// Method for removing element by its value;
        /// </summary>
        /// <param name="data">Value of the element.</param>
        public void RemoveByData(string data)
        {
            if (!DoesElementExist(data))
            {
                throw new RemoveNotExistentElementException("You can not remove this element!", data);
            }
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
