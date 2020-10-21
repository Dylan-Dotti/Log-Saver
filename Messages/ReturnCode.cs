
namespace Messages
{
    public enum ReturnCode
    {
        Ok,
        Error
    }

    public static class ReturnCodeExtensions
    {
        public static string ToString(this ReturnCode value)
        {
            return ((int)value).ToString();
        }
    }
}
