using Newtonsoft.Json;

namespace Messages
{
    public class ZipRequestMessage : FileOperationRequestMessage
    {
        [JsonProperty("ZipFileName", Order = 2, Required = Required.Always)]
        public string ZipFileName { get; private set; }

        [JsonConstructor]
        public ZipRequestMessage(string zipFileName) : base(FileOperationType.Zip)
        {
            ZipFileName = zipFileName;
        }
    }
}
