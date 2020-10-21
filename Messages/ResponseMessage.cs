using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class ResponseMessage : LogSaverMessage
    {
        public ResponseMessage() : base(MessageType.Response)
        {

        }

        public override string ToJsonString()
        {
            throw new NotImplementedException();
        }
    }
}
