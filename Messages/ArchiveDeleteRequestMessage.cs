using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class ArchiveDeleteRequestMessage : LogSaverMessage
    {
        [JsonProperty("ArchiveNameToDelete")]
        public string ArchiveNameToDelete { get; private set; }

        public ArchiveDeleteRequestMessage(string archiveNameToDelete)
            : base(MessageType.ArchiveDeleteRequest)
        {

        }
    }
}
