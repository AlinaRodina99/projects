using System;

namespace CompressArrayNameSpace
{
    /// <summary>
    /// Class for exception when array is empty.
    /// </summary>
    public class EmptyArrayException : Exception
    {
        /// <summary>
        /// Constructor fot exception.
        /// </summary>
        /// <param name="message">Message about empty.</param>
        public EmptyArrayException(string message)
            : base(message)
        {
            
        }
    }
}
