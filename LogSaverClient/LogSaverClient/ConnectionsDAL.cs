using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSaverClient
{
    static class ConnectionsDAL
    {
        private static readonly string filePath = Path.Combine(
                "..", "..", "Data", "connections.json");

        public static IReadOnlyList<ConnectionInfo> GetConnections()
        {
            return LoadConnections();
        }

        public static bool TryAddConnection(ConnectionInfo newConnection)
        {
            if (ConnectionExists(newConnection.ConnectionName))
            {
                return false;
            }
            List<ConnectionInfo> connections = LoadConnections();
            connections.Add(newConnection);
            SaveConnections(connections);
            return true;
        }

        public static bool RemoveConnection(ConnectionInfo connection)
        {
            List<ConnectionInfo> connections = LoadConnections();
            if (connections.Remove(connection))
            {
                SaveConnections(connections);
                return true;
            }
            return false;
        }

        public static ConnectionInfo GetConnectionByName(string connectionName)
        {
            return GetConnections().Single(c => c.ConnectionName == connectionName);
        }

        public static bool ConnectionExists(string connectionName)
        {
            var connections = GetConnections();
            return connections.Any(c => c.ConnectionName == connectionName);
        }

        private static List<ConnectionInfo> LoadConnections()
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<ConnectionInfo>>(json);
        }

        public static void SaveConnections(List<ConnectionInfo> connections)
        {
            string json = JsonConvert.SerializeObject(connections, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
