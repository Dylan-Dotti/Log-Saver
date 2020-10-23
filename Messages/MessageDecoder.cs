using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages
{
    public class MessageDecoder
    {
        public T DecodeMessage<T>(string message) where T : LogSaverMessage
        {
            Console.WriteLine($"Decoding message: " + message);
            return JsonConvert.DeserializeObject<T>(message);
        }
    }

    public class MessageDecodingException : Exception
    {
        public MessageDecodingException(MessageType decodeType) : 
            base ("Could not decode message to " + decodeType)
        {

        }

        public MessageDecodingException(string message) : base(message)
        {

        }
    }
}
