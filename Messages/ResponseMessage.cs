using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Messages
{
    public class ResponseMessage : LogSaverMessage
    {
        [JsonProperty("ResponseCode")]
        public ResponseCode ResCode { get; private set; }
        [JsonProperty("ErrorMessage")]
        public string ErrorMessage { get; private set; }

        public ResponseMessage(ResponseCode resCode) : this(resCode, "") { }

        [JsonConstructor]
        public ResponseMessage(ResponseCode responseCode, string errroMessage) : base(MessageType.Response)
        {
            ResCode = responseCode;
            ErrorMessage = errroMessage;
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
