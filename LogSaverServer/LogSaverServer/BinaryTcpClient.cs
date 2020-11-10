using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;

namespace LogSaverServer
{
    class BinaryTcpClient
    {
        public TcpClient Client { get; private set; }
        public BinaryReader Reader { get; private set; }
        public BinaryWriter Writer { get; private set; }

        public BinaryTcpClient(TcpClient client)
        {
            Client = client;
            Reader = new BinaryReader(client.GetStream());
            Writer = new BinaryWriter(client.GetStream());
        }
    }
}
