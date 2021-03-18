using FileUtilities;
using Messages;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace LogSaverClient
{
    class TransferOperationUpdateReceiver : FileOperationUpdateReceiver
    {
        private readonly string folderPath;
        private readonly bool zipLocal;
        
        // producer/consumer queue
        private readonly ConcurrentQueue<TransferOperationMessage> operationMessageQueue;
        private readonly AutoResetEvent autoEvent;
        private bool doneReceiving;

        public TransferOperationUpdateReceiver(
            LSClient client, string folderPath, bool zipLocal) 
            : base(FileOperationType.Transfer, client)
        {
            this.folderPath = folderPath;
            this.zipLocal = zipLocal;
            autoEvent = new AutoResetEvent(false);
            operationMessageQueue = new ConcurrentQueue<TransferOperationMessage>();
        }

        public async override Task HandleOperationUpdates()
        {
            doneReceiving = false;
            // producer thread
            ThreadPool.QueueUserWorkItem(ReceivingAndDecodingWork);

            // consumer thread
            await Task.Run(() =>
            {
                // while still receiving or something still in queue
                while (!doneReceiving || !operationMessageQueue.IsEmpty)
                {
                    if (operationMessageQueue.IsEmpty)
                    {
                        autoEvent.WaitOne();
                        // wait here until a message is decoded and added to the queue
                    }
                    // create a file from the message
                    if (operationMessageQueue.TryDequeue(out TransferOperationMessage msg))
                    {
                        string filePath = Path.Combine(folderPath, msg.FileName);
                        Console.WriteLine("Decompressing: " + msg.FileName);
                        byte[] bytesUncompressed = ByteCompression.GZipDecompress(
                            msg.FileBytesCompressed);
                        if (zipLocal)
                        {
                            using (ZipArchive archive = ZipFile.Open(folderPath, ZipArchiveMode.Update))
                            {
                                var zipEntry = archive.CreateEntry(msg.FileName);
                                using (var originalFileStream = new MemoryStream(bytesUncompressed))
                                using (var zipEntryStream = zipEntry.Open())
                                {
                                    //Copy the attachment stream to the zip entry stream
                                    originalFileStream.CopyTo(zipEntryStream);
                                }
                            }
                        }
                        else
                        {
                            CreateLogFile(filePath, bytesUncompressed);
                        }
                        OnProgressUpdated(msg.NumFilesCompleted, msg.NumTotalFiles);
                    }
                }
            });
        }

        private void CreateLogFile(string filePath, byte[] fileBytes)
        {
            Console.WriteLine("Creating file: " + filePath);
            File.WriteAllBytes(filePath, fileBytes);
        }

        private async void ReceivingAndDecodingWork(object state)
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
