using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class ZipRequestMessage : FileOperationRequestMessage
    {
        [JsonProperty("ZipFileName")]
        public string ZipFileName { get; private set; }

        public ZipRequestMessage(string zipFileName) : 
            base(FileOperationType.Zip)
        {
            ZipFileName = zipFileName;
        }
    }
}
