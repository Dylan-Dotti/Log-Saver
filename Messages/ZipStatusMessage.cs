using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Messages
{
    public class ZipStatusMessage : LogSaverMessage
    {
        [JsonProperty("ZippedCount")]
        public int ZippedCount { get; private set; }
        [JsonProperty("TotalFileCount")]
        public int TotalFileCount { get; private set; }

        public ZipStatusMessage(int zippedCount, int totalFileCount) : base(MessageType.ZipStatus)
        {
            ZippedCount = zippedCount;
            TotalFileCount = totalFileCount;
        }

        public override JObject ToJObject()
        {
            JObject jObject = base.ToJObject();
            jObject.Add("ZippedCount", ZippedCount);
            jObject.Add("TotalFileCount", TotalFileCount);
            return jObject;
        }
    }
}
