using FileUtilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Messages
{
    public class ServerInfoMessage : LogSaverMessage
    {
        [JsonProperty("FileCategories", Order = 1, Required = Required.Always)]
        public IReadOnlyList<FileCategory> FileCategories { get; private set; }

        [JsonProperty("ExistingArchives", Order = 2, Required = Required.Always)]
        public IReadOnlyList<string> ExistingArchives { get; private set; }

        [JsonProperty("AvailableCapacityInBytes", Order = 3, Required = Required.Always)]
        public long AvailableCapacityInBytes { get; private set; }

        [JsonProperty("TotalCapacityInBytes", Order = 4, Required = Required.Always)]
        public long TotalCapacityInBytes { get; private set; }

        public ServerInfoMessage(
            IEnumerable<FileCategory> fileCategories,
            IEnumerable<string> existingArchives,
            long availableCapacityInBytes, long totalCapacityInBytes) 
            : base(MessageType.ServerInfo)
        {
            FileCategories = fileCategories.ToList();
            ExistingArchives = existingArchives.ToList();
            AvailableCapacityInBytes = availableCapacityInBytes;
            TotalCapacityInBytes = totalCapacityInBytes;
        }
    }
}
