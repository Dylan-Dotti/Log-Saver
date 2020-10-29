using Messages;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LogSaverClient
{
    class TransferOperationUpdateReceiver : FileOperationUpdateReceiver
    {
        private readonly string dstDirectory;
        
        // producer/consumer queue
        private readonly ConcurrentQueue<TransferOperationMessage> operationMessageQueue;
        private readonly AutoResetEvent autoEvent;
        private bool doneReceiving;

        public TransferOperationUpdateReceiver(LSClient client, string dstDirectory) : base(client)
        {
            this.dstDirectory = dstDirectory;
            autoEvent = new AutoResetEvent(false);
            operationMessageQueue = new ConcurrentQueue<TransferOperationMessage>();
        }

        public async override Task HandleOperationUpdates()
        {
            doneReceiving = false;
            // producer thread
            new Thread(ReceivingAndDecodingWork).Start();

            // consumer thread
            await Task.Run(() =>
            {
                // while still receiving or something still in queue
                while (!doneReceiving || !operationMessageQueue.IsEmpty)
                {
                    if (operationMessageQueue.IsEmpty)
                    {
                        Console.WriteLine("Waiting for signal...");
                        autoEvent.WaitOne();
                        Console.WriteLine("Signal received");
                        // wait here until a message is decoded and added to the queue
                    }
                    // create a file from the message
                    if (operationMessageQueue.TryDequeue(out TransferOperationMessage msg))
                    {
                        CreateFileFromMessage(msg);
                        OnProgressUpdated(msg.NumFilesCompleted, msg.NumTotalFiles);
                    }
                }
            });
        }

        private void CreateFileFromMessage(TransferOperationMessage message)
        {
            Console.WriteLine("Creating file: " + message.FileName);
            File.WriteAllBytes(Path.Combine(dstDirectory, message.FileName), message.FileBytes);
        }

        private async void ReceivingAndDecodingWork()
        {
            while (!doneReceiving)
            {
                string message = await Client.AwaitMessageAsync();
                Console.WriteLine("Received file message. Decoding...");
                TransferOperationMessage msgDecoded = 
                    Decoder.DecodeMessage<TransferOperationMessage>(message);
                Console.WriteLine("Decoded file: " + msgDecoded.FileName);
                operationMessageQueue.Enqueue(msgDecoded);
                if (msgDecoded.NumFilesCompleted == msgDecoded.NumTotalFiles)
                {
                    doneReceiving = true;
                }
                autoEvent.Set();
            }
        }
    }
}
