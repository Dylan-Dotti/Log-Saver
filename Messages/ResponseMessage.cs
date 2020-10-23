using Newtonsoft.Json.Linq;

namespace Messages
{
    public class ResponseMessage : LogSaverMessage
    {
        public ResponseCode ResCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public ResponseMessage(ResponseCode resCode) : this(resCode, "") { }

        public ResponseMessage(ResponseCode resCode, string errMsg) : base(MessageType.Response)
        {
            ResCode = resCode;
            ErrorMessage = errMsg;
        }

        public override JObject ToJObject()
        {
            JObject jObject = base.ToJObject();
            jObject.Add("ResponseCode", ResCode.ToString());
            jObject.Add("ErrorMessage", ErrorMessage);
            return jObject;
        }
    }
}
