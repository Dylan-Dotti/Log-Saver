using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Messages
{
    public class ResponseMessage : LogSaverMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("ResponseCode", Order = 1)]
        public ResponseCode ResCode { get; private set; }

        [JsonProperty("ErrorMessage", Order = 2)]
        public string ErrorMessage { get; private set; }

        public ResponseMessage(ResponseCode resCode) : this(resCode, "") { }

        [JsonConstructor]
        public ResponseMessage(ResponseCode responseCode, string errroMessage) : base(MessageType.Response)
        {
            ResCode = responseCode;
            ErrorMessage = errroMessage;
        }
    }
}
