using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class ResponseMessage : LogSaverMessage
    {
        private readonly ReturnCode returnCode;

        public ResponseMessage(ReturnCode returnCode) : base(MessageType.Response)
        {
            this.returnCode = returnCode;
        }

        public override JObject ToJObject()
        {
            return base.ToJObject();
        }
    }
}
