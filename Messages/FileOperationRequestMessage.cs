using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using TimeUtilities;

namespace Messages
{
    public abstract class FileOperationRequestMessage : LogSaverMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("OperationType", Order = 1, Required = Required.Always)]
        public FileOperationType OperationType { get; private set; }

        [JsonProperty("TimeRangeUTC", Order = 2, Required = Required.Always)]
        public DateTimeRange TimeRangeUTC { get; private set; }

        [JsonProperty("FullCategories", Order = 3, Required = Required.Always)]
        public string[] FullCategories { get; private set; }

        [JsonIgnore]
        public DateTimeRange TimeRangeLocal => TimeRangeUTC.ToLocal();

        public FileOperationRequestMessage(FileOperationType operationType,
            DateTimeRange timeRangeUtc, string[] fullCategories) : 
            base(MessageType.FileOperationRequest)
        {
            OperationType = operationType;
            TimeRangeUTC = timeRangeUtc;
            FullCategories = fullCategories;
        }
    }
}
