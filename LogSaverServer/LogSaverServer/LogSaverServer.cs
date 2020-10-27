﻿using System;
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
            listener.Start();
            Console.WriteLine($"Server is running at {ip}...");
            while (true)
            {
                BeginAcceptTcpClient();
            }
        }

        public void Stop()
        {
            listener.Stop();
        }

        private void BeginAcceptTcpClient()
        {
            tcpClientConnected.Reset();
            Console.WriteLine("Waiting for a connection...");
            listener.BeginAcceptTcpClient(new AsyncCallback(AcceptClientCallback), listener);
            tcpClientConnected.WaitOne();
        }

        private void AcceptClientCallback(IAsyncResult result)
        {
            Console.WriteLine("Connection received");
            TcpListener listenerLocal = (TcpListener)result.AsyncState;
            TcpClient client = listenerLocal.EndAcceptTcpClient(result);
            new Thread(() => new ClientHandler(client, logSourcePath, logDestPath).HandleClient()).Start();
            tcpClientConnected.Set();
        }
    }
}
