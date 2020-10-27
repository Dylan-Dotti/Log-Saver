
namespace Messages
{
    class TransferRequestMessage : FileOperationRequestMessage
    {
        public TransferRequestMessage() : base(FileOperationType.Transfer)
        { }
    }
}
