using System;

namespace UniqueListNameSpace
{
    /// <summary>
    /// Class for exception when user tries to remove nonexistent element from the list.
    /// </summary>
    public class RemoveNotExistentElementException : Exception
    {
        /// <summary>
        /// Value of the nonexistent element.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public RemoveNotExistentElementException() { }

        /// <summary>
        /// Consrtuctor which inherited property for the message of the exception.
        /// </summary>
        /// <param name="message">Message about exception.</param>
        /// <param name="data">Value that is not in the list.</param>
        public RemoveNotExistentElementException(string message, string data)
            :base(message)
        {
            Value = data;
        }
    }
}
