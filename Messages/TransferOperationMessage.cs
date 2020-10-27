using Newtonsoft.Json;

namespace Messages
{
    public class TransferOperationMessage : FileOperationMessage
    {
        public TransferOperationMessage(int numFilesCompleted, int numTotalFiles) 
            : this(numFilesCompleted, numTotalFiles, "", new byte[] { })
        { }

        public TransferOperationMessage(int numFilesCompleted, int numTotalFiles, string errorMessage)
            : this(numFilesCompleted, numTotalFiles, errorMessage, new byte[] { })
        { }

        public TransferOperationMessage(int numFilesCompleted, int numTotalFiles, byte[] fileBytes)
            : this(numFilesCompleted, numTotalFiles, "", fileBytes)
        { }

        [JsonConstructor]
        private TransferOperationMessage(int numFilesCompleted, int numTotalFiles,
            string errorMessage, byte[] fileBytes)
            : base(FileOperationType.Transfer, numFilesCompleted, numTotalFiles, errorMessage)
        {
            FileBytes = fileBytes;
        }

        public byte[] FileBytes { get; private set; }
    }
}
