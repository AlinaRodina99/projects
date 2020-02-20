using System;

namespace MyThreadPool
{
    /// <summary>
    /// Class for exception when task is being tried to add to the queue of tasks.
    /// </summary>
    [Serializable]
    public class ThreadPoolException : Exception
    {
        public ThreadPoolException() { }

        public ThreadPoolException(string message)
            : base(message) { }

        public ThreadPoolException(string message, Exception inner)
            : base(message, inner) { }

        protected ThreadPoolException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
             : base(info, context) { }
    }
}
