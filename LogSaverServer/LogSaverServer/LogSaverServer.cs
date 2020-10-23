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

        public LogSaverServer(IPAddress ip, int port,
            string logSourcePath, string logDestPath)
        {
            this.ip = ip;
            this.port = port;
            this.logSourcePath = logSourcePath;
            this.logDestPath = logDestPath;
        }

        public void StartServer()
        {
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();
            Console.WriteLine($"The server is running at {ip}:{port}...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                // blocks here until a client connects
                Console.WriteLine("Received connection.");
                // start new thread to handle the client's requests, then go back to listening
                new Thread(() => new ClientHandler(client, logSourcePath, logDestPath).HandleClient()).Start();
            }
        }
    }
}
