using Newtonsoft.Json;
using System;

namespace Messages
{
    public class ZipRequestMessage : FileOperationRequestMessage
    {
        [JsonProperty("ZipFileName", Order = 3, Required = Required.Always)]
        public string ZipFileName { get; private set; }

        [JsonConstructor]
        public ZipRequestMessage(string zipFileName, (DateTime lowerBound, DateTime upperBound) timeRangeUtc) 
            : base(FileOperationType.Zip, timeRangeUtc)
        {
            ZipFileName = zipFileName;
        }
    }
}
