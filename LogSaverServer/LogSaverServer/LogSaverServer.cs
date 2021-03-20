using LoggingLibrary;
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
        private readonly ILogger logger;

        public LogSaverServer(IPAddress ip, int port,
            string logSourcePath, string logDestPath,
            ILogger logger)
            : base(ip, port)
        {
            this.logSourcePath = logSourcePath;
            this.logDestPath = logDestPath;
            this.logger = logger;
        }

        protected override void OnServerStarted()
        {
            logger.Log($"Server is running at {IP}...");
        }

        protected override void OnServerStopped()
        {
            logger.Log("Server stopped");
        }

        protected override void OnBeginListen()
        {
            logger.Log("Waiting for a connection...");
        }

        protected override void OnAcceptClient(BinaryTcpClient client)
        {
            logger.Log("Connection received");
            ThreadPool.QueueUserWorkItem(stateInfo =>
            {
                new ClientHandler(
                    client, logSourcePath, logDestPath, logger)
                .HandleClient();
            });
            logger.Log("Created thread for user");
        }
    }
}
