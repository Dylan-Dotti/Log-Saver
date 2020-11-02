using Newtonsoft.Json;
using System;

namespace Messages
{
    public class TransferRequestMessage : FileOperationRequestMessage
    {
        [JsonConstructor]
        public TransferRequestMessage((DateTime, DateTime) timeRangeUtc) 
            : base(FileOperationType.Transfer, timeRangeUtc)
        { }
    }
}
