using Newtonsoft.Json;
using System;

namespace Messages
{
    public class ZipRequestMessage : FileOperationRequestMessage
    {
        [JsonProperty("ZipFileName", Order = 4, Required = Required.Always)]
        public string ZipFileName { get; private set; }

        [JsonConstructor]
        public ZipRequestMessage(string zipFileName, 
            (DateTime lowerBound, DateTime upperBound) timeRangeUtc, string[] fullCategories) 
            : base(FileOperationType.Zip, timeRangeUtc, fullCategories)
        {
            ZipFileName = zipFileName;
        }
    }
}
