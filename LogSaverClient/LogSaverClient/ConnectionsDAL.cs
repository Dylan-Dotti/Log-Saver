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
            if (ConnectionExists(newConnection))
            {
                return false;
            }
            var connections = LoadConnections();
            return true;
        }

        public static void RemoveConnection(ConnectionInfo connection)
        {

        }

        public static bool ConnectionExists(ConnectionInfo connection)
        {
            var connections = GetConnections();
            return connections.Any(c => c.ConnectionName == connection.ConnectionName);
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
