using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using TopshelfBoilerplate;

namespace LogSaverServer
{
    class LogSaverServer : IServiceWorker
    {
        private readonly IPAddress ip;
        private readonly int port;
        private readonly string logSourcePath;
        private readonly string logDestPath;

        private readonly TcpListener listener;

        public bool IsRunning { get; private set; }

        public LogSaverServer(IPAddress ip, int port,
            string logSourcePath, string logDestPath)
        {
            this.ip = ip;
            this.port = port;
            this.logSourcePath = logSourcePath;
            this.logDestPath = logDestPath;
            listener = new TcpListener(ip, port);
        }

        public void Start()
        {
            listener.Start();
            FileLogger.Log($"Server is running at {ip}...");
            IsRunning = true;
            BeginAcceptTcpClient();
        }

        public void Stop()
        {
            IsRunning = false;
            listener.Stop();
        }

        private void BeginAcceptTcpClient()
        {
            listener.BeginAcceptTcpClient(new AsyncCallback(AcceptClientCallback), listener);
            FileLogger.Log("Waiting for a connection...");
        }

        private void AcceptClientCallback(IAsyncResult result)
        {
            if (IsRunning)
            {
                try
                {
                    TcpListener listenerLocal = (TcpListener)result.AsyncState;
                    BinaryTcpClient client = new BinaryTcpClient(listenerLocal.EndAcceptTcpClient(result));
                    FileLogger.Log("Connection received");
                    ThreadPool.QueueUserWorkItem(stateInfo =>
                    {
                        new ClientHandler(client, logSourcePath, logDestPath).HandleClient();
                    });
                    FileLogger.Log("Created thread for user");
                    BeginAcceptTcpClient();
                }
                catch (Exception e)
                {
                    FileLogger.Log(e.Message + Environment.NewLine +
                        e.StackTrace + Environment.NewLine);
                }
            }
        }
    }
}
