using System;
using LinkedList;

namespace UniqueListNameSpace
{
    public class UniqueList : MyList
    {
        /// <summary>
        /// Method for adding elements.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        public override void AddAt(int index, string data)
        {
            if (DoesElementExist(data))
            {
                throw new AddSameElementsException("You can not add this element!", data);
            }
            base.AddAt(index, data);
        }

        /// <summary>
        /// Method for removing elements.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        public override void RemoveByData(string data)
        {
            if (!DoesElementExist(data))
            {
                throw new RemoveNotExistentElementException("You can not remove this element!", data);
            }
            base.RemoveByData(data);
        }

        /// <summary>
        /// Override method to set elements by its position.
        /// </summary>
        /// <param name="index">Index of the element in unique list.</param>
        /// <returns>Value of the element.</returns>
        public override string this[int index]
        {
            get => base[index];
            set
            {
                string currentElement;
                if (!IsEmpty)
                {
                    currentElement = GetElement(index).Data;
                    if (currentElement != null && DoesElementExist(currentElement))
                    {
                        throw new AddSameElementsException("You can not add this element!", GetElement(index).Data);
                    }
                }
                base[index] = value;
            }
        }
    }
}
