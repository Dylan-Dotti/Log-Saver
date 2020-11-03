using Newtonsoft.Json;

namespace LogSaverClient
{
    public class ConnectionInfo
    {
        [JsonProperty("ConnectionName", Order = 1, Required = Required.Always)]
        public string ConnectionName { get; private set; }

        [JsonProperty("ConnectionIP", Order = 2, Required = Required.Always)]
        public string ConnectionIP { get; private set; }

        public ConnectionInfo(string connectionName, string connectionIP)
        {
            ConnectionName = connectionName;
            ConnectionIP = connectionIP;
        }
    }
}
