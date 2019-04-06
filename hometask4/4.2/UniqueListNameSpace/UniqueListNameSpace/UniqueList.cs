using LinkedList;

namespace UniqueListNameSpace
{
    public class UniqueList : MyList
    {
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
        /// <summary>
        /// Method for adding elements.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        public void AddToTheUniqueList(string data)
        {
            if (DoesElementExist(data))
            { 
                throw new AddSameElementsException("You can not add this elemet!", data);
            }
            AddAt(Size, data);
        }
        /// <summary>
        /// Method for removing elements.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        public void RemoveFromTheUniqueList(string data)
        {
            if (!DoesElementExist(data))
            {
                throw new RemoveNotExistentElementException("You can not remove this element!", data);
            }
            RemoveByData(data);
        }
    }
}
