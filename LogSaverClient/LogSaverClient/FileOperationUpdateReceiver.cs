using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSaverClient
{
    public abstract class FileOperationUpdateReceiver
    {
        public event Action<int, int> ProgressUpdated;

        public FileOperationType OperationType { get; private set; }

        protected LSClient Client { get; private set; }
        protected MessageDecoder Decoder { get; private set; }

        public FileOperationUpdateReceiver(
            FileOperationType operationType, LSClient client)
        {
            OperationType = operationType;
            Client = client;
            Decoder = new MessageDecoder();
        }

        public abstract Task HandleOperationUpdates();

        protected void OnProgressUpdated(int numFilesCompleted, int numTotalFiles)
        {
            ProgressUpdated?.Invoke(numFilesCompleted, numTotalFiles);
        }
    }
}
