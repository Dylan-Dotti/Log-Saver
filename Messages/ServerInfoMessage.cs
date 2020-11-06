using FileUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages
{
    public class ServerInfoMessage : LogSaverMessage
    {
        [JsonProperty("FileCategories", Order = 1, Required = Required.Always)]
        public IReadOnlyList<FileCategory> fileCategories;

        public ServerInfoMessage(IEnumerable<FileCategory> fileCategories) 
            : base(MessageType.ServerInfo)
        {
            this.fileCategories = new List<FileCategory>(fileCategories);
        }
    }
}
