using Newtonsoft.Json.Linq;

namespace Messages
{
    public class ResponseMessage : LogSaverMessage
    {
        private readonly ResponseCode responseCode;
        private readonly string errorMessage;

        public ResponseMessage(ResponseCode resCode) : this(resCode, "") { }

        public ResponseMessage(ResponseCode resCode, string errMsg) : base(MessageType.Response)
        {
            responseCode = resCode;
            errorMessage = errMsg;
        }

        public override JObject ToJObject()
        {
            JObject jObject = base.ToJObject();
            jObject.Add("ResponseCode", responseCode.ToString());
            jObject.Add("ErrorMessage", errorMessage);
            return jObject;
        }
    }
}
