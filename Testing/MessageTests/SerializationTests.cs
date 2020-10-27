using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MessageTests
{
    public class SerializationTests
    {
        [Fact]
        public void SerializeZipOperation()
        {
            FileOperationType operationType = FileOperationType.Zip;
            FileOperationStatus operationStatus = FileOperationStatus.Ok;
            int filesCompleted = 50;
            int totalFiles = 100;
        }
    }
}
