using Newtonsoft.Json;
using TimeUtilities;

namespace Messages
{
    public class ZipRequestMessage : FileOperationRequestMessage
    {
        [JsonProperty("ZipFileName", Order = 4, Required = Required.Always)]
        public string ZipFileName { get; private set; }

        [JsonConstructor]
        public ZipRequestMessage(string zipFileName, 
            DateTimeRange timeRangeUtc, string[] fullCategories) 
            : base(FileOperationType.Zip, timeRangeUtc, fullCategories)
        {
            ZipFileName = zipFileName;
        }
    }
}
