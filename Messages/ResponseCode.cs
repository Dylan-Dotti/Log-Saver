using System.Collections.Generic;
using System.Linq;

namespace Messages
{
    public enum ResponseCode
    {
        Ok,
        Error
    }

    public static class ResponseCodeExtensions
    {
        private static readonly IEnumerable<ResponseCode> messageTypeValues =
            EnumExtensions.GetValues<ResponseCode>();

        public static string ToIntString(this ResponseCode value)
        {
            return ((int)value).ToString();
        }

        public static ResponseCode ToResponseCode(this string value)
        {
            return messageTypeValues
                .Where(m => m.ToString().Equals(value)).FirstOrDefault();
        }
    }
}
