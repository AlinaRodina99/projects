using LinkedList;

namespace UniqueListNameSpace
{
    public class UniqueList : MyList
    {
        /// <summary>
        /// Method for adding elements.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        public void AddToTheUniqueList(string data)
        {
            AddAt(Size, data);
        }

        /// <summary>
        /// Method for removing elements.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        public void RemoveFromTheUniqueList(string data)
        {
            RemoveByData(data);
        }
    }
}
