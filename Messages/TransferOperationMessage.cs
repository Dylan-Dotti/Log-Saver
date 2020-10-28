using Newtonsoft.Json;

namespace Messages
{
    public class TransferOperationMessage : FileOperationMessage
    {
        public TransferOperationMessage(int numFilesCompleted, int numTotalFiles, string errorMessage)
            : this(numFilesCompleted, numTotalFiles, errorMessage, "", new byte[]{})
        { }

        public TransferOperationMessage(int numFilesCompleted, int numTotalFiles,
            string fileName, byte[] fileBytes)
            : this(numFilesCompleted, numTotalFiles, "", fileName, fileBytes)
        { }

        [JsonConstructor]
        private TransferOperationMessage(int numFilesCompleted, int numTotalFiles,
            string errorMessage, string fileName, byte[] fileBytes)
            : base(FileOperationType.Transfer, numFilesCompleted, numTotalFiles, errorMessage)
        {
            FileName = fileName;
            FileBytes = fileBytes;
        }

        [JsonProperty(Order = 5)]
        public string FileName { get; private set; }

        [JsonProperty(Order = 6)]
        public byte[] FileBytes { get; private set; }
    }
}
