using System;

namespace MyNUnit_task4
{ 
    [Serializable]
    public class TestRunException : Exception
    {
        public TestRunException() { }
        public TestRunException(string message) : base(message) { }
        public TestRunException(string message, Exception inner) : base(message, inner) { }
        protected TestRunException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
