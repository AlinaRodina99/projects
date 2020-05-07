using System;

namespace GUIforFTP
{
    [Serializable]
    public class FtpClientException : Exception
    {
        public FtpClientException() { }
        public FtpClientException(string message) : base(message) { }
        public FtpClientException(string message, Exception inner) : base(message, inner) { }
        protected FtpClientException(
           System.Runtime.Serialization.SerializationInfo info,
           System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        
    }
}
