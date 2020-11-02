using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Messages
{
    public abstract class FileOperationRequestMessage : LogSaverMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("OperationType", Order = 1)]
        public FileOperationType OperationType { get; private set; }

        [JsonProperty("TimeRangeUTC", Order = 2)]
        public (DateTime lowerBound, DateTime upperBound) TimeRangeUTC { get; private set; }

        [JsonIgnore]
        public (DateTime lowerBound, DateTime upperBound) TimeRangeLocal =>
            (TimeRangeUTC.lowerBound.ToLocalTime(), TimeRangeUTC.upperBound.ToLocalTime());

        public FileOperationRequestMessage(FileOperationType operationType,
            (DateTime lowerBound, DateTime upperBound) timeRangeUtc) : 
            base(MessageType.FileOperationRequest)
        {
            OperationType = operationType;
            TimeRangeUTC = timeRangeUtc;
        }
    }
}
