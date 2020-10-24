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

        private TcpListener listener;
        private ManualResetEvent tcpClientConnected;

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
            while (true)
            {
                BeginAcceptTcpClient();
                Console.WriteLine("After begin accept in start");
            }
            /*listener.Start();
            Console.WriteLine($"The server is running at {ip}...");

            while (true)
            {
                using (TcpClient client = listener.AcceptTcpClient())
                {
                    // blocks here until a client connects
                    Console.WriteLine("Received connection.");
                    // start new thread to handle the client's requests, then go back to listening
                    new Thread(() => new ClientHandler(client, logSourcePath, logDestPath).HandleClient()).Start();
                }
            }*/
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
            Console.WriteLine("After wait one");
        }

        private void AcceptClientCallback(IAsyncResult result)
        {
            TcpListener listenerLocal = (TcpListener)result.AsyncState;
            TcpClient client = listenerLocal.EndAcceptTcpClient(result);
            new Thread(() => new ClientHandler(client, logSourcePath, logDestPath).HandleClient()).Start();
            Console.WriteLine("Made thread for client");
            tcpClientConnected.Set();
            Console.WriteLine("Set value. exiting");
            //BeginAcceptTcpClient();
        }
    }
}
