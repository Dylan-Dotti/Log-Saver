using Newtonsoft.Json;

namespace Messages
{
    public class TransferOperationMessage : FileOperationMessage
    {
        [JsonProperty(Order = 5, Required = Required.Always)]
        public string FileName { get; private set; }

        [JsonProperty(Order = 6, Required = Required.Always)]
        public byte[] FileBytesCompressed { get; private set; }

        public TransferOperationMessage(int numFilesCompleted, int numTotalFiles, string errorMessage)
            : this(numFilesCompleted, numTotalFiles, errorMessage, "", new byte[]{})
        { }

        public TransferOperationMessage(int numFilesCompleted, int numTotalFiles,
            string fileName, byte[] fileBytes)
            : this(numFilesCompleted, numTotalFiles, "", fileName, fileBytes)
        { }

        [JsonConstructor]
        private TransferOperationMessage(int numFilesCompleted, int numTotalFiles,
            string errorMessage, string fileName, byte[] fileBytesCompressed)
            : base(FileOperationType.Transfer, numFilesCompleted, numTotalFiles, errorMessage)
        {
            FileName = fileName;
            FileBytesCompressed = fileBytesCompressed;
        }
    }
}
