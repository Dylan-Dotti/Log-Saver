using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class SaveRequestMessage : LogSaverMessage
    {
        [JsonProperty("ZipFileName")]
        public string ZipFileName { get; private set; }

        public SaveRequestMessage(string zipFileName) : base(MessageType.SaveRequest)
        {
            ZipFileName = zipFileName;
        }
    }
}
