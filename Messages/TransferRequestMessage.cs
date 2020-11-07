using Newtonsoft.Json;
using System;

namespace Messages
{
    public class TransferRequestMessage : FileOperationRequestMessage
    {
        [JsonConstructor]
        public TransferRequestMessage((DateTime, DateTime) timeRangeUtc, string[] fullCategories) 
            : base(FileOperationType.Transfer, timeRangeUtc, fullCategories)
        { }
    }
}
