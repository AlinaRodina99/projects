namespace LinkedList
{
    /// <summary>
    /// Class describing the elements of list.
    /// </summary>
    public class ElementOfList
    {
        /// <summary>
        /// Element value property.
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Property to read and set next element.
        /// </summary>
        public ElementOfList Next { get; set; }
        /// <summary>
        /// Property to read and set previous element.
        /// </summary>
        public ElementOfList Previous { get; set; }
        /// <summary>
        /// Property for unique key of element.
        /// </summary>
        public int Key { get; set; }
        /// <summary>
        /// Class constructor that creates an element with its value and unique key.
        /// </summary>
        /// <param name="data">Element value.</param>
        /// <param name="key">Unique key of element.</param>
        public ElementOfList(string data, int key)
        {
            Data = data;
            Key = key;
        }
    }
}

