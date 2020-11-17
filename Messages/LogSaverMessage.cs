using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

namespace Messages
{
    public abstract class LogSaverMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("MessageType", Order = -1, Required = Required.Always)]
        public MessageType MsgType { get; private set; }

        [JsonConstructor]
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
