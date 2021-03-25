using Newtonsoft.Json;
using System;

namespace Messages
{
    public class ExistingArchive
    {
        [JsonProperty("Name", Order = 1, Required = Required.Always)]
        public string Name { get; private set; }

        [JsonProperty("SizeInBytes", Order = 2, Required = Required.Always)]
        public long SizeInBytes { get; private set; }

        [JsonProperty("CreateDateUtc", Order = 3, Required = Required.Always)]
        public DateTime CreateDateUtc { get; private set; }

        [JsonProperty("UpdateDateUtc", Order = 4, Required = Required.Always)]
        public DateTime UpdateDateUtc { get; private set; }

        public ExistingArchive(string name, long sizeInBytes,
            DateTime createDateUtc, DateTime updateDateUtc)
        {
            Name = name;
            SizeInBytes = sizeInBytes;
            if (createDateUtc.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException("DateTimeKind of CreateDateUtc must be Utc");
            }
            CreateDateUtc = createDateUtc;
            if (updateDateUtc.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException("DateTimeKind of UpdateDateUtc must be Utc");
            }
            UpdateDateUtc = updateDateUtc;

        }
    }
}
