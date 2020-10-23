
namespace Messages
{
    public enum ResponseCode
    {
        Ok,
        Error
    }

    public static class ResponseCodeExtensions
    {
        public static string ToIntString(this ResponseCode value)
        {
            return ((int)value).ToString();
        }

        public static ResponseCode ToResponseCode(this string value)
        {
            return (ResponseCode)int.Parse(value);
        }
    }
}
