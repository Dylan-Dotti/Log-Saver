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
        private static List<ConnectionInfo> connectionCache;

        static ConnectionsDAL()
        {
            LoadConnections();
        }

        public static IReadOnlyList<ConnectionInfo> GetConnections()
        {
            return connectionCache;
        }

        public static bool TryAddConnection(ConnectionInfo newConnection)
        {
            if (ConnectionExists(newConnection.ConnectionName))
            {
                return false;
            }
            connectionCache.Add(newConnection);
            SaveConnections();
            return true;
        }

        public static bool EditConnection(ConnectionInfo connection,
            string newName, string newIP)
        {
            if (!ConnectionExists(connection.ConnectionName))
            {
                return false;
            }
            int index = connectionCache.IndexOf(connection);
            connectionCache[index] = new ConnectionInfo(newName, newIP);
            SaveConnections();
            return true;
        }

        public static bool RemoveConnection(ConnectionInfo connection)
        {
            if (connectionCache.Remove(connection))
            {
                SaveConnections();
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

        private static void LoadConnections()
        {
            string json = File.ReadAllText(filePath);
            connectionCache = JsonConvert.DeserializeObject<List<ConnectionInfo>>(json);
        }

        private static void SaveConnections()
        {
            string json = JsonConvert.SerializeObject(
                connectionCache, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
