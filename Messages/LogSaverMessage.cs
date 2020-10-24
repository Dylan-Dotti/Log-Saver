using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Messages
{
    public abstract class LogSaverMessage
    {
        [JsonProperty("MessageType", Order = 1, Required = Required.Default)]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageType MsgType { get; private set; }

        public LogSaverMessage(MessageType messageType)
        {
            MsgType = messageType;
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool indentedFormat)
        {
            return JsonConvert.SerializeObject(this,
                indentedFormat ? Formatting.Indented : Formatting.None);
        }

        public virtual JObject ToJObject()
        {
            JObject jObj = new JObject();
            jObj.Add("MessageType", MsgType.ToString());
            return jObj;
        }
    }
}
