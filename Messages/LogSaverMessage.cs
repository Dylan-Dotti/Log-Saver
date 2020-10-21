using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Messages
{
    public abstract class LogSaverMessage
    {
        public MessageType MsgType { get; private set; }

        public LogSaverMessage(MessageType messageType)
        {
            MsgType = messageType;
        }

        public abstract string ToJsonString();
    }
}
