using Newtonsoft.Json;
using System;
using TimeUtilities;

namespace Messages
{
    public class TransferRequestMessage : FileOperationRequestMessage
    {
        [JsonConstructor]
        public TransferRequestMessage(DateTimeRange timeRangeUtc, string[] fullCategories) 
            : base(FileOperationType.Transfer, timeRangeUtc, fullCategories)
        { }
    }
}
