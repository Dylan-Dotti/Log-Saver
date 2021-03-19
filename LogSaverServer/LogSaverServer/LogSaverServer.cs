using System.Net;
using System.Threading;
using TcpLibrary;
using TopshelfBoilerplate;

namespace LogSaverServer
{
    class LogSaverServer : TcpServer, IServiceWorker
    {
        private readonly string logSourcePath;
        private readonly string logDestPath;

        public LogSaverServer(IPAddress ip, int port,
            string logSourcePath, string logDestPath)
            : base(ip, port)
        {
            this.logSourcePath = logSourcePath;
            this.logDestPath = logDestPath;
        }

        protected override void OnServerStarted()
        {
            FileLogger.Log($"Server is running at {IP}...");
        }

        protected override void OnServerStopped()
        {
            FileLogger.Log("Server stopped");
        }

        protected override void OnBeginListen()
        {
            FileLogger.Log("Waiting for a connection...");
        }

        protected override void OnAcceptClient(BinaryTcpClient client)
        {
            FileLogger.Log("Connection received");
            ThreadPool.QueueUserWorkItem(stateInfo =>
            {
                new ClientHandler(client, logSourcePath, logDestPath).HandleClient();
            });
            FileLogger.Log("Created thread for user");
        }
    }
}
