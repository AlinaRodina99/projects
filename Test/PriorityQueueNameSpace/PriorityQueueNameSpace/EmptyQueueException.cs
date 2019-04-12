using System;

namespace PriorityQueueNameSpace
{
    public class EmptyQueueException : Exception
    {
        public EmptyQueueException(string message)
            : base(message)
        {

        }
    }
}
