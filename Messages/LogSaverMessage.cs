
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Messages
{
    public abstract class LogSaverMessage
    {
        public MessageType MType { get; private set; }

        public LogSaverMessage(JObject jsonObject)
        {
            if (!jsonObject.ContainsKey("MessageType"))
                throw new JsonException("Expected key named 'MessageType' but did not find it");
            MType = jsonObject.Value<string>("MessageType").ToMessageType();
        }

        public abstract string ToJsonString();
    }
}
