using Newtonsoft.Json;

namespace Messages
{
    public class ZipOperationMessage : FileOperationMessage
    {
        public ZipOperationMessage(int numFilesCompleted, int numTotalFiles)
            : this(numFilesCompleted, numTotalFiles, "")
        { }

        [JsonConstructor]
        public ZipOperationMessage(int numFilesCompleted, int numTotalFiles, string errorMessage)
            : base(FileOperationType.Zip, numFilesCompleted, numTotalFiles, errorMessage)
        { }
    }
}
