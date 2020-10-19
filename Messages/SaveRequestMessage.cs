using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    class SaveRequestMessage : LogSaverMessage
    {
        public SaveRequestMessage(JObject jObject) : base(jObject)
        {

        }

        public override string ToJsonString()
        {
            return "";
        }
    }
}
