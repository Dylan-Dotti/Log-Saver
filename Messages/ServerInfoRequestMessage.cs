
namespace Messages
{
    public class ServerInfoRequestMessage : LogSaverMessage
    {
        public ServerInfoRequestMessage() 
            : base(MessageType.ServerInfoRequest)
        { }
    }
}
