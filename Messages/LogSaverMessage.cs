using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Messages
{
    public abstract class LogSaverMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("MessageType", Order = -1, Required = Required.Default)]
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
    }

    public static class LogSaverMessageExtensions
    {
        public static void Write(this BinaryWriter writer, LogSaverMessage message)
        {
            writer.Write(message.ToString());
        }
    }
}
