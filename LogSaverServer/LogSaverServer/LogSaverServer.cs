using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LogSaverServer
{
    class LogSaverServer
    {
        private readonly IPAddress ip;
        private readonly int port;
        private readonly string logSourcePath;
        private readonly string logDestPath;

        private readonly TcpListener listener;
        private readonly ManualResetEvent tcpClientConnected;

        public bool IsRunning { get; private set; }

        public LogSaverServer(IPAddress ip, int port,
            string logSourcePath, string logDestPath)
        {
            this.ip = ip;
            this.port = port;
            this.logSourcePath = logSourcePath;
            this.logDestPath = logDestPath;
            listener = new TcpListener(ip, port);
            tcpClientConnected = new ManualResetEvent(false);
        }

        public void Start()
        {
            ThreadPool.QueueUserWorkItem(stateInfo =>
            {
                listener.Start();
                FileLogger.Log($"Server is running at {ip}...");
                IsRunning = true;
                while (IsRunning)
                {
                    BeginAcceptTcpClient();
                }
                FileLogger.Log("Exited server loop");
            });
        }

        public void Stop()
        {
            IsRunning = false;
            listener.Stop();
        }

        private void BeginAcceptTcpClient()
        {
            tcpClientConnected.Reset();
            FileLogger.Log("Waiting for a connection...");
            listener.BeginAcceptTcpClient(new AsyncCallback(AcceptClientCallback), listener);
            tcpClientConnected.WaitOne();
        }

        private void AcceptClientCallback(IAsyncResult result)
        {
            if (IsRunning)
            {
                try
                {
                    TcpListener listenerLocal = (TcpListener)result.AsyncState;
                    TcpClient client = listenerLocal.EndAcceptTcpClient(result);
                    FileLogger.Log("Connection received");
                    FileLogger.Log("Creating thread for user...");
                    ThreadPool.QueueUserWorkItem(stateInfo =>
                    {
                        new ClientHandler(client, logSourcePath, logDestPath).HandleClient();
                    });
                    FileLogger.Log("Created thread for user");
                }
                catch (Exception e)
                {
                    FileLogger.Log(e.Message);
                    FileLogger.Log(e.StackTrace);
                }
            }
            else
            {
                FileLogger.Log("Server is no longer running. Stopped listening for connections");
            }
            tcpClientConnected.Set();
        }
    }
}
