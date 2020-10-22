﻿using Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogSaverClient
{
    public class LSClient
    {
        private readonly TcpClient client;
        private BinaryWriter writer;
        private BinaryReader reader;

        public LSClient()
        {
            client = new TcpClient();
        }

        ~LSClient()
        {
            client.Close();
        }

        public async Task ConnectAsync(IPAddress address, int port)
        {
            await client.ConnectAsync(address, port);
            writer = new BinaryWriter(client.GetStream());
            reader = new BinaryReader(client.GetStream());
        }

        public void Close()
        {
            client.Close();
        }

        public void SendMessage(LogSaverMessage message)
        {
            writer.Write(message.ToString());
        }

        public async Task<string> AwaitMessageAsync()
        {
            return await Task.Run(() =>
            {
                string response = reader.ReadString();
                return response;
            });
        }
    }
}
