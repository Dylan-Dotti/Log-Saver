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

        public override string ToString()
        {
            return ToJObject().ToString();
        }

        public virtual JObject ToJObject()
        {
            JObject jObj = new JObject();
            jObj.Add("MessageType", MsgType.ToString());
            return jObj;
        }
    }
}
