using System;

namespace UniqueListNameSpace
{
    /// <summary>
    /// Class for the exception when user tries to add element that is already in the list.
    /// </summary>
    public class AddSameElementsException : Exception
    {
        /// <summary>
        /// Property for the value of the element which is in the list.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public AddSameElementsException() { }

        /// <summary>
        /// Constructor which inherited property for the message of the exception.
        /// </summary>
        /// <param name="message">Message about exception.</param>
        /// <param name="data">Value that is in the list.</param>
        public AddSameElementsException(string message, string data) 
            : base(message)
        {
            Value = data;
        }
    }
}
