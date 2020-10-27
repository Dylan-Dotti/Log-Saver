using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Messages
{
    public class FileOperationMessage : LogSaverMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("OperationType", Order = 1)]
        public FileOperationType OperationType { get; private set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("OperationStatus", Order = 2)]
        public FileOperationStatus OperationStatus { get; private set; }

        [JsonProperty("NumFilesCompleted", Order = 3)]
        public int NumFilesCompleted { get; private set; }

        [JsonProperty("TotalNumFiles", Order = 4)]
        public int NumTotalFiles { get; private set; }

        [JsonProperty("ErrorMessage", Order = 5)]
        public string ErrorMessage { get; private set; }

        public FileOperationMessage(
            FileOperationType operationType, FileOperationStatus operationStatus,
            int numFilesCompleted, int numTotalFiles, string errorMessage) 
            : base(MessageType.FileOperation)
        {
            if (numTotalFiles < numFilesCompleted)
                throw new ArgumentException("numTotalFiles should not be less than numFilesCompleted");
            OperationType = operationType;
            OperationStatus = operationStatus;
            NumFilesCompleted = numFilesCompleted;
            NumTotalFiles = numTotalFiles;
            ErrorMessage = errorMessage;
        }
    }
}
