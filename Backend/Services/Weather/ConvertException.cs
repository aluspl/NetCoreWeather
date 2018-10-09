using System;
using System.Runtime.Serialization;

namespace Backend.Services.Weather
{
    [Serializable]
    public class ConvertException : Exception
    {
        public ConvertException()
        {
        }

        public ConvertException(string message) : base(message)
        {
            this.CustomMessage = message;
        }

        public ConvertException(string message, Exception innerException) : base(message, innerException)
        {
            this.CustomMessage = message+ innerException.Message;
           
        }

        protected ConvertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public override string ToString()
        {
            return CustomMessage;
        }
        public string CustomMessage { get;  set; }
        public string Code { get;  set; }
    }
}