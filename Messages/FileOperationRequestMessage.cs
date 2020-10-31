﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Messages
{
    public abstract class FileOperationRequestMessage : LogSaverMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("OperationType", Order = 1)]
        public FileOperationType OperationType { get; private set; }

        public FileOperationRequestMessage(FileOperationType operationType) : 
            base(MessageType.FileOperationRequest)
        {
            OperationType = operationType;
        }
    }
}