using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Messages
{
    public abstract class LogSaverMessage
    {
        [JsonProperty(Order = -2, Required = Required.Always)]
        public int MessageID { get; private set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("MessageType", Order = -1, Required = Required.Always)]
        public MessageType MsgType { get; private set; }

        public LogSaverMessage(MessageType messageType)
            :this(messageType, new Random().Next(1, 101))
        { }

        [JsonConstructor]
        public LogSaverMessage(MessageType messageType, int messageID)
        {
            MessageID = messageID;
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
