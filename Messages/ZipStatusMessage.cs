using Newtonsoft.Json.Linq;

namespace Messages
{
    class ZipStatusMessage : LogSaverMessage
    {
        public int ZippedCount { get; private set; }
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
