using Newtonsoft.Json;

namespace Messages
{
    public class TransferRequestMessage : FileOperationRequestMessage
    {
        [JsonConstructor]
        public TransferRequestMessage() : base(FileOperationType.Transfer)
        { }
    }
}
