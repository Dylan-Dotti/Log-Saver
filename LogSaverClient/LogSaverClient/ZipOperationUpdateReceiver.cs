using Messages;
using System.Threading.Tasks;

namespace LogSaverClient
{
    public class ZipOperationUpdateReceiver : FileOperationUpdateReceiver
    {
        public ZipOperationUpdateReceiver(LSClient client) : base(client)
        { }

        public async override Task HandleOperationUpdates()
        {
            while (true)
            {
                string message = await Client.AwaitMessageAsync();
                ZipOperationMessage msgDecoded = Decoder.DecodeMessage<ZipOperationMessage>(message);
                OnProgressUpdated(msgDecoded.NumFilesCompleted, msgDecoded.NumTotalFiles);
                if (msgDecoded.NumFilesCompleted == msgDecoded.NumTotalFiles) break;
            }
        }
    }
}
